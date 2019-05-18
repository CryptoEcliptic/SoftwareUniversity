namespace CakesWebApp.Models
{
    using System;
    using System.Collections.Generic;

    public class User: BaseModel<int>
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
            this.RegistrationDate = DateTime.UtcNow;
        }
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime RegistrationDate { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
