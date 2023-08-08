using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts.Dto
{
    public class GetAllProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }       
        public string Title { get; set; }
        public int MinimumInventory { get; set; }
        public int Inventory { get; set; }
        public StatusType StatusType { get; set; }
    }
}
