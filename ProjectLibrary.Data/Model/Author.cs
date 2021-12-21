using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Author
    {
        
        [Key]
        public int AuthorID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string AuthorName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string AuthorSurname { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
