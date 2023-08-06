using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts.Dto;
using ShopApp.Specs.Test;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopApp.Specs.Test.Categores.Add
{
    [Scenario(" ثبت گروه ")]
    public class AddCatgory : BusinessIntegrationTest
    {
        [Given("فهرست گروه خالی است ")]
        public void Given()
        {

        }

        [When(" یک گروه با نام بهداشتی را ثبت میکنم ")]
        public void When()
        {
            var dto = CategoryDtoFactory.Generate("بهداشتی");
            var sut = CategoryServicesFactories.Create(SetupContext);
            sut.Add(dto);


        }

        [Then("در فهرست گروه ها یک گروه با نام بهداشتی باید وجود داشته باشد")]
        public void Then()
        {
            var expect = ReadContext.Set<Category>().Single();
            expect.Name.Should().Be("بهداشتی");

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
