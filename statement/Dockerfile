
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 18083
WORKDIR /ahleen/statement
ENV ASPNETCORE_URLS=http://+:18083

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ahleen/statement
COPY ["statement.csproj", "./"]
RUN dotnet restore "statement.csproj"
COPY . .
RUN dotnet build "statement.csproj" -c Release -o /ahleen/statement/build
RUN dotnet publish "statement.csproj" -c Release -o /ahleen/statement/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /ahleen/statement
COPY --from=build /ahleen/statement/publish .

