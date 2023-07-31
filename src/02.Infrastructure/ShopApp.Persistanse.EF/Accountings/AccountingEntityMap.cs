using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Accountings
{
    public class AccountingEntityMap : IEntityTypeConfiguration<Accounting>
    {
        public void Configure(EntityTypeBuilder<Accounting> entity)
        {
            entity.ToTable("Accountings");
            entity.HasKey(_ => _.Id);
            entity.Property(_ => _.Id).ValueGeneratedOnAdd();
            entity.Property(_ => _.TotalCount).IsRequired();
            entity.Property(_ => _.NumberOfinvoiceSell).IsRequired();
            entity.Property(_ => _.NumberOfDocument).IsRequired();
            entity.Property(_ => _.DocumentRegistrationDate).IsRequired();

         
        }
    }
}
