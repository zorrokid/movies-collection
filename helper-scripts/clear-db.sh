#!/bin/bash
dotnet ef database update 0 --startup-project ./MovieAPI/ --project ./Infrastructure/ --context ApplicationContext