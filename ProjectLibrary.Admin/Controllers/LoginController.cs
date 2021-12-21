using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjectLibrary.Core;
using ProjectLibrary.Data;

namespace ProjectLibrary.Admin.Controllers
{
    public class LoginController : Controller
    {
        ProjectLibraryContext _db = new ProjectLibraryContext();
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Stuff p)
        {
            //p.Durum = true;
            _db.Stuffs.Add(p);
            _db.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult StuffLogin1()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult StuffLogin1(Stuff p)
        {
            var infos = _db.Stuffs.FirstOrDefault(x => x.NickName == p.NickName && x.Password == p.Password);
            if (infos != null)
            {
                FormsAuthentication.SetAuthCookie(infos.NickName, false);
                Session["NickName"] = infos.NickName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}