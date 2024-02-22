using Microsoft.EntityFrameworkCore;
using WebOrderSystem.Context;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
