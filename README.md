# Building project

To build the project run in the root folder

    dotnet build

# Database

Currently the database is PostgreSQL database. 

## Connection

Connection string is defined in MovieAPI-project's appsettings.json file.

## Creating database

TODO

## Running migrations

From the project root-folder run:

    dotnet ef database update --startup-project ./MovieAPI/ --project ./Infrastructure/

## Adding migrations

From the project root-folder run:

    dotnet ef migrations add <migration name> --startup-project ./MovieAPI/ --project ./Infrastructure/ -- --environment Development

## Removing migrations

To remove last migration

    dotnet ef migrations remove

To remove all migrations

    dotnet ef database update 0 --startup-project ./MovieAPI/ --project ./Infrastructure/

# Integrations

## Import from CSV

Currently a custom CSV-format is supported. Use CsvImport-project to import collection from CSV.

TODO

Run build

    dotnet build

To use appsettings.json from MovieAPI run CsvImport from MovieAPI-project folder:

    $ ../CsvImport/bin/Debug/net5.0/CsvImport ../CsvImport/data/Collection.csv

# API

## Launching API

To launch API go to MoviesAPI-project folder and run

    dotnet run

Swagger is started in following address: https://localhost:5001/swagger/index.html

TODO: certificate problem on running localhost

# Adding project

Create project folder inside root folder of repository.

In project folder run 

    dotnet new <project template name>

e.g. to create a test project

    dotnet new mstest

To add project to solution in root folder run:

    dotnet sln add <Project name>/<Project name>.csproj 

# Referencing project in another project

    $ dotnet add CsvImport/CsvImport.csproj reference Application/Application.csproj

# Tests

To run tests, in root folder run

    dotnet test

