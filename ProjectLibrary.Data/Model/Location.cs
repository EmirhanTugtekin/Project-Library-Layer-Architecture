using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        

        public short floor { get; set; }

        public string section { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
