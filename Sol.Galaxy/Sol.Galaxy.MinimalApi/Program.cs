using Microsoft.EntityFrameworkCore;
using Sol.Galaxy.Application;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.MinimalApi.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInjections();

string cadena = builder.Configuration.GetValue<string>("CnnSQL");
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddDbContext<VentasContext>(option =>
{
    option.UseSqlServer(cadena);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureMetodos();


app.Run();
