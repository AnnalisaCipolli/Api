using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Userbox.Models;
using Userbox.Models.Services;

#region Services container
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
ConfigurationManager StaticConfig = configuration;
IWebHostEnvironment env = builder.Environment;

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("it")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "it", uiCulture: "it");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddTransient<IStringLocalizer, CustomLocalizer>();
#endregion
#region HTTP pipeline configuration
var app = builder.Build();

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
#endregion