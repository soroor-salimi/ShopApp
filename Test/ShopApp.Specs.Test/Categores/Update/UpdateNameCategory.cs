using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts.Dto;
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

namespace OnlineShop.Specs.Tests.Categories.Update
{
    [Scenario("ویرایش یک دسته بندی ")]
    public class UpdateCategoryName : BusinessIntegrationTest
    {
        private Category _category;
        private UpdateCategoryNameDto _dto;


        [Given("در فهرست دسته بندی ها" +
            " یک دسته بندی با نام بهداشتی وجود دارد ")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
        }

        [When(" دسته بندی بهداشتی را به آرایشی_بهداشتی تغییر میدهم")]
        public void When()
        {

            _dto = UpdateCategoryNameDtoFactory.Generate("آرایشی_بهداشتی");

            var sut = CategoryServicesFactories.Create(SetupContext);
            sut.UpdateNameCategory(_category.Id, _dto);

        }

        [Then("در فهرست دسته بندی ها" +
            " باید یک دسته بندی با نام آرایشی بهداشتی وجود داشته باشد.")]
        public void Then()
        {
            var expect = ReadContext.Set<Category>().Single();
            expect.Id.Should().Be(_category.Id);
            expect.Name.Should().Be("آرایشی_بهداشتی");

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
