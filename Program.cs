using Microsoft.EntityFrameworkCore;
using nailon.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<testContext>(options => 
    options.UseMySql("server=localhost;database=test;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.21-mariadb")));

builder.Services.AddControllersWithViews();


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
    pattern: "{controller=Nailon}/{action=Index}/{id?}");

app.Run();
