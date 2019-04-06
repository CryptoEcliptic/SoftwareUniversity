namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        { 
            var prisoners = context.Prisoners
                 .Where(x => ids.Contains(x.Id))
                 .Select(x => new
                 {
                     Id = x.Id,
                     Name = x.FullName,
                     CellNumber = x.Cell.CellNumber,
                     Officers = x.PrisonerOfficers.Select(y => new
                     {
                         OfficerName = y.Officer.FullName,
                         Department = y.Officer.Department.Name,
                     })
                     .OrderBy(y => y.OfficerName)
                     .ToArray(),
                     TotalOfficerSalary = x.PrisonerOfficers.Select(y => y.Officer.Salary).Sum()
                 })
                 .OrderBy(x => x.Name)
                 .ThenBy(x => x.Id)
                 .ToArray();

            string result = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] splittedNames = prisonersNames.Split(",").ToArray();

            var prisoners = context.Prisoners
                .Where(x => splittedNames.Contains(x.FullName))
                .Select(x => new PrisonerExportDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(y => new ExportMessageDto
                    {
                        Description = ReverserDescription(y.Description)
                    })
                    .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PrisonerExportDto[]), new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();
            serializer.Serialize(new StringWriter(result), prisoners, namespaces);

            return result.ToString().TrimEnd();
        }

        private static string ReverserDescription(string description)
        {
            char[] charArray = description.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}