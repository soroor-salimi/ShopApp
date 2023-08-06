using FluentAssertions;
using ShopApp.Entities;
using ShopApp.Services.Categories.Exceptions;
using ShopApp.TestTools.Categories;
using ShopApp.TestTools.infrastructure.DataBaseConfig;
using ShopApp.TestTools.infrastructure.DataBaseConfig.Unit;
using ShopApp.TestTools.Products;
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
            var dto = CategoryDtoFactory.Generate("dummy");
            var sut = CategoryServicesFactories.Create(SetupContext);

            sut.Add(dto);

            var expect = ReadContext.Set<Category>().Single();
            expect.Name.Should().Be(dto.Name);

        }
        [Fact]
        public void Failed_Add_dublicate_Name_category()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);

            var dto = CategoryDtoFactory.Generate("dummy");

            var expected = () => CategoryServicesFactories
            .Create(SetupContext).Add(dto);

            expected.Should().ThrowExactly<CategoryNameIsExistException>();
        }
        [Fact]
        public void Get_get_all_name_category_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var sut = CategoryServicesFactories.Create(SetupContext);
            var result =sut.GetAll();

            result.Should().HaveCount(1);
            result.First().Id.Should().Be(category.Id);
            result.First().Name.Should().Be(category.Name);

        }
        [Fact]
        public void update_update_name_category_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);

            var sut = CategoryServicesFactories.Create(SetupContext);
            var dto = UpdateCategoryNameDtoFactory.Generate("dummy_U");
           

            sut.UpdateNameCategory(category.Id, dto);

            var expected = ReadContext.Set<Category>().Single();
            expected.Id.Should().Be(category.Id);
            expected.Name.Should().Be(dto.Name);

        }
        [Fact]
        public void Failed_update_invalidId_category_properly()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);

            var dto = UpdateCategoryNameDtoFactory.Generate("dummy");
            var invalidid = -1;

            var expected = () => sut.UpdateNameCategory(invalidid, dto);
            expected.Should().ThrowExactly<IdIsNotFoundException>();
        }
        [Fact]
        public void Failed_to_edit_a_dublicate_name_in_a_category()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var category1 = CategoryFactory.Generate("dummy1");
            DbContext.Save(category1);

            var dto = UpdateCategoryNameDtoFactory.Generate("dummy");

            var sut = CategoryServicesFactories.Create(SetupContext);
            var expected = () => sut.UpdateNameCategory(category1.Id, dto);

            expected.Should().ThrowExactly<CategoryNameIsExistException>();

        }    
        [Fact]
        public void Delete_deleted_category_properly()   
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);

            var sut = CategoryServicesFactories.Create(SetupContext);

            sut.DeleteCategory(category.Id);

            var expected = ReadContext.Set<Category>().Any();
        }
        [Fact]
        public void Failed_Deleted_invalidId_category()
        {
            var sut = CategoryServicesFactories.Create(SetupContext);

            var invalidid = -1;

            var expected = () => sut.DeleteCategory(invalidid);
            expected.Should().ThrowExactly<IdIsNotFoundException>();
        }
        [Fact]
        public void Get_get_all_product_with_one_category_properly()
        {
            var category = CategoryFactory.Generate("dummy");
            DbContext.Save(category);
            var product = new Product()
            {
                Title = "dummy_title",
                Inventory = 0,
                MinimumInventory = 10,
                CategoryId = category.Id,
            };
            DbContext.Save(product);


            var sut = CategoryServicesFactories.Create(SetupContext);
            var result = sut.GetAllproductWithcategoryId(category.Id);

            
            result.Name.Should().Be(category.Name);
            result.ProductDetails.Should().HaveCount(1);
            var testProduct = result.ProductDetails.ElementAt(0);
            testProduct.Title.Should().Be(product.Title);
            testProduct.Inventory.Should().Be(product.Inventory);
            testProduct.MinimumInventory.Should().Be(product.MinimumInventory);

        }
        [Fact]
        public void Failed_delete_the_category_contains_the_product()
        {
            var category = CategoryFactory.Generate("dummy_category");
            DbContext.Save(category);
            var product = new ProductBuilder()
                .WithTitle("dummy_product")
                .WithCategoryId(category.Id)
                .Build();
            DbContext.Save(product);

            var sut = CategoryServicesFactories.Create(SetupContext);
            var expected = () => sut.DeleteCategory(category.Id);

            expected.Should().ThrowExactly<CategoryHasProductException>();
        }
    }
}
