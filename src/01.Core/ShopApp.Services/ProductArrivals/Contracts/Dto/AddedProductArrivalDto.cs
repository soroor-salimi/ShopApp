using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.ProductArrivals.Contracts.Dto
{
    public class AddedProductArrivalDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public int Count { get; set; }
        [Required]
        [MaxLength(255)]
        public string NumberOfInvoice { get; set; }
        [Required]
        [MaxLength(255)]
        public string NameCompany { get; set; }
    }
}
