FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /code
COPY *.sln ./
COPY src/WebApiTemplate.Application/WebApiTemplate.Application.csproj src/WebApiTemplate.Application/
COPY src/WebApiTemplate.Core/WebApiTemplate.Core.csproj src/WebApiTemplate.Core/
COPY src/WebApiTemplate.EntityFrameworkCore/WebApiTemplate.EntityFrameworkCore.csproj src/WebApiTemplate.EntityFrameworkCore/
COPY src/WebApiTemplate.Web/WebApiTemplate.Web.csproj src/WebApiTemplate.Web/
COPY test/WebApiTemplate.Tests/WebApiTemplate.Tests.csproj test/WebApiTemplate.Tests/
COPY test/WebApiTemplate.Web.Tests/WebApiTemplate.Web.Tests.csproj test/WebApiTemplate.Web.Tests/
RUN dotnet restore
COPY . .
WORKDIR /code/src/WebApiTemplate.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApiTemplate.Web.dll"]
