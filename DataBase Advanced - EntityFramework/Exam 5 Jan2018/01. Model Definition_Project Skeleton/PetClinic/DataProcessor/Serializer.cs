namespace PetClinic.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.DTOs.Export;

    public class Serializer
    {
        public static string ExportAnimalsByOwnerPhoneNumber(PetClinicContext context, string phoneNumber)
        {
            var animals = context.Animals
                .Where(x => x.Passport.OwnerPhoneNumber == phoneNumber)
                .Select(x => new
                {
                    OwnerName = x.Passport.OwnerName,
                    AnimalName = x.Name,
                    Age = x.Age,
                    SerialNumber = x.PassportSerialNumber,
                    RegisteredOn = x.Passport.RegistrationDate.ToString("dd-MM-yyyy")
                })
                .OrderBy(x => x.Age)
                .ThenBy(x => x.SerialNumber);

            string result = JsonConvert.SerializeObject(animals, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        public static string ExportAllProcedures(PetClinicContext context)
        {
            var procedures = context.Procedures
                .OrderBy(x => x.DateTime)
                .ThenBy(x => x.Animal.PassportSerialNumber)
                 .Select(x => new ExportProcedureDto
                 {
                     PassportNumber = x.Animal.PassportSerialNumber,
                     OwnerNumber = x.Animal.Passport.OwnerPhoneNumber,
                     DateTime = x.DateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                     AnimalAid = x.ProcedureAnimalAids.Select(y => new ExportAnimalAidDto
                     {
                         Name = y.AnimalAid.Name,
                         Price = y.AnimalAid.Price.ToString("F2")
                     })
                      .ToArray(),
                     TotalPrice = x.ProcedureAnimalAids.Sum(y => y.AnimalAid.Price).ToString("F2")
                 })
                 .ToArray();

            var serializer = new XmlSerializer(typeof(ExportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), procedures, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}
