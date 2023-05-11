FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Quantum.WebAPI/Quantum.WebAPI.csproj", "Quantum.WebAPI/"]
RUN dotnet restore "Quantum.WebAPI/Quantum.WebAPI.csproj"
COPY . .
WORKDIR "/src/Quantum.WebAPI"
RUN dotnet build "Quantum.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quantum.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quantum.WebAPI.dll"]
