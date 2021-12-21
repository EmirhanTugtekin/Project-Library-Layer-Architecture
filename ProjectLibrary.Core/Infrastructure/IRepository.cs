using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Core
{
    public interface IRepository<T> where T : class // where T : class = T bir class olmak zorunda
    {
        IEnumerable<T> GetAll();//data çekmek
        T GetById(int id);//tek nesne döner
        T Get(Expression<Func<T, bool>> expression);//tek bir nesneyi bir expression sonucunda döner
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);// birçok nesneyi bir expression sonucunda döner
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        int Count();
        void Save();
    }
}
