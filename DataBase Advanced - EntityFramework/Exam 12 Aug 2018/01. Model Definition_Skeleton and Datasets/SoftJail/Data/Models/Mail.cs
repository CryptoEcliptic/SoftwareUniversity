namespace SoftJail.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Sender { get; set; }

        [RegularExpression(@"[0-9]+ [A-Za-z\s]+ str.")]
        [Required]
        public string Address { get; set; }

        [ForeignKey(nameof(Prisoner))]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }

        //[RegularExpression(@"^\d+ (?:[A-Za-z]+) (?:[A-Za-z]+) str.|^\d+ (?:[A-Za-z]+) (?:[A-Za-z]+) (?:[A-Za-z]+) str.|^\d+ (?:[A-Za-z]+) str.")]
    }
}
