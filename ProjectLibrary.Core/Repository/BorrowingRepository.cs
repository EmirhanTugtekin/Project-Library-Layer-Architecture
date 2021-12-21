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
    public class BorrowingRepository : IBorrowingRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Borrowings.Count();
        }

        public void Delete(int id)
        {
            var borrowing = GetById(id);
            if (borrowing != null)
            {
                _context.Borrowings.Remove(borrowing);
            }
        }

        public Borrowing Get(Expression<Func<Borrowing, bool>> expression)
        {
            return _context.Borrowings.FirstOrDefault(expression);
        }

        public IEnumerable<Borrowing> GetAll()
        {
            return _context.Borrowings.Select(x => x);
        }

        public Borrowing GetById(int id)
        {
            return _context.Borrowings.FirstOrDefault(x => x.BorrowingID == id);
        }

        public IQueryable<Borrowing> GetMany(Expression<Func<Borrowing, bool>> expression)
        {
            return _context.Borrowings.Where(expression);
        }

        public void Insert(Borrowing obj)
        {
            _context.Borrowings.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Borrowing obj)
        {
            _context.Borrowings.AddOrUpdate(obj);
        }
    }
}
