FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ApiResource/ApiResource.csproj ApiResource/
RUN dotnet restore ApiResource/ApiResource.csproj
COPY . .
WORKDIR /src/ApiResource
RUN dotnet build ApiResource.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ApiResource.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiResource.dll"]
