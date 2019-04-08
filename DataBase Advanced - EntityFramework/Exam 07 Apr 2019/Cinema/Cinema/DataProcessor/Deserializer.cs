namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesJson = JsonConvert.DeserializeObject<MovieImportDto[]>(jsonString);

            var movies = new List<Movie>();
            StringBuilder resultMessage = new StringBuilder();

            foreach (var movieJson in moviesJson)
            {
                if (!IsValid(movieJson))
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = movies.FirstOrDefault(x => x.Title == movieJson.Title);

                if (movie == null)
                {
                    movie = new Movie
                    {
                        Title = movieJson.Title,
                        Genre = (Genre)Enum.Parse(typeof(Genre), movieJson.Genre),
                        Duration = TimeSpan.Parse(movieJson.Duration),
                        Rating = movieJson.Rating,
                        Director = movieJson.Director
                    };
                }
                else
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                movies.Add(movie);
         
                resultMessage.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:f2}!");
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatsJson = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);

            var halls = new List<Hall>();
            StringBuilder resultMessage = new StringBuilder();
            foreach (var hall in hallSeatsJson)
            {
                if (!IsValid(hall))
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                var currentHall = halls.FirstOrDefault(x => x.Name == hall.Name);
                var seats = new List<Seat>();

                if (currentHall == null)
                {
                    currentHall = new Hall
                    {
                        Name = hall.Name,
                        Is4Dx = hall.Is4Dx,
                        Is3D = hall.Is3D,
                    };

                    for (int i = 1; i <= hall.Seats; i++)
                    {
                        var seat = new Seat
                        {
                            Hall = currentHall
                        };

                        currentHall.Seats.Add(seat);
                    } 
                }
                else
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                halls.Add(currentHall);
                string typeHall = null;

                if (currentHall.Is3D && currentHall.Is4Dx)
                {
                    typeHall = "4Dx/3D";
                }

                else if (currentHall.Is3D)
                {
                    typeHall = "3D";
                }
                
                else if (currentHall.Is4Dx)
                {
                    typeHall = "4Dx";
                }

                else
                {
                    typeHall = "Normal";
                }
                

                resultMessage.AppendLine($"Successfully imported {currentHall.Name}({typeHall}) with {currentHall.Seats.Count()} seats!");
            }
            context.Halls.AddRange(halls);
            context.SaveChanges();

            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionDto[]), new XmlRootAttribute("Projections"));

            var deserializedProjections = (ImportProjectionDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Projection> projections = new List<Projection>();
            var validMovies = context.Movies.ToList();
            var validHalls = context.Halls.ToList();

            StringBuilder resultMessage = new StringBuilder();

            foreach (var projDto in deserializedProjections)
            {
                var isValidMovie = validMovies.Any(x => x.Id == projDto.MovieId);
                var isValidHall = validHalls.Any(x => x.Id == projDto.HallId);
             
                if (!IsValid(projDto) || !isValidMovie || !isValidHall)
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                var currentProjection = new Projection
                {
                    MovieId = projDto.MovieId,
                    HallId = projDto.HallId,
                    DateTime = DateTime.ParseExact(projDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(currentProjection);
                var movie = validMovies.FirstOrDefault(x => x.Id == currentProjection.MovieId);
                var title = movie.Title;
                resultMessage.AppendLine($"Successfully imported projection {title} on {currentProjection.DateTime.ToString("MM/dd/yyyy")}!");
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();
            return resultMessage.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var deserializedCustomers = (ImportCustomerDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Customer> customers = new List<Customer>();
            StringBuilder resultMessage = new StringBuilder();

            foreach (var customer in deserializedCustomers)
            {
                if (!IsValid(customer))
                {
                    resultMessage.AppendLine(ErrorMessage);
                    continue;
                }

                var currentCustomer = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Age = customer.Age,
                    Balance = customer.Balance,
                };

                bool invalidTicket = false;
                foreach (var ticket in customer.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        resultMessage.AppendLine(ErrorMessage);
                        invalidTicket = true;
                        break; ;
                    }

                    else
                    {
                        currentCustomer.Tickets.Add(new Ticket
                        { ProjectionId = ticket.ProjectionId, Price = ticket.Price });
                    }
                }

                if (!invalidTicket)
                {
                    customers.Add(currentCustomer);
                    resultMessage.AppendLine($"Successfully imported customer {currentCustomer.FirstName} {currentCustomer.LastName} with bought tickets: {currentCustomer.Tickets.Count()}!");
                }
            }
            context.Customers.AddRange(customers);
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