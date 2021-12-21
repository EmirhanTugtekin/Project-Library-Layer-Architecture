using ProjectLibrary.Admin;
using ProjectLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectLibrary.Admin.Controllers
{
    public class HomeController : Controller
    {
        public readonly IBookRepository _bookRepository;
        public readonly IMemberRepository _memberRepository;
        public readonly IStuffRepository _stuffRepository;

        public HomeController (IBookRepository bookRepository, IMemberRepository memberRepository, IStuffRepository stuffRepository)
        {
            _bookRepository = bookRepository;
            _memberRepository = memberRepository;
            _stuffRepository = stuffRepository;
        
        }
        [Authorize]
        public ActionResult Index()
        {
            //var pageModel = new HomePageModel();

            //pageModel.BookCount = _bookRepository.Count();
            //pageModel.MemberCount = _memberRepository.Count();
            //pageModel.StuffCount = _stuffRepository.Count();

            //return View(pageModel);

            var degerler = _bookRepository.GetAll().ToList() ;
            return View(degerler);
        }

        
    }
}