using ShopApp.Entities;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.Products.Delete
{
    [Scenario("حذف کالا از دسته بندی")]
    public class DeletedProductFromCategory: BusinessIntegrationTest
    {
        private Product _product;
        [Given("در فهرست دسته بندی ها یک دسته بندی با نام بهداشتی وجود دارد")]
        [And("و یک محصول با نام شامپو وجود دارد")]
        public void Given()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            _product = new Product()
            {
                Title= "شامپو",
                CategoryId=category.Id,
            };
            DbContext.Save(_product);

        }

        [When("شامپو را حذف میکنم")]
        public void When()
        {
            var sut = ProductServicesFactories.Create(SetupContext);
            sut.DeleteProduct(_product.Id);
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
