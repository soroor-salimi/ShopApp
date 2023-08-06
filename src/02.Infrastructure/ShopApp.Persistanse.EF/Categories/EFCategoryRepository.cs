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
    public class EFCategoryRepository : CategoryRepository
    {
        private DbSet<Category> _categories;
        private DbSet<Product> _products;
        public EFCategoryRepository(EFDataContext context)
        {
            _categories = context.Set<Category>();
            _products = context.Set<Product>();
        }
        public void Add(Category category)
        {
            _categories.Add(category);
        }
        public List<GetAllCategoryDto> GetAll()
        {
            var result = _categories.Select(_ => new GetAllCategoryDto()
            {
                Id = _.Id,
                Name = _.Name
            });

            return result.ToList();
        }
        public void UpdateName(Category category)
        {
            _categories.Update(category);
        }
        public void DeletedCategory(Category category)
        {
            _categories.Remove(category);
        }
        public GetCategoryDto? GetCategoryWithProduct(int id)
        {
            var result = _categories.Where(_ => _.Id == id)
                .Select(_ => new GetCategoryDto()
                {
                    Id = _.Id,
                    Name = _.Name,
                    ProductDetails = _.Products.Select(p => new productDetaile()
                    {
                        productId = p.Id,
                        Title = p.Title,
                        Inventory = p.Inventory,
                        MinimumInventory = p.MinimumInventory
                    }).ToList(),

                });

            return result.FirstOrDefault();
        }
        public bool DublicateName(string name)
        {
            return _categories.Any(_ => _.Name == name);
        }
        public Category? FindById(int id)
        {
            return _categories.Find(id);
        }
        public bool HasProduct(int categoryId)
        {
            return _products.Any(_ => _.CategoryId == categoryId);
        }
        public bool IsDublicateName(int id, string name)
        {
            return _categories.Any(_ => _.Name == name && _.Id != id);
        }


    }
}
