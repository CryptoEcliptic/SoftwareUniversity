using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Torshia.Data.Models.Enums;

namespace Torshia.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid().ToString();
            this.AffectedSectors = new HashSet<TaskSector>();
            this.UsersTasks = new HashSet<UsersTasks>();
            this.IsReported = false;
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Title { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsReported { get; set; }

        [Required]
        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        public virtual ICollection<TaskSector> AffectedSectors { get; set; }

        public virtual ICollection<UsersTasks> UsersTasks { get; set; }
    }
}
