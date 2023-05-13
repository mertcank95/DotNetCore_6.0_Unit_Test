using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
               new Product { Id = 1, Name = "Laptop", StockQuantity = 5},
               new Product { Id = 2, Name = "Phone", StockQuantity = 3 },
               new Product { Id = 3, Name = "PC", StockQuantity = 7 },
               new Product { Id = 4, Name = "Vacuum Cleaner", StockQuantity = 10 });
        }
    }
}
