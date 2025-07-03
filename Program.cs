using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;    // ← make sure this is here!
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using ControlCenterApp.Data;

var builder = WebApplication.CreateBuilder(args);

// 1) Configure OpenID Connect with MS Identity Web
builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

// 2) Add Razor Pages and hook up the Microsoft Identity UI
builder.Services
    .AddRazorPages()                   // returns a RazorPagesBuilder
    .AddMicrosoftIdentityUI();         // extension on RazorPagesBuilder

// 3) Configure EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Require login for all pages
app.MapRazorPages().RequireAuthorization();

// map a GET /logout that will sign you out of both the cookie and OIDC schemes
app.MapGet("/logout", async context =>
{
    // clear the OpenIDConnect cookie
    await context.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
    // clear the local cookie
    await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    // redirect home
    context.Response.Redirect("/");
})
.RequireAuthorization();

app.Run();
