namespace CarDealer.DTO
{
    using Newtonsoft.Json;

    public class SalesWithDiscountDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public decimal Discount { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public decimal PriceWithDiscount => this.Price * ((100 - Discount) / 100);

        [JsonProperty("priceWithDiscount")]
        public string FormattedPrice => this.PriceWithDiscount.ToString("n2");

    }
}
