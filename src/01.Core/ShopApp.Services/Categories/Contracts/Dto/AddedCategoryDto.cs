using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Categories.Contracts.Dto
{
    public class AddedCategoryDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
