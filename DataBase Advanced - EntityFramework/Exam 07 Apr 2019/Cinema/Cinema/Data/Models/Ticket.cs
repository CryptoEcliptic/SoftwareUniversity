namespace Cinema.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }  //Required

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; } //Required
        public Customer Customer { get; set; }

        [ForeignKey(nameof(Projection))]
        public int ProjectionId { get; set; } //required
        public Projection Projection { get; set; }
    }
}
