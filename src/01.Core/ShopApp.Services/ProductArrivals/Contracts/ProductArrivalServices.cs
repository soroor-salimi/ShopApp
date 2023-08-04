using ShopApp.Entities;
using ShopApp.Services.ProductArrivals.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.ProductArrivals.Contracts
{
    public interface ProductArrivalServices
    {
        void Add(AddedProductArrivalDto dto);
    }
}
