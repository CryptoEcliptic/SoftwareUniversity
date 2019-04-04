﻿namespace VaporStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VaporStore.Data.Models.Enums;

    public class Card
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([\d]{4} [\d]{4} [\d]{4} [\d]{4}$)")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^[\d]{3}$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Purchase> Purchases { get; set; }


    }
}
