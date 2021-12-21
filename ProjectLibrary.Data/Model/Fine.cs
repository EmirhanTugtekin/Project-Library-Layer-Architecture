using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Fine
    {     

        [Key]
        public int FineID { get; set; }

        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public double Cash { get; set; }

        public int MemberID { get; set; }
        public virtual Member Member { get; set; }

        public int BorrowingID { get; set; }
        public virtual Borrowing Borrowing { get; set; }

        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
