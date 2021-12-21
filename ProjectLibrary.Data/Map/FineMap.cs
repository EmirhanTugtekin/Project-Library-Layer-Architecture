
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class FineMap : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            builder.HasKey(b => b.FineID);
            builder.Property(b => b.FineID).ValueGeneratedOnAdd();
           
            builder.HasOne<Member>(b => b.Member).WithMany(c => c.Fines).HasForeignKey(b => b.MemberID);
            builder.HasOne<Borrowing>(b => b.Borrowing).WithMany(c => c.Fines).HasForeignKey(b => b.BorrowingID);

            
        }
    }
}
