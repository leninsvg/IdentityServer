FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ApiResource2/ApiResource2.csproj ApiResource2/
RUN dotnet restore ApiResource2/ApiResource2.csproj
COPY . .
WORKDIR /src/ApiResource2
RUN dotnet build ApiResource2.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ApiResource2.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiResource2.dll"]
