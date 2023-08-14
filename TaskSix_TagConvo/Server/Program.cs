using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using TaskSix_TagConvo.Server.Data;
using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Server.Domain.Repo;
using TaskSix_TagConvo.Server.Services.Interfaces;
using TaskSix_TagConvo.Server.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                          ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//string connectionString = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb")?? throw new InvalidOperationException("Connection string 'MYSQLCONNSTR_localdb' not found.");
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection, sqlServerOptionsAction:
    sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10,
        maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null);
    }));
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddTransient<ITagRepo, TagRepo>();
builder.Services.AddTransient<IMessageRepo, MessageRepo>();
builder.Services.AddTransient<IMessageTagsRelationsRepo, MessageTagsRelationsRepo>();
builder.Services.AddTransient<IMessageService, MessageService>();



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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();