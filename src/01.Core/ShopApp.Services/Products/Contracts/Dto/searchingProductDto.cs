using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts.Dto
{
    public class searchingProductDto
    {
        public StatusType? type  { get; set; }
        public string? NameCategory { get; set; }
    }
}
