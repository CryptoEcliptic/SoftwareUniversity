using Musaca.Data;
using Musaca.Data.Models;
using Musaca.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musaca.Services
{
    public class ProductsService : IProductsService
    {
        private readonly MusacaDbContext context;
        private readonly IUsersService usersService;

        public ProductsService(MusacaDbContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }
        public void CreateProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            this.context.Products.Add(product);
            this.context.SaveChanges();
        }

        public IQueryable<Product> GetAllProducts()
        {
            var products = this.context.Products;
            return products;
        }

        public Product GetByName(string name)
        {
            var product = this.context.Products.FirstOrDefault(x => x.Name == name);

            return product;
        }

        public IQueryable<Product> GetAllProductsFromCurrentOrder(string userId)
        {
            var user = this.usersService.GetById(userId);
            var order = context.Orders.FirstOrDefault(x => x.CashierId == user.Id && x.Status == OrderStatus.Active);

            var products = this.context.Products.Where(x => x.OrderId == order.Id);

            return products;
        }
    }
}
