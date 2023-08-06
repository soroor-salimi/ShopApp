using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.Categores.Delete
{
    [Scenario("حذف گروه وقتی که برای گروه کالا وجود دارد")]
    public class FailedDeleteCategoryWheneContainsTheProducts: BusinessIntegrationTest
    {
        private Category _category;
        private Product _product;
        private Action _expected;

        [Given("در فهرست گروه ها یک گروه به نام بهداشتی وجود دارد")]
        [And("یک کالا با عنوان شامپو در گروه بهداشتی ثبت شده است")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
            _product=new ProductBuilder()
                .WithTitle("شامپو")
                .WithCategoryId(_category.Id)
                .Build();
            DbContext.Save(_product);
        }

        [When("گروه بهداشتی را حذف میکنم ")]
        public void When()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);
            _expected=() => sut.DeleteCategory(_category.Id);

        }

        [Then("خطایی با عنوان 'گروه دارای کالا است' باید رخ دهد")]
        public void Then()
        {
            _expected.Should().ThrowExactly<CategoryHasProductException>();

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
