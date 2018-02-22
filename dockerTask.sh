#!/bin/bash
projectName="WebApiTemplate"
imageName="webapi_image"
serviceName="webapi_service"
runtimeID="linux-x64"
framework="netcoreapp2.0"
prefix="local"

invokeDockerCompose()
{
    environment=$1
    action=$2
    if [[ $environment = "production" ]]; then
        docker-compose -f docker-compose.yml -p $prefix $action
    else
        docker-compose -f docker-compose.yml -f docker-compose.$environment.yml -p $prefix $action
    fi
}

composeForDebug()
{
    invokeDockerCompose debug "kill ${serviceName}"
    invokeDockerCompose debug "up -d"
}

cleanAll()
{
    # Remove any dangling images (from previous builds)
    danglingImages=$(docker images -q --filter 'dangling=true')
    if [[ ! -z $danglingImages ]]; then
        docker rmi -f $danglingImages
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
    echo "    composeForDebug: Runs docker-compose ready for a debugging session."
    echo "    clean: Removes the image '$imageName' and kills all containers based on that image."
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
            invokeDockerCompose $ENVIRONMENT "up -d"
        ;;
        "build")
            invokeDockerCompose $ENVIRONMENT build
        ;;
        "clean")
            invokeDockerCompose $ENVIRONMENT down
            cleanAll
        ;;
        "composeForDebug")
            composeForDebug
        ;;
        "startDebugging")
            docker exec -i "${prefix}_${serviceName}_1" /vsdbg/vsdbg --interpreter=vscode
        ;;
        *)
            showUsage
        ;;
    esac
fi