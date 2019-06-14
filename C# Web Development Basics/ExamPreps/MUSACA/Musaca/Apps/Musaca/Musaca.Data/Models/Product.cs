using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musaca.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrdersProducts = new List<OrdersProducts>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<OrdersProducts> OrdersProducts { get; set; }

    }
}
