using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Accounting
    {
        public int Id { get; set; }
        public DateTime DocumentRegistrationDate { get; set; }
        public int NumberOfDocument { get; set; }
        public string NumberOfinvoiceSell { get; set; }
        public double TotalCount { get; set; }

        public Sell Sell { get; set; }
    }
}
