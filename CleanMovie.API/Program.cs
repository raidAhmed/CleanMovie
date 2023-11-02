using CleanMovie.Application.Extensions;
using CleanMovie.Application.Interfaces.Common;
using CleanMovie.Application.Interfaces.Repositories;
using CleanMovie.Application.Interfaces.Services;
using CleanMovie.Application.Services;
using CleanMovie.Infrastructure.DbContexts;
using CleanMovie.Infrastructure.Extensions;
using CleanMovie.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


 


builder.Services.AddPresistenceAPI(builder.Configuration);
builder.Services.AddApplicationAPI();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
