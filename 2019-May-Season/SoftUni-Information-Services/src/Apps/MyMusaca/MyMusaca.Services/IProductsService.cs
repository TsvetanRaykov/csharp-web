using System.Collections.Generic;
using MyMusaca.Models;

namespace MyMusaca.Services
{
    public interface IProductsService
    {
        bool CreateProduct(string name, decimal price);
        IEnumerable<Product> GetAllProducts();
    }
}