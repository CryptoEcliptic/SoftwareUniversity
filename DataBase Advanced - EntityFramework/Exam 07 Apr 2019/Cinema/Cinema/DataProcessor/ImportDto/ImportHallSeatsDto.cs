﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallSeatsDto
    {

        [Required]
        [MinLength(3), MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public bool Is4Dx { get; set; } //required

        [Required]
        public bool Is3D { get; set; } //required

        [Required]
        [Range(1, 700)]
        public int Seats { get; set; }
    }

    public class ImportSeadDto
    {
      
    }
}
