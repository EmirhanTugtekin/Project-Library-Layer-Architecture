
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    class MemberMap : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(b => b.MemberID);
            builder.Property(b => b.MemberID).ValueGeneratedOnAdd();
            
            builder.Property(b => b.MemberName).HasMaxLength(30);
            
            builder.Property(b => b.MemberName).HasMaxLength(30);
            builder.Property(b => b.NickName).HasMaxLength(30);
            
            builder.Property(b => b.Password).HasMaxLength(30);
            
            builder.Property(b => b.PhoneNumber).HasMaxLength(30);
            
            builder.Property(b => b.Email).HasMaxLength(30);
            
            builder.Property(b => b.Sex).HasMaxLength(30);
            
            builder.Property(b => b.Job).HasMaxLength(30);
           
            builder.Property(b => b.Photo).HasMaxLength(30);
        }
    }
}
