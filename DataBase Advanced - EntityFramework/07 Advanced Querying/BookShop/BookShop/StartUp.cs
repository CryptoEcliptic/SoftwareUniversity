namespace BookShop
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                //int command = int.Parse(Console.ReadLine());
                IncreasePrices(db);

                //Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string formattedCommand = command.First().ToString().ToUpper() + command.Substring(1).ToLower();
            var restrictedBooks = context.Books
                .Where(x => x.AgeRestriction.ToString() == formattedCommand)
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in restrictedBooks)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType.ToString() == "Gold")
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in goldenBooks)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksWithPriceOverFoutry = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new { x.Title, x.Price })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksWithPriceOverFoutry)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var title in books)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputargs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<int> categoryIds = new List<int>();

            foreach (var item in inputargs)
            {
                string formattedInput = item.First().ToString().ToUpper() + item.Substring(1).ToLower();
                var categotyId = context.Categories
                   .Where(x => x.Name == formattedInput)
                   .Select(x => x.CategoryId);

                categoryIds.AddRange(categotyId);
            }

            List<string> result = new List<string>();

            for (int i = 0; i < categoryIds.Count; i++)
            {
                var books = context.Books
                    .Include(x => x.BookCategories)
                    .Where(x => x.BookCategories.Any(y => y.CategoryId == categoryIds[i]))
                    .OrderBy(x => x.Title)
                    .Select(x => x.Title)
                    .ToList();
                result.AddRange(books);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var title in result.OrderBy(x => x))
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();

        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime formattedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < formattedDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new { x.Title, x.Price, x.EditionType })
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => (x.FirstName + ' ' + x.LastName))
                .OrderBy(x => x)
                .ToList();

            return String.Join(Environment.NewLine, authors);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .ToList();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    x.Author.FirstName,
                    x.Author.LastName
                })
                .ToList();

            string result = String.Join(Environment.NewLine, books.Select(x => $"{x.Title} ({x.FirstName} {x.LastName})"));

            return result;
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList();

            int countBooks = books.Count();

            return countBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorCopies = context.Authors
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    bookCopies = x.Books.Sum(y => y.Copies)
                })
                .OrderByDescending(x => x.bookCopies)
                .ToList();

            return string.Join(Environment.NewLine, authorCopies.Select(x => $"{x.FirstName} {x.LastName} - {x.bookCopies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryProfit = context.Categories
                .Select(x => new
                {
                    x.Name,
                    profit = x.CategoryBooks.Sum(y => y.Book.Price * y.Book.Copies)
                })
                .OrderByDescending(x => x.profit)
                .ToList();

            return String.Join(Environment.NewLine, categoryProfit.Select(x => $"{x.Name} ${x.profit:f2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var genres = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    books = x.CategoryBooks
                    .Select(y => new
                    {
                        y.Book.Title,
                        y.Book.ReleaseDate
                    })
                    .OrderByDescending(w => w.ReleaseDate)
                    .ToList()
                })
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var category in genres)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.books.Take(3))
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var bookPrices = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in bookPrices)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();
            int count = booksToRemove.Count();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return count;
        }            
    }
}
