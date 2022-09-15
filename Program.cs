using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyWebApp.Entities;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DekDueShopContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("ConnectionSQLServer"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
