﻿using FluentAssertions;
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
            var category = CategoryFactory.Generate("اسباب بازی");
            DbContext.Save(category);
            var category1 = CategoryFactory.Generate("لبنیات");
            DbContext.Save(category1);
            var propduct = new Product()
            {
                Title = "شیر ",
                CategoryId= category1.Id,

            };
            DbContext.Save(propduct);

            var dto = new AddProductDtoBuilder()
               .WithTitle("شیر")
               .WithCategoryId(category.Id)
               .WithMinimumInventory(10)
               .WithInventory(0)
               .Build();

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Add(dto);

            var expected = ReadContext.Set<Product>()
                .First(_=>_.CategoryId==dto.CategoryId);
            expected.CategoryId.Should().Be(category.Id);
            expected.Title.Should().Be(dto.Title);
            expected.Inventory.Should().Be(dto.Inventory);
            expected.MinimumInventory.Should().Be(dto.MinimumInventory);

        }

        [Fact]
        public void Add_added_a_product_invalid_categoryId_peroprly()
        {

            var category = CategoryFactory.Generate();
            DbContext.Save(category);

            var invalidId = -1;

            var dto = new AddProductDtoBuilder()
             .WithTitle("شامپو")
                .WithCategoryId(invalidId)
                .Build();

            var result = () => ProductServicesFactories.Create(SetupContext)
            .Add(dto);

            result.Should().ThrowExactly<CategoryIdIsNotFoundException>();
        }
        [Fact]
        public void Add_dublicate_Name_()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            var product = new Product()
            {
                Title = "شامپو",
                CategoryId=category.Id,
            };
            DbContext.Save(product);

            var dto = new AddProductDtoBuilder()
                .WithTitle("شامپو")
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
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            var product = new Product()
            {
                CategoryId = category.Id,
                Title="شامپو",
                Inventory=0,
                MinimumInventory=10,
            };
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

    }
    
}