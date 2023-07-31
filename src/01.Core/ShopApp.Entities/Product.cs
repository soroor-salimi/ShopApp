using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Product
    {
        public Product()
        {
            Sells = new HashSet<Sell>();
            productArrivals = new HashSet<ProductArrival>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int MinimumInventory { get; set; }
        public int Inventory { get; set; }

        public HashSet<Sell> Sells { get; set; }
        public HashSet<ProductArrival> productArrivals { get; set; }

        public Category Category { get; set; }
    }
}
