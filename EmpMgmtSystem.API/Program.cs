using EmpMgmtSystem.Application;
using EmpMgmtSystem.Domain;
using EmpMgmtSystem.Infra;
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


// Step iv : Enabling Swagger/OpenAPI support for the API project 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
} // Swagger is only preferred for dev env 

app.UseHttpsRedirection();

// Map all controller endpoints (routes) into the request pipeline.
app.MapControllers();

app.Run();
