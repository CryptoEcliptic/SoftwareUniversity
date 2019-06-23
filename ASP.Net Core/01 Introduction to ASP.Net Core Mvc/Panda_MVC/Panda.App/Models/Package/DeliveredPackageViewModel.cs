namespace Panda.App.Models.Package
{
    public class DeliveredPackageViewModel
    {
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public string Recipient { get; set; }

        public int Id { get; set; }
    }
}
