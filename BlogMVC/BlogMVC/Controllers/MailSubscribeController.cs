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
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        SubscripeManager subscriberManager = new SubscripeManager(new EFSubscribeDAL());


        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(Subscribe p) 
        {
            SubscribeRules validations = new SubscribeRules();

            ValidationResult rules = validations.Validate(p);

            if (rules.IsValid)
            {
                subscriberManager.TAdd(p);
            }
            else
            {
                foreach (var rule in rules.Errors) 
                {
                    ModelState.AddModelError(rule.PropertyName, rule.ErrorMessage);
                }
            }

            

            return PartialView();
        }
    }
}