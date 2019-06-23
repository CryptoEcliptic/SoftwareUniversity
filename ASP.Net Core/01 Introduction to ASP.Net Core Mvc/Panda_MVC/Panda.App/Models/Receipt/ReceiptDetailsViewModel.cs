using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.App.Models.Receipt
{
    public class ReceiptDetailsViewModel
    {
        public int ReceiptNumber { get; set; }

        public string IssuedOn { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal PackageWeight { get; set; }

        public string PackageDescription { get; set; }

        public string Recipient { get; set; }

        public decimal Total { get; set; }
    }
}
