namespace PetClinic.DataProcessor.DTOs.Import
{
    using System.ComponentModel.DataAnnotations;

    public class ImportAnimalDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Range(1, 150)]
        [Required]
        public int Age { get; set; }

        public ImportPassportDto Passport { get; set; }
    }
  }

