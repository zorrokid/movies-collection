#!/bin/bash

dotnet ef database update --startup-project ./MovieAPI/ --project ./Infrastructure/ --context ApplicationContext