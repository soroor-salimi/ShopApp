using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts.Dto;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.Services.Sells.Contracts.Dto;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Integration;
using ShopApp.TestTools.Products;
using ShopApp.TestTools.Sells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Specs.Test.Sells.Add
{
    [Scenario("فروش کالا")]
    public class AddedSellWhenStatusTypeAvalable : BusinessIntegrationTest
    {
        private Category _category;
        private Product _product;
        private AddedSellWithAccountigDto _dtoAccounting;

        [Given("گروهی با نام لوازم یدکی در فهرست گروه ها وجود دارد")]
        [And("کالایی با عنوان لنت ترمز با موجودی ۲۰  " +
            "و وضعیت موجود و حداقل موجودی ۵ در گروه لوازم یدکی وجود دارد ")]
        public void Given()
        {
            _category = CategoryFactory.Generate("لوازم یدکی");
            DbContext.Save(_category);

            _product = new ProductBuilder()
                .WithInventory(20)
                .WithMinimumInventory(5)
                .WithCategoryId(_category.Id)
                .WithTitle("لنت ترمز")
                .WithStatusType(StatusType.Available)
                .Build();

            DbContext.Save(_product);
        }

        [When("کالای با عنوان لنت ترمز و" +
            " قیمت واحد ۱۰۰۰ تومان برای مشتری به" +
            " نام مجید رضوی به تعداد ۵ عدد را ثبت میکنم")]
        public void When()
        {

            var dto = new AddedSellWithAccountigDto()
            {
                Count = 5,
                CustomerName = "مجید رضوی",
                Price = 1000,
                ProductId = _product.Id,
                NumberOfinvoiceSell = "123a"
            };
            dto.AccountinginSell = new AddedAccountingForSellDto()
            {
                
                DocumentRegistrationDate = (new DateTime(2023, 8, 3)),
                NumberOfDocument = 1233455657,
                NumberOfinvoiceSell = "123a",
                TotalPrice = dto.Price * dto.Count,
            };

            var sut = SellServicesFactories.Create(SetupContext);
            sut.AddWithAccounting(dto);

        }

        [Then("کالا با عنوان لنت ترمز با موجودی ۱۵ " +
            "و وضعیت موجود و حداقل موجودی ۵ در گروه لوازم یدکی وجود داشته باشد")]

        [And("یک فاکتور فروش " +
            " و تعداد ۵ و قیمت ۱۰۰۰ و شماره فاکتور ۱۲۳a و مشتری با نام مجید رضوی و " +
            "تاریخ 1402 در فاکتورهای فروش باید وجود داشته باشد")]

        [And("و یک سند حسابداری با شماره فاکتور ۱۲۳a و شماره سند 1233455657 " +
            "و تاریخ 1402 و " +
            "مبلغ ۵۰۰۰ باید در فهرست سندهای حسابداری ثبت شده باشد")]
        public void Then()
        {
            var expectedProduct = ReadContext.Set<Product>().Single();
            expectedProduct.Title.Should().Be("لنت ترمز");
            expectedProduct.Inventory.Should().Be(15);
            expectedProduct.statusType.Should().Be(StatusType.Available);
            expectedProduct.MinimumInventory.Should().Be(5);
            expectedProduct.CategoryId.Should().Be(_product.CategoryId);

            var expected = ReadContext.Set<Sell>().Single();
            expected.Product.Id.Should().Be(_product.Id);
            expected.CustomerName.Should().Be("مجید رضوی");
            expected.NumberOfinvoiceSell.Should().Be("123a");
            expected.Count.Should().Be(5);
            expected.Price.Should().Be(1000);
            expected.DateTime.Should().Be(new DateTime(2023, 8, 3));


            var expectedAccounting = ReadContext.Set<Accounting>().Single();
            expectedAccounting.NumberOfinvoiceSell.Should().Be("123a");
            expectedAccounting.NumberOfDocument.Should().Be(1233455657);
            expectedAccounting.DocumentRegistrationDate.Should().Be(new DateTime(2023, 8, 3));
            expectedAccounting.TotalPrice.Should().Be(5000);

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
