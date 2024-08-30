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
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Contact p)
        {
            ContactRules validations = new ContactRules();

            ValidationResult rules = validations.Validate(p);

            if (rules.IsValid)
            {
                p.MailDate = Convert.ToDateTime(DateTime.Now);

                contactManager.TAdd(p);
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

        [AllowAnonymous]
        public PartialViewResult ContactAddress(AboutInfo p)
        {
            AboutInfoManager aboutInfoManager = new AboutInfoManager(new EFAboutInfoDAL());

            var ınfoList = aboutInfoManager.GetList();

            return PartialView(ınfoList);
        }

        public ActionResult AdminSendMailList()
        {
            var mailList = contactManager.GetList();

            return View(mailList);
        }

        public ActionResult AdminSendDetailMailList(int id)
        {
            var findMail=contactManager.FindMailList(id);

            return View(findMail);
        }

        public ActionResult AdminMailDelete(int id)
        {
            var findMail = contactManager.GetById(id);

            contactManager.TDelete(findMail);

            return RedirectToAction("AdminSendMailList", "Contact");

        }

    }
}