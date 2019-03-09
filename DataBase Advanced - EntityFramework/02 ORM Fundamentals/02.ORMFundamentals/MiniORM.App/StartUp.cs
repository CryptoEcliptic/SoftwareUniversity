namespace MiniORM.App
{
    using System.Linq;
    using Data;
    using Data.Entities;

    public class StartUp
    {
        public static void Main()
        {
            SoftUniDbContext db = new SoftUniDbContext(Configuration.ConnectionString);

            db.Employees.Add(new Employee("Rado", "Radov", db.Departments.First().Id, true));

            Employee employee = db.Employees.Last();
            employee.FirstName = "Rado";

            db.SaveChanges();
        }
    }
}