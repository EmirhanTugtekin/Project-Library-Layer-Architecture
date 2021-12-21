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
    public class LibrarySituationRepository : ILibrarySituationRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.LibrarySituations.Count();
        }

        public void Delete(int id)
        {
            var librarySituation = GetById(id);
            if (librarySituation != null)
            {
                _context.LibrarySituations.Remove(librarySituation);
            }
        }

        public LibrarySituation Get(Expression<Func<LibrarySituation, bool>> expression)
        {
            return _context.LibrarySituations.FirstOrDefault(expression);
        }

        public IEnumerable<LibrarySituation> GetAll()
        {
            return _context.LibrarySituations.Select(x => x);
        }

        public LibrarySituation GetById(int id)
        {
            return _context.LibrarySituations.FirstOrDefault(x => x.LibrarySituationID == id);
        }

        public IQueryable<LibrarySituation> GetMany(Expression<Func<LibrarySituation, bool>> expression)
        {
            return _context.LibrarySituations.Where(expression);
        }

        public void Insert(LibrarySituation obj)
        {
            _context.LibrarySituations.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(LibrarySituation obj)
        {
            _context.LibrarySituations.AddOrUpdate(obj);
        }
    }
}
