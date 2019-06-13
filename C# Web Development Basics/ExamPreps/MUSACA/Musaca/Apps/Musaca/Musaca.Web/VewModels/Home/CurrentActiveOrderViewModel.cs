using Musaca.Web.VewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Web.VewModels.Home
{
    public class CurrentActiveOrderViewModel
    {
        public List<OrderedProductsViewModel> Products { get; set; }

        public decimal Sum { get; set; }
    }
}
