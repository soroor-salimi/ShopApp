using ShopApp.Services.Products.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts
{
    public interface ProductServices
    {
        void Add(AddProductDto dto);
        void DeleteProduct(int id);
        void Update(int productId, UpdateProductDto productDto);
        List<GetAllProductDto> GetAll(searchingProductDto? dto = null);
    }
}
