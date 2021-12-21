
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.CategoryID);
            builder.Property(a => a.CategoryID).ValueGeneratedOnAdd();
            
            builder.Property(a => a.CategoryName).HasMaxLength(30);

         
        }
    }
}