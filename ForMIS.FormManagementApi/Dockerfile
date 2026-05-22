FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ForMIS.FormManagementApi/ForMIS.FormManagementApi.csproj", "ForMIS.FormManagementApi/"]
RUN dotnet restore "ForMIS.FormManagementApi/ForMIS.FormManagementApi.csproj"
COPY . .
WORKDIR "/src/ForMIS.FormManagementApi"
RUN dotnet build "ForMIS.FormManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ForMIS.FormManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForMIS.FormManagementApi.dll"]
