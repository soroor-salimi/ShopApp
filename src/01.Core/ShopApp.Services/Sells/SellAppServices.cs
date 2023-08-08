using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts;
using ShopApp.Services.Accountings.Contracts.Dto;
using ShopApp.Services.Accountings.Contracts.Exceptions;
using ShopApp.Services.Contracts;
using ShopApp.Services.ProductArrivals.Exceptions;
using ShopApp.Services.Products.Contracts;
using ShopApp.Services.Sells.Contracts;
using ShopApp.Services.Sells.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Sells
{
    public class SellAppServices : SellServices
    {
        private SellRepository _repository;
        private AccountingRepository _accountingrepository;
        private ProductRepository _productRepository;
        private UnitOfWork _unitOfWork;
        public SellAppServices(SellRepository repository
            , UnitOfWork unitOfWork,
            AccountingRepository accountingRepository,
            ProductRepository productRepository
            )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _accountingrepository = accountingRepository;
            _productRepository = productRepository;
        }

        public void AddWithAccounting(AddedSellWithAccountigDto dto)
        {
            var product = _productRepository.FindById(dto.ProductId);
            if (product == null)
            {
                throw new ProductIsNotFoundException();
            }
            var accountingF = _accountingrepository.FindById(dto.AccountingId);
            if (accountingF == null)
            {
                throw new AccountingIsNotFoundException();
            }

            var sell = new Sell()
            {
               Count=dto.Count,
               AccountingId=dto.AccountingId,
               CustomerName=dto.CustomerName,
               ProductId=dto.ProductId,
               Price=dto.Price,
               DateTime=dto.DateTime,
               NumberOfinvoiceSell=dto.NumberOfinvoiceSell,             
            };
            var accounting = new Accounting()
            {
                TotalPrice = dto.Count * dto.Price,
                DocumentRegistrationDate = DateTime.UtcNow,
                NumberOfinvoiceSell = dto.NumberOfinvoiceSell,
                NumberOfDocument=dto.AccountinginSell.NumberOfDocument
            };
            _repository.Add(sell);
          
            product.Inventory = product.Inventory - dto.Count;


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
