using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Web.VewModels.Orders
{
    public class UserOrdersView
    {
        public string Id { get; set; }

        public decimal Total { get; set; }

        public string IssuedOn { get; set; }

        public string Cashier { get; set; }
    }
}
