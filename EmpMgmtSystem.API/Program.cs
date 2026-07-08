using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.Services;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra.Repositories;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Comes by default configured with .NETCore WebAPI


// Step i : Registering DbContext class - by default it will be registered as scoped lifetime i.e one instance per req
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EmpMgmtDB")));

// Step ii : registers the services required for Web API controllers in ASP.NET Core, including routing, model binding, and serialization etc
builder.Services.AddControllers();


// Step iii: Adding all other Services into IoC container 
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


// Step iv : Enabling Swagger/OpenAPI support for the API project 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Step v : Setting up CORS(Cross Origin Resource Sharing)

// v.a : getting origins(domains on which our UI will be running) from the configuration file using Binder pattern(fetch & then bind the configurations to a strongly typed type),instead of hardcoding into the program.cs  file

var allowedOrigins = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();


builder.Services.AddCors(options =>
{
    // Named policy : We have to add the dev,qa,stage,uat prod env details as and when they are available
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod());
});


// Step vi : Add the JWT authentication scheme in the ConfigureServices method & define Token Validation Parameters.

// vi.a : fetching jwt configuration from appsettings.json 
var jwtSettings = builder.Configuration.GetSection("Jwt");

// For local/dev envs, it’s fine to keep a dummy Secret_Key inside appsettings.json. But for prod, we should always externalize it (env vars, user secrets, or a vault like Azure Key Vault).
var secret_key = jwtSettings.GetValue<string>("Secret_Key") ?? throw new InvalidOperationException("JWT Secret_Key is missing!"); // fail-fast check for secret_key 

// by default the DefaultAuthenticateSchema is CookiesAuthentication(for MVC controller) so we need to change this to JWT for WebAPI 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],

        ValidateAudience = true,
        ValidAudience = jwtSettings.GetValue<string>("Audience"),

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret_key)),

        ClockSkew = TimeSpan.Zero // by default 5‑minute clock skew i.e for a grace period of 5 minutes our token will still remain valid even though it has crossed the EXPIRATION_MINUTES. (TimeZone.Zero) Removes the default 5‑minute grace period. Token expiration is enforced exactly at the exp claim time.
    };
});


builder.Services.AddAuthorization(options => { });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
} // Swagger is only preferred for dev env 

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();

app.UseAuthorization();

// Map all controller endpoints (routes) into the request pipeline.
app.MapControllers();

app.Run();
