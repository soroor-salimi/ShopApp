using ShopApp.Entities;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tempelte.Specs.Tests;
using Xunit;

namespace OnlineShop.Specs.Tests.Products.Delete
{
    [Scenario("حذف دسته بندی")]
    public class DeleteProduct : BusinessIntegrationTest
    {
        private Category _category;

        [Given("در فهرست دسته بندی ها یک دسته بندی با نام بهداشتی وجود دارد")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
           
        }

        [When("دسته بندی بهداشتی را حذف میکنم")]
        public void When()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);
            sut.DeleteCategory(_category.Id);
        }

        [Then("فهرست دسته بندی باید خالی باشد")]
        public void Then()
        {
            var expected = ReadContext.Set<Category>().Any();

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
