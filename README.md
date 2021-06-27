# ServiceFabricTodoApp
Service Fabric application 



Service Fabric app implemeting a .Net core stateless web api solution


Yet to improve on Clean Architecture


Used code-first migrations to configure on-prem SQL Server Instance


CURRENTLY ERRORS WITH EF db migrations (commands to execute while having SQL Server Express running)


cd "C:\Users\Kausi\Desktop\Projects\TodoApp\TodoSFService" (Try having either one of the projects as Startup Project)


dotnet ef migrations add InitialCreate --verbose
