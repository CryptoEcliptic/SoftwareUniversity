using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Data.Models
{
    public class OrdersProducts
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
