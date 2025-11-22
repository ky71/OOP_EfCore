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
    internal class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);
            builder.Property(c=>c.CategoryName).IsRequired().HasMaxLength(200);
            builder.Property(c=>c.Description).HasDefaultValue("No İnfo.");
            builder.HasData(
                 new Category { CategoryId = 1, CategoryName = "Saglık" },
                 new Category { CategoryId = 2, CategoryName = "Computer Science" },
                 new Category { CategoryId = 3, CategoryName = "Roman" }
                 


             );
        }
    }
}
