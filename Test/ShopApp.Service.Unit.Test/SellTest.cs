using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.TestTools.Accountings;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using ShopApp.TestTools.Products;
using ShopApp.TestTools.Sells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopApp.Service.Unit.Test
{
    public class SellTest : BusinessUnitTest
    {
        [Fact]
        public void Add_added_sell_properly()
        {
            var category = CategoryFactory.Generate("لوازم یدکی");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithInventory(20)
                .WithMinimumInventory(5)
                .WithCategoryId(category.Id)
                .WithTitle("لنت ترمز")
                .WithStatusType(StatusType.Available)
                .Build();
            DbContext.Save(product);

            var dto = new AddedSellDtoBuilder()
              .WithCount(5)
              .WithProductId(product.Id)
              .WithPrice(1000)
              .WithCustomerName("مجید رضوی")
               
              .Build();

            var sut = SellServicesFactories.Create(SetupContext);
            sut.Add(dto);

            var totalPrice = dto.Count * dto.Price;

             var dtoAccounting = new AddedAccountingDtoBuilder()
            .WithTotalPrice(totalPrice)
            .WithNumberOfDocument(123)
            .WithDocumentRegistrationDate(DateTime.UtcNow)
            .WithNumberOfinvoiceSell(dto.NumberOfinvoiceSell)
            .Build();
            var sutAccounting = AccountingServicesFactories.Create(SetupContext);
            sutAccounting.Add(dtoAccounting);

             var productDto = new UpdateProductDto()
            {
                Inventory = product.Inventory - dto.Count,
            };

            var productSut = ProductServicesFactories.Create(SetupContext);
            productSut.Update(dto.ProductId, productDto);



            var expectedProduct = ReadContext.Set<Product>().Single();
            expectedProduct.Title.Should().Be("لنت ترمز");
            expectedProduct.Inventory.Should().Be(15);
            expectedProduct.statusType.Should().Be(product.statusType);
            expectedProduct.MinimumInventory.Should().Be(5);
            expectedProduct.CategoryId.Should().Be(product.CategoryId);

            var expected = ReadContext.Set<Sell>().Single();
            expected.Product.Title.Should().Be("لنت ترمز");
            expected.CustomerName.Should().Be("مجید رضوی");
            expected.NumberOfinvoiceSell.Should().Be("123a");
            expected.Count.Should().Be(5);
            expected.Price.Should().Be(1000);
            expected.DateTime.Should().Be(new DateTime(2023, 8, 3));
            //var expectAccounting = expected.dtoAccounting.Single();
            // expected.ProductId.Should().Be(_product.Id);

            var expectedAccounting = ReadContext.Set<Accounting>().Single();
            expectedAccounting.NumberOfinvoiceSell.Should().Be("123a");
            expectedAccounting.NumberOfDocument.Should().Be(1233455657);
            expectedAccounting.DocumentRegistrationDate.Should().Be(new DateTime(2023, 8, 3));
            expectedAccounting.TotalPrice.Should().Be(5000);


        }
    }
}
