using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public class BookDetail
    {
        //ONE TO ONE RELATİON
        public int BookDetailId { get; set; }

        //foreign key-unique olmalı
        public int BookId { get; set; }
        //navigation property
        public Book Book { get; set; }
        public string ISSN { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }

    }
}
