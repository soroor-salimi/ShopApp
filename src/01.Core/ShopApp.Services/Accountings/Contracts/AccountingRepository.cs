using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Accountings.Contracts
{
    public interface AccountingRepository
    {
        void Add(Accounting accounting);
        Accounting? FindById(int accountingId);
    }
}
