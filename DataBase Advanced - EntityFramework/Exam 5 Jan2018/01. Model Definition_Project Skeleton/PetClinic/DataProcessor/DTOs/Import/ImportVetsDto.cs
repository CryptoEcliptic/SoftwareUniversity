namespace PetClinic.DataProcessor.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Vet")]
    public class ImportVetsDto
    {
        [Required]
        [MinLength(3), MaxLength(40)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        [XmlElement("Profession")]
        public string Profession { get; set; }

        [Range(22, 65)]
        [Required]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^\+359[0-9]{9}$|^0[0-9]{9}$")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; } //Unique
    }
}
