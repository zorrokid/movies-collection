#!/bin/bash

if [ -z "$1"]
then
    echo "Pass migration name as parameter"
else
    MIGRATION_NAME=$1
    dotnet ef migrations add $MIGRATION_NAME --startup-project ./MovieAPI/ --project ./Infrastructure/ --context ApplicationContext --output-dir=Migrations/Application
fi

