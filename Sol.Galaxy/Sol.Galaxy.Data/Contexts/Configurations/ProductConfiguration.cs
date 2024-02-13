using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sol.Galaxy.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol.Galaxy.Data.Contexts.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
        {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product", "DBO");
            builder.HasKey(t => t.ProductId);
            builder.Property(t => t.ProductId).HasColumnName("ProductCode");
            builder.Property(t => t.ProductName).HasColumnName("ProductDescripcion");
            builder.Property(t=>t.ProductName).HasColumnType("nvarchar(250)");
           
        }


    }
}
