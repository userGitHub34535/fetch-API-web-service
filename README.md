# fetch-API-web-service
writing a .NET Core 3.1 API web service to Fetch points

(steps 0-6 are basic steps)
0. After the ASP.NET Core Web API project is created, you have to run it (F5) & trust the SSL.
Properties\launchSettings.json, update launchUrl from "swagger" to "api/todoitems"
1. Add model classes to a Models folder. 
2. Add Microsoft.EntityFrameworkCore.InMemory NuGet package. 
3. Add TodoContext.cs to the Models folder. You can find it at this link https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
4. Update Program.cs (again, code is in the link) and un-comment out lines 23& 24.
5. Add a New Scffolded Item > scaffolded API controller with actions using EF. Use the Points model & points context. 
6. Edit the POST method's return statement. return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);

Troubleshooting 
7. make sure the "Swashbuckle.Aspnetcore" NuGet package is installed. You may have to add the package source "http://api.nuget.org/v3/index.json" see image below for help adding this package. 
![image](https://user-images.githubusercontent.com/15200128/177609563-07215a77-c8da-447b-81b8-dca0e6df09b0.png)

8. use the httprepl tool. 
First open a powershell terminal and type dotnet run --project TodoApi. If successful you will get "Now listening on {port}".
Then open a different terminal and httprepl https://localhost:7033 i.e. https://localhost:{port}. If it says (Disconnected) and when you type "ls" it says no directory structure is set, then (while httprepl is running in your first terminal) type "connect https://localhost:7033 --verbose --openapi /swagger/v1/swagger.json" or just "connect https://localhost:7033"  It should then say "Using OpenApi description....blah blah". The path should also change to the https://localhost:{port}> 
At that new path, type ls and you should see your endpoints like this: 
![image](https://user-images.githubusercontent.com/15200128/177775270-da797a05-6838-46df-b31e-86b4b35e5470.png)
Some links I used to troubleshoot https://stackoverflow.com/questions/69571770/unable-to-find-an-openapi-description

9. After you've got the "ls" or "get" working, you can use commands such as get and post to interact with the API. 
e.g. post -h Content-Type=application/json -c "{"payer":"DANON","TransactionPoints":4000}"
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-6.0&tabs=visual-studio
N.b. this app uses an in-memory db. If the API app is stopped & restarted, the data that I posted to the app previously will not be there.
 


10. I needed to add NewtonSoft.json to the class to help parse the Timestamp datetime.
![image](https://user-images.githubusercontent.com/15200128/178111087-7caf3882-aa5f-4361-8ae4-ae387e5fc72f.png)

