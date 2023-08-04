using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts.Dto
{
    public class AddProductDto
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        [Required]
        public int MinimumInventory { get; set; }
        [Required]
        public int Inventory { get; set; }
        [Required]
        public StatusType StatusType { get; set; }
    }
}
