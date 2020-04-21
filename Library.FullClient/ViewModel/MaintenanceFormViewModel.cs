using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;

namespace Library.FullClient.ViewModel
{
    public class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        private LibraryModel model = new LibraryModel();
        public MaintenanceFormViewModel() 
        {
            Task.Run(() => Init());
        }
        
        internal void Init()
        {
            this.PrzykladoweBooks();
            this.OdswiezBooks();
            this.PrzykladoweReaders();
            this.OdswiezReaders();
        }

        private void OdswiezBooks()
        {
            // this.Zawody -> wywoluje Zawody.set{...} oraz OnPropertyChanged
            this.Books = model.ListBooks;
        }

        
        internal void PrzykladoweBooks()
        {
            model.AddBook(1, "Pan Tadeusz", "Adam Mickiewicz");
            model.AddBook(2, "Potop", "Henryk Sienkiewicz");
            model.AddBook(3, "Pan Samochodzik", "Zbigniew Nienacki");
        }

        private void OdswiezReaders()
        {
            this.Readers = model.ListReaders;

        }

        internal void PrzykladoweReaders()
        {
            model.AddReader(1, "Marcin", "Wolkowicz");
            model.AddReader(2, "Iwona", "Wolkowicz");
            model.AddReader(3, "Franek", "Wolkowicz");
            model.AddReader(4, "Łucja", "Wolkowicz");
        }
        private IEnumerable<Book> books;
        public IEnumerable<Book> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books = value;
                this.OnPropertyChanged(nameof(Books));

            }
        }

        private IEnumerable<Reader> readers;
        public IEnumerable<Reader> Readers
        {
            get
            {
                return this.readers;
            }
            set
            {
                this.readers = value;
                this.OnPropertyChanged(nameof(Reader));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            /*
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            */
            // C# 6.0:
            this.PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(propertyName));

        }
    

    }

}

