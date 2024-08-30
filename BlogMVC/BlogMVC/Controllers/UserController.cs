using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;


namespace BlogMVC.Controllers
{

 
    public class UserController : Controller
    {
        
        UserProfileManager profileManager = new UserProfileManager(new EfBlogDAL(),new EFAuthorDaL(),new EfCommnetDAl());

        Context c = new Context();

        

        public ActionResult Index()
        {
            string mail = Session["Mail"].ToString();

            ViewBag.Mail = mail;

            return View();
        }

        [HttpGet]
        public PartialViewResult settingView(String mail) 
        {
            mail = (string)Session["Mail"];

            var authorInfo = profileManager.GetByAuthorInfo(mail);

            return PartialView(authorInfo);
        }

        [HttpPost]
        public PartialViewResult settingView(Author p)
        {
            var mail = Session["Mail"].ToString();

            AuthorRules validations = new AuthorRules();
            ValidationResult rules = validations.Validate(p);

            if (rules.IsValid)
            {
                

                var findAuthor = profileManager.findAuthorId(p.AuthorId);

                findAuthor.AuthorMail = p.AuthorMail;
                findAuthor.AuthorName = p.AuthorName;
                findAuthor.AuthorPhoneNumber = p.AuthorPhoneNumber;
                findAuthor.AuthorAbout = p.AuthorAbout;
                findAuthor.AuthorTitle = p.AuthorTitle;
                findAuthor.AuthorImage = p.AuthorImage;
                findAuthor.AuthorPassWord = p.AuthorPassWord;

                profileManager.updateAuthorInfo(findAuthor);
            }
            else
            {
                foreach(var x in rules.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            

            return PartialView();
        }

        public ActionResult AuthorBlog(string mail)
        {
            mail = Session["Mail"].ToString();

            var findAuthor = profileManager.findAuthor(mail);

            var blogList =profileManager.AuthorBlogList(findAuthor);


            return View(blogList);
        }

        [HttpGet]
        public ActionResult UpdateAuthorBlog() 
        {
            

            var mail = Session["Mail"].ToString();

            var finndAuthor=profileManager.findAuthorBlog(mail);

            List<SelectListItem> categories = (from x in c.Categories.ToList() select new SelectListItem
            {
                Value = x.CategoryId.ToString(),
                Text = x.CategoryName

            }).ToList();

            ViewBag.categories = categories;    

            return View(finndAuthor);

        }

        [HttpPost]
        public ActionResult UpdateAuthorBlog(Blog blog)
        {
            var mail = Session["Mail"].ToString();

            BlogRules validations = new BlogRules();

            ValidationResult rules = validations.Validate(blog);

            if (rules.IsValid)
            {
                

                var authorBlog = profileManager.findAuthorBlog(mail);

                authorBlog.AuthorId = blog.AuthorId;
                authorBlog.BlogDate = blog.BlogDate;
                authorBlog.CategoryId = blog.CategoryId;
                authorBlog.BlogContent = blog.BlogContent;
                authorBlog.BlogImage = blog.BlogImage;
                authorBlog.BlogTitle = blog.BlogTitle;

                profileManager.updateAuthorBlog(authorBlog);

                return RedirectToAction("AuthorBlog", "User");

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

        public ActionResult DeleteAuthorBlog(int id)
        {


            var findBlog = profileManager.GetById(id);

            profileManager.DeleteAuthorBlog(findBlog);

            return RedirectToAction("AuthorBlog", "User");
        }

        [HttpGet]
        public ActionResult AddAuthorBlog()
        {
            

            List<SelectListItem> categories = (from x in c.Categories.ToList() 
                                               where x.CategoryStatus == true
                                               select new SelectListItem
            {
                Value=x.CategoryId.ToString(),
                Text=x.CategoryName
            }).ToList();

            ViewBag.Categories = categories;
  
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthorBlog(Blog blog)
        {
            var mail = Session["Mail"].ToString();

            BlogRules validations = new BlogRules();
            ValidationResult rules = validations.Validate(blog);

            if (rules.IsValid)
            {
                

                var findAuthor = profileManager.findAuthor(mail);

                blog.AuthorId = findAuthor.AuthorId;


                profileManager.AddAuthorBlog(blog);

                return RedirectToAction("AuthorBlog", "User");
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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("AuthorLogin", "Login");
        }

        public ActionResult AuthorBlogCommentDetail(int id)
        {
            TempData["deleteId"] = id;

           var commnet= profileManager.AuthorBlogCommnet(id);

            return View(commnet);
        }

        public ActionResult AuthorBlogCommentDelete(int id)
        {
            int findId = (int)TempData["deleteId"];

            profileManager.AuthorBlogCommnetDelete(id);

            return RedirectToAction("AuthorBlogCommentDetail", "User", new {id=findId});
        }

        public ActionResult LogoutAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin","Login");
        }

       







    }
}