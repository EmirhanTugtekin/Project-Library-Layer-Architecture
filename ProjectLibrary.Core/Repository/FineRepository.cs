using ProjectLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
namespace ProjectLibrary.Core
{
    public class FineRepository : IFineRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Fines.Count();
        }

        public void Delete(int id)
        {
            var fine = GetById(id);
            if (fine != null)
            {
                _context.Fines.Remove(fine);
            }
        }

        public Fine Get(Expression<Func<Fine, bool>> expression)
        {
            return _context.Fines.FirstOrDefault(expression);
        }

        public IEnumerable<Fine> GetAll()
        {
            return _context.Fines.Select(x => x);
        }

        public Fine GetById(int id)
        {
            return _context.Fines.FirstOrDefault(x => x.FineID == id);
        }

        public IQueryable<Fine> GetMany(Expression<Func<Fine, bool>> expression)
        {
            return _context.Fines.Where(expression);
        }

        public void Insert(Fine obj)
        {
            _context.Fines.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Fine obj)
        {
            _context.Fines.AddOrUpdate(obj);
        }
    }
}
