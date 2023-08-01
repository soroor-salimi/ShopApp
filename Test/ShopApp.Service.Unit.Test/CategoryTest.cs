using FluentAssertions;
using OnlineShop.TestTools.Categories;
using ShopApp.Entities;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CMS.Service.Unit.Test
{
    public class CategoryTest : BusinessUnitTest
    {
        [Fact]
        public void Add_added_category_properly()
        {
            var dto = CategoryDtoFactory.Generate("بهداشتی");
            var sut = CategoryServicesFactories.Create(SetupContext);

            sut.Add(dto);

            var expect = ReadContext.Set<Category>().Single();
            expect.Name.Should().Be(dto.Name);

        }
        [Fact]
        public void Add_dublicate_Name_()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);

            var dto = CategoryDtoFactory.Generate("بهداشتی");

            var expected = () => CategoryServicesFactories
            .Create(SetupContext).Add(dto);

            expected.Should().ThrowExactly<CategoryNameIsExistException>();
        }
        [Fact]
        public void Get_get_all_name_category_properly()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);

            var result = CategoryServicesFactories.Create(SetupContext).GetAll();

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(category.Id);
            result.First().Name.Should().Be(category.Name);

        }
        //[Fact]
        //public void Update_update_name_category_properly()
        //{
        //    var sut = CategoryServicesFactories.Create(SetupContext);

        //    var dto = UpdateCategoryNameFactory.Generate("آرایشی_بهداشتی");
        //    var category = CategoryFactory.Generate("بهداشتی");
        //    DbContext.Save(category);


        //    sut.UpdateName(category.Id, dto);

        //    var expected = ReadContext.Set<Category>().Single();
        //    expected.Id.Should().Be(category.Id);
        //    expected.Name.Should().Be(dto.Name);


        //}
        //[Fact]
        //public void Update_invalidId_category_properly()
        //{
        //    var sut = CategoryServicesFactories.Create(SetupContext);

        //    var dto = UpdateCategoryNameFactory.Generate("آرایشی_بهداشتی");
        //    var invalidId = -1;

        //    var expected = () => sut.UpdateName(invalidId, dto);
        //    expected.Should().ThrowExactly<IdIsNotFoundException>();
        //}

    }
}
