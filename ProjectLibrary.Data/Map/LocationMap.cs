
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(b => b.LocationID);
            builder.Property(b => b.LocationID).ValueGeneratedOnAdd();
            
            builder.Property(b => b.floor).HasMaxLength(30);
           
            builder.Property(b => b.section).HasMaxLength(30);

           
        }
    }
}
