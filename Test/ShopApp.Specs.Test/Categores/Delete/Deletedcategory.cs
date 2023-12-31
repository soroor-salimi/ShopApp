﻿using ShopApp.Entities;
using ShopApp.Specs.Test;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ShopApp.Specs.Test.Categores.Delete
{
    [Scenario("حذف گروه")]
    public class DeleteProduct : BusinessIntegrationTest
    {
        private Category _category;

        [Given("در فهرست گروه ها یک گروه به نام بهداشتی وجود دارد")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);

        }

        [When(" گروه بهداشتی را حذف میکنم")]
        public void When()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);
            sut.DeleteCategory(_category.Id);
        }

        [Then("فهرست گروه باید خالی باشد")]
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
