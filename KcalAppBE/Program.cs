using KcalAppBE.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Main");
if (Environment.GetEnvironmentVariable("POSTGRES_HOSTNAME") != null)
{
    var hostname = Environment.GetEnvironmentVariable("POSTGRES_HOSTNAME");
    var port = Environment.GetEnvironmentVariable("POSTGRES_PORT");
    if (port == null)
        throw new ArgumentNullException("POSTGRES_PORT");

    var user = Environment.GetEnvironmentVariable("POSTGRES_USER");
    if (user == null)
        throw new ArgumentNullException("POSTGRES_USER");

    var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    if (password == null)
        throw new ArgumentNullException("POSTGRES_PASSWORD");

    connectionString = $"Server={hostname};Port={port};Database=Appy;Userid={user};Password={password}";

}


builder.Services.AddDbContext<MainDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MainDbContext>();
    db.Database.Migrate(); // <- creates database if missing and applies migrations
}

app.Run();
