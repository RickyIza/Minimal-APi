using Microsoft.EntityFrameworkCore;
using Sol.Galaxy.Data.Contexts.Configurations;
using Sol.Galaxy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Contexts
{
    public class VentasContext : DbContext
    {
        public VentasContext(DbContextOptions<VentasContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Product { get; set; }
    }
}
