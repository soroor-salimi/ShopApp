using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts;
using ShopApp.Services.Accountings.Contracts.Dto;
using ShopApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Accountings
{
    public class AccountingAppServices : AccountingServices
    {
        private AccountingRepository _repository;
        private UnitOfWork _unitOfWork;
        public AccountingAppServices(
            AccountingRepository repository,
             UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddedAccountingForSellDto dtoAccounting)
        {
            var accounting = new Accounting()
            {
                NumberOfDocument = dtoAccounting.NumberOfDocument,
                DocumentRegistrationDate = DateTime.Today,
                NumberOfinvoiceSell = dtoAccounting.NumberOfinvoiceSell,
                TotalPrice = dtoAccounting.TotalPrice,
            };
            _repository.Add(accounting);
            _unitOfWork.Complete();
        }
    }
}
