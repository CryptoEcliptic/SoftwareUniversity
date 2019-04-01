namespace CarDealer
{
    using AutoMapper;
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class StartUp
    {
        private const string SuppliersPath = @"../../../Datasets/suppliers.xml";
        private const string PartsPath = @"../../../Datasets/parts.xml";
        private const string CarsPath = @"../../../Datasets/cars.xml";
        private const string CustomersPath = @"../../../Datasets/customers.xml";
        private const string SalesPath = @"../../../Datasets/sales.xml";

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));

            using (context)
            {
                //string inputXml = File.ReadAllText(SalesPath);

                var result = GetSalesWithAppliedDiscount(context);

                Console.WriteLine(result);
            }
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var deserializedSuppliers = (ImportSupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Supplier> suppliers = new List<Supplier>();

            foreach (var supplier in deserializedSuppliers)
            {
                var currentSupplier = Mapper.Map<Supplier>(supplier);
                suppliers.Add(currentSupplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var deserializedParts = (ImportPartDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Part> parts = new List<Part>();

            foreach (var part in deserializedParts)
            {
                if (!context.Suppliers.Any(x => x.Id == part.SupplierId))
                {
                    continue;
                }
                var currentPart = Mapper.Map<Part>(part);
                parts.Add(currentPart);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";

        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var deserializedCars = (ImportCarDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Car> cars = new List<Car>();

            foreach (var car in deserializedCars)
            {
                var currentVehicle = Mapper.Map<Car>(car);

                var partIds = car.Parts
                    .Distinct()
                    .ToList();

                if (partIds == null)
                {
                    continue;
                }

                foreach (var part in partIds)
                {
                    bool isValidPart = context.Parts.Any(x => x.Id == part.PartId) == true;
                    bool hasEqualParts = currentVehicle.PartCars.Any(x => x.PartId == part.PartId) == true;

                    if (isValidPart && !hasEqualParts)
                    {
                        var currentPart = new PartCar { CarId = currentVehicle.Id, PartId = part.PartId };
                        currentVehicle.PartCars.Add(currentPart);
                    }
                }
                cars.Add(currentVehicle);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var deserializedCustomers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Customer> customers = new List<Customer>();

            foreach (var customer in deserializedCustomers)
            {
                var currentCustomer = Mapper.Map<Customer>(customer);
               customers.Add(currentCustomer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";

        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            var deserializedSales = (ImportSaleDto[])serializer.Deserialize(new StringReader(inputXml));

            List<Sale> sales = new List<Sale>();

            foreach (var sale in deserializedSales)
            {
                if (!context.Cars.Any(x => x.Id == sale.CarId))
                {
                    continue;
                }
                var currentSale = Mapper.Map<Sale>(sale);
                sales.Add(currentSale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Select(x => new CarWithDistanceDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance

                })
                .Take(10)
                .ToArray();


            var serializer = new XmlSerializer(typeof(CarWithDistanceDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), cars, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var bmwCars = context.Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new BMWCarDto
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance

                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(BMWCarDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), bmwCars, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        { 
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliersDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(LocalSuppliersDto[]), new XmlRootAttribute("suppliers"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), localSuppliers, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price and sort all pars by price (descending). Sort all cars by travelled distance (descending) then by model (ascending). Select top 5 records.
            var carsWithParts = context.Cars
                .OrderByDescending(x => x.TravelledDistance)
                .ThenBy(x => x.Model)
                .Select(x => new CartWithListOfPartsDto
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new ExportPartDto
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray()

                })
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CartWithListOfPartsDto[]), new XmlRootAttribute("cars"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), carsWithParts, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending.
            var customersWithSales = context.Customers
                .Where(x => x.Sales.Count() >= 1)
                .Select(x => new TotalSaleCustomer
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(),
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(TotalSaleCustomer[]), new XmlRootAttribute("customers"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), customersWithSales, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get all sales with information about the car, customer and price of the sale with and without discount.
            var sales = context.Sales
                .Select(x => new LSaleWithDiscountDto
                {
                    Car = new LCarDto
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },

                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Select(y => y.Part).Sum(y => y.Price),
                    PriceWithDiscount = $"{x.Car.PartCars.Select(y => y.Part).Sum(y => y.Price) * ((100 - x.Discount) / 100)}".TrimEnd('0')
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(LSaleWithDiscountDto[]), new XmlRootAttribute("sales"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("","") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), sales, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}