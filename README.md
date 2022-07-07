# fetch-API-web-service
writing a .NET Core 3.1 API web service to Fetch points


1. make sure the "Swashbuckle.Aspnetcore" NuGet package is installed. You may have to add the package source "http://api.nuget.org/v3/index.json" see image below for help adding this package. 
![image](https://user-images.githubusercontent.com/15200128/177609563-07215a77-c8da-447b-81b8-dca0e6df09b0.png)

2. use the httprepl tool. 
First open a powershell terminal and type dotnet run --project TodoApi. If successful you will get "Now listening on {port}".
Then open a different terminal and httprepl https://localhost:7033 i.e. https://localhost:{port}. If it says (Disconnected) and when you type "ls" it says no directory structure is set, then (while httprepl is running in your first terminal) type "connect https://localhost:7033 --verbose --openapi /swagger/v1/swagger.json" or just "connect https://localhost:7033"  It should then say "Using OpenApi description....blah blah". The path should also change to the https://localhost:{port}> 
At that new path, type ls and you should see your endpoints like this: 
![image](https://user-images.githubusercontent.com/15200128/177775270-da797a05-6838-46df-b31e-86b4b35e5470.png)
Some links I used to troubleshoot https://stackoverflow.com/questions/69571770/unable-to-find-an-openapi-description
