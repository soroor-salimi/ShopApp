using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Categories.Contracts
{
    public interface CategoryRepository
    {
        void Add(Category category);
        bool DublicateName(string name);
        List<GetAllCategoryDto> GetAll();
        Category? FindById(int id);

    }
}
