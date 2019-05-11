namespace CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
