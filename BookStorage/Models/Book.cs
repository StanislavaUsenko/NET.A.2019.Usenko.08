using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Models
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="publishingHouse"></param>
        /// <param name="yearOfPublish"></param>
        /// <param name="countOfPages"></param>
        /// <param name="price"></param>
        public Book(string isbn, string author, string name, string publishingHouse, int yearOfPublish, int countOfPages, int price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.PublishingHouse = publishingHouse;
            this.CountOfPages = countOfPages;
            this.YearOfPublish = yearOfPublish;
            this.Price = price;
        }

        /// <summary>
        /// identity code for book
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// who write book
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// name of the book
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// who publish this book
        /// </summary>
        public string PublishingHouse { get; private set; }

        /// <summary>
        /// year of publish
        /// </summary>
        public int YearOfPublish { get; private set; }

        /// <summary>
        /// count of pages
        /// </summary>
        public int CountOfPages { get; private set; }

        /// <summary>
        /// price of the book
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// returns a value indicating whether the given instance is equal to the given object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }

            if (ReferenceEquals(this, book))
            {
                return true;
            }

            return ISBN == book.ISBN && Author == book.Author && Name == book.Name && PublishingHouse == book.PublishingHouse && YearOfPublish == book.YearOfPublish && CountOfPages == book.CountOfPages;
        }

        /// <summary>
        /// compares this instance  with the given object and returns a value indicating  how the values of these objects relate
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            var book = (Book)obj;
            return CompareTo(book);
        }

        /// <summary>
        /// compares this instance  with the given object and returns a value indicating  how the values of these objects relate
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            return string.Compare(Name, other.Name);
        }

        /// <summary>
        /// Convert object to string format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "6";
            }

            switch (format)
            {
                case "1": return "Book: " + Name + " Author: " + Author;
                case "2": return "Book: " + Name + " Author: " + Author + " ISBN: " + ISBN;
                case "3": return "Book: " + Name + " Author: " + Author + " y. " + YearOfPublish + " ISBN: " + ISBN;
                case "4": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN;
                case "5": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN + " Publishing House : " + PublishingHouse;
                case "6": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN + " Publishing House : " + PublishingHouse + " " + Price + " y.e ";
                default: throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }

        /// <summary>
        /// convert object to string format
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString("6", null);
        }

        /// <summary>
        /// returns a value indicating whether the given instance is equal to the given object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var book = (Book)obj;
            if (book == null)
            {
                return false;
            }

            return ISBN == book.ISBN && Author == book.Author && Name == book.Name
                   && PublishingHouse == book.PublishingHouse && YearOfPublish == book.YearOfPublish && CountOfPages == book.CountOfPages;
        }

        /// <summary>
        /// returns hash of this instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (ISBN + Author + Name + PublishingHouse + CountOfPages + Price).GetHashCode();
        }
    }
}
