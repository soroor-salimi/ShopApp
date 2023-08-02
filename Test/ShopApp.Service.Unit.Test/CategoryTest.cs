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

namespace ShopApp.Service.Unit.Test
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
            var sut = CategoryServicesFactories.Create(SetupContext);
            var result =sut.GetAll();

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(category.Id);
            result.First().Name.Should().Be(category.Name);

        }

        //[Fact]
        //public void Get_get_all_product_with_one_category_properly()
        //{
        //    var category = CategoryFactory.Generate("بهداشتی");
        //    DbContext.Save(category);
        //    var product = new Product()
        //    {
        //        Title = "شامپو",
        //        Inventory=0,
        //        MinimumInventory=10,
        //        CategoryId = category.Id,
        //    };
        //    DbContext.Save(product);


        //    var sut= CategoryServicesFactories.Create(SetupContext);
        //    var result =sut.GetAllproductWithcategoryId(category.Id);

        //   result.Should().;
           
        //}
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
        [Fact]
        public void update_failed_to_Edit_category_name_with_one_categoryId_properly()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);
            var category1 = CategoryFactory.Generate("آرایشی _بهداشتی");
            DbContext.Save(category1);

            var dto = UpdateCategoryNameDtoFactory.Generate("بهداشتی");

            var sut = CategoryServicesFactories.Create(SetupContext);
            var expected = () => sut.UpdateNameCategory(category1.Id, dto);

            expected.Should().ThrowExactly<CategoryNameIsExistException>();

        }
        [Fact]
        public void Delete_deleted_category_properly()
        {
            var category = CategoryFactory.Generate("بهداشتی");
            DbContext.Save(category);

            var sut = CategoryServicesFactories.Create(SetupContext);

            sut.DeleteCategory(category.Id);

            var expected = ReadContext.Set<Category>().Any();
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
