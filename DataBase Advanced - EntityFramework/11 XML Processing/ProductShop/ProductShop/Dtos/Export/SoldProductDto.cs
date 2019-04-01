namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class SoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductDto[] ProductDtos { get; set; }
    }
}
