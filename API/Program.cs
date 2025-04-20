
using ContactsManager.Core.ServiceContracts;
using ContactsManager.Core.Services;
using ContactsManager.Infrastructure.DbInitializer;
using Microsoft.EntityFrameworkCore;
using MyWebApi.DataAccess;
using MyWebApi.Repositories;
using MyWebApi.RepositoryContracts;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentAdderService, DepartmentAdderService>();
builder.Services.AddScoped<IDepartmentUpdaterService, DepartmentUpdaterService>();
builder.Services.AddScoped<IDepartmentGetterService, DepartmentGetterService>();
builder.Services.AddScoped<IDepartmentDeleterService, DepartmentDeleterService>();
builder.Services.AddScoped<IEmployeeAdderService, EmployeeAdderService>();
builder.Services.AddScoped<IEmployeeUpdaterService, EmployeeUpdaterService>();
builder.Services.AddScoped<IEmployeeGetterService, EmployeeGetterService>();
builder.Services.AddScoped<IEmployeeDeleterService, EmployeeDeleterService>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
SeedDatabase();
app.MapControllers();

app.Run();
void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}
