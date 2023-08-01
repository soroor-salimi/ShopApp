using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Categories.Contracts.Dto;

namespace OnllineShop.RestApi
{
    [ApiController]
    [Route("categories")]
    public class CategoryController : Controller
    {
        private CaregoryServices _services;
        public CategoryController(CaregoryServices services)
        {
            _services = services;
        }

        [HttpPost]
        public void Add([FromBody] AddedCategoryDto dto)
        {
            _services.Add(dto);
        }
        [HttpGet]
        public List<GetAllCategoryDto> GetAll()
        {
            return _services.GetAll();
        }

    }
}