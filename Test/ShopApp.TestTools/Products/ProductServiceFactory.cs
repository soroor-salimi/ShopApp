using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.Categories;
using ShopApp.Persistanse.EF.Products;
using ShopApp.Services.Products;
using ShopApp.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Products
{
    public static class ProductServicesFactories
    {
        public static ProductServices Create(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var productRepository = new EFProductRepository(context);
            var categoryRepository = new EFCategoryRepository(context);
            var sut = new ProductAppServices(productRepository,categoryRepository, unitOfWork);

            return sut;
        }
    }
}
