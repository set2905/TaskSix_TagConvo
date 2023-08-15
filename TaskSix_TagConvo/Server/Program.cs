using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using TaskSix_TagConvo.Server.Data;
using TaskSix_TagConvo.Server.Domain.Repo.Interfaces;
using TaskSix_TagConvo.Server.Domain.Repo;
using TaskSix_TagConvo.Server.Services.Interfaces;
using TaskSix_TagConvo.Server.Services;
using TaskSix_TagConvo.Server.Hubs;
using kedzior.io.ConnectionStringConverter;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);


//string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection, sqlServerOptionsAction:
//    sqlOptions =>
//    {
//        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10,
//        maxRetryDelay: TimeSpan.FromSeconds(30),
//        errorNumbersToAdd: null);
//    }));
string? connection = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb")?? throw new InvalidOperationException("Connection string 'MYSQLCONNSTR_localdb' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(AzureMySQL.ToMySQLStandard(connection)));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
       new[] { "application/octet-stream" });
});

builder.Services.AddTransient<ITagRepo, TagRepo>();
builder.Services.AddTransient<IMessageRepo, MessageRepo>();
builder.Services.AddTransient<IMessageTagsRelationsRepo, MessageTagsRelationsRepo>();
builder.Services.AddTransient<IMessageService, MessageService>();




var app = builder.Build();
app.UseResponseCompression();
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
app.MapHub<MessageHub>("/messageHub");

app.MapFallbackToFile("index.html");


app.Run();