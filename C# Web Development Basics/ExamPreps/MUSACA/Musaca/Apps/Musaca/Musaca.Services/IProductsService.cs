using Musaca.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musaca.Services
{
    public interface IProductsService
    {
        void CreateProduct(string name, decimal price);

        IQueryable<Product> GetAllProducts();

        Product GetByName(string name);

        IQueryable<Product> GetAllProductsFromCurrentOrder(string userId);
    }
}
