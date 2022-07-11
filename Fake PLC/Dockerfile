#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Fake PLC/Fake PLC.csproj", "Fake PLC/"]
ENV http_proxy=http://165.225.200.15:80
ENV https_proxy=http://165.225.200.15:80
ENV TZ=Europe/Budapest
RUN dotnet restore "Fake PLC/Fake PLC.csproj"
COPY . .
WORKDIR "/src/Fake PLC"
RUN dotnet build "Fake PLC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fake PLC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV TZ=Europe/Budapest
EXPOSE 502
ENTRYPOINT ["dotnet", "Fake PLC.dll"]