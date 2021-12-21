
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class BorrowingMap : IEntityTypeConfiguration<Borrowing>
    {
        public void Configure(EntityTypeBuilder<Borrowing> builder)
        {
            builder.HasKey(b => b.BorrowingID);
            builder.Property(b => b.BorrowingID).ValueGeneratedOnAdd();
            builder.Property(b => b.DateOfBorrowed).IsRequired();
            builder.Property(b => b.DateOfReturn).IsRequired();
            builder.Property(b => b.ActualDateOfReturn).IsRequired();

            builder.HasOne<Book>(b => b.Book).WithMany(c => c.Borrowings).HasForeignKey(b => b.BookID);
            builder.HasOne<Member>(b => b.Member).WithMany(c => c.Borrowings).HasForeignKey(b => b.MemberID);
            builder.HasOne<Stuff>(b => b.Stuff).WithMany(c => c.Borrowings).HasForeignKey(b => b.StuffID);

        }
    }
}
