using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
        //her kategori içinde birden fazla kitap olabilir
    }
}
