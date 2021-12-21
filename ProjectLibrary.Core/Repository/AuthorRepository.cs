
using ProjectLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Core
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Authors.Count();
        }

        public void Delete(int id)
        {
            var author = GetById(id);
            if(author!=null)
            {
                _context.Authors.Remove(author);
            }
        }

        public Author Get(Expression<Func<Author, bool>> expression)
        {
            return _context.Authors.FirstOrDefault(expression);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.Select(x => x);
        }

        public Author GetById(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.AuthorID == id);
        }

        public IQueryable<Author> GetMany(Expression<Func<Author, bool>> expression)
        {
            return _context.Authors.Where(expression);
        }

        public void Insert(Author obj)
        {
            _context.Authors.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Author obj)
        {
            _context.Authors.AddOrUpdate(obj);
        }
    }
}
