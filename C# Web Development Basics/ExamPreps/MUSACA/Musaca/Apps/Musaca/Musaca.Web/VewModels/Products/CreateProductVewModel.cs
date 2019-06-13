using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musaca.Web.VewModels.Products
{
    public class CreateProductVewModel
    {
        [RequiredSis]
        [StringLengthSis(3, 10, "Product name should be between 5 and 20 characters!")]
        public string Name { get; set; }

        [RequiredSis]
        public decimal Price { get; set; }
    }
}
