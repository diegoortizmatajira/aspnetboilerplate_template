FROM microsoft/aspnetcore-build:2 AS builder
VOLUME /app
WORKDIR /app
RUN mkdir /publish
RUN dotnet publish -c Release -o /publish

FROM microsoft/aspnetcore:2
EXPOSE 80
COPY --from=builder /publish /app
WORKDIR /app
ENTRYPOINT ["dotnet", "WebApiTemplate.WebApi.dll"]

