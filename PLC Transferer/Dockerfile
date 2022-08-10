#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
ENV http_proxy=http://165.225.200.15:80
ENV https_proxy=http://165.225.200.15:80
ENV TZ=Europe/Budapest
COPY ["PLC Transferer/PLC Transferer.csproj", "PLC Transferer/"]
RUN dotnet restore "PLC Transferer/PLC Transferer.csproj"
COPY . .
WORKDIR "/src/PLC Transferer"
RUN dotnet build "PLC Transferer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PLC Transferer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Europe/Budapest
ENTRYPOINT ["dotnet", "PLC Transferer.dll"]