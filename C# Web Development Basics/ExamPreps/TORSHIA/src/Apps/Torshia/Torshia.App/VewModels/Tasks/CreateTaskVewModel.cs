using SIS.MvcFramework.Attributes.Validation;
using System;

namespace Torshia.App.VewModels.Tasks
{
    public class CreateTaskVewModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Title should be between 5 and 20 characters!")]
        public string Title { get; set; }

        [RequiredSis]
        public DateTime DueDate { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 512, "Description should be between 5 and 512 characters!")]
        public string Description { get; set; }

        public string Participants { get; set; }

        public string CustomersCheckbox { get; set; } = "Empty";

        public string MarketingCheckbox { get; set; } = "Empty";

        public string FinancesCheckbox { get; set; } = "Empty";

        public string InternalCheckbox { get; set; } = "Empty";

        public string ManagementCheckbox { get; set; } = "Empty";

    }
}
