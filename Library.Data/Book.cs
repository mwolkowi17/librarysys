using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Rented { get; set; }
        public int ReaderID { get; set; }
        public int DateofRent { get; set; }
        public int DateofReturn { get; set; }

        public Book(int id, string title, string author)
        {
            BookID = id;
            Title = title;
            Author = author;
        }
    }
}
