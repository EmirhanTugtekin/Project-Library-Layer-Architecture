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
    public class MemberRepository : IMemberRepository
    {
        private readonly ProjectLibraryContext _context = new ProjectLibraryContext();
        public int Count()
        {
            return _context.Members.Count();
        }

        public void Delete(int id)
        {
            var member = GetById(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
        }

        public Member Get(Expression<Func<Member, bool>> expression)
        {
            return _context.Members.FirstOrDefault(expression);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.Select(x => x);
        }

        public Member GetById(int id)
        {
            return _context.Members.FirstOrDefault(x => x.MemberID == id);
        }

        public IQueryable<Member> GetMany(Expression<Func<Member, bool>> expression)
        {
            return _context.Members.Where(expression);
        }

        public void Insert(Member obj)
        {
            _context.Members.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Member obj)
        {
            _context.Members.AddOrUpdate(obj);
        }

        public IEnumerable<Member> MemberIndex(string p)
        {
            var members = from member in _context.Members select member;
            if (!string.IsNullOrEmpty(p))
            {
                members= members.Where(x => x.MemberName.Contains(p));
            }
            return members;

        }
    }
}
