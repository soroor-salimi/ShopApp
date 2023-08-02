using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Categories.Contracts.Dto
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<productDetaile> ProductDetails { get; set; }
    }
    public class productDetaile
    {
        public int productId { get; set; }
        public string Title { get; set; }
        public int MinimumInventory { get; set; }
        public int Inventory { get; set; }
    }
}
