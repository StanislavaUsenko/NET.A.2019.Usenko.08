using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStorage.Interfaces;
using BookStorage.Models;


namespace BookStorage.Storage
{
    class BookListStorage : IStorage<Book>
    {
        private readonly string path;

        public BookListStorage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Incorrect");
            }

            this.path = path;
        }
        

        public List<Book> Read()
        {
            List<Book> books = new List<Book>();
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var book = Reader(binaryReader);
                    books.Add(book);
                }
            }

            return books;
        }

        public void Write(List<Book> obj)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                foreach (var book in obj)
                {
                    Writer(binaryWriter, book);
                }
            }
        }
        public void AppendToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }



        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.ISBN);
            binary.Write(book.Author);
            binary.Write(book.Name);
            binary.Write(book.PublishingHouse);
            binary.Write(book.YearOfPublish);
            binary.Write(book.Price);
            binary.Write(book.CountOfPages);
        }

        private static Book Reader(BinaryReader binary)
        {
            var isbn = binary.ReadString();
            var author = binary.ReadString();
            var name = binary.ReadString();
            var publish = binary.ReadString();
            var year = binary.ReadInt32();
            var price = binary.ReadInt32();
            var pages = binary.ReadInt32();

            return new Book(isbn, author, name, publish, year, price, pages);
        }
    }
}
