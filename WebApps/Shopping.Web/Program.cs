using BuildingBlocks.Common.Logging;
using BuildingBlocks.SeriLog;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Polly;
using Serilog;
using Shopping.Web.Helpers;
using System.Reflection.Metadata;
using System;
using Common;
using IdentityModel;

var builder = WebApplication.CreateBuilder(args);

/// Config SeriLog
builder.Logging.Configure(options =>
{
    options.ActivityTrackingOptions = ActivityTrackingOptions.TraceId | ActivityTrackingOptions.SpanId;
});

builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTransient<LoggingDelegatingHandler>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddRefitClient<ICatalogService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
    }).AddHttpMessageHandler<LoggingDelegatingHandler>()
    .AddPolicyHandler(PollyHelper.GetRetryPolicy())
    .AddPolicyHandler(PollyHelper.GetCircuitBreakerPolicy());

builder.Services.AddRefitClient<IBasketService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
    }).AddHttpMessageHandler<LoggingDelegatingHandler>()
    .AddPolicyHandler(PollyHelper.GetRetryPolicy())
    .AddPolicyHandler(PollyHelper.GetCircuitBreakerPolicy());

builder.Services.AddRefitClient<IOrderingService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]!);
    })
    .AddHttpMessageHandler<LoggingDelegatingHandler>()
    .AddPolicyHandler(PollyHelper.GetRetryPolicy())
    .AddPolicyHandler(PollyHelper.GetCircuitBreakerPolicy());

// Add Health Check
builder.Services.AddHealthChecks();

// Add Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
//    {
//        options.Authority = Url.Identity_Server;
//        options.ClientId = Common.Constant.Shopping_Client_Id_Value;
//        options.ClientSecret = Common.Constant.Shopping_Client_Secret;
//        options.ResponseType = Common.Constant.Response_Type;

//        options.Scope.Add(Common.Constant.Scope_Open_Id);
//        options.Scope.Add(Common.Constant.Scope_Profile);
//        options.Scope.Add(Common.Constant.Scope_Address);
//        options.Scope.Add(Common.Constant.Scope_Email);
//        options.Scope.Add(Common.Constant.Scope_Role_Value);
//        options.Scope.Add(Common.Constant.Scope_Shopping_Api_Value);

//        options.ClaimActions.MapUniqueJsonKey(Common.Constant.Scope_Role_Value, Common.Constant.Scope_Role_Value);

//        options.SaveTokens = true;
//        options.GetClaimsFromUserInfoEndpoint = true;

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            NameClaimType = JwtClaimTypes.GivenName,
//            RoleClaimType = JwtClaimTypes.Role
//        };
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
