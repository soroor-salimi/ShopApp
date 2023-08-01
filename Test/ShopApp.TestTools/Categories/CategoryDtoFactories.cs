
using ShopApp.Services.Categories.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Categories
{
    public static class CategoryDtoFactory
    {
        public static AddedCategoryDto Generate(string name = "بهداشتی")
        {
            return new AddedCategoryDto()
            {
                Name = name,
            };

        }
    }
}
