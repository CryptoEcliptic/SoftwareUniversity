using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Torshia.Data.Models.Enums;

namespace Torshia.Data.Models
{
    public class Report
    {
        public Report()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public ReportStatus Status { get; set; }

        public DateTime? ReportedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Task))]
        public string TaskId { get; set; }
        public Task Task { get; set; }

        [Required]
        public string ReporterId { get; set; }
        public User Reporter { get; set; }

    }
}
