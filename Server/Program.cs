using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.ResponseCompression;
using BlazorCRUD.Server.Models;
using BlazorCRUD.Server.Interfaces;
using BlazorCRUD.Server.Services;
using BlazorCRUD.Server.Data;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Setting up Database Context");
// Add services to the container.
//trying to use same database for all entities
// builder.Services.AddDbContext<DatabaseContext>
//     (options =>
//     //options.UseSqlite("Data Source = User.db"));
//     options.UseSqlite("Data Source = Product.db"));
builder.Services.AddTransient<IUser, UserManager>();

//builder.Services.AddDbContext<ProductDbContext> (opts => opts.UseSqlite("Data Source = Product.db"));
//attempting to share database Product.db with both Movie and Products
//builder.Services.AddDbContext<MovieContext> (opts => opts.UseSqlite("Data Source = Product.db"));
// builder.Services.AddScoped<ProductServices>();
//builder.Services.AddDbContext<ApplicationDBContext> (opts => opts.UseSqlite("Data Source = Product.db"));
builder.Services.AddDbContext<ApplicationDBContext> (opts => opts.UseSqlServer("Server=.\\SQLEXPRESS; Database=Product.db;Trusted_Connection=True;TrustServerCertificate=True"));
//builder.Services.AddDbContext<TodoDBContext> (opts => opts.UseSqlServer("Server=.\\SQLEXPRESS; Database=Product.db;Trusted_Connection=True;TrustServerCertificate=True"));
//builder.Services.AddDbContext<TodoDBContext> (opts => opts.UseSqlite("Data Source = todo.db"));
builder.Services.AddDbContext<SchoolContext> (opts => opts.UseSqlite("Data Source = CU.db"));
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
Console.WriteLine("building app");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
Console.WriteLine("seeding database");
//seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    //Contoso University
    var context = services.GetRequiredService<SchoolContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
    //Movies
    var movieContext = services.GetRequiredService<ApplicationDBContext>();
    movieContext.Database.EnsureCreated();
    MovieDBInitializer.Initialize(movieContext);
    //Products
    var ProductDbContext = services.GetRequiredService<ApplicationDBContext>();
    ProductDbContext.Database.EnsureCreated();
    ProductDBInitializer.Initialize(ProductDbContext);

}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
Console.WriteLine("using swagger");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.Run();
