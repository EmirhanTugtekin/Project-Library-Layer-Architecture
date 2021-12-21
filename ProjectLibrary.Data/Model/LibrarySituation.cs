using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class LibrarySituation
    {
        [Key]
        public int LibrarySituationID { get; set; }

        public int NumberOfStuff { get; set; }

        public int NumberOfMember { get; set; }
    }
}
