using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;

namespace ShopApp.TestTools.Products
{
    public class AddProductDtoBuilder
    {
        private AddProductDto _product;

        public AddProductDtoBuilder()
        {

            _product = new AddProductDto()
            {
                Title = "شیر",
                CategoryId = 0,
                Inventory = 0,
                MinimumInventory = 20,
                StatusType = StatusType.Available,
            };

        }
        public AddProductDtoBuilder WithCategoryId(int categoryId)
        {
            _product.CategoryId = categoryId;
            return this;
        }
        public AddProductDtoBuilder WithTitle(string title)
        {
            _product.Title = title;
            return this;
        }
        public AddProductDtoBuilder WithInventory(int inventory)
        {
            _product.Inventory = inventory;
            return this;
        }

        public AddProductDtoBuilder WithMinimumInventory(int minimumInventory)
        {
            _product.MinimumInventory = minimumInventory;
            return this;
        }
        public AddProductDtoBuilder WithStatusType(StatusType statusType)
        {
            _product.StatusType = statusType;
            return this;
        }
        public AddProductDto Build()
        {
            return _product;
        }

    }
}
