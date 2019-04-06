namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.DTOs.ImportDtos;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
            var gamesJson = JsonConvert.DeserializeObject<GameImportDto[]>(jsonString);

            List<Game> gamesList = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            StringBuilder sb = new StringBuilder();
            
            foreach (var game in gamesJson)
            {
                if (!IsValid(game) || game.Tags.Count == 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }


                var developer = developers.FirstOrDefault(x => x.Name == game.Developer);

                if (developer == null)
                {
                    developer = new Developer { Name = game.Developer };
                    developers.Add(developer);
                }


                var genre = genres.FirstOrDefault(x => x.Name == game.Genre);

                if (genre == null)
                {
                    genre = new Genre { Name = game.Genre };
                    genres.Add(genre);
                }

                List<Tag> currentTags = new List<Tag>();
                foreach (var t in game.Tags)
                {
                    var tag = tags.FirstOrDefault(x => x.Name == t);

                    if (tag == null)
                    {
                        tag = new Tag { Name = t };
                        tags.Add(tag);
                    }
                    currentTags.Add(tag);
                }

                var currentGame = new Game
                {
                    Name = game.Name,
                    Price = game.Price,
                    ReleaseDate = DateTime.ParseExact(game.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var t in currentTags)
                {
                    currentGame.GameTags.Add(new GameTag { Tag = t });
                }

                gamesList.Add(currentGame);
                sb.AppendLine($"Added {currentGame.Name} ({currentGame.Genre.Name}) with {currentGame.GameTags.Count} tags");
            }

            context.Games.AddRange(gamesList);
            //context.Tags.AddRange(tags);
            //context.Developers.AddRange(developers);
            //context.Genres.AddRange(genres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
            var usersJson = JsonConvert.DeserializeObject<UserImportDto[]>(jsonString);

            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();

            StringBuilder sb = new StringBuilder();

            foreach (var user in usersJson)
            {
                if (!IsValid(user))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

  
                var currentUser = new User
                {
                    FullName = user.FullName,
                    Username = user.Username,
                    Age = user.Age,
                    Email = user.Email
                };

                foreach (var card in user.Cards)
                {
                    var currentCardType = (CardType)Enum.Parse(typeof(CardType), card.Type);
                    var currentCard = new Card
                    {
                        Number = card.Number,
                        Cvc = card.Cvc,
                        Type = currentCardType,

                    };

                    cards.Add(currentCard);
                    currentUser.Cards.Add(currentCard);
                }
                sb.AppendLine($"Imported {currentUser.Username} with {user.Cards.Count()} cards");
                users.Add(currentUser);
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
            var serializer = new XmlSerializer(typeof(PurchaseImportDto[]), new XmlRootAttribute("Purchases"));

            var deserializedPurchasess = (PurchaseImportDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Purchase> purchases = new List<Purchase>();

            StringBuilder sb = new StringBuilder();
            foreach (var purchase in deserializedPurchasess)
            {
                var game = context.Games.FirstOrDefault(x => x.Name == purchase.Title);
                bool isValidType = Enum.IsDefined(typeof(PurchaseType), purchase.Type);
                var card = context.Cards.FirstOrDefault(x => x.Number == purchase.Card);

                if (!IsValid(purchase) || game == null || !isValidType || card == null)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var currentPurchase = new Purchase
                {
                    Game = game,
                    ProductKey = purchase.ProductKey,
                    Date = DateTime.ParseExact(purchase.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = (PurchaseType)Enum.Parse(typeof(PurchaseType), purchase.Type),
                    Card = card
                };
                purchases.Add(currentPurchase);

                sb.AppendLine($"Imported {currentPurchase.Game.Name} for {currentPurchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, results, true);
        }
    }
}