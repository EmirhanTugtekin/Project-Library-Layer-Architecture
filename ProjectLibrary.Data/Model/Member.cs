using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime DateOfMembership { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Photo { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
        public ICollection<Fine> Fines { get; set; }

        
    }
}
