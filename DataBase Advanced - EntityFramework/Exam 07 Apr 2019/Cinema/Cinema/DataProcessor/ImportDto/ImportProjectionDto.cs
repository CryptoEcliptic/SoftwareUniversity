﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ImportProjectionDto
    {
        [Required]
        [XmlElement("MovieId")]
        public int MovieId { get; set; } //Required

        [Required]
        [XmlElement("HallId")]
        public int HallId { get; set; } //Required

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; } //Required
    }
}