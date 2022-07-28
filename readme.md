# CRUD Operations Using Blazor, .Net 6.0, Entity Framework Core
This is a combination of several Blazor EntityFramework tutorials.
### Resources
https://www.c-sharpcorner.com/article/crud-operations-using-blazor-net-6-0-entity-framework-core/
https://codewithmukesh.com/blog/blazor-crud-with-entity-framework-core/
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-6.0&tabs=visual-studio
https://executecommands.com/crud-in-blazor-using-sqlite-entity-framework/

### Users
![screenshot](/Screenshots/CaptureUsers.PNG)
### Products
![screenshot](/Screenshots/CaptureProducts.PNG)
### Developers
![screenshot](/Screenshots/CaptureDevelopers.PNG)
### Movies
![screenshot](/Screenshots/CaptureMovies.PNG)
### SwaggerUI
![screenshot](/Screenshots/CaptureSwagger.PNG)



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
    25        0.080 history
  26     3:58.900 dotnet watch run --project .\Server\
  27        0.235 python .\names.py
  40        0.700 dotnet watch run
  41  1:38:54.187 dotnet watch run --project .\Server\
  42        5.251 dotnet build
  43        7.023 dotnet build
  44        1.028 dotnet ef migrations add addprod --context ProductDbContext
  45        0.038 cd .\Server\
  46       13.056 dotnet ef migrations add addprod --context ProductDbContext
  47        5.311 dotnet build
  53       10.931 dotnet ef migrations add addedProd --context ProductDbContext
  55       11.128 dotnet ef database update --context ProductDbContext
  56       52.958 dotnet watch run
  57        3.068 dotnet build
  58        2.013 dotnet restore
  66        5.391 dotnet build
  67  1:51:19.623 dotnet watch run
  69        0.848 git add .
  70        0.884 git commit -m "added button and API for generating random user"
  71     8:30.882 dotnet watch run
  72       20.576 dotnet ef migrations add init
  73       12.075 dotnet ef migrations add init --context ProductDbContext
  74       13.262 dotnet ef database update --context ProductDbContext
  75       12.389 dotnet build
  76        5.187 dotnet build
  77  1:30:23.024 dotnet watch run
  78     8:19.305 dotnet watch run
  79       11.058 dotnet watch run
  80    30:52.767 dotnet watch run
  11        0.572 git init
  12       35.191 git add .
  13        5.346 git commit -m "created blazor CRUD application with entity framework"
  24        1.601 git add .
  25        2.480 git commit -m "added product delete buttom"
  26        0.829 dotnet ef migrations add addedMovies --context MovieContext
  27        0.029 cd .\Server\
  28       20.719 dotnet ef migrations add addedMovies --context MovieContext
  29       15.931 dotnet build
  30        5.076 dotnet build
  31       12.110 dotnet ef migrations add addedMovies --context MovieContext
  32       11.240 dotnet ef migrations add addedMovies --context MovieContext
  33        0.509 dotent ef database update
  34        9.641 dotnet ef database update
  35       11.508 dotnet ef database update --context MovieContext
  81        0.785 git add .
  82        0.975 git commit -m "added movies db table and blazor page"
  83       12.050 dotnet add package Swashbuckle.AspNetCore
  84     1:51.265 dotnet watch run
  85        1.037 git add .
  86        0.802 git commit -m "added swagger ui"
  87     5:37.929 dotnet watch run
  88        4.866 dotnet build
  89       55.327 dotnet watch run
  90        9.850 dotnet ef migrations add "addedUserstoproductDB"
  91       11.331 dotnet ef migrations add "addedUserstoproductDB" --context DatabaseContext
  92       12.001 dotnet ef database update --context DatabaseContext
  93     1:34.259 dotnet watch run
  94        0.623 git add .
  95        0.713 git commit -m "added users table to Product.db and added swaggerui to navigation link"
  96       12.052 dotnet ef migrations add "addedDeveloper" --context DatabaseContext
  97       11.329 dotnet ef database update --context DatabaseContext
  98     8:45.988 dotnet watch run
  99        6.001 dotnet build
 100    16:47.154 dotnet watch run
 101       16.230 dotnet build
 102     1:46.389 dotnet watch run
 103     3:44.325 dotnet watch run
 104     1:01.019 dotnet watch run
 105        1.972 dotnet restore
 106        4.449 dotnet build
 107     1:37.608 dotnet watch run
 108       12.889 dotnet ef migrations add "addedDeveloper" --context ApplicationDBContext
 109       11.970 dotnet ef database update --context ApplicationDBContext
 110     2:02.358 dotnet watch run
 111        1.403 git add .
 112        2.490 git commit -m "added developers entity and blazor page"
 113        0.657 git rm -r --cached .
 114        0.375 git add .
 115        2.933 git commit -am "Removed ignore files"
 116        0.313 git status
 117        0.197 git add
 118        0.233 git add .
 119        0.355 git status
 120        0.327 git commit -m "updated ignore"
 121        0.227 git add .gitignore
 122        0.241 git add /.gitignore
 123        0.244 git add -u
 124        0.218 git status
 125        0.023 cd ..
 126        0.083 ls
 127        0.468 git add .
 128        0.350 git sttus
 129        0.231 git status
 130        0.589 git commit -m "added client webpages"
 131        0.467 $ git ls-tree --full-tree --name-only -r HEAD
 132        0.293 git ls-tree --full-tree --name-only -r HEAD
 133        3.702 git rm -r --cached .
 134        0.586 git add .
 135        6.416 git commit -am "removed ignored files"
 136        0.236 git status
 137        5.378 curl -u dlh0038 https://api.github.com/user/repos -d '{"name":"BlazorCRUD"}'
 138        0.585 dotnet watch run
 139     2:31.265 dotnet watch run --project .\Server\