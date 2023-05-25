using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Identity.Web.UI;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Userbox.Models;
using Userbox.Models.Services;

#region Services container
var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
UtenteAuth utenteauth = new UtenteAuth();


ConfigurationManager configuration = builder.Configuration;
ConfigurationManager StaticConfig = configuration;
IWebHostEnvironment env = builder.Environment;
builder.Services.AddSingleton(utenteauth);
builder.Services.AddSingleton(config);




builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
builder.Services.AddControllersWithViews();
//builder.Services.AddAuthentication(
//    options =>
//    {
//        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        options.DefaultChallengeScheme = "UnipiAuth";
//    })
//    .AddCookie() // https://localhost:7077/MicrosoftIdentity/Account/Signout
//    .AddOAuth("UnipiAuth", oAuthOptions =>
//    {
//        oAuthOptions.ClientId = config["AuthenticationMgt:ClientID"];
//        oAuthOptions.ClientSecret = config["AuthenticationMgt:ClientSecret"];
//        oAuthOptions.AuthorizationEndpoint = config["AuthenticationMgt:AuthorizationEndpoint"];
//        oAuthOptions.TokenEndpoint = config["AuthenticationMgt:TokenEndpoint"];
//        oAuthOptions.UserInformationEndpoint = config["AuthenticationMgt:UserinfoEndpoint"];
//        oAuthOptions.CallbackPath = new PathString(config["AuthenticationMgt:CallbackPath"]);
//        oAuthOptions.Scope.Add(config["AuthenticationMgt:Scope"]);
//        oAuthOptions.SaveTokens = true;

//        foreach (string c in config.GetSection("AuthenticationMgt:Claims").Get<List<string>>())
//        {
//            oAuthOptions.ClaimActions.MapJsonKey(c, c);
//        }

//        // web can map json values to any standard-defined ClaimTypes names
//        oAuthOptions.ClaimActions.MapJsonKey(ClaimTypes.UserData, "sub");
//        // or use any name we prefer
//        oAuthOptions.ClaimActions.MapJsonKey("UnipiUserID", "sub");
//        var originalOnCreatingTicketEvent = oAuthOptions.Events.OnCreatingTicket;

//        oAuthOptions.Events = new OAuthEvents
//        {
//            OnCreatingTicket = async context =>
//            {
//                originalOnCreatingTicketEvent?.Invoke(context);

//                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
//                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
//                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);

//                string userinfo = await response.Content.ReadAsStringAsync();
//                var myuser = JsonDocument.Parse(userinfo);

//                context.RunClaimActions(myuser.RootElement);
//                context.HttpContext.Response.Cookies.Append("unipiAuthToken", context.AccessToken);
//            }
//        };
//    })
//;


builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = "UnipiAuth";
    })
    .AddCookie() // https://localhost:7077/MicrosoftIdentity/Account/Signout
    .AddOAuth("UnipiAuth", oAuthOptions =>
    {
        oAuthOptions.ClientId = config["AuthenticationMgt:ClientID"];
        oAuthOptions.ClientSecret = config["AuthenticationMgt:ClientSecret"];
        oAuthOptions.AuthorizationEndpoint = config["AuthenticationMgt:AuthorizationEndpoint"];
        oAuthOptions.TokenEndpoint = config["AuthenticationMgt:TokenEndpoint"];
        oAuthOptions.UserInformationEndpoint = config["AuthenticationMgt:UserinfoEndpoint"];
        oAuthOptions.CallbackPath = new PathString(config["AuthenticationMgt:CallbackPath"]);
        oAuthOptions.Scope.Add(config["AuthenticationMgt:Scope"]);
        oAuthOptions.SaveTokens = true;

        foreach (string c in config.GetSection("AuthenticationMgt:Claims").Get<List<string>>())
        {
            oAuthOptions.ClaimActions.MapJsonKey(c, c);
        }

        // web can map json values to any standard-defined ClaimTypes names
        oAuthOptions.ClaimActions.MapJsonKey(ClaimTypes.UserData, "sub");
        // or use any name we prefer
        oAuthOptions.ClaimActions.MapJsonKey("UnipiUserID", "sub");
        var originalOnCreatingTicketEvent = oAuthOptions.Events.OnCreatingTicket;

        oAuthOptions.Events = new OAuthEvents
        {
            OnCreatingTicket = async context =>
            {
                originalOnCreatingTicketEvent?.Invoke(context);

                var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);

                string userinfo = await response.Content.ReadAsStringAsync();
                var myuser = JsonDocument.Parse(userinfo);

                context.RunClaimActions(myuser.RootElement);
                //  context.HttpContext.Response.Cookies.Append("unipiAuthToken", context.AccessToken);

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.None
                };

                // Add the cookie to the response cookie collection
                context.HttpContext.Response.Cookies.Append("unipiAuthToken", context.AccessToken, cookieOptions);

            }
        };
    })
;


builder.Services.AddRazorPages()
    .AddMicrosoftIdentityUI();

builder.Services.AddControllersWithViews(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});



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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
#endregion