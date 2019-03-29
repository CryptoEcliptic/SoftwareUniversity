using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        private static string SuppliersDatasetPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\suppliers.json";

        private static string PartsDatasetPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\parts.json";

        private static string CarsDatasetPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\cars.json";

        private static string CustomersDatasetPath = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\customers.json";

        private static string SalesPathDataset = @"C:\Users\Name\Desktop\SoftUni\DbAdvanced - Entity Framework\10 JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\sales.json";


        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            using (context)
            {
                string inputJson = File.ReadAllText(SalesPathDataset);

                string result = ImportSales(context, inputJson);

                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliersJson = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            List<Supplier> validSuppliers = new List<Supplier>();

            foreach (var supplier in suppliersJson)
            {
                if (IsValid(supplier))
                {
                    validSuppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var jsonParts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            List<Part> validParts = new List<Part>();

            foreach (var part in jsonParts)
            {
                bool existingSupplier = context.Suppliers.Any(x => x.Id == part.SupplierId);
                if (IsValid(part) && existingSupplier)
                {
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsPartsJson = JsonConvert.DeserializeObject<List<ImportedCarDto>>(inputJson);

            var validCars = new List<Car>();

            foreach (var car in carsPartsJson)
            {
                var currentcar = Mapper.Map<Car>(car);

                if (IsValid(currentcar))
                {
                    validCars.Add(currentcar);
                }

                var partIds = car.PartsId
                    .Distinct()
                    .ToList();

                if (partIds == null)
                {
                    continue;
                }

                foreach (var part in partIds)
                {
                    var currentPart = new PartCar() { CarId = currentcar.Id, PartId = part };
                    currentcar.PartCars.Add(currentPart);
                }
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customerJson = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            var validCustomers = new List<Customer>();

            foreach (var customer in customerJson)
            {
                if (IsValid(customer))
                {
                    validCustomers.Add(customer);
                }
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var salesJson = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            var validSales = new List<Sale>();

            foreach (var sale in salesJson)
            {
                if (IsValid(sale))
                {
                    validSales.Add(sale);
                }
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new OrderedCustomerDto()
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            string result = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return result;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new ToyotaCarDto()
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            string result = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return result;

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSupplierDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()

                })
                .ToList();

            string result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },

                    parts = x.PartCars
                        .Select(y => new
                        {
                            Name = y.Part.Name,
                            Price = $"{y.Part.Price:f2}"
                        })
                        .ToList()
                })
                .ToList();

            string result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithCars = context.Customers
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new CustomerSaleDto()
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales
                        .Select(y => y.Car.PartCars.Select(z => z.Part).Sum(z => z.Price)).Sum()

                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            string result = JsonConvert.SerializeObject(customersWithCars, Formatting.Indented);

            return result;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithDiscount = context.Sales
                .Where(x => x.Discount > 0)
                .Select(x => new SalesWithDiscountDto()
                {
                    Car = new CarDto()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    CustomerName = x.Customer.Name,
                    Discount = x.Discount,
                    Price = x.Car.PartCars.Select(z => z.Part).Sum(z => z.Price)

                })
                .Take(10)
                .ToList();

            string result = JsonConvert.SerializeObject(salesWithDiscount
                , Formatting.Indented
                );

            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }

    }
}