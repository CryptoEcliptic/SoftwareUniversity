namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeInputModel
    {
        [Required]
        [MinLength(3), MaxLength(36)]
        public string Name { get; set; }

        [Range(16, 68)]
        public int Age { get; set; }

        public string PositionName { get; set; }

        public string Address { get; set; }
    }
}
