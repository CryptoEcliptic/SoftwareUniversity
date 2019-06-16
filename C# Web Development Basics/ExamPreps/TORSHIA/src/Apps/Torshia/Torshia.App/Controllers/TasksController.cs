using SIS.MvcFramework;
using SIS.MvcFramework.Attributes;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Torshia.App.VewModels.Tasks;
using Torshia.App.VewModels.Users;
using Torshia.Data.Models;
using Torshia.Services;

namespace Torshia.App.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService tasksService;

        public TasksController(ITasksService tasksService)
        {
            this.tasksService = tasksService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateTaskVewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/Tasks/Create");
            }
 
            var checkBoxes = new string[]
            {
                model.CustomersCheckbox,
                model.MarketingCheckbox,
                model.FinancesCheckbox,
                model.InternalCheckbox,
                model.ManagementCheckbox
            }
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();

            string[] chexkboxes = new string[] { "Customers" };
            this.tasksService.CreateTask(chexkboxes, model.Participants, model.Title, model.DueDate, model.Description);

            return this.Redirect("/");
        }
    }
}
