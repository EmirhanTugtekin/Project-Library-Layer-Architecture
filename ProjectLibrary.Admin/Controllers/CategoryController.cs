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
    public class CategoryController : Controller
    {
        public readonly ICategoryRepository _categoryRepository;
        

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categoryList = _categoryRepository.GetAll().ToList();
            return View(categoryList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            _categoryRepository.Insert(category);
            _categoryRepository.Save();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _categoryRepository.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]

        public ActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _categoryRepository.Update(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var category = _categoryRepository.GetById(id.Value);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();

            return RedirectToAction("Index");
        }




    }
}