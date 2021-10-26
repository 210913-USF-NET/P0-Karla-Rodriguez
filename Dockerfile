FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY P0.sln ./
COPY BL/*.csproj ./BL/
COPY DL/*.csproj ./DL/
COPY Models/*.csproj ./Models/
COPY Tests/*.csproj ./Tests/
COPY UI/*.csproj ./UI/

RUN dotnet restore
COPY . .

WORKDIR /src/BL
RUN dotnet build -c release -o /app

WORKDIR /src/DL
RUN dotnet build -c release -o /app

WORKDIR /src/Models
RUN dotnet build -c release -o /app

WORKDIR /src/Tests
RUN dotnet build -c release -o /app

WORKDIR /src/UI
RUN dotnet build -c release -o /app

WORKDIR /src
RUN dotnet build -c release -o /app



FROM final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "UI.dll"]