using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Data.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_EmptyCollection()
        {
            LibraryModel model = new LibraryModel();
            Assert.AreEqual(0, model.ListBooks.Count);
            Assert.AreEqual(0, model.ListReaders.Count);
        }

        [TestMethod]
        public void Test_AddingBook()
        {
            LibraryModel model = new LibraryModel();
            Book testbook = model.AddBook(1, "Pan Tadeusz", "Adam Mickiewicz");
            Assert.AreEqual(1, model.ListBooks.Count);
        }

        [TestMethod]
        public void Test_AddingReader()
        {
            LibraryModel model = new LibraryModel();
            Reader testreader = model.AddReader(1, "Iwona", "Wołkowicz");
            Assert.AreEqual(1, model.ListReaders.Count);
            Assert.AreSame(testreader, model.ListReaders[0]);
        }

        [TestMethod]
        public void Test_BorrowBook()
        {
            LibraryModel model = new LibraryModel();
            Book testbook = model.AddBook(1, "Pan Tadeusz", "Adam Mickiewicz");
            Reader testreader = model.AddReader(1, "Marcin", "Wołkowicz");
            model.BorrowBook(1, 1);
            Assert.AreEqual(true, testbook.Rented);
            Assert.AreEqual(1, testreader.Books.Count);
        }

        [TestMethod]
        public void Test_DropOffBook()
        {

            LibraryModel model = new LibraryModel();
            Book testbook = model.AddBook(1, "Pan Tadeusz", "Adam Mickiewicz");
            Reader testreader = model.AddReader(1, "Marcin", "Wołkowicz");
            model.BorrowBook(1, 1);
            model.DropOffBook(1);
            Assert.AreEqual(0, testreader.Books.Count);
        }

        [TestMethod]
        public void Test_RemoveReader()
        {
            LibraryModel model = new LibraryModel();
            Reader testreader = model.AddReader(1, "Marcin", "Wołkowicz");
            model.RemoveReader(1);
            Assert.AreEqual(0, model.ListReaders.Count);
        }

    }

}
