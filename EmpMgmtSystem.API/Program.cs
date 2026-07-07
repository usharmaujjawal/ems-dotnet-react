using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.Services;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra.Repositories;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

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

// Map all controller endpoints (routes) into the request pipeline.
app.MapControllers();

app.Run();
