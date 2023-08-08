using ShopApp.Entities;
using ShopApp.Services.Contracts;
using ShopApp.Services.ProductArrivals.Contracts;
using ShopApp.Services.ProductArrivals.Contracts.Dto;
using ShopApp.Services.ProductArrivals.Exceptions;
using ShopApp.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.ProductArrivals
{
    public class ProductArrivalAppServices : ProductArrivalServices
    {
        private ProductArrivalRepository _repository;
        private ProductRepository _productRepository;
        private UnitOfWork _unitOfWork;
        public ProductArrivalAppServices(
            ProductArrivalRepository repository,
            ProductRepository productRepository
            , UnitOfWork unitOfWork)
        {
            _repository = repository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public void Add(AddedProductArrivalDto dto)
        {
            var productArrival = new ProductArrival()
            {
                NameCompany = dto.NameCompany,
                Count = dto.Count,
                DateTime = dto.DateTime,
                NumberOfInvoice = dto.NumberOfInvoice,
                ProductId = dto.ProductId,
            };

            _repository.Add(productArrival);

            var product = _productRepository.FindById(dto.ProductId);
            if (product == null)
            {
                throw new ProductIsNotFoundException();
            }   

            product.Inventory = product.Inventory + dto.Count;
            if (product.Inventory <= product.MinimumInventory)
            {
                product.statusType = StatusType.ReadyToOrder;
            }
            else
            {
                product.statusType = StatusType.Available;
            }

            _productRepository.Update(product);
            _unitOfWork.Complete();


        }
    }
}
