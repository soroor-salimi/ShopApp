using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Sell
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string CustomerName { get; set; }
        public DateTime DateTime { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
    }
}
