using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Models
{
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null)
                try
                {
                    return HandleOtherFormats(format, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                }
            format = format.ToLower();

            Book book = (Book)arg;

            switch (format)
            {
                case "all":
                    return "Book: " + book.Name + " Author: " + book.Author + " " + book.YearOfPublish + " y. " + book.CountOfPages + " p. "  + " ISBN: " + book.ISBN + " Publishing House : " + book.PublishingHouse + " " + book.Price + " y.e ";
                case "nameauthor":
                    return "Book: " + book.Name + " Author: " + book.Author;
                case "nameauthoryearpages":
                    return "Book: " + book.Name + " Author: " + book.Author + " " + book.YearOfPublish + " y. " + book.CountOfPages + " p. ";
                case "isbn":
                    return "Book: " + book.Name + " Author: " + book.Author + " ISBN: " + book.ISBN;
                case "price":
                    return "Book: " + book.Name + " Author: " + book.Author + " " + book.Price + " y.e ";
                default:
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
