namespace PetClinic.DataProcessor.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("AnimalAid")]
    public class ExportAnimalAidDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }
    }
}
