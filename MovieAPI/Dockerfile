FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

ENV ASPNETCORE_ENVIRONMENT=Production

WORKDIR /app

COPY *.sln .
COPY Domain/*.csproj ./Domain/
COPY Auth/*.csproj ./Auth/
COPY ErrorHandling/*.csproj ./ErrorHandling/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY CsvImport/*.csproj ./CsvImport/
COPY MovieAPI/*.csproj ./MovieAPI/
COPY Application.Tests/*.csproj ./Application.Tests/
COPY Infrastructure.Tests/*.csproj ./Infrastructure.Tests/

RUN dotnet restore

COPY Domain/. ./Domain/
COPY Auth/. ./Auth/
COPY ErrorHandling/. ./ErrorHandling
COPY Application/. ./Application/
COPY Infrastructure/. ./Infrastructure/
COPY CsvImport/. ./CsvImport/
COPY MovieAPI/. ./MovieAPI/
COPY Application.Tests/. ./Application.Tests
COPY Infrastructure.Tests/. ./Infrastructure.Tests

COPY MovieAPI/appsettings.${ASPNETCORE_ENVIRONMENT}.json ./MovieAPI/appsettings.json

WORKDIR /app/MovieAPI
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

COPY --from=build /app/MovieAPI/out ./
# This will not be used in Heroku:
#ENTRYPOINT ["dotnet", "movieAPI.dll"]

# For Heroku:
CMD ASPNETCORE_URLS=http://*:$PORT dotnet movieAPI.dll
