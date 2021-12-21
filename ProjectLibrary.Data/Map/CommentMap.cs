
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(b => b.CommentID);
            builder.Property(b => b.CommentID).ValueGeneratedOnAdd();
            
            builder.Property(b => b.Text).HasMaxLength(300);

            builder.HasOne<Book>(b => b.Book).WithMany(c => c.Comments).HasForeignKey(b => b.BookID);

           
        }
    }
}
