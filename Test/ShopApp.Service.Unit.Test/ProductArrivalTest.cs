using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.ProductArrivals.Exceptions;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using ShopApp.TestTools.ProductArrivals;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Unit.Test
{
    public class ProductArrivalTest : BusinessUnitTest
    {
        [Theory]
        [InlineData(StatusType.Available)]
        [InlineData(StatusType.ReadyToOrder)]
        [InlineData(StatusType.unAvailable)]
        public void Added_add_productArrical_peroperly(StatusType type)
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            var product = new ProductBuilder()
               .WithInventory(0)
               .WithMinimumInventory(10)
               .WithCategoryId(category.Id)
               .WithTitle("شامپو")
               .WithStatusType(type)
               .Build();
            DbContext.Save(product);

            var dto = new AddedProductArrivalDtoBuilder()
                .WithProductId(product.Id)
                .WithNumberOfInvoice("123a")
                .WithCount(20)
                .WithNameCompany("فپکو")
                .WithDateTime(new DateTime(2023,7,3))
                .Build();
           

            var sut = ProductArrivalServicesFactories.Create(SetupContext);
            sut.Add(dto);

            var productDto = new UpdateProductDto()
            {
                Inventory = product.Inventory + dto.Count,
            };

            var productSut = ProductServicesFactories.Create(SetupContext);
            productSut.Update(dto.ProductId,productDto);

            var expect = ReadContext.Set<ProductArrival>().Single();
            expect.NameCompany.Should().Be(dto.NameCompany);
            expect.NumberOfInvoice.Should().Be(dto.NumberOfInvoice);
            expect.Count.Should().Be(dto.Count);
            expect.ProductId.Should().Be(product.Id);
            expect.DateTime.Should().Be(new DateTime(2023,7,3));

            var expectProduct = ReadContext.Set<Product>().Single();
            expectProduct.Inventory.Should().Be(productDto.Inventory);
            expectProduct.Title.Should().Be(product.Title);
            expectProduct.statusType.Should().Be(product.statusType);
            expectProduct.CategoryId.Should().Be(product.CategoryId);
            expectProduct.MinimumInventory.Should().Be(product.MinimumInventory);

        }

        [Fact]
        public void Failed_invalid_productId_in_ProductArrival_peroperly()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            var product = new ProductBuilder()
               .WithInventory(0)
               .WithMinimumInventory(10)
               .WithCategoryId(category.Id)
               .WithTitle("شامپو")
               .Build();
            DbContext.Save(product);
            var invalidId = -1;

            var dto = new AddedProductArrivalDtoBuilder()
           .WithProductId(invalidId)
           .WithNameCompany("فپکو")
           .Build();

            var result = () => ProductArrivalServicesFactories.Create(SetupContext)
           .Add(dto);

            result.Should().ThrowExactly<ProductIsNotFoundException>();
        }
    }
}
