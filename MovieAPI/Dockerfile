FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Release/net5.0/publish/ MovieAPI/
WORKDIR /MovieAPI
ENTRYPOINT ["dotnet", "movieAPI.dll"]