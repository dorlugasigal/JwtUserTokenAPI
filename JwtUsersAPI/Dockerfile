FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["JwtUsersAPI/JwtUsersAPI.csproj", "JwtUsersAPI/"]
RUN dotnet restore "JwtUsersAPI/JwtUsersAPI.csproj"
COPY . .
WORKDIR "/src/JwtUsersAPI"
RUN dotnet build "JwtUsersAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JwtUsersAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JwtUsersAPI.dll"]