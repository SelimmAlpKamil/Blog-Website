using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BlogMVC.Controllers
{

    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogDAL());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {


            var blogList = bm.GetList().ToPagedList(page, 6);

            return PartialView(blogList);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedBlog()
        {
            //Post1
            var postTile1 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var postImg1 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogImage).FirstOrDefault();
            var postDate1 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogDate).FirstOrDefault();
            var postID1 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 1).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.PostID = postID1;
            ViewBag.PostDate1 = postDate1;
            ViewBag.PostTitle1 = postTile1;
            ViewBag.PostImg1 = postImg1;

            //post2
            var postTile2 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var postImg2 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogImage).FirstOrDefault();
            var postDate2 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogDate).FirstOrDefault();
            var postID2 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 2).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.postID2 = postID2;
            ViewBag.PostDate2 = postDate2;
            ViewBag.PostTitle2 = postTile2;
            ViewBag.PostImg2 = postImg2;

            //post3
            var postTile3 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var postImg3 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogImage).FirstOrDefault();
            var postDate3 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogDate).FirstOrDefault();
            var postID3 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 3).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.postID3 = postID3;
            ViewBag.PostDate3 = postDate3;
            ViewBag.PostTitle3 = postTile3;
            ViewBag.PostImg3 = postImg3;

            //post4
            var postTile4 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var postImg4 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogImage).FirstOrDefault();
            var postDate4 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogDate).FirstOrDefault();
            var postID4 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 4).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.postID4 = postID4;
            ViewBag.PostDate4 = postDate4;
            ViewBag.PostTitle4 = postTile4;
            ViewBag.PostImg4 = postImg4;

            //post5
            var postTile5 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var postImg5 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogImage).FirstOrDefault();
            var postDate5 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogDate).FirstOrDefault();
            var postID5 = bm.GetList().OrderByDescending(x => x.BlogId).Where(x => x.CategoryId == 5).Select(y => y.BlogId).FirstOrDefault();

            ViewBag.postID5 = postID5;
            ViewBag.PostDate5 = postDate5;
            ViewBag.PostTitle5 = postTile5;
            ViewBag.PostImg5 = postImg5;

            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedBlog()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var blogCoverList = bm.GetBlogById(id);

            return PartialView(blogCoverList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogAllRead(int id)
        {
            var blogDetailList = bm.GetBlogById(id);

            return PartialView(blogDetailList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var categoryName = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryName).FirstOrDefault();
            var categoryDescription = bm.GetBlogByCategory(id).Select(x => x.Category.CategoryDescription).FirstOrDefault();

            var blogCategory = bm.GetBlogByCategory(id);

            ViewBag.categoryName = categoryName;
            ViewBag.categoryDescription = categoryDescription;

            return View(blogCategory);
        }

        public ActionResult BlodAdminList()
        {
            var blogAdminList = bm.GetList();

            return View(blogAdminList);
        }

        public ActionResult BlodAdminListDetail()
        {
            var blogAdminList = bm.GetList();

            return View(blogAdminList);
        }

        [HttpGet]
        [Authorize(Roles="A")]
        public ActionResult AdminNewBlogAdd()
        {
            Context c = new Context();

            List<SelectListItem> blogCaterory = (from x in c.Categories.ToList()
                                                 where(x.CategoryStatus ==true)
                                                 select new SelectListItem 
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();

            List<SelectListItem> BlogAuthor = (from x in c.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorId.ToString(),
                                               }).ToList();


            ViewBag.blogCaterory = blogCaterory;
            ViewBag.BlogAuthor = BlogAuthor;

            return View();
        }

        [HttpPost]
        public ActionResult AdminNewBlogAdd(Blog p)
        {
            
            BlogRules rules = new BlogRules();

            FluentValidation.Results.ValidationResult validation = rules.Validate(p);

            if (validation.IsValid)
            {
                bm.TAdd(p);

                return RedirectToAction("BlodAdminListDetail", "Blog");
            }
            else
            {
                foreach(var x in validation.Errors)
                {
                    ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
                }
            }

            return View();
            
            




            
        }

        public ActionResult AdminDeleteBlog(int id)
        {
            bm.TDelete(bm.GetById(id));

            return RedirectToAction("BlodAdminListDetail", "Blog");
        }

        [HttpGet]
        public ActionResult AdminUpdateBlog(int id) 
        {
            Context c = new Context();

            List<SelectListItem> blogCaterory = (from x in c.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();

            List<SelectListItem> BlogAuthor = (from x in c.Authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName,
                                                   Value = x.AuthorId.ToString(),
                                               }).ToList();


            ViewBag.blogCaterory = blogCaterory;
            ViewBag.BlogAuthor = BlogAuthor;

            var findBlog=bm.GetById(id);
            
            return View(findBlog);
        }
        [HttpPost]
        public ActionResult AdminUpdateBlog(Blog blog)
        {
            BlogRules validation = new BlogRules();

            FluentValidation.Results.ValidationResult rules = validation.Validate(blog);

            if(rules.IsValid)
            {

                var findBlog = bm.GetById(blog.BlogId);

                findBlog.BlogTitle = blog.BlogTitle;
                findBlog.BlogImage = blog.BlogImage;
                findBlog.BlogContent = blog.BlogContent;
                findBlog.AuthorId = blog.AuthorId;
                findBlog.CategoryId = blog.CategoryId;
                findBlog.BlogDate = blog.BlogDate;

                bm.TUppdate(findBlog);

                return RedirectToAction("BlodAdminListDetail", "Blog");
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

        public ActionResult AdminGetByIdComment(int id)
        {
            TempData["deletedId"] = id;

            CommentManager c = new CommentManager(new EfCommnetDAl());

            var commentList = c.CommentGetById(id);

            return View(commentList);

        }

        public ActionResult AdminGetByIdCommentDelete(int id)
        {
            int deletedId = (int)TempData["deletedId"];

            CommentManager c = new CommentManager(new EfCommnetDAl());

            var findCommnet = c.GetById(id);

            findCommnet.CommnetStatuse = false;

            c.TUppdate(findCommnet);  

            return RedirectToAction("AdminGetByIdComment", "Blog", new { id = deletedId });

        }





    }
}