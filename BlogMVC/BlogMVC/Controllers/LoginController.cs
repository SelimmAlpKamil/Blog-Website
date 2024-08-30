using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace BlogMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        // GET: Login
        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorLogin(Author p)
        {
            Context c = new Context();
            
            var userInfo= c.Authors.FirstOrDefault(x=> x.AuthorMail==p.AuthorMail && x.AuthorPassWord == p.AuthorPassWord);
            
            if(userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.AuthorMail, true);
                Session["Mail"]=userInfo.AuthorMail.ToString();
                return RedirectToAction("Index","User");
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            Context c = new Context();  

            var adminInfo= c.Admins.FirstOrDefault(x=>x.UserName==admin.UserName && x.Password == admin.Password);

            if(adminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, false);
                Session["Username"]=admin.UserName.ToString();
                return RedirectToAction("BlodAdminList","Blog");
            }
            else
            {
               return RedirectToAction("AdminLogin","Login");
            }
        }
    }
}