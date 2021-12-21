using ProjectLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Core
{
    public interface IStuffRepository:IRepository<Stuff>
    {
        IEnumerable<Member> StuffIndex(string p);
    }
}
