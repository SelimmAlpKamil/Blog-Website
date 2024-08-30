using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAlcs());

        // GET: About
        [AllowAnonymous]
        public ActionResult Index(About p)
        {
            var aboutDetail = aboutManager.GetList();

            return View(aboutDetail);
        }
        [AllowAnonymous]
        public PartialViewResult Footer(About p) 
        {
            var footerAboutList = aboutManager.GetList();

            return PartialView(footerAboutList);
        }
        [AllowAnonymous]
        public PartialViewResult MeetTheTeam(Author p)
        {
            AuthorManager authorManager = new AuthorManager(new EFAuthorDaL());

            var authorList = authorManager.GetThreeAuthorList(p);

            return PartialView(authorList);
        }

        [HttpGet]
        public ActionResult AdmniAboutList()
        {
            About aboutList = aboutManager.GetById(1);

            return View(aboutList);
        }

        [HttpPost]
        public ActionResult AdmniAboutList(About p)
        {

            AboutRules validation = new AboutRules();
            
            ValidationResult rules = validation.Validate(p);

            if(rules.IsValid)
            {
                var findAbout = aboutManager.GetById(p.AboutId);
                findAbout.AboutContent1 = p.AboutContent1;
                findAbout.AboutContent2 = p.AboutContent2;
                findAbout.AboutImage1 = p.AboutImage1;
                findAbout.AboutImage2 = p.AboutImage2;

                aboutManager.TUppdate(findAbout);
            }
            else
            {
                foreach(var x in rules.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }


            return View();
        }


    }
}