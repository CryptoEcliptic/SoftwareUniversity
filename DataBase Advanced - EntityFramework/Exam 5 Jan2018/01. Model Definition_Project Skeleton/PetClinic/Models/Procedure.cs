﻿namespace PetClinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class Procedure
    {
        public Procedure()
        {
            this.ProcedureAnimalAids = new List<ProcedureAnimalAid>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Animal))]
        public int AnimalId { get; set; } //Required
        public Animal Animal { get; set; }

        [ForeignKey(nameof(Vet))]
        public int VetId { get; set; } //Required
        public Vet Vet { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }

        [NotMapped]
        public decimal Cost => this.ProcedureAnimalAids.Sum(x => x.AnimalAid.Price);

        [Required]
        public DateTime DateTime { get; set; }

    }
}
