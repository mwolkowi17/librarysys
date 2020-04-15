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
    }
}
