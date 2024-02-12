using Comunes;
using Galaxy.Sales.Api.Application.ApplicationDomain;
using Galaxy.Sales.Api.Application.Domain;
using Galaxy.Sales.Api.Services.Contexts;
using Galaxy.Sales.Api.Services.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArticuloApp, ArticuloApp>();
builder.Services.AddScoped<IAlumnoProc, AlumnoProc>();


//SQLSERVER
builder.Services.AddDbContext<SalesContext>(
    option =>
    {
        option.UseSqlServer("Data Source=LAPTOP-MO5BCA5I;Initial Catalog=Sales;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
    }
    );
//activar controller

//builder.Services.AddControllers().AddJsonOptions(option =>
//{
//    option.JsonSerializerOptions.PropertyNamingPolicy = null;
//});

// Add services to the container.

var app = builder.Build();
//app.MapControllers();
if (app.Environment.IsDevelopment() && app.Environment.EnvironmentName=="QA")//uat
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.MapGet("/articulodb",(SalesContext salescontex) =>
{
    //Product p = new Product { ProductId = 3, ProductName = "Demo PC" };
    //salesContext.Product.Add(p);
    //salesContext.SaveChanges();
    List<Product> res=  salescontex.Product.ToList();
    return res;

}).WithOpenApi();

app.MapGet("/articulos", (IArticuloApp articuloApp) =>
{
    return articuloApp.GetArticulos();
}).WithOpenApi();

// Configure the HTTP request pipeline.


app.Run();

public interface Iventa
{
    int Sumar(int i,int j);
    int Restar(int i, int j);


}


public class venta : Iventa
{
    public int Restar(int i, int j)
    {
        throw new NotImplementedException();
    }

    public int Sumar(int i, int j)
    {
        throw new NotImplementedException();
    }
}

public class ventaEmpres : Iventa
{
    public int Restar(int i, int j)
    {
        throw new NotImplementedException();
    }

    public int Sumar(int i, int j)
    {
        throw new NotImplementedException();
    }
}

public class Test
{

    public void teste()
    {
        ventaEmpres venta = new ventaEmpres();
        Procesar(venta);


    }
    public int Procesar(Iventa venta)
    {
        return venta.Sumar(10, 20);
    }
}