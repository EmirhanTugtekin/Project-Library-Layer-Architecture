using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectLibrary.Core;
using ProjectLibrary.Data;
namespace ProjectLibrary.Admin.Controllers
{
    public class StuffInfoController : Controller
    {
        ProjectLibraryContext _db = new ProjectLibraryContext();
        // GET: StuffInfo
        public ActionResult Index()
        {
            var nick = (string)Session["NickName"];
            var values = _db.Stuffs.FirstOrDefault(x => x.NickName == nick);
            ViewBag.m = nick;
            return View(values);
        }
    }
}