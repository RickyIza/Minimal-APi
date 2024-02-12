using Galaxy.Sales.Api.Application.Domain;

namespace Galaxy.Sales.Api.Application.ApplicationDomain
{
    public class ArticuloApp : IArticuloApp
    {
        public Articulo GetArticulo(int id)
        {
            throw new NotImplementedException();
        }

        public List<Articulo> GetArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            lista.Add(new Articulo { Codigo = 1, Nombre = "Monito", Precio = 100 });

            lista.Add(new Articulo { Codigo = 2, Nombre = "Mo2", Precio = 100 });

            lista.Add(new Articulo { Codigo = 3, Nombre = "me", Precio = 100 });

            return lista;
        }
    }
}
