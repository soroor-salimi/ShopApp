using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using ShopApp.Services.Products.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF.Products
{
    public class EFProductRepository : ProductRepository
    {
        private DbSet<Product> _products;
        public EFProductRepository(EFDataContext context)
        {
            _products = context.Set<Product>();
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void DeletedProduct(Product product)
        {
            _products.Remove(product);
        }

        public Product? FindById(int id)
        {
            return _products.Find(id);
        }

        public bool IsDublcateTitle(string title)
        {
            return _products.Any(_ => _.Title == title);
        }

    }
}
