using ProjectLibrary.Core;
using ProjectLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectLibrary.Admin.Controllers
{
    public class StuffController : Controller
    {
        public readonly IStuffRepository _stuffRepository;
        //ProjectLibraryContext _db = new ProjectLibraryContext();

        public StuffController(IStuffRepository StuffRepository)
        {
            _stuffRepository = StuffRepository;

        }

        // GET: Stuff
        public ActionResult Index(string p)
        {
            //var stuffs = from stuff in _db.Stuffs select stuff;
            //if (!string.IsNullOrEmpty(p))
            //{
            //    stuffs = stuffs.Where(x => x.StuffName.Contains(p));
            //}
            //return View(stuffs.ToList());

            return View(_stuffRepository.StuffIndex(p).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Stuff stuff)
        {
            if (!ModelState.IsValid)
            {
                return View(stuff);
            }
            _stuffRepository.Insert(stuff);
            _stuffRepository.Save();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stuff = _stuffRepository.GetById(id.Value);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        [HttpPost]

        public ActionResult Edit(Stuff stuff)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _stuffRepository.Update(stuff);
            _stuffRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var stuff = _stuffRepository.GetById(id.Value);
            if (stuff == null)
            {
                return HttpNotFound();
            }
            return View(stuff);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _stuffRepository.Delete(id);
            _stuffRepository.Save();

            return RedirectToAction("Index");
        }
    }
}