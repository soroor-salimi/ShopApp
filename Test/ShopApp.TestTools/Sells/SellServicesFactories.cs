using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.Accountings;
using ShopApp.Persistanse.EF.Products;
using ShopApp.Persistanse.EF.Sells;
using ShopApp.Services.Sells;
using ShopApp.Services.Sells.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Sells
{
    public static class SellServicesFactories
    {
        public static SellServices Create(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var sellRepository = new EFSellRepository(context);
            var productRepository = new EFProductRepository(context);
            var accountingRepository = new EFAccountingRepository(context);
            var sut = new SellAppServices(sellRepository,unitOfWork
                , accountingRepository
                , productRepository
                );

            return sut;
        }
    }
}
