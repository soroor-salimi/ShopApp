using ShopApp.Entities;
using ShopApp.Services.Products.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Products.Contracts
{
    public interface ProductRepository
    {
        void Add(Product product);
        bool IsDublcateTitle(string title);
        Product? FindById(int id);
        void DeletedProduct(Product product);
        void Update(Product product);
       // List<GetAllProductDto> GetAll(int? statusType);
    }
}
