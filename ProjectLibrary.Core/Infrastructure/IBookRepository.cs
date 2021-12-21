using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectLibrary.Data;

namespace ProjectLibrary.Core
{
    public interface IBookRepository : IRepository<Book>
    {
        void BookIndex(string p);

        //IEnumerable<Book> BookCreate();
    }
}
