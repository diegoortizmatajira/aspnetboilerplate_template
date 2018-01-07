#!/bin/bash
imageName="WebApiTemplate"
projectName="WebApiTemplate"
serviceName="webapi-service"
runtimeID="debian.8-x64"
framework="netcoreapp2.0"

composeClean () {
    composeFileName=$1
    prefix=$2
    docker-compose -f $composeFileName -p $prefix down
}

composeBuild () {
    composeFileName=$1
    prefix=$2
    echo "Building the images $prefix $imageName"
    docker-compose -f $composeFileName -p $prefix build
}

composeUp () {
    composeFileName=$1
    prefix=$2
    echo "Composing Up..."
    if [[ $ENVIRONMENT == "debug" ]]; then
        docker-compose -f $composeFileName -p $prefix up -d "$serviceName-debug"
    else
        docker-compose -f $composeFileName -p $prefix up -d $serviceName
    fi
}

composeKill () {
    composeFileName=$1
    prefix=$2
    echo "Composing Down..."
    if [[ $ENVIRONMENT == "debug" ]]; then
        docker-compose -f $composeFileName -p $prefix kill "$serviceName-debug"
    else
        docker-compose -f $composeFileName -p $prefix kill $serviceName
    fi
}

# Kills all running containers of an image and then removes them.
cleanAll () {
    if [[ $ENVIRONMENT != "release" ]]; then
        composeClean "docker-compose.development.yml" "development"
    else
        composeClean "docker-compose.yml" "release"
    fi
    # Remove any dangling images (from previous builds)
    danglingImages=$(docker images -q --filter 'dangling=true')
    if [[ ! -z $danglingImages ]]; then
        docker rmi -f $danglingImages
    fi
}

# Builds the Docker image.
buildImage () {
    if [[ $ENVIRONMENT != "release" ]]; then
        echo "Building the project (Development)."
        composeBuild "docker-compose.development.yml" "development"
    else
        echo "Building the project (Production)."
        composeBuild "docker-compose.yml" "release"
    fi
}

# Runs docker-compose.
compose () {
    buildImage
    if [[ $ENVIRONMENT != "release" ]]; then
        echo "Building the project (Development)."
        composeKill "docker-compose.development.yml" "development"
        composeUp "docker-compose.development.yml" "development"
    else
        echo "Building the project (Production)."
        composeKill "docker-compose.yml" "release"
        composeUp "docker-compose.yml" "release"
    fi
}

startDebugging () {
    containerName="development_${serviceName}-debug_1"
    containerId=$(docker ps -f "name=$containerName" -q -n=1)
    if [[ -z $containerId ]]; then
        echo "Could not find a container named $containerName"
    else
        docker exec -i $containerId /vsdbg/vsdbg --interpreter=vscode
    fi
}

# Shows the usage for the script.
showUsage () {
    echo "Usage: dockerTask.sh [COMMAND] (ENVIRONMENT)"
    echo "    Runs build or compose using specific environment (if not provided, debug environment is used)"
    echo ""
    echo "Commands:"
    echo "    build: Builds a Docker image ('$imageName')."
    echo "    compose: Runs docker-compose."
    echo "    clean: Removes the image '$imageName' and kills all containers based on that image."
    echo "    composeForDebug: Builds the image and runs docker-compose."
    echo "    startDebugging: Finds the running container and starts the debugger inside of it."
    echo ""
    echo "Environments:"
    echo "    debug: Uses debug environment."
    echo "    release: Uses release environment."
    echo ""
    echo "Example:"
    echo "    ./dockerTask.sh build debug"
    echo ""
    echo "    This will:"
    echo "        Build a Docker image named $imageName using debug environment."
}

ENVIRONMENT=$(echo $2 | tr "[:upper:]" "[:lower:]")
if [[ -z $ENVIRONMENT ]]; then
    ENVIRONMENT="debug"
fi
echo "Using $ENVIRONMENT Settings..."

if [ $# -eq 0 ]; then
    showUsage
else
    case "$1" in
        "compose")
            compose
        ;;
        "startDebugging")
            startDebugging
        ;;
        "build")
            buildImage
        ;;
        "clean")
            cleanAll
        ;;
        *)
            showUsage
        ;;
    esac
fi