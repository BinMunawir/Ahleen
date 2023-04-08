
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 18081
WORKDIR /ahleen/account
ENV ASPNETCORE_URLS=http://+:18081

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ahleen/account
COPY ["account.csproj", "./"]
RUN dotnet restore "account.csproj"
COPY . .
RUN dotnet build "account.csproj" -c Release -o /ahleen/account/build
RUN dotnet publish "account.csproj" -c Release -o /ahleen/account/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /ahleen/account
COPY --from=build /ahleen/account/publish .

