using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Sells.Contracts
{
    public interface SellRepository
    {
        void Add(Sell sell);
    }
}
