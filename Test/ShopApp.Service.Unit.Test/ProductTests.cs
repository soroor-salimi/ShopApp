using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.Services.Products.Exceptions;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Unit.Test
{
    public class ProductTests : BusinessUnitTest
    {
        [Fact]
        public void Add_added_Prooduct_properly()
        {
            var category = CategoryFactory.Generate("dummy ");
            DbContext.Save(category);
            var category1 = CategoryFactory.Generate("dummy1");
            DbContext.Save(category1);
            var propduct = new Product()
            {
                Title = "dummy_title ",
                CategoryId = category1.Id,

            };
            DbContext.Save(propduct);

            var dto = new AddProductDtoBuilder()
               .WithTitle("dummy_title")
               .WithCategoryId(category.Id)
               .WithMinimumInventory(10)
               .WithInventory(0)
               .Build();

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Add(dto);

            var expected = ReadContext.Set<Product>()
                .First(_ => _.CategoryId == dto.CategoryId);
            expected.Title.Should().Be(dto.Title);
            expected.Inventory.Should().Be(dto.Inventory);
            expected.statusType.Should().Be(StatusType.unAvailable);
            expected.MinimumInventory.Should().Be(dto.MinimumInventory);

        }
        [Fact]
        public void Add_added_a_product_invalid_categoryId_peroprly()
        {

            var category = CategoryFactory.Generate();
            DbContext.Save(category);

            var invalidId = -1;

            var dto = new AddProductDtoBuilder()
             .WithTitle("dummy_title")
                .WithCategoryId(invalidId)
                .Build();

            var result = () => ProductServicesFactories.Create(SetupContext)
            .Add(dto);

            result.Should().ThrowExactly<CategoryIdIsNotFoundException>();
        }
        [Fact]
        public void Failed_Add_dublicate_product_Name()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new Product()
            {
                Title = "dummy_title",
                CategoryId = category.Id,
            };
            DbContext.Save(product);

            var dto = new AddProductDtoBuilder()
                .WithTitle("dummy_title")
                .WithCategoryId(category.Id)
                .WithMinimumInventory(10)
                .Build();

            var expected = () => ProductServicesFactories
            .Create(SetupContext).Add(dto);

            expected.Should().ThrowExactly<TheTitleOfTheProductIsDublicatedEception>();
        }
        [Fact]
        public void Delete_deleted_product_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithInventory(0)
                .WithCategoryId(category.Id)
                .WithTitle("dummy_title")
                .WithMinimumInventory(10)
                .Build();

            DbContext.Save(product);

            var sut = ProductServicesFactories.Create(SetupContext);

            sut.DeleteProduct(product.Id);

            var expected = ReadContext.Set<Product>().Any();
        }
        [Fact]
        public void Deleted_invalidId_product_properly()
        {
            var sut = ProductServicesFactories.Create(SetupContext);

            var invalidId = -1;

            var expected = () => sut.DeleteProduct(invalidId);
            expected.Should().ThrowExactly<ProductIsNotFoundException>();
        }
        [Fact]
        public void Update_update_inventory_when_avalable_product_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithCategoryId(category.Id)
                .WithInventory(5)
                .WithMinimumInventory(10)
                .WithStatusType(StatusType.ReadyToOrder)
                .Build();
            DbContext.Save(product);


            var dto = new UpdateProductDto()
            {
                Inventory=20
            };

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Update(product.Id, dto);

            var expect = ReadContext.Set<Product>().Single();
            expect.Id.Should().Be(product.Id);
            expect.Inventory.Should().Be(product.Inventory+dto.Inventory);
            expect.Title.Should().Be(product.Title);
            expect.MinimumInventory.Should().Be(product.MinimumInventory);
            expect.statusType.Should().Be(StatusType.Available);
        }
        [Fact]
        public void Update_update_inventory_when_inventory_equal_mininventory_product_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithCategoryId(category.Id)
                .WithInventory(5)
                .WithMinimumInventory(10)
                .WithStatusType(StatusType.ReadyToOrder)
                .Build();
            DbContext.Save(product);


            var dto = new UpdateProductDto()
            {
                Inventory = 5
            };

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Update(product.Id, dto);

            var expect = ReadContext.Set<Product>().Single();
            expect.Id.Should().Be(product.Id);
            expect.Inventory.Should().Be(product.Inventory + dto.Inventory);
            expect.Title.Should().Be(product.Title);
            expect.MinimumInventory.Should().Be(product.MinimumInventory);
            expect.statusType.Should().Be(StatusType.ReadyToOrder);
        }
        [Fact]
        public void
      Update_update_inventory_when_inventory_smaller_than_minInventory_product_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithCategoryId(category.Id)
                .WithInventory(5)
                .WithMinimumInventory(10)
                .WithStatusType(StatusType.ReadyToOrder)
                .Build();
            DbContext.Save(product);


            var dto = new UpdateProductDto()
            {
                Inventory = 2
            };

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Update(product.Id, dto);

            var expect = ReadContext.Set<Product>().Single();
            expect.Id.Should().Be(product.Id);
            expect.Inventory.Should().Be(product.Inventory + dto.Inventory);
            expect.Title.Should().Be(product.Title);
            expect.MinimumInventory.Should().Be(product.MinimumInventory);
            expect.statusType.Should().Be(StatusType.ReadyToOrder);
        }

        public void get_get_all_inventory_product_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithInventory(0)
                .WithMinimumInventory(10)
                .WithCategoryId(category.Id)
                .WithTitle("dummy_title")
                .WithStatusType(StatusType.unAvailable)
                .Build();
            DbContext.Save(product);

            var product1 = new ProductBuilder()
                .WithInventory(5)
                .WithMinimumInventory(10)
                .WithCategoryId(category.Id)
                .WithTitle("dummy_pro")
                .WithStatusType(StatusType.ReadyToOrder)
                .Build();
            DbContext.Save(product1);

            var sut = ProductServicesFactories.Create(SetupContext);
            //var result = sut.GetAll();

        }
    }

}
