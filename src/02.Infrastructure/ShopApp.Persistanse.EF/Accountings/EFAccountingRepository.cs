using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Accountings
{
    public class EFAccountingRepository : AccountingRepository
    {
        private DbSet<Accounting> _accounting;
        public EFAccountingRepository(EFDataContext context)
        {
            _accounting = context.Set<Accounting>();
        }
        public void Add(Accounting accounting)
        {
            _accounting.Add(accounting);
        }

        public Accounting? FindById(int accountingId)
        {
            return _accounting.Find(accountingId);
        }
    }
}
