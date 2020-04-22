using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Library.Data;

namespace Library.FullClient.ViewModel
{
    public class MaintenanceFormViewModel : INotifyPropertyChanged
    {
        private LibraryModel model = new LibraryModel();
        public ICommand AddBookCommand { get; private set; }
        public ICommand BorrowCommand { get; private set; }
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
            this.AddBookCommand = new RelayCommand(
                action => this.AddNewBook());
            this.BorrowCommand = new RelayCommand(
                action => this.AddRentBook());
            this.OdswiezRentedBooks();
        }

        private void OdswiezBooks()
        {
            // this.Zawody -> wywoluje Zawody.set{...} oraz OnPropertyChanged
            this.Books = null;
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

        private IEnumerable<Book> rentedBooks;
        public IEnumerable<Book> RentedBooks
        {
            get
            {
                return this.rentedBooks;
            }
            set
            {
                this.rentedBooks = value;
                this.OnPropertyChanged(nameof(RentedBooks));
            }
        }
        private Reader selectedReader;
        public Reader SelectedReader
        {
            get
            {
                return this.selectedReader;
            }
            set
            {
                this.selectedReader = value;
                this.OnPropertyChanged(nameof(SelectedReader));
                this.OdswiezRentedBooks();
                
            }
        }
        private void OdswiezRentedBooks()
        {
          
            Reader roboczy = (from Reader item in Readers
                              where item == SelectedReader
                              select item).FirstOrDefault();
            this.RentedBooks = null;
            if (roboczy != null) { 
            
                this.RentedBooks = roboczy.Books;
            
            }
            //this.RentedBooks = roboczy.Books;
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
        // adding new book module
        private int idRoboczy;
        public int IdRoboczy
        {
            get { return idRoboczy; }
            set
            {
                idRoboczy = value;
                this.OnPropertyChanged(nameof(IdRoboczy));
            }
        }

        private string authorRoboczy;
        public string AuthorRoboczy
        {
            get { return authorRoboczy; }
            set
            {
                authorRoboczy = value;
                this.OnPropertyChanged(nameof(AuthorRoboczy));
            }
        }

        //pobiera text z textboxa AddTitle
        private string titleRoboczy;
        public string TitleRoboczy
        {
            get { return titleRoboczy; }
            set
            {
                titleRoboczy = value;
                this.OnPropertyChanged(nameof(TitleRoboczy));
            }
        }
        public void AddNewBook()
        {
            model.AddBook(IdRoboczy, TitleRoboczy, AuthorRoboczy);
        }

        // adding new addtorent module

        private int idRent;
        public int IdRent
        {
            get
            {
                return idRent;
            }
            set
            {
                idRent = value;
                this.OnPropertyChanged(nameof(IdRent));

            }
        }

        private int idReaderRent;
        public int IdReaderRent
        {
            get
            { 
                return idReaderRent;
            }
            set 
            {
                idReaderRent = value;
                this.OnPropertyChanged(nameof(IdReaderRent));
            }
        }

        public void AddRentBook()
        {
            model.BorrowBook(IdRent, IdReaderRent);
            this.OnPropertyChanged(nameof(Books));
            this.OdswiezBooks();
            this.OdswiezRentedBooks();


        }

    }

}

