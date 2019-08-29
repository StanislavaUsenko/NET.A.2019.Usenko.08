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
