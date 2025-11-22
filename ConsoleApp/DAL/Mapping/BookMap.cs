using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DAL.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId); // Fluent API kullanarak primary key belirleme
            builder.Property(b => b.Title) // Fluent API kullanarak Title property'si için kısıtlamalar belirleme
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(b => b.CreatedDate)
                    .HasDefaultValueSql("GETDATE()"); // Varsayılan değer olarak mevcut tarihi ayarlama
            
            builder.HasData(
                new Book { BookId = 1, Title = "Sample Book 1", CategoryId=2},
                new Book { BookId = 2, Title = "Sample Book 2",CategoryId=3},   
                new Book { BookId = 3, Title = "Yanlızlık Sözleri", CategoryId=2 },
                new Book { BookId = 4, Title = "Dalton", CategoryId=3 }


            );
            builder.HasOne(b => b.Category) // Book ile Category arasındaki ilişkiyi belirleme
                   .WithMany(c => c.Books)
                   .HasForeignKey(b => b.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull); // .Cascade==Silme davranışını ayarlama category silinirse ilgili kitaplarda silinsin setnull==category ile ilgli book silinmez



        }
    }
}
