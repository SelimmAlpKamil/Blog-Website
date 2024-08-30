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
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            var categoryList = categoryManager.GetList();


            return View(categoryList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryList = categoryManager.GetList();

            return PartialView(categoryList);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = categoryManager.GetList();

            return View(categoryList);
        }

        public ActionResult AdminCategoryFalseList()
        {
            var categoryList = categoryManager.CategoryListFalse();

            return View(categoryList);
        }



        [HttpGet]
        public ActionResult AdminAddNewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAddNewCategory(Category p)
        {

            CategoryRules categoryRules = new CategoryRules();
            
            ValidationResult result = categoryRules.Validate(p);

            if (result.IsValid)
            {
                p.CategoryStatus = true;

                categoryManager.TAdd(p);

                return RedirectToAction("AdminCategoryList", "Category");

            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }
            }

            return View();
        }

        public ActionResult AdminCategoryDelete(int id)
        {
            var findCategor = categoryManager.GetById(id);

            findCategor.CategoryStatus = false;

            categoryManager.TUppdate(findCategor);

            return  RedirectToAction("AdminCategoryList", "Category"); 
        }

        public ActionResult AdminCategoryMakeTrue(int id)
        {
            var findCategor = categoryManager.GetById(id);

            findCategor.CategoryStatus = true;

            categoryManager.TUppdate(findCategor);

            return RedirectToAction("AdminCategoryList", "Category");
        }

        [HttpGet]
        public ActionResult AdminUpdateCategory(int id)
        {
            var findCategor=categoryManager.GetById(id);

            return View(findCategor);
        }

        [HttpPost]
        public ActionResult AdminUpdateCategory(Category category)
        {

            CategoryRules validationRules = new CategoryRules();
            ValidationResult result = validationRules.Validate(category);

            if (result.IsValid)
            {
                var findCategor = categoryManager.GetById(category.CategoryId);

                findCategor.CategoryName = category.CategoryName;
                findCategor.CategoryDescription = category.CategoryDescription;

                categoryManager.TUppdate(findCategor);

                return RedirectToAction("AdminCategoryList", "Category");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }

                
            }


            return View();


        }
    }
}