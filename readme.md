CRUD Operations Using Blazor, .Net 6.0, Entity Framework Core

https://www.c-sharpcorner.com/article/crud-operations-using-blazor-net-6-0-entity-framework-core/

![screenshot](/Capture.PNG)

history:
  Id     Duration CommandLine
  --     -------- -----------
   0              dotnet new blazorwasm --hosted -o BlazorCRUD
   1        0.378 dotnet add package Microsoft.EntityFrameworkCore
   2        0.028 cd .\Shared\
   3        4.176 dotnet add package Microsoft.EntityFrameworkCore
   4        4.499 dotnet add package Microsoft.EntityFrameworkCore.Sqlite
   5        4.923 dotnet add package Microsoft.EntityFrameworkCore.Tools
   6        0.026 cd ..
   7        0.029 cd .\Server\
   8        3.962 dotnet add package Microsoft.EntityFrameworkCore
   9       18.877 dotnet build
  10        4.092 dotnet add package Microsoft.EntityFrameworkCore.Sqlite
  11        4.389 dotnet add package Microsoft.EntityFrameworkCore.Tools
  12        5.209 dotnet add package Microsoft.EntityFrameworkCore.Design
  13        0.033 cd ..
  14        0.029 cd .\Shared\
  15        4.124 dotnet add package Microsoft.EntityFrameworkCore.Design
  16        0.029 cd ..
  
  created Shared/Models/User.cs, Server/Models/DatabaseContext.cs, Server/Interfaces/IUser.cs, Server/Services/UserManager.cs,
          Server/Controllers/UserController.cs, Client/Pages/UserDetails.razor, Client/Pages/AddUser.razor, Client/Pages/DeleteUser.razor
modified Server/Program.cs:
`builder.Services.AddDbContext<DatabaseContext>
    (options =>
    options.UseSqlite("Data Source = User.db"));
builder.Services.AddTransient<IUser, UserManager>();`

  17        0.688 dotnet watch run .\Server\
  18     3:56.543 dotnet watch run --project .\Server\
  19     2:27.029 dotnet watch run --project .\Server\
  20        0.888 dotnet ef migrations add init
  21       10.129 dotnet ef migrations add init --project .\Server\
  22        0.575 dotnet ef database update
  23        9.995 dotnet ef database update --project .\Server\
  24     9:59.980 dotnet watch run --project .\Server\