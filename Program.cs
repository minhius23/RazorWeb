using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Razor09.Pages;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ArticleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArticleContext") ?? throw new InvalidOperationException("Connection string 'ArticleContext' not found.")));
builder.Services.AddDbContext<MyBlogContext>(option =>{
    string connectString = builder.Configuration.GetConnectionString("MyBlogContext");
    option.UseSqlServer(connectString);
});

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
/*
    CRUD
    dotnet aspnet-codegenerator razorpage -m Razor09.Pages.Article -dc Razor09.Pages.MyBlogContext -outDir Pages/Blog -udl referenceScriptLibraties
*/