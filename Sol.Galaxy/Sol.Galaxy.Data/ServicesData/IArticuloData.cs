using Sol.Galaxy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Services
{
    public interface IArticuloData
    {
        Task<List<Product>> GetProducts();

        Task <Product> GetProduct(int id);

        Task<Product> InsertProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> DeleteProduct(int id);    

    }
}
