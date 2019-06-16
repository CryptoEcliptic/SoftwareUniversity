using System;
using System.Collections.Generic;
using System.Text;

namespace Torshia.Data.Models
{
    public class UsersTasks
    {
        public string TaskId { get; set; }
        public Task Task { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
