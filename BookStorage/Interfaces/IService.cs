using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Models;

namespace BookStorage.Interfaces
{
    internal interface IService
    {
        /// <summary>
        /// add book into collection
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Book book);

        /// <summary>
        /// delete object from collection 
        /// </summary>
        /// <param name="book"></param>
        void RemoveBook(Book book);

        /// <summary>
        /// find object in collection by tag
        /// </summary>
        /// <param name="books"> collection of objects</param>
        /// <param name="tag">by what we find</param>
        /// <param name="parameter"> what we find</param>
        /// <returns>object</returns>
        Book FindBookByTag(List<Book> books, string tag, string parameter);

        /// <summary>
        /// sorting collection
        /// </summary>
        /// <param name="books">collection of objects</param>
        /// <param name="tag">by what we sorting</param>
        /// <returns>list of objects</returns>
        List<Book> SortBooksByTag(List<Book> books, string tag);

        /// <summary>
        /// get all objects from storage
        /// </summary>
        /// <returns>list of objects</returns>
        List<Book> GetAllBooks();
    }
}
