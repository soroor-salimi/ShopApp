using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.ProductArrivals;
using ShopApp.Persistanse.EF.Products;
using ShopApp.Services.ProductArrivals;
using ShopApp.Services.ProductArrivals.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.ProductArrivals
{
    public static class ProductArrivalServicesFactories
    {
        public static ProductArrivalServices Create(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var productArrivalRepository = new EFProductArrivalRepository(context);
            var productRepository = new EFProductRepository(context);
            var sut = new ProductArrivalAppServices(productArrivalRepository
                , productRepository
                 , unitOfWork
                );

            return sut;
        }
    }
}
