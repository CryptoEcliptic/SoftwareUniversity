using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.DTOs.ImportDtos
{
    public class GameImportDto
    {

        [Required]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.00", "10000000000")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        public List<string> Tags { get; set; }

        
    }
}
