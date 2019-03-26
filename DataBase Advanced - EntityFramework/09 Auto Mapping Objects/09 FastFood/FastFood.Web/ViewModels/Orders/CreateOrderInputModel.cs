using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        [MinLength(3), MaxLength(32)]
        public string Customer { get; set; }

        public int ItemId{ get; set; }

        public string ItemName { get; set; }

        public string EmployeeName { get; set; }

        [Range(1, 50)]
        public int Quantity { get; set; }

        public string OrderType { get; set; }
    }
}
