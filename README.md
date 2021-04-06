# Launching API

Launch Movie API

Go to MoviesAPI-project folder and run

    dotnet run

Swagger is started in following address: https://localhost:5001/swagger/index.html

TODO: certificate problem on running localhost

# Using CsvImport

Currently the database is Sqlite database. Migrations create the database in the Infrastucture-project and CsvImport must be run from the same directory where the movies.db database is (in Infrastructure-project root folder).

# dotnet memo

## Creating new project

    $ dotnet new console
    Getting ready...
    The template "Console Application" was created successfully.

    Processing post-creation actions...
    Running 'dotnet restore' on /home/mikko/dev/dotnet/movies/CsvImport/CsvImport.csproj...
    Determining projects to restore...
    Restored /home/mikko/dev/dotnet/movies/CsvImport/CsvImport.csproj (in 56 ms).
    Restore succeeded.

## Adding nuget-package to project

    $ dotnet add package Microsoft.Extensions.DependencyInjection

## Adding project to solution

    $ dotnet sln add CsvImport/CsvImport.csproj 
    Project `CsvImport/CsvImport.csproj` added to the solution.

## Referecing library project to another project

    $ dotnet add CsvImport/CsvImport.csproj reference Application/Application.csproj 
    Reference `..\Application\Application.csproj` added to the project.

## Building project

    $ dotnet build
    Microsoft (R) Build Engine version 16.8.3+39993bd9d for .NET
    Copyright (C) Microsoft Corporation. All rights reserved.

    Determining projects to restore...
    All projects are up-to-date for restore.
    CsvImport -> /home/mikko/dev/dotnet/movies/CsvImport/bin/Debug/net5.0/CsvImport.dll

    Build succeeded.
        0 Warning(s)
        0 Error(s)

## Running project

    $ dotnet run
