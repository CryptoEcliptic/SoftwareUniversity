using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class MovieImportDto
    {
        [Required]
        [MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Duration { get; set; }

        [Range(1, 10)]
        [Required]
        public double Rating { get; set; } //required

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Director { get; set; }
    }
}
