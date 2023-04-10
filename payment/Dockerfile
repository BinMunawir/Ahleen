
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
EXPOSE 18081
WORKDIR /ahleen/payment
ENV ASPNETCORE_URLS=http://+:18082

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /ahleen/payment
COPY ["payment.csproj", "./"]
RUN dotnet restore "payment.csproj"
COPY . .
RUN dotnet build "payment.csproj" -c Release -o /ahleen/payment/build
RUN dotnet publish "payment.csproj" -c Release -o /ahleen/payment/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /ahleen/payment
COPY --from=build /ahleen/payment/publish .

