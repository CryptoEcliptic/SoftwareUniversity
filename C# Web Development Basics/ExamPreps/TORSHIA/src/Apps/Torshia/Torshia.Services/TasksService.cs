using System;
using System.Collections.Generic;
using System.Text;
using Torshia.Data;
using Torshia.Data.Models;
using Torshia.Data.Models.Enums;

namespace Torshia.Services
{
    public class TasksService : ITasksService
    {
        private readonly TorshiaDbContext context;
        private readonly IUsersService usersService;

        public TasksService(TorshiaDbContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }
        public void CreateTask(string[] checkBoxes, string participants, string title, DateTime dueDate, string description)
        {
            string[] splittedPartcipants = participants.Split(new string[] { ", "}, StringSplitOptions.RemoveEmptyEntries);

            List<User> participantsAsObjects = this.usersService.GerUsersByUsernames(splittedPartcipants);

            var task = new Task
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
            };

            foreach (var participant in participantsAsObjects)
            {
                task.UsersTasks.Add(new UsersTasks { UserId = participant.Id });
            }

            foreach (var checkBox in checkBoxes)
            {
                var validCheckbox = Enum.TryParse<AffectedSectors>(checkBox, out AffectedSectors sector);
                if (validCheckbox)
                {
                    task.AffectedSectors.Add(new TaskSector { AffectedSector = sector });
                }
            }

            this.context.Tasks.Add(task);
            this.context.SaveChanges();
        }
    }
}
