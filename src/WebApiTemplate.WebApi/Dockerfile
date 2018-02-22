FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /code
COPY *.sln ./
COPY src/WebApiTemplate.Application/WebApiTemplate.Application.csproj src/WebApiTemplate.Application/
COPY src/WebApiTemplate.Core/WebApiTemplate.Core.csproj src/WebApiTemplate.Core/
COPY src/WebApiTemplate.EntityFrameworkCore/WebApiTemplate.EntityFrameworkCore.csproj src/WebApiTemplate.EntityFrameworkCore/
COPY src/WebApiTemplate.WebApi/WebApiTemplate.WebApi.csproj src/WebApiTemplate.WebApi/
COPY test/WebApiTemplate.Test/WebApiTemplate.Test.csproj test/WebApiTemplate.Test/
COPY test/WebApiTemplate.WebApi.Test/WebApiTemplate.WebApi.Test.csproj test/WebApiTemplate.WebApi.Test/
RUN dotnet restore
COPY . .
WORKDIR /code/src/WebApiTemplate.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiTemplate.WebApi.dll"]
