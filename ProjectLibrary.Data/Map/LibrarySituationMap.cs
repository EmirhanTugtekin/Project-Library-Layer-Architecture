
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectLibrary.Data
{
    public class LibrarySituationMap : IEntityTypeConfiguration<LibrarySituation>
    {
        public void Configure(EntityTypeBuilder<LibrarySituation> builder)
        {
            builder.HasKey(a => a.LibrarySituationID);
            builder.Property(a => a.LibrarySituationID).ValueGeneratedOnAdd();
            
            
        }
    }
}
