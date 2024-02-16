using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Sol.Galaxy.Application;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.MinimalApi.Extensions;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Host.UseSerilog(
    (HostBuilderContext context, LoggerConfiguration loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(context.Configuration.GetSection("Loggin"));
    
});

#region Autoriza
string semila = "Estaesunaclavelargacumplerequisitode256bitsEstaesunaclavelargacumplerequisitode256bits";
byte[] semilaBytes = Encoding.UTF8.GetBytes(semila);
SymmetricSecurityKey key = new SymmetricSecurityKey(semilaBytes);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = key,
        ValidateLifetime = true,
        ValidIssuer="galaxy.com",
        ValidAudience="galaxy",
        ValidateAudience=true,
        ValidateIssuer=true,
    };

});

#endregion

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

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.ConfigureMetodos();


app.Run();
