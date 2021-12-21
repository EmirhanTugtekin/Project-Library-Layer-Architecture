using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string BookName { get; set; }

        public short PublishYear { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Publisher { get; set; }

        public bool Available { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Language { get; set; }

        public string Image { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }//her kitap bir kategoriye ait olabilir

        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }//her kitap bir kategoriye ait olabilir

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }//her kitap bir kategoriye ait olabilir

        public ICollection<Borrowing> Borrowings { get; set; }
    }
    //virtual yazmazsak kitap sayfasında kategori sütunu hata verir

}
