using ShopApp.Entities;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Contracts;
using ShopApp.Services.Products.Contracts;
using ShopApp.Services.Products.Contracts.Dto;
using ShopApp.Services.Products.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products
{
    public class ProductAppServices : ProductServices
    {
        private ProductRepository _repository;
        private CategoryRepository _categoryRepository;
        private UnitOfWork _unitOfWork;
        public ProductAppServices(ProductRepository repository
            , CategoryRepository categoryRepository
            , UnitOfWork unitOfWork)
        {
            _repository = repository;
            _categoryRepository= categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddProductDto dto)
        {
            var category = _categoryRepository.FindById(dto.CategoryId);
            if (category == null)
            {
                throw new CategoryIdIsNotFoundException();
            }

            var isDublicateTitle = _repository.IsDublcateTitle(dto.Title);
            if (isDublicateTitle)
            {
                throw new TheTitleOfTheProductIsDublicatedEception();
            }

            var product = new Product()
            {
                Title = dto.Title,
                CategoryId = dto.CategoryId,
                Inventory = dto.Inventory,
                MinimumInventory = dto.MinimumInventory,
            };
            _repository.Add(product);
            _unitOfWork.Complete();
        }

        public void DeleteProduct(int id)
        {
            var product = _repository.FindById(id);
            if (product == null)
            {
                throw new ProductIsNotFoundException();
            }

            _repository.DeletedProduct(product);
            _unitOfWork.Complete();
        }

        public void Update(int productId, UpdateProductDto productDto)
        {
            var product=_repository.FindById(productId);
            if (product==null)
            {
                throw new ProductIsNotFoundException();
            }
            product.Inventory=productDto.Inventory;
            _repository.Update(product);
            _unitOfWork.Complete();
        }
    }
}
