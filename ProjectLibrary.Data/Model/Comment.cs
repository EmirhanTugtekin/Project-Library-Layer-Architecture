using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        public string Text { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
    }
}
