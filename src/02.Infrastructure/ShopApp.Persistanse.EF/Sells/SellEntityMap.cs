using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Sells
{
    public class SellEntityMap : IEntityTypeConfiguration<Sell>
    {
        public void Configure(EntityTypeBuilder<Sell> entity)
        {
            entity.ToTable("Sells");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_=>_.Price).IsRequired();
            entity.Property(_=>_.NumberOfinvoiceSell).IsRequired();
            entity.Property(_=>_.CustomerName).IsRequired();
            entity.Property(_=>_.DateTime).IsRequired();
            entity.Property(_=>_.Count).IsRequired();
            entity.Property(_=>_.StatusType).IsRequired();

            entity.Property(_ => _.ProductId).IsRequired();
            entity.HasOne(_ => _.Product)
                .WithMany(_ => _.Sells)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(_ => _.AccountingId).IsRequired();
            entity.HasOne(_ => _.Accounting)
                .WithOne(_ => _.Sell)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
