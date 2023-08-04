using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Products
{
    public class ProductBuilder
    {
        private Product _product;
        public ProductBuilder()
        {
            _product = new Product()
            {
                Title = "شیر",
                CategoryId = 0,
                Inventory = 0,
                MinimumInventory = 20,
                statusType=StatusType.ReadyToOrder,
            };
        }

        public ProductBuilder WithCategoryId(int categoryId)
        {
            _product.CategoryId = categoryId;
            return this;
        }
        public ProductBuilder WithTitle(string title)
        {
            _product.Title = title;
            return this;
        }
        public ProductBuilder WithInventory(int inventory)
        {
            _product.Inventory = inventory;
            return this;
        }

        public ProductBuilder WithMinimumInventory(int minimumInventory)
        {
            _product.MinimumInventory = minimumInventory;
            return this;
        } 
        public ProductBuilder WithStatusType(StatusType statusType)
        {
            _product.statusType = statusType;
            return this;
        }

        public Product Build()
        {
            return _product;
        }
    }
}
