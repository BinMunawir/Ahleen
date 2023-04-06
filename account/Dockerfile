
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 18081
WORKDIR /ahleen/account/app
ENV ASPNETCORE_URLS=http://+:18081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ahleen/account
COPY ["account.csproj", "./"]
RUN dotnet restore "account.csproj"
COPY . .
RUN dotnet build "account.csproj" -c Release -o /ahleen/account/app/build
RUN dotnet publish "account.csproj" -c Release -o /ahleen/account/app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /ahleen/account/app
COPY --from=build /ahleen/account/app/publish .



# FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
# WORKDIR /app
# EXPOSE 5168

# ENV ASPNETCORE_URLS=http://+:5168

# FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
# WORKDIR /src
# COPY ["wallet.csproj", "./"]
# RUN dotnet restore "wallet.csproj"
# COPY . .
# WORKDIR "/src/."
# RUN dotnet build "wallet.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "wallet.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .


