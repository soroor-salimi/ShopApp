using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.Accountings;
using ShopApp.Services.Accountings;
using ShopApp.Services.Accountings.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Accountings
{
    public static class AccountingServicesFactories
    {
        public static AccountingServices Create(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var accountingRepository = new EFAccountingRepository(context);
            var sut = new AccountingAppServices(accountingRepository,unitOfWork);

            return sut;
        }
    }
}
