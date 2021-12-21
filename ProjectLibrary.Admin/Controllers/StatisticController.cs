using ProjectLibrary.Core;
using ProjectLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLibrary.Admin.Controllers
{
    public class StatisticController : Controller
    {
        public ProjectLibraryContext _db = new ProjectLibraryContext();

        public ActionResult Index()
        {

            var deger1 = _db.Books.Count();
            var deger2 = _db.Stuffs.Count();
            var deger3 = _db.Members.Count();

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }
        public ActionResult Images()
        {
            return View();
        }
    }
}