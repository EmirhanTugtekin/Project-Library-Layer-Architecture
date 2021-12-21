
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookID);
            builder.Property(b => b.BookID).ValueGeneratedOnAdd();
       
            builder.Property(b => b.BookName).HasMaxLength(30);
            
            builder.Property(b => b.Publisher).HasMaxLength(30);
        
            builder.Property(b => b.Language).HasMaxLength(30);
            

            //builder.HasMany(b => b.Borrowings)
            //    .WithOne(c => c.Book).HasForeignKey(b => b.BookID);

            builder.HasOne<Author>(b => b.Author).WithMany(c => c.Books).HasForeignKey(b => b.AuthorID);
            builder.HasOne<Category>(b => b.Category).WithMany(c => c.Books).HasForeignKey(b => b.CategoryID);
            builder.HasOne<Location>(b => b.Location).WithMany(c => c.Books).HasForeignKey(b => b.LocationID);

        }
    }
}
