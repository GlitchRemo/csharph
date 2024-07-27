FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["tic-tac-toe/tic-tac-toe.csproj", "tic-tac-toe/"]
RUN dotnet restore "tic-tac-toe/tic-tac-toe.csproj"
COPY . .
WORKDIR "/src/tic-tac-toe"
RUN dotnet build "tic-tac-toe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tic-tac-toe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tic-tac-toe.dll"]
