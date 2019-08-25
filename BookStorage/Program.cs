using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Service;
using BookStorage.Storage;
using BookStorage.Models;
using BookStorage.Interfaces;

namespace BookStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            IStorage<Book> storage = new BookListStorage("test.bin");
            IService service = new BookListService(storage);

            ToConsole(service.GetAllBooks());

            service.AddBook(new Book("978-3-16-123451-10", "test", "test", "test", 2152, 1264, 1111));

            ToConsole(service.GetAllBooks());

            ToConsole(service.FindBookByTag(service.GetAllBooks(),"name","test"));

            ToConsole(service.SortBooksByTag(service.GetAllBooks(), "author"));

            Console.ReadLine();

        }

        public static void ToConsole(List<Book> books)
        {
            foreach (var book in books)
                    Console.WriteLine(book);
            Console.WriteLine();
        }
        public static void ToConsole(Book book)
        {
            Console.WriteLine(book);
            Console.WriteLine();
        }
    }
}
