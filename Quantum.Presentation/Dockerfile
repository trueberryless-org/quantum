FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Quantum.Presentation/Quantum.Presentation.csproj", "Quantum.Presentation/"]
RUN dotnet restore "Quantum.Presentation/Quantum.Presentation.csproj"
COPY . .
WORKDIR "/src/Quantum.Presentation"
RUN dotnet build "Quantum.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quantum.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quantum.Presentation.dll"]
