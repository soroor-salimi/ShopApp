using FluentAssertions;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.Categores.Add
{
    [Scenario(" ثبت گروه با نام تکراری")]
    public class FailedWhenDublicateNameCategory : BusinessIntegrationTest
    {
        private Action _expected;

        [Given("یک گروه با نام بهداشتی در فهرست گروه وجود دارد")]
        public void Given()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
        }

        [When(" یک گروه با نام بهداشتی را ثبت میکنم")]
        public void When()
        {
            var dto = CategoryDtoFactory.Generate("بهداشتی");

            _expected = () => CategoryServicesFactories
            .Create(SetupContext).Add(dto);

        }

        [Then("خطایی با عنوان 'اسم گروه تکراری' باید رخ دهد")]
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
