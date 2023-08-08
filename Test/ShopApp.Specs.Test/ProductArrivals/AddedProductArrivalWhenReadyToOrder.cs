using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.ProductArrivals;
using ShopApp.TestTools.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.ProductArrivals
{

    [Scenario("ورود کالا")]

    public class AddedProductArrivalWhenReadyToOrder : BusinessIntegrationTest
    {
        private Category _category;
        private Product _product;

        [Given("یک گروه با نام بهداشتی در فهرست گروه ها وجود دارد")]
        [And("یک کالا با عنوان شامپو با موجودی ۰ و " +
            "وضعیت ناموجود و حداقل موجودی ۱۰ در گروه بهداشتی وجود دارد")]
        public void Given()
        {
            _category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(_category);
            _product = new ProductBuilder()
                .WithInventory(0)
                .WithMinimumInventory(10)
                .WithCategoryId(_category.Id)
                .WithTitle("شامپو")
                .WithStatusType(StatusType.unAvailable)
                .Build();

            DbContext.Save(_product);
        }

        [When("تعداد 10 تااز کالایی با عنوان شامپو با شماره فاکتور ۱۲۳a " +
            "در نام شرکت فپکو  در گروه بهداشتی را وارد میکنم ")]
        public void When()
        {


            var dto = new AddedProductArrivalDtoBuilder()
                 .WithProductId(_product.Id)
                 .WithNumberOfInvoice("123a")
                 .WithCount(10)
                 .WithNameCompany("فپکو")
                 .WithDateTime(new DateTime(2023, 8, 3))
                 .Build();
            var sut = ProductArrivalServicesFactories.Create(SetupContext);
            sut.Add(dto);

        }

        [Then("یک کالا با عنوان شامپو و حداقل موجودی ۱۰ و وضعیت اماده ی " +
            "سفارش در گروه بهداشتی " +
            "  و موجودی10 باید در فهرست کالاها وجود داشته باشد")]

        [And("یک " +
            "ورودی کالا برای کالای شامپو در تاریخ 1402 / 09 / 19 21:59 " +
            " و تعداد ۲۰ و شماره فاکتور ۱۲۳a" +
            " و نام شرکت فپکو باید در فهرست ورودی های" +
            " کالا وجود داشته باشد")]
        public void Then()
        {
            var expectProduct = ReadContext.Set<Product>().Single();
            expectProduct.Inventory.Should().Be(10);
            expectProduct.Title.Should().Be("شامپو");            
            expectProduct.statusType.Should().Be(StatusType.ReadyToOrder);
            expectProduct.CategoryId.Should().Be(_product.CategoryId);
            expectProduct.MinimumInventory.Should().Be(10);

            var expect = ReadContext.Set<ProductArrival>().Single();
            expect.NameCompany.Should().Be("فپکو");
            expect.NumberOfInvoice.Should().Be("123a");
            expect.Count.Should().Be(10);
            expect.ProductId.Should().Be(_product.Id);
            expect.DateTime.Should().Be(new DateTime(2023, 8, 3));

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
