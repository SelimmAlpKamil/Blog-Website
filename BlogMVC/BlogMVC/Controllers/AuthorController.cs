using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class AuthorController : Controller
    {
        AuthorManager authorManager = new AuthorManager(new EFAuthorDaL());
        BlogManager blogManager = new BlogManager(new EfBlogDAL());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            

            var authorBlogs = blogManager.GetBlogById(id);

            return PartialView(authorBlogs);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            BlogManager bm =new BlogManager(new EfBlogDAL());

            var authorBlogDetail = bm.GetList().Where(x=>x.BlogId==id).Select(x=> x.AuthorId).FirstOrDefault();

            var authorBlogs = bm.GetBlogByAuthor(authorBlogDetail);


            return PartialView(authorBlogs);
        }

        public ActionResult AdminAuthorList()
        {
            var authorList = authorManager.GetList();

            return View(authorList);
        }

        [HttpGet]
        public ActionResult AdminNewAuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminNewAuthorAdd(Author p)
        {
            AuthorRules validations = new AuthorRules();
            
            ValidationResult rules = validations.Validate(p);

            if (rules.IsValid)
            {
                authorManager.TAdd(p);

                return RedirectToAction("AdminAuthorList", "Author");
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

        [HttpGet]
        public ActionResult AdminAuthorUpdate(int id)
        {
            var findAuthore = authorManager.GetById(id);

            return View(findAuthore);
        }

        [HttpPost]
        public ActionResult AdminAuthorUpdate(Author p)
        {


            AuthorRules validations = new AuthorRules();

            ValidationResult rules = validations.Validate(p);

            if (rules.IsValid)
            {
                var findAuthor = authorManager.GetById(p.AuthorId);

                findAuthor.AuthorName = p.AuthorName;
                findAuthor.AuthorMail = p.AuthorMail;
                findAuthor.AuthorPhoneNumber = p.AuthorPhoneNumber;
                findAuthor.AuthorPassWord = p.AuthorPassWord;
                findAuthor.AuthorAbout = p.AuthorAbout;
                findAuthor.AuthorImage = p.AuthorImage;
                findAuthor.AuthorTitle = p.AuthorTitle;


                authorManager.TUppdate(findAuthor);

                return RedirectToAction("AdminAuthorList", "Author");
            }
            else
            {
                foreach (var x in rules.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();






            
        }

        public ActionResult AdminAuthorPost(int id)
        {
            var authotBlog = authorManager.GetAuthorPostList(id);

            return View(authotBlog);
        }

    }
}