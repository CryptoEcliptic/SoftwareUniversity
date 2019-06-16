using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Torshia.Data.Models.Enums;

namespace Torshia.Data.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Reports = new HashSet<Report>();
            this.UsersTasks = new HashSet<UsersTasks>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string Username { get; set; }

        [Required]
        [MaxLength(32)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Report> Reports { get; set; }

        public virtual ICollection<UsersTasks> UsersTasks { get; set; }
    }
}
