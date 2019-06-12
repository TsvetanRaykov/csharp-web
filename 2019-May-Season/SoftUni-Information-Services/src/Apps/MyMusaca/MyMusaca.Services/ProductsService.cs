using System;
using System.Collections.Generic;
using System.Linq;
using MyMusaca.Data;
using MyMusaca.Models;

namespace MyMusaca.Services
{
    public class ProductsService : IProductsService
    {
        private readonly MyMusacaDbContext dbContext;

        public ProductsService(MyMusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Price = price
            };

            this.dbContext.Add(product);
            this.dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var allProducts = this.dbContext.Products.ToList();
            return allProducts;
        }
    }
}