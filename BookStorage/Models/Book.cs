using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Models
{
    class Book: IEquatable<Book>, IComparable,IComparable<Book>, IFormattable
    {
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublish { get; set; }
        public int CountOfPages { get; set; }
        public int Price { get; set; }

        public Book (string isbn, string author, string name, string publishingHouse, int yearOfPublish, int countOfPages, int price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.PublishingHouse = publishingHouse;
            this.CountOfPages = countOfPages;
            this.Price = price;
        }

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
            return ISBN == book.ISBN && Author == book.Author && Name == book.Name
                   && PublishingHouse == book.PublishingHouse && YearOfPublish == book.YearOfPublish && CountOfPages == book.CountOfPages;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null)) return 1;
            var book = (Book)obj;
            return CompareTo(book);
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return string.Compare(Name, other.Name);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "6";


            switch (format)
            {
                case "1": return "Book: " + Name + " Author: " + Author;
                case "2": return "Book: " + Name + " Author: " + Author + " ISBN: " + ISBN;
                case "3": return "Book: " + Name + " Author: " +  Author + " y. " + YearOfPublish + " ISBN: " + ISBN;
                case "4": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN;
                case "5": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN + " Publishing House : " + PublishingHouse;
                case "6": return "Book: " + Name + " Author: " + YearOfPublish + " y. " + CountOfPages + " p. " + Author + " ISBN: " + ISBN + " Publishing House : " + PublishingHouse + Price + " y.e ";
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public override string ToString()
        {
            return ToString("6",null);
        }

        public override bool Equals(object obj)
        {
            var book = (Book)obj;
            if (book == null)
                return false;

            return ISBN == book.ISBN && Author == book.Author && Name == book.Name
                   && PublishingHouse == book.PublishingHouse && YearOfPublish == book.YearOfPublish && CountOfPages == book.CountOfPages;
        }

        public override int GetHashCode()
        {
            return (ISBN + Author + Name + PublishingHouse + CountOfPages + Price).GetHashCode();
        }
    }
}
