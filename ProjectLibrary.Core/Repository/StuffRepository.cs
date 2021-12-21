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
    public class StuffRepository : IStuffRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Stuffs.Count();
        }

        public void Delete(int id)
        {
            var stuff = GetById(id);
            if (stuff != null)
            {
                _context.Stuffs.Remove(stuff);
            }
        }

        public Stuff Get(Expression<Func<Stuff, bool>> expression)
        {
            return _context.Stuffs.FirstOrDefault(expression);
        }

        public IEnumerable<Stuff> GetAll()
        {
            return _context.Stuffs.Select(x => x);
        }

        public Stuff GetById(int id)
        {
            return _context.Stuffs.FirstOrDefault(x => x.StuffID == id);
        }

        public IQueryable<Stuff> GetMany(Expression<Func<Stuff, bool>> expression)
        {
            return _context.Stuffs.Where(expression);
        }

        public void Insert(Stuff obj)
        {
            _context.Stuffs.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Stuff obj)
        {
            _context.Stuffs.AddOrUpdate(obj);
        }

        public IEnumerable<Stuff> StuffIndex(string p)
        {
            var stuffs = from stuff in _context.Stuffs select stuff;
            if (!string.IsNullOrEmpty(p))
            {
                stuffs = stuffs.Where(x => x.StuffName.Contains(p));
            }
            return stuffs;

        }
    }
}
