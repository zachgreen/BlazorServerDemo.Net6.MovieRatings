using BlazorServerDemo.Net6.MovieRatings.Models.Configuration;
using BlazorServerDemo.Net6.MovieRatings.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<PathService>();
builder.Services.AddSingleton<MoviesService>();


JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration.GetSection(PathConfiguration.SectionName).Get<PathConfiguration>()?.Identity;

        options.ClientId = "web";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;

        options.TokenValidationParameters.NameClaimType = "name";

    });
builder.Services.AddMvcCore(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    //options.Filters.Add(new AuthorizeFilter(policy));
}); 
builder.Services.AddHttpContextAccessor();

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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); //adds mvc endpoint
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");




app.Run();
