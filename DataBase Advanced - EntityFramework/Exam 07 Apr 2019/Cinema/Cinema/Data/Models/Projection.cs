namespace Cinema.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Projection
    {
        public Projection()
        {
            this.Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; } //Required
        public Movie Movie { get; set; }

        [ForeignKey(nameof(Hall))]
        public int HallId { get; set; } //Required
        public Hall Hall { get; set; }

        public DateTime DateTime { get; set; } //Required

        public ICollection<Ticket> Tickets { get; set; }
    }
}
