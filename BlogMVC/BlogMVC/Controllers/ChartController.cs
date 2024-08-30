using BlogMVC.Models;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class ChartController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisiualizeResult()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Class1> BlogList()
        {
            List<Class1> cs1 = new List<Class1>();

            using (var c = new Context())
            {
                cs1 = c.Blogs.Select(x => new Class1
                {
                    BlogName = x.BlogTitle,
                    BlogRating = x.BlogRating,
                }).ToList();
            }

            return cs1;
        }

        public ActionResult Chart1()
        {
            return View();
        }

        public ActionResult Chart2()
        {
            return View();
        }

    }
}