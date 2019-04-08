namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Hall))]
        public int HallId  { get; set; } //required
        public Hall Hall { get; set; }
    }
}
