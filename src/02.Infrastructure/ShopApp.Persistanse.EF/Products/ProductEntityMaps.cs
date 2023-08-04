using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Products
{
    internal class ProductEntityMaps : IEntityTypeConfiguration<Product>
    {
      
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.Title).IsRequired().HasMaxLength(255);
            entity.Property(_ => _.MinimumInventory).IsRequired();
            entity.Property(_ => _.Inventory).IsRequired();
            entity.Property(_ => _.statusType).IsRequired();

            entity.Property(_ => _.CategoryId).IsRequired();
            entity.HasOne(_ => _.Category)
                .WithMany(_ => _.Products)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
