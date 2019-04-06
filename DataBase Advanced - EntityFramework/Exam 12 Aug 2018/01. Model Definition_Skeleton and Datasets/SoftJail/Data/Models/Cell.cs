namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Cell
    {
        public Cell()
        {
            this.Prisoners = new List<Prisoner>();
        }

        [Key]
        public int Id { get; set; }

        [Range(1, 1000)]
        public int CellNumber { get; set; } //Required

        [Required]
        public bool HasWindow { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }
    }
}
