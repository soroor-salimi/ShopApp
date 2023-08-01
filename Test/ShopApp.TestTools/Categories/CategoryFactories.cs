using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.TestTools.Categories
{
    public static class CategoryFactory
    {
        public static Category Generate(string name = "بهداشتی")
        {
            return new Category()
            {
                Name = name,
            };
        }
    }
}
