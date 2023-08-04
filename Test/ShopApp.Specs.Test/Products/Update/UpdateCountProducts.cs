using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.Products.Update
{
    [Scenario("ویرایش یک محصول ")]
    public class UpdateCountProducts: BusinessIntegrationTest
    {
        private Category _category;
        private Product _product;
        private UpdateProductDto _dto;

        [Given("در فهرست دسته بندی های بهداشتی " +
            "یک محصول با نام شامپو و موجودی 20 و حداقل موجودی 10 وجود دارد")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
            _product = new Product()
            {
                CategoryId = _category.Id,
                Title = "شامپو",
                Inventory = 20,
                MinimumInventory=10
            };

            DbContext.Save(_product);

        }

        [When(" مقدار موجودی را از 20 به 30 تغییر میدهیم")]
        public void When()
        {

            _dto = new UpdateProductDto()
            {
                Inventory = 30
            };

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Update(_product.Id, _dto);

        }

        [Then("در لیست محصولات یک محصول با نام شامپو و تعداد 30 وجودد دارد")]
        public void Then()
        {
            var expect = ReadContext.Set<Product>().Single();
            expect.Id.Should().Be(_product.Id);
            expect.Inventory.Should().Be(30);
            expect.Title.Should().Be("شامپو");
            expect.MinimumInventory.Should().Be(10);

        }

        [Fact]
        public void Run()
        {
            Runner.RunScenario(
                _ => Given(),
                _ => When(),
                _ => Then()
            );
        }
    }
}
