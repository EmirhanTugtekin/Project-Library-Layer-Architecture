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
    public class BookController : Controller
    {
        public readonly IBookRepository _bookRepository;
        ProjectLibraryContext _db = new ProjectLibraryContext();

        public BookController(IBookRepository BookRepository)
        {
            _bookRepository = BookRepository;
           
        }

        // GET: Book
        public ActionResult Index(string p)
        {
            //var books = from book in _db.Books select book;
            //if(!string.IsNullOrEmpty(p))
            //{
            //    books = books.Where(x => x.BookName.Contains(p));
            //}          

            _bookRepository.BookIndex(p);
            return View(_bookRepository.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> deger1 = _db.Categories.Select(p => new SelectListItem {
                Text = p.CategoryName,
                Value = p.CategoryID.ToString()
            }).ToList();//LAMBDA EXPRESSION
                                        

            List<SelectListItem> deger2 = (from x in _db.Authors.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.AuthorName + " " + x.AuthorSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList(); //LINQ


            List<SelectListItem> deger3 = (from x in _db.Locations.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.floor + x.section,
                                               Value = x.LocationID.ToString()
                                           }).ToList(); 

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }

        [HttpPost]

        public ActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _bookRepository.Insert(book);
            _bookRepository.Save();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = _bookRepository.GetById(id.Value);
            List<SelectListItem> deger1 = (from x in _db.Categories.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList(); //seçmiş olduğum öğrenin text ve value değerlerini aldım

            List<SelectListItem> deger2 = (from x in _db.Authors.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.AuthorName + " " + x.AuthorSurname,
                                               Value = x.AuthorID.ToString()
                                           }).ToList(); //seçmiş olduğum öğrenin text ve value değerlerini aldım


            List<SelectListItem> deger3 = (from x in _db.Locations.ToList()
                                           select new SelectListItem //bir öğeyi seçtim
                                           {
                                               Text = x.floor + x.section,
                                               Value = x.LocationID.ToString()
                                           }).ToList(); //seçmiş olduğum öğrenin text ve value değerlerini aldım

            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]

        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _bookRepository.Update(book);
            _bookRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = _bookRepository.GetById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookRepository.Delete(id);
            _bookRepository.Save();

            return RedirectToAction("Index");
        }
    }
}