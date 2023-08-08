using ShopApp.Services.Accountings.Contracts.Dto;
using ShopApp.Services.Sells.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Accountings.Contracts
{
    public interface AccountingServices
    {
        void Add(AddedAccountingForSellDto dtoAccounting);
    }
}
