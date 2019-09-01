using NUnit.Framework;
using BookStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Models.Tests
{
    [TestFixture()]
    public class BookTests
    {
        private readonly Book book = new Book("978-0-141-34844-5", "Rebecca Donovan", "reason to breathe", "Pinguin Books", 2012, 531, 8);

        [TestCase("1", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan")]
        [TestCase("2", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan ISBN: 978-0-141-34844-5")]
        [TestCase("3", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan y. 2012 ISBN: 978-0-141-34844-5")]
        [TestCase("4", ExpectedResult = "Book: reason to breathe Author: 2012 y. 531 p.Rebecca Donovan ISBN: 978-0-141-34844-5")]
        [TestCase("5", ExpectedResult = "Book: reason to breathe Author: 2012 y. 531 p.Rebecca Donovan ISBN: 978-0-141-34844-5 Publishing House : Pinguin Books")]
        [TestCase("6", ExpectedResult = "Book: reason to breathe Author: 2012 y. 531 p.Rebecca Donovan ISBN: 978-0-141-34844-5 Publishing House : Pinguin Books 8 y.e")]
        public string ToStringTest(string format) => book.ToString(format, null);

        [TestCase("{0:all}", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan 2012 y. 531 p.ISBN: 978-0-141-34844-5 Publishing House : Pinguin Books 8 y.e")]
        [TestCase("{0:nameauthor}", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan")]
        [TestCase("{0:nameauthoryearpages}", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan 2012 y. 531 p.")]
        [TestCase("{0:isbn}", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan ISBN: 978-0-141-34844-5")]
        [TestCase("{0:price}", ExpectedResult = "Book: reason to breathe Author: Rebecca Donovan 8 y.e")]
        [TestCase("{0}", ExpectedResult = "Book: reason to breathe Author: 2012 y. 531 p.Rebecca Donovan ISBN: 978-0-141-34844-5 Publishing House : Pinguin Books 8 y.e")]
        public string ToStringFormatTest(string format) => String.Format(new BookFormatter(), format, book);
        
            
            
            
           
            
            

    }
}