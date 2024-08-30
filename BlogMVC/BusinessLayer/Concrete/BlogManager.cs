using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Runtime.InteropServices;




namespace BusinessLayer.Concrete
{
     

    public class BlogManager:IBlogService
    {
        Repository<Blog> repoBlog = new Repository<Blog>();

        IBlogDAL _blog;

        public BlogManager(EfBlogDAL blog)
        {
            _blog = blog;
        }

        public List<Blog> GetBlogById(int id) 
        { 
            return  _blog.List(x=>x.BlogId == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _blog.List(x => x.AuthorId == id);
        }

        public List<Blog> GetBlogByCategory(int id)
        {
            return _blog.List(x => x.CategoryId == id);
        }


        public List<Blog> GetList()
        {
           return _blog.List();
        }

       

        public Blog GetById(int id)
        {
            return _blog.GetById(id);
        }


        public void TAdd(Blog t)
        {
            _blog.Insert(t);
        }

        

        public void TDelete(Blog t)
        {
            _blog.Delete(t);
        }

        public void TUppdate(Blog t)
        {
            _blog.Update(t);
        }
    }
}
