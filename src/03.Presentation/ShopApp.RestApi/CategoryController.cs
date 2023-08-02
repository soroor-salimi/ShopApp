using Microsoft.AspNetCore.Mvc;
using ShopApp.Services.Categories.Contracts;
using ShopApp.Services.Categories.Contracts.Dto;

namespace ShopApp.RestApi
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
        [HttpGet("{id}")]
        public GetCategoryDto GetCategoryWithProducts(int id)
        {
            return _services.GetAllproductWithcategoryId(id);
        }

        [HttpPut("{id}")]
        public void UpdateName([FromRoute] int id, UpdateCategoryNameDto dto)
        {
            _services.UpdateNameCategory(id, dto);
        }
        [HttpDelete("{id}")]
        public void DeletedCategory([FromRoute] int id)
        {
            _services.DeleteCategory(id);
        }
    }
}