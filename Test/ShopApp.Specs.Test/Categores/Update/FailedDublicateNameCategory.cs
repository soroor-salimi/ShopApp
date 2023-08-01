using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Tempelte.Specs.Tests;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.Entities;
using ShopApp.TestTools.Categories;

namespace OnlineShop.Specs.Tests.Categories.Add
{
    [Scenario("رخ دادن خطا هنگام ویرایش دسته بندی تکراری")]
    public class DublicateNameCategory : BusinessIntegrationTest
    {
        private Action _expected;
        private Category _category;
        private Category _category1;

        [Given("در فهرست دسته بندی ها یک دسته بندی با نام بهداشتی وجود دارد ")]
        [And("و یک دستع بندی با نام آرایشی_بهداشتی وجود دارد")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
            _category1 = CategoryFactory.Generate("آرایشی_بهداشتی");
            DbContext.Save(_category1);
        }

        [When(" میخواهم دسته بندی آرایشی_بهداشتی را با نام بهداشتی تغییر دهم")]
        public void When()
        {
            var dto = UpdateCategoryNameDtoFactory.Generate("بهداشتی");

            _expected = () => CategoryServicesFactories.Create(SetupContext)
            .UpdateNameCategory(_category1.Id,dto);

        }

        [Then("باید خطایی با عنوان نام دسته بندی تکراری است رخ بنماید")]
        public void Then()
        {
            _expected.Should().ThrowExactly<CategoryNameIsExistException>();

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
