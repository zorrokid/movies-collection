

# dotnet memo

## Creating new project

New console project:

    $ dotnet new console

## Adding nuget-package to project

    $ dotnet add package Microsoft.Extensions.DependencyInjection

## Adding project to solution

    $ dotnet sln add CsvImport/CsvImport.csproj 
    Project `CsvImport/CsvImport.csproj` added to the solution.

## Referecing library project to another project

    $ dotnet add CsvImport/CsvImport.csproj reference Application/Application.csproj 
    Reference `..\Application\Application.csproj` added to the project.

## PostgreSQL-database

show status:

$ service postgresql status

login as postgres user:

$ sudo su postgres
[sudo] password for mikko:          
postgres@mikko-Strix-15-GL503GE:/home/mikko$

authentication configuration:

$ sudo vim /etc/postgresql/12/main/pg_hba.conf

restart server:

$ sudo service postgresql restart

change password:

postgres=# \password postgres

add user:

postgres=# create user movies_api_user with password 'movies';

create user

postgres@mikko-Strix-15-GL503GE:/home/mikko$ createuser --interactive --pwprompt
Enter name of role to add: movies
Enter password for new role: movies123
Enter it again: movies123
Shall the new role be a superuser? (y/n) n
Shall the new role be allowed to create databases? (y/n) y
Shall the new role be allowed to create more new roles? (y/n) n

postgres@mikko-Strix-15-GL503GE:/home/mikko$ createdb -O movies moviesdb


mikko@mikko-Strix-15-GL503GE:~$ psql -Umovies -dmoviesdb
Password for user movies: 

moviesdb=> \c moviesdb
You are now connected to database "moviesdb" as user "movies".

moviesdb=> \dt
           List of relations
 Schema |     Name     | Type  | Owner  
--------+--------------+-------+--------
 public | cases        | table | movies
 public | compilations | table | movies
 public | conditions   | table | movies
 public | statuses     | table | movies
(4 rows)

