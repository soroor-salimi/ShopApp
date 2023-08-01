using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Categories.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Categories
{
    public class EFCategoryRepository: CategoryRepository
    {
        private DbSet<Category> _categories;
        public EFCategoryRepository(EFDataContext context)
        {
            _categories = context.Set<Category>();
        }
        public void Add(Category category)
        {
            _categories.Add(category);
        }
        public bool DublicateName(string name)
        {
            return _categories.Any(_ => _.Name == name);
        }
        public Category? FindById(int id)
        {
            return _categories.Find(id);
        }

        public List<GetAllCategoryDto> GetAll()
        {
            var result = _categories.Select(_ => new GetAllCategoryDto()
            {
               Name=_.Name,
               Id=_.Id
            });

            return result.ToList();
        }
    }
}
