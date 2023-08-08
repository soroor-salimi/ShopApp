using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Products.Contracts;
using ShopApp.Services.Products.Contracts.Dto;

namespace ShopApp.RestApi
{
    [ApiController]
    [Route("products")]
    public class ProductController:Controller
    {
        private ProductServices _services;
        public ProductController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        public void Add([FromBody] AddProductDto dto)
        {
            _services.Add(dto);
        }
        [HttpGet()]
        public void Get([FromQuery]searchingProductDto? dto)
        {
            _services.GetAll(dto);
        }
        [HttpDelete("{id}")]
        public void Delete([FromRoute]int id)
        {
            _services.DeleteProduct(id);
        }
    }
}
