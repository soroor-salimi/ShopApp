using OnlineShop.Services.Contracts;
using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Categories.Contracts.Dto;
using ShopApp.Services.Categories.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Categories
{
    public class CategoryAppServices : CaregoryServices
    {
        private CategoryRepository _repository;
        private UnitOfWork _unitOfWork;
        public CategoryAppServices(CategoryRepository repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddedCategoryDto dto)
        {
            var dublicateName = _repository.DublicateName(dto.Name);
            if (dublicateName)
            {
                throw new CategoryNameIsExistException();
            }

            var categoryDto = new Category()
            {
                Name = dto.Name,
            };
            _repository.Add(categoryDto);
            _unitOfWork.Complete();
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.FindById(id);
            if(category == null)
            {
                throw new IdIsNotFoundException();
            }
            _repository.DeletedCategory(category);
            _unitOfWork.Complete();
        }

        public List<GetAllCategoryDto> GetAll()
        {
            return _repository.GetAll();
        }


        public void UpdateNameCategory(int id, UpdateCategoryNameDto dto)
        {
            var category = _repository.FindById(id);
            if (category == null)
            {
                throw new IdIsNotFoundException();
            };

            bool isdDuplicate = _repository.IsDublicateName(id, dto.Name);
            if (isdDuplicate)
            {
                throw new CategoryNameIsExistException();
            }

            category.Name = dto.Name;

            _repository.UpdateName(category);
            _unitOfWork.Complete();
        }
    }
}
