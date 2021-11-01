using BlazorServerDemo.Net6.MovieRatings.Models.Configuration;
using BlazorServerDemo.Net6.MovieRatings.Web.Data;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<PathService>();
builder.Services.AddSingleton<MoviesService>();


JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

var pathConfiguration = builder.Configuration.GetSection(PathConfiguration.SectionName).Get<PathConfiguration>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", options =>
    {
        options.Events.OnSigningOut = async e =>
        {
            await e.HttpContext.RevokeUserRefreshTokenAsync();
        };
    })
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = pathConfiguration?.Identity;

        options.ClientId = "web";
        options.ClientSecret = "secret";
        options.ResponseType = "code";

        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;

        options.Scope.Clear();
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("apis.movies");
        options.Scope.Add("apis.movies.read");
        options.Scope.Add("apis.movies.write");

        options.TokenValidationParameters.NameClaimType = "name";

    });
builder.Services.AddMvcCore(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    //if we wanted all pages to require authorization, we'd uncomment this
    //options.Filters.Add(new AuthorizeFilter(policy));
});

//add service that will allow us to access HttpContext
builder.Services.AddHttpContextAccessor();


//add http client for the movie service
//builder.Services.AddHttpClient<MoviesService>(client =>
//{
//    client.BaseAddress = new Uri(pathConfiguration.Api);
//})
//    .AddClientAccessTokenHandler("web");
////builder.Services.AddAccessTokenManagement();
//builder.Services.AddAccessTokenManagement(options =>
//{
//    options.Client.Clients.Add("web", new ClientCredentialsTokenRequest
//    {
//        RequestUri = new Uri($"{pathConfiguration.Identity}/connect/token"),
//        ClientId = "web",
//        ClientSecret = "secret"
//    });
//});

// registers HTTP client that uses the managed user access token
builder.Services.AddAccessTokenManagement(options =>
{
    // client config is inferred from OpenID Connect settings
    // if you want to specify scopes explicitly, do it here, otherwise the scope parameter will not be sent
    options.Client.DefaultClient.Scope = "movies";
})
    .ConfigureBackchannelHttpClient()
        .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        }));

builder.Services.AddUserAccessTokenHttpClient("user_client", configureClient: client =>
{
    client.BaseAddress = new Uri(pathConfiguration.Api);
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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}"); //adds mvc endpoint
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");




app.Run();
