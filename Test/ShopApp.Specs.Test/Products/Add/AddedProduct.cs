using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.Specs.Test;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopApp.Specs.Test.Products.Add
{
    [Scenario("تعریف کالا ")]
    public class AddedProduct : BusinessIntegrationTest
    {

        private Category _category;
        private Category _category1;
        [Given("دو گروه با عنوان های  اسباب بازی " +
            "و لبنیات در فهرست گروه ها وجود دارد")]
        [And("یک کالا با نام شیر در فهرست کالا های لبنیات وجود دارد ")]

        public void Given()
        {
            _category = CategoryFactory.Generate("اسباب بازی");
            DbContext.Save(_category);

            _category1 = CategoryFactory.Generate("لبنیات");
            DbContext.Save(_category1);

            var propduct = new Product()
            {
                Title = "شیر ",
                CategoryId = _category1.Id

            };
        }

        [When("یک کالا با عنوان شیر در گروه " +
            "اسباب بازی  با حداقل موجودی ۱۰ را ثبت میکنم ")]
        public void When()
        {
            var dto = new AddProductDtoBuilder()
                .WithTitle("شیر")
                .WithCategoryId(_category.Id)
                .WithMinimumInventory(10)
                .WithInventory(0)
                .Build();

            var sut = ProductServicesFactories.Create(SetupContext);
            sut.Add(dto);
        }

        [Then("یک کالا با عنوان شیر " +
            "در گروه اسباب بازی و حداقل موجودی ۱۰ " +
            "و وضعیت ناموجود و موجودی ۰  باید فهرست کالا موجود باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Product>().First();
            expected.Title.Should().Be("شیر");
            expected.CategoryId.Should().Be(_category.Id);
            expected.MinimumInventory.Should().Be(10);
            expected.Inventory.Should().Be(0);

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
