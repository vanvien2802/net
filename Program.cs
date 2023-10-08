using StudentMVC.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services =builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");
var serverVersion = new MySqlServerVersion(new Version(8,0,34));
services.AddControllersWithViews();
services.AddDbContext<DataContext>(
    dbContextOption => dbContextOption
        .UseMySql(connectionString,serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
