using Musaca.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaca.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.OrdersProducts = new HashSet<OrdersProducts>();
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string CashierId { get; set; }
        public User Cashier { get; set; }

        public ICollection<OrdersProducts> OrdersProducts { get; set; }

    }
}
