using Application;
using Infrastructure;
using Application.Abstractions;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Application.Employees.Commands;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
var connectionString = builder.Configuration.GetConnectionString("EmployeeConnectionString");
builder.Services.AddDbContext<EmployeeDBContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployee).Assembly));
string LogFilePath = builder.Configuration.GetSection("Path").GetSection("LogFilePath").Value;
Log.Logger = new LoggerConfiguration().WriteTo.File(LogFilePath, rollingInterval: RollingInterval.Day).CreateLogger();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
