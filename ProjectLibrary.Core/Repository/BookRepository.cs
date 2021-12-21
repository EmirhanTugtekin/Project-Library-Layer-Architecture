using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProjectLibrary.Data;

namespace ProjectLibrary.Core
{
    public class BookRepository : IBookRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Books.Count();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public Book Get(Expression<Func<Book, bool>> expression)
        {
            return _context.Books.FirstOrDefault(expression);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Select(x => x);
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.BookID == id);
        }

        public IQueryable<Book> GetMany(Expression<Func<Book, bool>> expression)
        {
            return _context.Books.Where(expression);
        }

        public void Insert(Book obj)
        {
            _context.Books.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Book obj)
        {
            _context.Books.AddOrUpdate(obj);
        }

        public void BookIndex(string p)
        {
            var books=from book in _context.Books select book;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(x => x.BookName.Contains(p));
            }
        }

        public IEnumerable<Book> BookCreate()
        {
            List<SelectListItem> deger1 = (from x in _context.Categories.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList(); //seçmiş olduğum öğrenin text ve value değerlerini aldım

            


        }

    }
}
