FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY src/RuculaUp.WebApi/*.csproj ./src/RuculaUp.WebApi/
COPY src/RuculaUp.Application/*.csproj ./src/RuculaUp.Application/
COPY src/RuculaUp.Domain/*.csproj ./src/RuculaUp.Domain/
COPY src/RuculaUp.EntityFramework/*.csproj ./src/RuculaUp.EntityFramework/
COPY src/RuculaUp.EntityFramework.Query/*.csproj ./src/RuculaUp.EntityFramework.Query/

RUN dotnet restore
COPY src/. ./src/
RUN dotnet build
WORKDIR /app
RUN dotnet publish -c release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /publish ./
ENTRYPOINT ["dotnet", "RuculaUp.WebApi.dll", "--urls", "http://*:5900"]
EXPOSE 5900