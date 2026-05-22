FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8082

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ForMIS.UserManagementApi/ForMIS.UserManagementApi.csproj", "ForMIS.UserManagementApi/"]
RUN dotnet restore "ForMIS.UserManagementApi/ForMIS.UserManagementApi.csproj"
COPY . .
WORKDIR "/src/ForMIS.UserManagementApi"
RUN dotnet build "ForMIS.UserManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ForMIS.UserManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForMIS.UserManagementApi.dll"]
