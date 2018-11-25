using System;
using System.Collections.Generic;
using System.Text;

namespace _02BookShop.Models
{
    public class GoldenEditionBook : Book
    {
        
        public GoldenEditionBook(string name, string author, decimal price) : base(name, author, price)
        {

        }

        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }

    }
}
