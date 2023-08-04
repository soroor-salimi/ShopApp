using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts.Dto
{
    public class UpdateProductDto
    {
        [Required]
        public int Inventory { get; set; }
    }
}
