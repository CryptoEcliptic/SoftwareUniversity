using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Data.Models;
using Torshia.Data.Models.Enums;

namespace Torshia.App.VewModels.Users
{
    public class UsersInTasksViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }
  
        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
