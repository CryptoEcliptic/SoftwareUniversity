using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Web.ViewModels.Receipts
{
    public class ReceiptViewModel
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        public string Recipient { get; set; }
    }
}
