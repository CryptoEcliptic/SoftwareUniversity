﻿namespace SoftJail.Data.Models
{
    using SoftJail.Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Officer
    {
        public Officer()
        {
            this.OfficerPrisoners = new List<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(30)]
        public string FullName { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Salary { get; set; } //Required

        public Position Position { get; set; }

        public Weapon Weapon { get; set; } //Required

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
