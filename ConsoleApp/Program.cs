using ConsoleApp.DAL;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

//var _contex = new BookAppDbContext();
//var category= _contex.Categories.Where(c=> c.CategoryId==3).SingleOrDefault();
//_contex.Categories.Remove(category);
//_contex.SaveChanges();
using (var _context = new BookAppDbContext())
{
    var book = new Book { 
        Title = "Son Ornek Kitap", 
        Price = 55, 
        Category = _context.Categories.OrderBy(c => c.CategoryId).FirstOrDefault(),
        BookDetail=new BookDetail
        {
             City="Kırıkkale",
             Country= "Turkey",
             ISSN="2222-2222-2222"
             
        }
    
    };

    _context.Books.Add(book);
    _context.SaveChanges();
    ListOfBook();
}


static void AddBook()
{
    var book = new Book { Title = "Ef Core", Price = 105 };

    using (var _context = new BookAppDbContext())
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }
}

static void AddBooks()
{
    var list = new List<Book> {
    new Book { Title = "Tutunamayanlar", Price = 25 },
    new Book { Title = "Ef core2", Price = 90 },
    new Book { Title = "Tutunamayanlar-2", Price = 100 },
    new Book { Title = "Tutunamayanlar-3", Price = 50 },
    new Book { Title = "Tutunamayanlar-4", Price = 30 }

    };
    using (var _context = new BookAppDbContext())
    {
        _context.Books.AddRange(list);
        _context.SaveChanges();
    }
}

static void ListOfBook()
{
    var list = new List<Book>();
    using (var _context = new BookAppDbContext())
    {
        list = _context.Books.Include(b=>b.Category).ToList();
        foreach (var item in list)
        {
            Console.WriteLine($" {item.BookId,-5} {item.Title,-25} {item.Price,+10} {item.Category?.CategoryName ?? "Category null",-20}");
        }

    }
}

static void UpdateBook()
{
    using (var _context = new BookAppDbContext())
    {
        var book = _context.Books.OrderBy(b => b.BookId).FirstOrDefault();
        book.Title = "Updated Book";
        book.Price = 50;



        _context.SaveChanges();
        ListOfBook();
    }
}

static void DeleteBook()
{
    using (var _context = new BookAppDbContext())
    {
        var book = _context.Books.OrderBy(b => b.BookId).LastOrDefault();
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}

static void AddBookWithCategory()
{
    var book = new Book { Title = "Software Engineering", Price = 1000, Category = new Category { CategoryName = "Engineering" } };

    using (var _context = new BookAppDbContext())
    {
        _context.Books.Add(book);
        _context.SaveChanges();

        ListOfBook();
        Console.WriteLine(new String('-', 20));
        _context.Categories.ToList().ForEach(c => Console.WriteLine(c.CategoryName));
    }
}