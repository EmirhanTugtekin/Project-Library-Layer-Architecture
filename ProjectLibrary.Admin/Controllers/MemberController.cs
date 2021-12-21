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
    public class memberController : Controller
    {
        public readonly IMemberRepository _memberRepository;
        

        public memberController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;

        }

        // GET: member
        public ActionResult Index(string p)
        {
            

            return View(_memberRepository.MemberIndex(p).ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }
            _memberRepository.Insert(member);
            _memberRepository.Save();

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = _memberRepository.GetById(id.Value);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost]

        public ActionResult Edit(Member member)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _memberRepository.Update(member);
            _memberRepository.Save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var member = _memberRepository.GetById(id.Value);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _memberRepository.Delete(id);
            _memberRepository.Save();

            return RedirectToAction("Index");
        }
    }
}