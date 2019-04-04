namespace VaporStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        public Game()
        {
            this.GameTags = new List<GameTag>();
            this.Purchases = new List<Purchase>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Range(typeof(decimal), "0.00", "10000000000")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("Developer")]
        public int DeveloperId { get; set; } 
        public Developer Developer { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public ICollection<GameTag> GameTags { get; set; }

        public ICollection<Purchase> Purchases  { get; set; }

    }
}
