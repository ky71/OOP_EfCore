using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public class Book
    {
        //[Key]
        public int BookId { get; set; }
        //[Required] //gerekli data annatotion çok tercih edilen bir yöntem değil
        //[MaxLength(50)]
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; } //foreign key
        public Category Category { get; set; } // simple navigation property
        public BookDetail BookDetail { get; set; } // navigation property

        //collectioon navigation property
        public ICollection<BookAuthor> BookAuthors { get; set; }





    }
}
