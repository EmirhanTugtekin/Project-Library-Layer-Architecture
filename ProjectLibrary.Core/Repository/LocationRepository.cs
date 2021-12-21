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
    public class LocationRepository : ILocationRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Locations.Count();
        }

        public void Delete(int id)
        {
            var location = GetById(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
            }
        }

        public Location Get(Expression<Func<Location, bool>> expression)
        {
            return _context.Locations.FirstOrDefault(expression);
        }

        public IEnumerable<Location> GetAll()
        {
            return _context.Locations.Select(x => x);
        }

        public Location GetById(int id)
        {
            return _context.Locations.FirstOrDefault(x => x.LocationID == id);
        }

        public IQueryable<Location> GetMany(Expression<Func<Location, bool>> expression)
        {
            return _context.Locations.Where(expression);
        }

        public void Insert(Location obj)
        {
            _context.Locations.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Location obj)
        {
            _context.Locations.AddOrUpdate(obj);
        }
    }
}
