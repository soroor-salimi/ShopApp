using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Sells.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Sells
{
    public class EFSellRepository : SellRepository
    {
        private DbSet<Sell> _sells;
        public EFSellRepository(EFDataContext context)
        {
            _sells = context.Set<Sell>();
        }
        public void Add(Sell sell)
        {
            _sells.Add(sell);
        }
    }
}
