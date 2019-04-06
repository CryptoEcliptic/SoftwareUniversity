namespace PetClinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Animal
    {
        public Animal()
        {
            this.Procedures = new List<Procedure>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Type { get; set; }

        [Range(1, 150)]
        public int Age { get; set; }//Required

        [ForeignKey("Passport")]
        public string PassportSerialNumber { get; set; }
        public Passport Passport { get; set; } //Required

        public ICollection<Procedure> Procedures { get; set; }
    }
}
