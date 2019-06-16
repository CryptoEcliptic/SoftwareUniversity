using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Data.Models;

namespace Torshia.Services
{
    public interface ITasksService
    {
        void CreateTask(string[] checkBoxes, string participants, string title, DateTime dueDate, string description);
    }
}
