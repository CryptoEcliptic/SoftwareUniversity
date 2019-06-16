using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Torshia.Data.Models.Enums;

namespace Torshia.Data.Models
{
    public class TaskSector
    {
        [Key]
        public int Id { get; set; }

        public string TaskId { get; set; }
        public Task Task { get; set; }

        public AffectedSectors AffectedSector { get; set; }
    }
}
