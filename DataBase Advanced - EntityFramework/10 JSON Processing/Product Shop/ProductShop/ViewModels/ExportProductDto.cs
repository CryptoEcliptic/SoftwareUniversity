using Newtonsoft.Json;

namespace ProductShop.ViewModels
{
    public class ExportProductDto
    {
        [JsonProperty("name")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string Seller { get; set; }

    }
}
