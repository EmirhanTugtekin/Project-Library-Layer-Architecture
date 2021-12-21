using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Borrowing
    {
        [Key]
        public int BorrowingID { get; set; }

        public string DateOfBorrowed { get; set; }

        public string DateOfReturn { get; set; }

        public string ActualDateOfReturn { get; set; }

        public bool SituationOfBorrowing { get; set; }

        public int BookID { get; set; }
        public virtual Book Book { get; set; }//her kitap bir kategoriye ait olabilir

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }

        public int StuffID { get; set; }
        public virtual Stuff Stuff { get; set; }

        public ICollection<Fine> Fines { get; set; }
    }
}

