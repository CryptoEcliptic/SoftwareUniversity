namespace Cinema.DataProcessor
{
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any())
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(y => y.Tickets.Sum(z => z.Price)).ToString("F2"),
                    Customers = x.Projections
                        .SelectMany(z => z.Tickets)
                        .Select(y => new
                        {
                            FirstName = y.Customer.FirstName,
                            LastName = y.Customer.LastName,
                            Balance = y.Customer.Balance.ToString("F2")
                        })
                        .OrderByDescending(y => y.Balance)
                        .ThenBy(y => y.FirstName)
                        .ThenBy(y => y.LastName)
                        .ToArray()
                })
                .OrderByDescending(x => double.Parse(x.Rating))
                .ThenByDescending(x => double.Parse(x.TotalIncomes))
                .Take(10)
                .ToArray()
                ;

            string result = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .Select(x => new ExportTopCustomerDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(z => z.Price).ToString("F2"),
                    SpentTime = (new TimeSpan(x.Tickets.Sum(z => z.Projection.Movie.Duration.Ticks))).ToString()
                })
                .OrderByDescending(x => decimal.Parse(x.SpentMoney))
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportTopCustomerDto[]), new XmlRootAttribute("Customers"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), customers, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}