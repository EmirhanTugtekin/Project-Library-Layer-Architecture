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
    public class CommentRepository : ICommentRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Comments.Count();
        }

        public void Delete(int id)
        {
            var comment = GetById(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }
        }

        public Comment Get(Expression<Func<Comment, bool>> expression)
        {
            return _context.Comments.FirstOrDefault(expression);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.Select(x => x);
        }

        public Comment GetById(int id)
        {
            return _context.Comments.FirstOrDefault(x => x.CommentID == id);
        }

        public IQueryable<Comment> GetMany(Expression<Func<Comment, bool>> expression)
        {
            return _context.Comments.Where(expression);
        }

        public void Insert(Comment obj)
        {
            _context.Comments.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Comment obj)
        {
            _context.Comments.AddOrUpdate(obj);
        }
    }
}
