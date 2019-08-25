using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Models;

namespace BookStorage.Interfaces
{
    interface IService
    {
        void AddBook(Book book);

        void RemoveBook(Book book);

        Book FindBookByTag(List<Book> books, string tag, string parameter);

        List<Book> SortBooksByTag(List<Book> books, string tag);

        List<Book> GetAllBooks();
    }
}
