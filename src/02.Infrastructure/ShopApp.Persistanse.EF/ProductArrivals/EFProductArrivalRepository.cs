using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.ProductArrivals.Contracts;
using ShopApp.Services.ProductArrivals.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.ProductArrivals
{
    public class EFProductArrivalRepository : ProductArrivalRepository
    {
        private DbSet<ProductArrival> _productArivals;
        public EFProductArrivalRepository(EFDataContext context)
        {
            _productArivals=context.Set<ProductArrival>();
        }
        public void Add(ProductArrival productArrival)
        {
            _productArivals.Add(productArrival);
        }
    }
}
