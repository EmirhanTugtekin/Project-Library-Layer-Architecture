
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class AuthorMap
    {
        
            public void Configure(EntityTypeBuilder<Author> builder)
            {
                builder.HasKey(a => a.AuthorID);

                builder.Property(a => a.AuthorID).ValueGeneratedOnAdd();

                builder.Property(a => a.AuthorName).HasMaxLength(30);

                builder.Property(a => a.AuthorSurname).HasMaxLength(30);


            }
        
    }
}
