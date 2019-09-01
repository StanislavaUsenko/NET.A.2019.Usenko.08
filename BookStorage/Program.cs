using System;
using System.Collections.Generic;
using BookStorage.Interfaces;
using BookStorage.Models;
using BookStorage.Service;
using BookStorage.Storage;

namespace BookStorage
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Book bookForTest = new Book("978-0-141-34844-5", "Rebecca Donovan", "reason to breathe", "Pinguin Books", 2012, 531, 8);
            IFormatProvider formatProvider = new BookFormatter();

            Console.WriteLine(String.Format(new BookFormatter(), "{0:all}", bookForTest));
            Console.WriteLine(String.Format(new BookFormatter(), "{0:nameauthor}", bookForTest));
            Console.WriteLine(String.Format(new BookFormatter(), "{0:nameauthoryearpages}", bookForTest));
            Console.WriteLine(String.Format(new BookFormatter(), "{0:isbn}", bookForTest));
            Console.WriteLine(String.Format(new BookFormatter(), "{0:price}", bookForTest));
            Console.WriteLine(String.Format(new BookFormatter(), "{0}", bookForTest));

            //Console.WriteLine(bookForTest.ToString("2", ));
            //Console.WriteLine(bookForTest.ToString("3", ));
            //Console.WriteLine(bookForTest.ToString("4", ));
            //Console.WriteLine(bookForTest.ToString("5",  ));
            //Console.WriteLine(bookForTest.ToString("6", ));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("______________________________________________________________________");

            IStorage<Book> storage = new BookListStorage("test.bin");
            IService service = new BookListService(storage);

            ToConsole(service.GetAllBooks());

            service.AddBook(new Book("978-3-16-123451-10", "test", "test", "test", 2152, 1264, 1111));

            ToConsole(service.GetAllBooks());

            ToConsole(service.FindBookByTag(service.GetAllBooks(), "name", "test"));

            ToConsole(service.SortBooksByTag(service.GetAllBooks(), "author"));

            Console.ReadLine();
        }

        private static void ToConsole(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
        }

        private static void ToConsole(Book book)
        {
            Console.WriteLine(book);
            Console.WriteLine();
        }
    }
}
