using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Models;
using BookStorage.Interfaces;

namespace BookStorage.Service
{
    class BookListService: IService
    {
        private IStorage<Book> bookStorage;
        private List<Book> books = new List<Book>();


        public BookListService(IStorage<Book> bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }

            books.Add(book);
            bookStorage.AppendToFile(book);
        }

        public Book FindBookByTag(List<Book> books,string tag,string parameter)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException();
            return Finder(books, tag, parameter);
        }

        private Book Finder (List<Book> books, string tag, string parameter)
        {
            foreach (var book in books)
            {
                switch (tag.ToLower())
                {
                    case "name":
                        if (book.Name == parameter)
                            return book;
                        break;
                    case "author":
                        if (book.Author == parameter)
                            return book;
                        break;
                    case "isbn":
                        if (book.ISBN == parameter)
                            return book;
                        break;
                    case "year":
                        if (book.YearOfPublish.ToString() == parameter)
                            return book;
                        break;
                    case "pages":
                        if (book.CountOfPages.ToString() == parameter)
                            return book;
                        break;
                    case "price":
                        if (book.Price.ToString() == parameter)
                            return book;
                        break;
                    default: throw new ArgumentException();
                }
            }
            throw new ArgumentOutOfRangeException();
        }

        public List<Book> GetAllBooks()
        {
            return bookStorage.Read();
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }

        public List<Book> SortBooksByTag(List<Book> books, string tag)
        {
            if (string.IsNullOrEmpty(tag))
                throw new ArgumentNullException();
            switch (tag.ToLower())
            {
                case "name": return books.OrderBy(x => x.Name).ToList();
                case "author": return books.OrderBy(x => x.Author).ToList();
                case "isbn": return books.OrderBy(x => x.ISBN).ToList();
                case "year": return books.OrderBy(x => x.YearOfPublish).ToList();
                case "pages": return books.OrderBy(x => x.CountOfPages).ToList();
                case "price": return books.OrderBy(x => x.Price).ToList();
                default: throw new ArgumentException();
            }
                
        }
    }
}
