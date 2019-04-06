namespace PetClinic.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using PetClinic.Data;
    using PetClinic.DataProcessor.DTOs.Import;
    using PetClinic.Models;

    public class Deserializer
    {

        public static string ImportAnimalAids(PetClinicContext context, string jsonString)
        {
            var animalAidJson = JsonConvert.DeserializeObject<ImportAnimalAidDto[]>(jsonString);

            List<AnimalAid> animalAids = new List<AnimalAid>();

            StringBuilder resultMessage = new StringBuilder();
            foreach (var animalAid in animalAidJson)
            {
                if (!IsValid(animalAid))
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }

                var currentAid = animalAids.FirstOrDefault(x => x.Name == animalAid.Name);

                if (currentAid == null)
                {
                    currentAid = new AnimalAid
                    {
                        Name = animalAid.Name,
                        Price = animalAid.Price
                    };

                    animalAids.Add(currentAid);
                    resultMessage.AppendLine($"Record {currentAid.Name} successfully imported.");
                }
                else
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }
            }
            context.AnimalAids.AddRange(animalAids);
            context.SaveChanges();
            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportAnimals(PetClinicContext context, string jsonString)
        {
            var animalJson = JsonConvert.DeserializeObject<ImportAnimalDto[]>(jsonString);

            List<Animal> animals = new List<Animal>();

            StringBuilder resultMessage = new StringBuilder();

            foreach (var animalDto in animalJson)
            {
                if (!IsValid(animalDto) || !IsValid(animalDto.Passport))
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }

                var currentAnimal = animals.FirstOrDefault(x => x.Name == animalDto.Name && x.PassportSerialNumber == animalDto.Passport.SerialNumber);

                if (currentAnimal == null)
                {
                    currentAnimal = new Animal
                    {
                        Name = animalDto.Name,
                        Age = animalDto.Age,
                        Type = animalDto.Type,
                        PassportSerialNumber = animalDto.Passport.SerialNumber,
                        Passport =
                        new Passport
                        {
                            SerialNumber = animalDto.Passport.SerialNumber.ToString(),
                            OwnerName = animalDto.Passport.OwnerName,
                            OwnerPhoneNumber = animalDto.Passport.OwnerPhoneNumber,
                            RegistrationDate = DateTime.ParseExact(animalDto.Passport.RegistrationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture)
                        }

                    };

                    var passportNumber = animalDto.Passport.SerialNumber;
                    if (animals.Any(x => x.PassportSerialNumber == passportNumber))
                    {
                        resultMessage.AppendLine("Error: Invalid data.");
                        continue;
                    }

                    animals.Add(currentAnimal);
                    resultMessage.AppendLine($"Record {currentAnimal.Name} Passport №: {currentAnimal.PassportSerialNumber} successfully imported.");
                }
            }
            context.Animals.AddRange(animals);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportVets(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportVetsDto[]), new XmlRootAttribute("Vets"));

            var deserializedVets = (ImportVetsDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Vet> vets = new List<Vet>();
            StringBuilder resultMessage = new StringBuilder();

            foreach (var vet in deserializedVets)
            {
                if (!IsValid(vet))
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }

                var currentVet = vets.FirstOrDefault(x => x.Name == vet.Name);
                if (currentVet == null)
                {
                    currentVet = new Vet
                    {
                        Name = vet.Name,
                        Age = vet.Age,
                        Profession = vet.Profession,
                        PhoneNumber = vet.PhoneNumber
                    };
                }
                if (vets.Any(x => x.PhoneNumber == currentVet.PhoneNumber))
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }

                vets.Add(currentVet);
                resultMessage.AppendLine($"Record {currentVet.Name} successfully imported.");
            }

            context.Vets.AddRange(vets);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportProcedures(PetClinicContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProcedureDto[]), new XmlRootAttribute("Procedures"));

            var deserializedProcedures = (ImportProcedureDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Procedure> procedures = new List<Procedure>();
            StringBuilder resultMessage = new StringBuilder();

            var validVets = context.Vets.ToList();
            var validAnimals = context.Animals.ToList();
            var validAnimalAid = context.AnimalAids.ToList();

            foreach (var proc in deserializedProcedures)
            {
                var animalAidDto = proc.AnimalAids.ToList();
                bool hasValidAids = HasValidAnimalAids(validAnimalAid, animalAidDto);

                bool hasValidData = validVets.Any(x => x.Name == proc.Vet)
                    && validAnimals.Any(x => x.PassportSerialNumber == proc.Animal)
                    && hasValidAids;

                if (hasValidData)
                {
                    var currentProcedure = new Procedure
                    {
                        Animal = validAnimals.FirstOrDefault(x => x.PassportSerialNumber == proc.Animal),
                        Vet = validVets.FirstOrDefault(x => x.Name == proc.Vet),
                        DateTime = DateTime.ParseExact(proc.DateTime, "dd-MM-yyyy", CultureInfo.InvariantCulture),
                    };

                    bool hasRepeatedAids = false;
                    foreach (var aid in animalAidDto)
                    {
                        var currentAid = new ProcedureAnimalAid
                        {
                            AnimalAid = validAnimalAid.FirstOrDefault(x => x.Name == aid.Name)
                        };

                        if (!currentProcedure.ProcedureAnimalAids.Any(x => x.AnimalAid.Name == aid.Name))
                        {
                            currentProcedure.ProcedureAnimalAids.Add(currentAid);
                        }
                        else
                        {
                            resultMessage.AppendLine("Error: Invalid data.");
                            hasRepeatedAids = true;
                            break;
                        } 
                    }

                    if (!hasRepeatedAids)
                    {
                        procedures.Add(currentProcedure);
                        resultMessage.AppendLine($"Record successfully imported.");
                    }
                }

                else
                {
                    resultMessage.AppendLine("Error: Invalid data.");
                    continue;
                }
            }

            context.Procedures.AddRange(procedures);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        private static bool HasValidAnimalAids(List<AnimalAid> validAnimalAid, List<ImportAidDto> animalAidDto)
        {
            bool hasValidAids = true;

            foreach (var aid in animalAidDto)
            {
                if (!validAnimalAid.Any(x => x.Name == aid.Name))
                {
                    hasValidAids = false;
                    break;
                }
            }

            return hasValidAids;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}
