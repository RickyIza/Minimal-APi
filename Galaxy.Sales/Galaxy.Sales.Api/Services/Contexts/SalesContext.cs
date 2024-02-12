using Galaxy.Sales.Api.Services.Entities;
using Microsoft.EntityFrameworkCore;

namespace Galaxy.Sales.Api.Services.Contexts
{
    public class SalesContext:DbContext
    {
        public SalesContext(
            DbContextOptions<SalesContext> options
            ):base(options) { }
        
            
        
        public DbSet<Product> Product { get; set; }
    }
}
