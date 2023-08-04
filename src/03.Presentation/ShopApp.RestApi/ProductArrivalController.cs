using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.ProductArrivals.Contracts;
using ShopApp.Services.ProductArrivals.Contracts.Dto;

namespace ShopApp.RestApi
{
    [ApiController]
    [Route("product_ariivals")]
    public class ProductArrivalController:Controller
    {
        private ProductArrivalServices _services;
        public ProductArrivalController(ProductArrivalServices services)
        {
            _services = services;
        }

        [HttpPost]
        public void Add([FromBody] AddedProductArrivalDto dto)
        {
            dto.DateTime = DateTime.UtcNow;
            _services.Add(dto);
        }
    }
}
