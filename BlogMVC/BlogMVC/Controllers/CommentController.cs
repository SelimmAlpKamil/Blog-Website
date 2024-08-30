using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class CommentController : Controller
    {
        CommentManager c = new CommentManager(new EfCommnetDAl());

        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            return PartialView(c.CommentGetById(id));
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveCommnet(int id) 
        {
            ViewBag.Id = id;
            return PartialView();
        }
        [AllowAnonymous]

        [HttpPost]
        public PartialViewResult LeaveCommnet(Comment comment)
        {
            CommnetRules validations = new CommnetRules();

            ValidationResult rule=validations.Validate(comment);

            

            if(rule.IsValid)
            {
                comment.CommentTime = Convert.ToDateTime(DateTime.Now.ToLongDateString());

                comment.CommnetStatuse = true;

                c.TAdd(comment);

            }
            else
            {
                foreach(var x in rule.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);

                    
                }
            }

        

            return PartialView();






        }

        public ActionResult CommnetAdminListTrue()
        {
            var commnetList= c.CommnetListTrue();

            return View(commnetList);
        }

        public ActionResult CommnetAdminListFalse()
        {
            var commnetList = c.CommnetListFalse();

            return View(commnetList);
        }

        public ActionResult CommnetAdminListDelete(int id)
        {
            var findCommnet = c.GetById(id);

            findCommnet.CommnetStatuse=false;

            c.TUppdate(findCommnet);

            return RedirectToAction("CommnetAdminListTrue","Comment");   
        }

        public ActionResult CommnetAdminListCheck(int id)
        {
            var findCommnet = c.GetById(id);

            findCommnet.CommnetStatuse = true;

            c.TUppdate(findCommnet);


            return RedirectToAction("CommnetAdminListFalse", "Comment");
        }


    }
}