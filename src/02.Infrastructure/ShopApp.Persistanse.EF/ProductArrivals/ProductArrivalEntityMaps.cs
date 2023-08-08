using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.ProductArrivals
{
    public class ProductArrivalEntityMaps : IEntityTypeConfiguration<ProductArrival>
    {
        public void Configure(EntityTypeBuilder<ProductArrival> entity)
        {
            entity.ToTable("ProductArrivals");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.DateTime).IsRequired();
            entity.Property(_ => _.Count).IsRequired();
            entity.Property(_ => _.NumberOfInvoice).IsRequired();
            entity.Property(_ => _.NameCompany).IsRequired().HasMaxLength(255);

            entity.Property(_ => _.ProductId).IsRequired();
            entity.HasOne(_ => _.Product)
                .WithMany(_ => _.productArrivals)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
