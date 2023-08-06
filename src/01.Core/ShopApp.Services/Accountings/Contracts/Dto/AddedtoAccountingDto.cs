using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Accountings.Contracts.Dto
{
    public class AddedAccountingDto
    {
        [Required]
        public DateTime DocumentRegistrationDate { get; set; }
        [Required]
        public int NumberOfDocument { get; set; }
        [Required]
        [MaxLength(255)]
        public string NumberOfinvoiceSell { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
