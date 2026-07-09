using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ops.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)");

            builder.Property(x => x.SKU)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasIndex(x => x.SKU)
                   .IsUnique();

            //builder.HasData(
            //    new Product
            //    {
            //        //Id = 1,
            //        Name = "Laptop",
            //        Description = "Dell Laptop",
            //        Price = 55000,
            //        StockQuantity = 20,
            //        SKU = "LAP001"
            //    },
            //    new Product
            //    {
            //        //Id = 2,
            //        Name = "Mouse",
            //        Description = "Wireless Mouse",
            //        Price = 800,
            //        StockQuantity = 100,
            //        SKU = "MOU001"
            //    }
            //);
        }
    }
}
