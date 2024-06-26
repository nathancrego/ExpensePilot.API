using ExpensePilot.API.Data;
using ExpensePilot.API.Models.Domain.Administration.UserManagement;
using ExpensePilot.API.Repositories.Implementation.Administration.DepartmentManagement;
using ExpensePilot.API.Repositories.Implementation.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Implementation.Administration.UserManagement;
using ExpensePilot.API.Repositories.Interface.Administration.DepartmentManagement;
using ExpensePilot.API.Repositories.Interface.Administration.RoleAccessManagement;
using ExpensePilot.API.Repositories.Interface.Administration.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injecting the dbcontext class using dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //Linking to ExpensePilotConnectionString
    options.UseSqlServer(builder.Configuration.GetConnectionString("ExpensePilotConnectionString"));
});

//Injecting the repositories(Dependency Injection)
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUserRolesRepository, UserRolesRepository>();
builder.Services.AddScoped<IUserAccessRepository, UserAccessRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IAuthLoginRepository, AuthLoginRepository>();

builder.Services.AddSingleton<IPasswordHasher<Users>, PasswordHasher<Users>>();


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
