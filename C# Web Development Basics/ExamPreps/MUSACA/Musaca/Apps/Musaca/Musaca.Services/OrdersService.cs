using Musaca.Data;
using Musaca.Data.Models;
using Musaca.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musaca.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly MusacaDbContext context;
        private readonly IProductsService productsService;
        private readonly IUsersService usersService;

        public OrdersService(MusacaDbContext context, IProductsService productsService, IUsersService usersService)
        {
            this.context = context;
            this.productsService = productsService;
            this.usersService = usersService;
        }

        public Order CreateOrder(string id)
        {
            var order = new Order
            {
                CashierId = id,
                IssuedOn = DateTime.UtcNow,
                Status = OrderStatus.Active,
            };

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return order;
        }

        public void AddProductToOrder(string name, string userId)
        {
            var product = this.productsService.GetByName(name);

            if (product == null)
            {
                return;
            }

            var order = this.context.Orders.FirstOrDefault(x => x.Status == OrderStatus.Active 
            && x.CashierId == userId);

            product.OrderId = order.Id;

            this.context.Update(product);
            this.context.SaveChanges();
        }

        public void CahsoutCurrentOrder(string userId)
        {
            var order = this.context.Orders.FirstOrDefault(x => x.Status == OrderStatus.Active
            && x.CashierId == userId);

            order.Status = OrderStatus.Completed;
            order.IssuedOn = DateTime.UtcNow;

            this.context.Update(order);
            this.context.SaveChanges();

            this.CreateOrder(userId);
        }
    }
}
