using ShopApp.Services.Sells.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Sells.Contracts
{
    public interface SellServices
    {
        void AddSellWithAccounting(AddedSellWithAccountigDto dto);
    }
}
