using Sol.Galaxy.Application;
using Sol.Galaxy.Data.Services;
using Sol.Galaxy.Domain;
using System.Runtime.CompilerServices;

namespace Sol.Galaxy.MinimalApi.Extensions
{
    public static class ConfiguracionExtensions
    {
        /// <summary>
        /// Contador de Palabras Galaxy
        /// </summary>
        /// <param name="cadena">Palabra a contar</param>
        /// <returns>Numero de letras</returns>
        public static int ContadorPalabras(this string cadena)
        {

            int cantidad = cadena.Length;
            return cantidad;

        }


        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IArticuloApp, ArticuloApp>();
            services.AddScoped<IArticuloData, ArticuloData>();
            return services;
        }

        public static WebApplication ConfigureMetodos(this WebApplication app)
        {
            app.MapGet("/articulos", async(IArticuloApp articuloApp) =>
            {
                return await articuloApp.GetArticulos();
            }).WithOpenApi();
            //metods

            app.MapGet("/articulos/{id}", async (IArticuloApp articuloApp, int id =0) =>
            {
                Articulo a = await articuloApp.GetArticulo(id);
                if (a == null)
                {
                    return Results.BadRequest("No se encontro el articulo ");

                }
                else
                    return Results.Ok(a);
              
            }).WithOpenApi();
            //metods

            app.MapPost("/articulos", async (IArticuloApp articuloApp, Articulo articulo) =>{

                return Results.Ok(await articuloApp.SaveArticulo(articulo));
            
            });




            return app;

        }

    }
}
