using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Migrations
{
    [Migration(202307311620)]
    public class _202307311620_AddedAllEntity : Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
                  .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                  .WithColumn("Name").AsString(255).NotNullable();


            Create.Table("Products")
         .WithColumn("Id").AsInt32().PrimaryKey().Identity()
         .WithColumn("Title").AsString(255).NotNullable()
         .WithColumn("MinimumInventory").AsInt32().NotNullable()
         .WithColumn("Inventory").AsInt32().NotNullable()
         .WithColumn("statusType").AsInt32().NotNullable()

         .WithColumn("CategoryId").AsInt32().NotNullable()
         .ForeignKey("Fk_Products_Categories", "Categories", "Id");


            Create.Table("ProductArrivals")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Count").AsInt32().NotNullable()
              .WithColumn("DateTime").AsDateTime().NotNullable()
              .WithColumn("NumberOfinvoice").AsString(255).NotNullable()
              .WithColumn("NameCompany").AsString(255).NotNullable()
              .WithColumn("StatusType").AsInt32().NotNullable()

               .WithColumn("ProductId").AsInt32().NotNullable()
         .ForeignKey("Fk_Products_ProductArrivals", "Products", "Id");


            Create.Table("Accountings")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DocumentRegistrationDate").AsDateTime().NotNullable()
                .WithColumn("NumberOfDocument").AsInt32().NotNullable()
                .WithColumn("NumberOfinvoiceSell").AsString(255).NotNullable()
                .WithColumn("TotalPrice").AsDouble().NotNullable();

            Create.Table("Sells")
                 .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                 .WithColumn("Count").AsInt32().NotNullable()
                 .WithColumn("Price").AsDouble().NotNullable()
                 .WithColumn("DateTime").AsDateTime().NotNullable()
                 .WithColumn("NumberOfInvoice").AsString(255).NotNullable()
                 .WithColumn("CustomerName").AsString(255).NotNullable()

                  .WithColumn("ProductId").AsInt32().NotNullable()
                  .ForeignKey("FK_Sells_Products", "Products", "Id")

                    .WithColumn("AccountingId").AsInt32().NotNullable()
                  .ForeignKey("FK_Sells_Accountings", "Accountings", "Id");





        }
        public override void Down()
        {
            Delete.Table("Sells");
            Delete.Table("Accountings");
            Delete.Table("ProductArrivals");
            Delete.Table("Products");
            Delete.Table("Categories");
        }

    }
}
