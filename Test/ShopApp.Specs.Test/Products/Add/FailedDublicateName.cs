

using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.Services.Products.Exceptions;
using ShopApp.Specs.Test;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;

namespace ShopApp.Specs.Test.Products.Add
{
    public class DublicateNameProductInthisCategory
    {
        [Scenario("تعریف کالا با عنوان تکراری در یک گروه")]
        public class DublicateNameCategory : BusinessIntegrationTest
        {
            private Action _expected;
            private Category _category;

            [Given("یک گروه با عنوان بهداشتی در فهرست گروه ها وجود دارد")]

            [And("یک کالا با نام شامپو در گروه بهداشتی وجود دارد")]
            public void Given()
            {
                _category = CategoryFactory.Generate("بهداشتی");
                DbContext.Save(_category);

                var product = new Product()
                {
                    Title = "شامپو",
                    CategoryId = _category.Id
                };
                DbContext.Save(product);
            }

            [When("یک کالا با عنوان شامپو و " +
                "گروه بهداشتی و حداقل موجودی ۱۰ را ثبت میکنم ")]
            public void When()
            {
                var dto = new AddProductDtoBuilder()
                .WithTitle("شامپو")
                .WithCategoryId(_category.Id)
                .WithMinimumInventory(10)
                .Build();

                _expected = () => ProductServicesFactories.Create(SetupContext)
                .Add(dto);

            }

            [Then("خطایی با عنوان 'عنوان کالا تکراری است' باید رخ دهد")]
            public void Then()
            {
                _expected.Should()
                    .ThrowExactly<TheTitleOfTheProductIsDublicatedEception>();

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
}
