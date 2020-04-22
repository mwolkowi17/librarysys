using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class LibraryModel
    {
        private ObservableCollection<Book> listBooks;
        private ObservableCollection<Reader> listReaders;

        public LibraryModel()
        {
            this.listBooks = new ObservableCollection<Book>();
            this.listReaders = new ObservableCollection<Reader>();
        }

        public ObservableCollection<Book> ListBooks
        {
            get { return listBooks; }
        }

        public ObservableCollection<Reader> ListReaders
        {
            get { return listReaders; }
        }

        public Book AddBook(int bookid,string title, string author)
        {
            Book newbook = new Book(bookid, title, author)
            {
                BookID = bookid,
                Title = title,
                Author = author
            };

            listBooks.Add(newbook);

            return newbook;
        }

        public Reader AddReader(int readerid, string name, string surname)
        {
            Reader newreader = new Reader(readerid, name, surname)
            {
                ReaderID = readerid,
                Name = name,
                Surname = surname
            };

            listReaders.Add(newreader);

            return newreader;
        }

        public Book BorrowBook(int bookid, int readerid)
        {
            Book wantedbook = (from Book item in listBooks
                               where item.BookID == bookid
                               select item).FirstOrDefault();

            Reader readercustomer = (from Reader item in listReaders
                                     where item.ReaderID == readerid
                                     select item).FirstOrDefault();

            wantedbook.Rented = true;
            wantedbook.ReaderID = readercustomer.ReaderID;
            if (readercustomer.Books == null)
            {
                readercustomer.Books = new List<Book>();
            }
            readercustomer.Books.Add(wantedbook);

            return wantedbook;
        }

        public Book DropOffBook(int bookid)
        {
            Book wantedbook = (from Book item in listBooks
                               where item.BookID == bookid
                               select item).FirstOrDefault();

            Reader readercustomer = (from Reader item in listReaders
                                     where item.ReaderID == wantedbook.ReaderID
                                     select item).FirstOrDefault();
            wantedbook.Rented = false;
            readercustomer.Books.Remove(wantedbook);

            return wantedbook;

        }

        public Reader RemoveReader ( int readerid)
        {
            Reader removedreader = (from Reader item in listReaders
                                    where item.ReaderID == readerid
                                    select item).FirstOrDefault();
            
            
                listReaders.Remove(removedreader);
            
            

            return removedreader;
        }

    }
}
