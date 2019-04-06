namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;

    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Xml.Serialization;
    using System.Linq;
    using System.Text;
    using System.IO;

    using SoftJail.Data.Models.Enums;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var jsonInput = JsonConvert.DeserializeObject<ImportDepartmentCellDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            StringBuilder resultMessage = new StringBuilder();
            foreach (var dep in jsonInput)
            {
                if (!IsValid(dep))
                {
                    resultMessage.AppendLine("Invalid Data");
                    continue;
                }

                var department = departments.FirstOrDefault(x => x.Name == dep.Name);
                if (department == null)
                {
                    department = new Department { Name = dep.Name };
                }

                bool hasValidCells = true;
                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        resultMessage.AppendLine("Invalid Data");
                        hasValidCells = false;
                        continue;
                    }

                    var currentCell = new Cell { CellNumber = cell.CellNumber, HasWindow = cell.HasWindow };
                    department.Cells.Add(currentCell);
                }

                if (!hasValidCells)
                {
                    continue;
                }

                departments.Add(department);

                resultMessage.AppendLine($"Imported {department.Name} with {department.Cells.Count()} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var jsonInput = JsonConvert.DeserializeObject<ImportPrisonerMailDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            StringBuilder resultMessage = new StringBuilder();

            foreach (var prisoner in jsonInput)
            {
                if (!IsValid(prisoner))
                {
                    resultMessage.AppendLine("Invalid Data");
                    continue;
                }

                var currentPrisoner = prisoners.FirstOrDefault(x => x.FullName == prisoner.FullName);

                if (currentPrisoner == null)
                {
                    currentPrisoner = new Prisoner
                    {
                        FullName = prisoner.FullName,
                        Age = prisoner.Age,
                        Bail = prisoner.Bail,
                        IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),

                        ReleaseDate = prisoner.ReleaseDate == null? (DateTime?) null 
                        : DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),

                        Nickname = prisoner.Nickname,
                        CellId = prisoner.CellId
                    };
                }

                bool isValidMail = true;
                foreach (var email in prisoner.Mails)
                {
                    if (!IsValid(email))
                    {
                        resultMessage.AppendLine("Invalid Data");
                        isValidMail = false;
                        break;
                    }

                    currentPrisoner.Mails.Add(new Mail
                    {
                        Description = email.Description,
                        Address = email.Address,
                        Sender = email.Sender
                    });
                }

                if (!isValidMail)
                {
                    continue;
                }

                prisoners.Add(currentPrisoner);
                resultMessage.AppendLine($"Imported {currentPrisoner.FullName} {currentPrisoner.Age} years old");
            }
            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();
            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportOfficerPrisonerDto[]), new XmlRootAttribute("Officers"));

            var deserializedOfficers = (ImportOfficerPrisonerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Officer> officers = new List<Officer>();

            StringBuilder resultMessage = new StringBuilder();

            foreach (var officer in deserializedOfficers)
            {
                bool isValidPosition = Enum.IsDefined(typeof(Position), officer.Position);
                bool isValidWeapon = Enum.IsDefined(typeof(Weapon), officer.Weapon);

                if (!IsValid(officer) || !isValidPosition || !isValidWeapon)
                {
                    resultMessage.AppendLine("Invalid Data");
                    continue;
                }

                var currentOfficer = new Officer
                {
                    FullName = officer.FullName,
                    Salary = officer.Salary,
                    Position = (Position)Enum.Parse(typeof(Position), officer.Position),
                    Weapon = (Weapon)Enum.Parse(typeof(Weapon), officer.Weapon),
                    DepartmentId = officer.DepartmentId,
                    OfficerPrisoners = officer.Prisoners
                                        .Select(x => new OfficerPrisoner
                                        { PrisonerId = x.PrisonerId })
                                        .ToArray()
                };

                officers.Add(currentOfficer);

                resultMessage.AppendLine($"Imported {currentOfficer.FullName} ({currentOfficer.OfficerPrisoners.Count()} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}