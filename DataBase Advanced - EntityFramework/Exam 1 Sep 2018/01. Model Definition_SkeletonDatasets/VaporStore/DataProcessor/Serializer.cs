namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.DTOs.ExportDtos;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genresAndGames = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games
                    .Where(y => y.Purchases.Any())
                    .Select(y => new
                    {
                        Id = y.Id,
                        Title = y.Name,
                        Developer = y.Developer.Name,
                        Tags = (string.Join(", ", y.GameTags.Select(z => z.Tag.Name))),
                        Players = y.Purchases.Count()
                    })
                    .OrderByDescending(y => y.Players)
                    .ThenBy(y => y.Id)
                    .ToList(),
                    TotalPlayers = x.Games.Sum(y => y.Purchases.Count())
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToList();

            string result = JsonConvert.SerializeObject(genresAndGames, Newtonsoft.Json.Formatting.Indented);
            return result;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var type = (PurchaseType)Enum.Parse(typeof(PurchaseType), storeType);

            var users = context.Users
                .Select(x => new ExportUserDto
                {
                    UserName = x.Username,
                    PurchaseExportDto = x.Cards
                    .SelectMany(y => y.Purchases)
                    .Where(t => t.Type == type)
                    .Select(y => new PurchaseExportDto
                    {
                        Card = y.Card.Number,
                        Cvc = y.Card.Cvc,
                        Date = y.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = y.Game.Name,
                            Genre = y.Game.Genre.Name,
                            Price = y.Game.Price
                        }
                    })
                    .OrderBy(y => y.Date)
                    .ToArray(),
                     TotalSpent = x.Cards.SelectMany(z => z.Purchases)
                        .Where(z => z.Type == type)
                        .Sum(p => p.Game.Price)
                })
                .Where(p => p.PurchaseExportDto.Any())
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.UserName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces
            (
                new[] { new XmlQualifiedName("", "") }
            );

            StringBuilder result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), users, namespaces);

            return result.ToString().TrimEnd();
        }
    }
}