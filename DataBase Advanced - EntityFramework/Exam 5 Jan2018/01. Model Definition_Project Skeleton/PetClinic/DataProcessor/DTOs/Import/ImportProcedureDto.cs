namespace PetClinic.DataProcessor.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ImportProcedureDto
    {
        [Required]
        [XmlElement("Vet")]
        public string Vet { get; set; }

        [Required]
        [XmlElement("Animal")]
        public string Animal { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ImportAidDto[] AnimalAids { get; set; }
    }

    [XmlType("AnimalAid")]
    public class ImportAidDto
    {
        [Required]
        [XmlElement("Name")]
        public string Name { get; set; }
    }
}
