using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Stuff
    {
        
        public int StuffID { get; set; }

       
        public string StuffName { get; set; }

        
        public string StuffSurname { get; set; }

       
        public string NickName { get; set; }

      
        public string Password { get; set; }

        


      
        public string Email { get; set; }

      


        public DateTime DateOfHiring { get; set; }

        


        public DateTime DateOfBirth { get; set; }

        
        public string Photo { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
