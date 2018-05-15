using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberLines = int.Parse(Console.ReadLine());
            List<Book> bookList = new List<Book>();

            for (int i = 0; i < numberLines; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();
                Book inputBook = new Book();
                inputBook.Title = input[0];
                inputBook.Autor = input[1];
                inputBook.Publisher = input[2];
                inputBook.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                inputBook.IBSNnumber = input[4];
                inputBook.Price = double.Parse(input[5]);
                bookList.Add(inputBook);
            }
            Library MyLibrary = new Library();
            MyLibrary.ListBooks = bookList;

            foreach (var pair in MyLibrary.ListBooks.GroupBy(x => x.Autor).OrderByDescending(x => x.Sum(y => y.Price))
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Sum(x => x.Price):f2}");
            }
        }
    }
}
