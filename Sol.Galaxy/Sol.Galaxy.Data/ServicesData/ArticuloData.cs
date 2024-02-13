using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sol.Galaxy.Data.Contexts;
using Sol.Galaxy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Services
{
    public class ArticuloData : IArticuloData
    {
        private readonly VentasContext ventasContext;

        public ArticuloData(VentasContext ventasContext , ILogger<ArticuloData> logger)
        {
            this.ventasContext = ventasContext;
            Logger = logger;
        }

        public ILogger<ArticuloData> Logger { get; }

        public async Task<Product> DeleteProduct(int id)
        {
            var product = await ventasContext.Product.FindAsync(id);

            if (product != null)
            {
                ventasContext.Product.Remove(product);
                await ventasContext.SaveChangesAsync();
            }

            return product;
        }

        public Task<Product> GetProduct(int id)
        {
            return ventasContext.Product.Where(t=>t.ProductId == id).FirstOrDefaultAsync();
        }

        public Task<List<Product>> GetProducts()
        {
            //Logger.LogError("Errir");
            //Logger.LogWarning("Warning");
            
            var res = ventasContext.Product.ToListAsync();

            return res;
        }

        public async Task<Product> InsertProduct(Product product)
        {
          ventasContext.Product.Add(product);
          await  ventasContext.SaveChangesAsync();

            return product;
        }

        public Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
