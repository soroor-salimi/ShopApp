using ShopApp.Services.Categories.Contracts.Dto;
using ShopApp.Services.Products.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Categories.Contracts
{
    public interface CaregoryServices
    {
        void Add(AddedCategoryDto dto);
        List<GetAllCategoryDto> GetAll();
        void UpdateNameCategory(int id, UpdateCategoryNameDto dto);
        void DeleteCategory(int id);
        GetCategoryDto GetAllproductWithcategoryId(int id);
    }
}
