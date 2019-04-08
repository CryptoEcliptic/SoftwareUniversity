namespace Cinema.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hall
    {
        public Hall()
        {
            this.Projections = new List<Projection>();
            this.Seats = new List<Seat>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        public bool Is4Dx { get; set; } //required

        public bool Is3D { get; set; } //required

        public ICollection<Projection> Projections { get; set; }

        public ICollection<Seat> Seats { get; set; }

    }
}
