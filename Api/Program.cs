using Api.core.Interfaces;
using Api.core.Security;
using Api.core.Services;
using Api.Infrastructure.Data;
using Api.Infrastructure.Repositories;
using Api.Middlewares;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<DataContextEf>();
builder.Services.AddScoped<IJwt, JwtService>();
builder.Services.AddScoped<IAuth, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
// inja behtare baraye prod estefade beshe 
app.UseHttpsRedirection();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<JwtValidationMiddleware>();
app.MapControllers();

app.Run();

