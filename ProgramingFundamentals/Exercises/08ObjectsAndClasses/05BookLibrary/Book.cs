using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05BookLibrary
{
    class Book
    {
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IBSNnumber { get; set; }
        public double Price { get; set; }
    }
    class Library
    {
        public string Name { get; set; }
        public List<Book> ListBooks { get; set; }
    }
}
