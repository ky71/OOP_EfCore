using ConsoleApp.DAL.Mapping;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAL
{
    public class BookAppDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BookAppDb;Integrated Security=True;");
        }

        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options)
        {
        }
        public BookAppDbContext() { }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasKey(b => b.BookId); //Fluent API kullanarak primary key belirleme ///BookMap de yazdık 
            //modelBuilder.Entity<Book>().Property(b => b.Title)//Flurent API kullanarak Title property'si için kısıtlamalar belirleme
            //                           .IsRequired()
            //                           .HasMaxLength(150);
            modelBuilder.ApplyConfiguration(new BookMap()); 
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new BookDetailMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new BookAuthorMap());



        }

    }
    //veri tabanından direk northwind gibi hazır classları direk hiç upraşmadan oluşturman için
    //PM ye yaz: Scaffold-DbContex -Connection "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=BookAppDb;" -Provider "Microsoft.EntityFrameworkCore.SqlServer" -OutputDir "DAL\Entities"     


}
