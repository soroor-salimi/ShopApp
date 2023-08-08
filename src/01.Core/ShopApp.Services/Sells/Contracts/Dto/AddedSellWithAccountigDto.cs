using ShopApp.Entities;
using ShopApp.Services.Accountings.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Sells.Contracts.Dto
{
    public class AddedSellWithAccountigDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(255)]
        public string NumberOfinvoiceSell { get; set; }
        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public double Price { get; set; }
        public AddedAccountingForSellDto AccountinginSell { get; set; }
    }
}
