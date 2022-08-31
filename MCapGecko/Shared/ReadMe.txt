Package Manager Console:   dotnet tool install --global dotnet-ef  

nuget packages:
   install Microsoft.EntityFrameworkCore 
   install Microsoft.EntityFrameworkCore.Design
   install Microsoft.EntityFrameworkCore.SqlServer

PM> dotnet ef migrations add coin //add coin migration
PM> dotnet ef database update //Update database from migration