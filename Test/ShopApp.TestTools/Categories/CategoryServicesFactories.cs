using ShopApp.Persistanse.EF;
using ShopApp.Persistanse.EF.Categories;
using ShopApp.Services.Categories;
using ShopApp.Services.Categories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.TestTools.Categories
{
    public static class CategoryServicesFactories
    {
        public static CaregoryServices Create(EFDataContext context)
        {
            var unitOfWork = new EFUnitOfWork(context);
            var categoryRepository = new EFCategoryRepository(context);
            var sut = new CategoryAppServices(categoryRepository, unitOfWork);

            return sut;
        }


    }
}
