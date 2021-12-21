using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLibrary.Data;
using ProjectLibrary.Core;

namespace ProjectLibrary.Admin.Controllers
{
    public class BorrowingController : Controller
    {
        public readonly IBorrowingRepository _borrowingRepository;
        ProjectLibraryContext _db = new ProjectLibraryContext();

        public BorrowingController(IBorrowingRepository BorrowingRepository)
        {
            _borrowingRepository = BorrowingRepository;
        }

        public ActionResult Index()
        {
            var borrowings = _borrowingRepository.GetAll().Where(x=>x.SituationOfBorrowing==false).ToList();
            return View(borrowings);
        }
        [HttpGet]
        public ActionResult Give()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Give(Borrowing p)
        {

            _borrowingRepository.Insert(p);
            _borrowingRepository.Save();
            return View();
        }
        public ActionResult GiveBack(int id)
        {
            var value = _db.Borrowings.Find(id);

            DateTime d1 = DateTime.Parse(value.DateOfReturn.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            ViewBag.dgr = d3.TotalDays;

            return View("GiveBack", value);
        }
        public ActionResult UpgradeBorrow(Borrowing p)
        {
            var value = _db.Borrowings.Find(p.BorrowingID);
            value.ActualDateOfReturn = p.ActualDateOfReturn;
            value.SituationOfBorrowing = true;
            
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}