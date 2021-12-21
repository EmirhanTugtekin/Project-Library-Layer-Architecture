using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class StuffMap : IEntityTypeConfiguration<Stuff>
    {
    
        public void Configure(EntityTypeBuilder<Stuff> builder)
        {
            builder.HasKey(b => b.StuffID);
            builder.Property(b => b.StuffID).ValueGeneratedOnAdd();

            builder.Property(b => b.StuffName).HasMaxLength(30);
            
            builder.Property(b => b.StuffSurname).HasMaxLength(30);

            builder.Property(b => b.NickName).HasMaxLength(30);
           
            builder.Property(b => b.Password).HasMaxLength(30);
     
            builder.Property(b => b.PhoneNumber).HasMaxLength(30);
            
            builder.Property(b => b.Email).HasMaxLength(30);
            
            builder.Property(b => b.Sex).HasMaxLength(30);
              
            builder.Property(b => b.Photo).HasMaxLength(300);

        }
    }
}
