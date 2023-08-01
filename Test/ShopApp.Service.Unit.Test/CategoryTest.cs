using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

        [Fact]
        public void update_update_name_category_properly()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);

            var dto = UpdateCategoryNameDtoFactory.Generate("آرایشی_بهداشتی");
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);

            sut.UpdateNameCategory(category.Id, dto);

            var expected = ReadContext.Set<Category>().Single();
            expected.Id.Should().Be(category.Id);
            expected.Name.Should().Be(dto.Name);

        }
        [Fact]
        public void update_invalidId_category_properly()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);

            var dto = UpdateCategoryNameDtoFactory.Generate("آرایشی_بهداشتی");
            var invalidid = -1;

            var expected = () => sut.UpdateNameCategory(invalidid, dto);
            expected.Should().ThrowExactly<IdIsNotFoundException>();
        }
        //[Fact]
        //public void update_update_name_with_diffrent_categoryId_properly()
        //{
        //    var sut = CategoryServicesFactories.Create(SetupContext);
        //    var category = CategoryFactory.Generate("بهداشتی");
        //    DbContext.Save(category);
        //    var category1 = CategoryFactory.Generate("آرایشی _بهداشتی");
        //    DbContext.Save(category1);

        //    var dto = UpdateCategoryNameDtoFactory.Generate("آرایشی_بهداشتی");

        //    var expected = () => CategoryServicesFactories
        //    .Create(SetupContext).UpdateNameCategory(category.Id,dto);

        //    expected.Should().ThrowExactly<CategoryNameIsExistException>();

        //}
        [Fact]
        public void Delete_deleted_product_properly()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
       
            var sut = CategoryServicesFactories.Create(SetupContext);

            sut.DeleteCategory(category.Id);

            var expected = ReadContext.Set<Product>().Any();
        }
        [Fact]
        public void Deleted_invalidId_category_properly()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);

            var invalidid = -1;

            var expected = () => sut.DeleteCategory(invalidid);
            expected.Should().ThrowExactly<IdIsNotFoundException>();
        }

    }
}
