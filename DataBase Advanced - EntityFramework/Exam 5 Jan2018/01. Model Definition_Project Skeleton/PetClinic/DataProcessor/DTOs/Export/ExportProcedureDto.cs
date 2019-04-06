namespace PetClinic.DataProcessor.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Procedure")]
    public class ExportProcedureDto
    {
        [XmlElement("Passport")]
        public string PassportNumber { get; set; }

        [XmlElement("OwnerNumber")]
        public string OwnerNumber { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlArray("AnimalAids")]
        public ExportAnimalAidDto[] AnimalAid { get; set; }

        [XmlElement("TotalPrice")]
        public string TotalPrice { get; set; }
    }
}
