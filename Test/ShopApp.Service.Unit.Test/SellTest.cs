using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts.Dto;
using ShopApp.Services.Sells.Contracts.Dto;
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
            var dto = new AddedSellWithAccountigDto()
            {
                Count = 5,
                CustomerName = "dummy_name",
                Price = 1000,
                ProductId = product.Id,
                NumberOfinvoiceSell = "123a",
               // DateTime=new DateTime(2023, 8, 3),

            };


            var sut = SellServicesFactories.Create(SetupContext);
            sut.AddSellWithAccounting(dto);

            var expectedProduct = ReadContext.Set<Product>().Single();
            expectedProduct.Id.Should().Be(product.Id);
            expectedProduct.Inventory.Should().Be(15);
            expectedProduct.statusType.Should().Be(StatusType.Available);
            expectedProduct.MinimumInventory.Should().Be(product.MinimumInventory);
            expectedProduct.CategoryId.Should().Be(product.CategoryId);
            var expected = ReadContext.Set<Sell>().Single();
            expected.CustomerName.Should().Be(dto.CustomerName);
            expected.Count.Should().Be(dto.Count);
            expected.Price.Should().Be(dto.Price);
           // expected.DateTime.Should().Be(new DateTime(2023, 8, 3));


            var expectedAccounting = ReadContext.Set<Accounting>().Single();
            //expectedAccounting.DocumentRegistrationDate.Should()
             //   .Be(new DateTime(2023, 8, 3));
            expectedAccounting.TotalPrice.Should()
                .Be(5000);

        }
    }
}
