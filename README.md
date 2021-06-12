# Client

Web client for this project is here: https://github.com/zorrokid/movies-collection-web-client

# Framework and library dependencies

* .net 5
* Entity Framework Core 5
* Automapper
* MediatR: https://github.com/jbogard/MediatR

# MovieAPI

This is the main entry point of this backend project providing REST API for this application.

## appsettings

To set environment specific appsettings.json export environment variable first, e.g. to use appsettings.Development.json:

    $ export ASPNETCORE_ENVIRONMENT=Development


# Database

Currently the database is PostgreSQL database. 

## Connection

Connection string is defined in MovieAPI-project's appsettings.json file.

## Creating database

Log in as postgres user:

    $ sudo su postgres

Create db user:

    $ createuser --interactive --pwprompt
    Enter name of role to add: movies
    Enter password for new role: xxxxxxx
    Enter it again: xxxxxxx
    Shall the new role be a superuser? (y/n) n
    Shall the new role be allowed to create databases? (y/n) n
    Shall the new role be allowed to create more new roles? (y/n) n

Create db with previously created user as owner:

    $ createdb --owner=movies moviedb

To login to db:

    $ psql -Umovies -dmoviedb

# Building project

To build the project run in the root folder

    dotnet build

## Running migrations

From the project root-folder run:

    dotnet ef database update --startup-project ./MovieAPI/ --project ./Infrastructure/ --context IdentityContext

    dotnet ef database update --startup-project ./MovieAPI/ --project ./Infrastructure/ --context ApplicationContext


Or use helper script 

    $ bash migate-db.sh

## Adding migrations

## Adding migrations for identity db

From the project root-folder run:

    dotnet ef migrations add <migration name> --startup-project ./MovieAPI/ --project ./Infrastructure/ --context IdentityContext --output-dir=Migrations/Identity

## Adding migrations for app db

From the project root-folder run:

    dotnet ef migrations add <migration name> --startup-project ./MovieAPI/ --project ./Infrastructure/ --context ApplicationContext --output-dir=Migrations/Application

## Removing migrations

To remove last migration

    dotnet ef migrations remove --context ApplicationContext

To remove all migrations

    dotnet ef database update 0 --startup-project ./MovieAPI/ --project ./Infrastructure/  --context ApplicationContext

Or use helper script 

    $ bash clear-db.sh

# Integrations

## Import from CSV

Currently only a custom CSV-format is supported. Use CsvImport-project to import collection from CSV.

Run build

    dotnet build

Run CsvImport to get help about command line options.

Example:

    $ bin/Debug/net5.0/CsvImport -p data/Collections.csv -c /home/mikko/dev/dotnet/movies/MovieAPI/ -m 1

# API

## Launching API

To launch API go to MoviesAPI-project folder and run

    dotnet run

Swagger is started in following address: https://localhost:5001/swagger/index.html

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

# Creating local development certificate for HTTPS

Links:
* https://github.com/FiloSottile/mkcert
* https://blog.bitsrc.io/using-https-for-local-development-for-react-angular-and-node-fdfaf69693cd

## Create root certificate

    $ mkcert -install
    Created a new local CA 💥
    Sudo password:         
    The local CA is now installed in the system trust store! ⚡️
    The local CA is now installed in the Firefox and/or Chrome/Chromium trust store (requires browser restart)! 🦊

## Create certificate for localhost

    $ mkcert -CAROOT
    /home/mikko/.local/share/mkcert

    ~/.local/share/mkcert$ mkcert localhost

    Created a new certificate valid for the following names 📜
    - "localhost"

    The certificate is at "./localhost.pem" and the key at "./localhost-key.pem" ✅

    It will expire on 12 September 2023 🗓

## Set the webpack devserver config for https

    devServer: {
        contentBase: './dist',
        hot: true,
        https: {
            key: fs.readFileSync('/home/mikko/.local/share/mkcert/localhost-key.pem'),
            cert: fs.readFileSync('/home/mikko/.local/share/mkcert/localhost.pem'),
            ca: fs.readFileSync('/home/mikko/.local/share/mkcert/rootCA.pem'),
          },
    },


