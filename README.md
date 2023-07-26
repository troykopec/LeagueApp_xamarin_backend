# LeagueApp_xamarin_backend
backend functions for xamarin mobile app
--------------------------------------------
to update and migrate new database tables and changes, make the changes in MyDbContext.cs, I will leave items table there for an example. It needs to refer to a class, in the item tables case it is the object class "Item.cs".

to apply changes (only works locally for now) go into vs code terminal and type :
- dotnet ef migrations add <Name of Migration> --project LeagueApp_xamarin_backend.csproj --startup-project LeagueApp_xamarin_backend.csproj  
- dotnet ef database update --project LeagueApp_xamarin_backend.csproj --startup-project LeagueApp_xamarin_backend.csproj 
