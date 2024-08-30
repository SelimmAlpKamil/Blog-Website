using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager:IBlogService,IAuthorService,ICommentService
    {
        Repository<Author> userRepo = new Repository<Author>();
        Repository<Blog> userBlogRepo = new Repository<Blog>(); 
        Repository<Comment> userCommentRepo = new Repository<Comment>();

        IBlogDAL _blog;
        IAuthorDAL _author;
        ICommentDAL _comment;

       

        

        public UserProfileManager(IBlogDAL blog, IAuthorDAL author, ICommentDAL comment)
        {
            _blog = blog;
            _author = author;
            _comment = comment;
        }

        public Author GetByAuthorInfo(string mail)
        {
            return _author.Find(x=>x.AuthorMail == mail);
        }

        public Author findAuthor(string mail)
        {
            return _author.Find(x=>x.AuthorMail == mail);
        }

        public Author findAuthorId(int id)
        {
            return _author.Find(x => x.AuthorId == id);
        }

        public Blog findAuthorBlog(string mail)
        {
            var author = _author.Find(x => x.AuthorMail == mail);

            return _blog.Find(x => x.AuthorId == author.AuthorId);
        }

        public void updateAuthorBlog(Blog p)
        {
            
            _blog.Update(p);
        }

        public void updateAuthorInfo(Author p)
        {
            _author.Update(p);
        }

      

        public void DeleteAuthorBlog(Blog blog)
        {
             _blog.Delete(blog);
        }



        public List<Blog> AuthorBlogList(Author p)
        {
            return _blog.List(x=>x.AuthorId == p.AuthorId);
        }

        public void AddAuthorBlog(Blog p)
        {
            _blog.Insert(p);
        }

        public List<Comment> AuthorBlogCommnet(int id)
        {
            return _comment.List(x=>x.BlogId==id);
        }



        public void AuthorBlogCommnetDelete(int id)
        {
            var findCommnet = _comment.Find(x=>x.CommentId==id);    

             _comment.Delete(findCommnet);
        }

        


        public void TAdd(Author t)
        {
            _author.Insert(t);
        }

    
        

        public void TDelete(Author t)
        {
            _author.Delete(t);
        }

        public void TUppdate(Author t)
        {
            _author.Update(t);
        }

       

        public void TAdd(Comment t)
        {
            _comment.Insert(t);
        }

      

        public void TDelete(Comment t)
        {
            _comment.Delete(t);
        }

        public void TUppdate(Comment t)
        {
            _comment.Update(t);
        }

        List<Author> IGenericService<Author>.GetList()
        {
           return _author.List();
        }

        Author IGenericService<Author>.GetById(int id)
        {
            return _author.GetById(id);
        }

        List<Comment> IGenericService<Comment>.GetList()
        {
            return _comment.List();
        }

        Comment IGenericService<Comment>.GetById(int id)
        {
            return _comment.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blog.List();
        }

        public void TAdd(Blog t)
        {
            _blog.Insert(t);
        }

        public Blog GetById(int id)
        {
            return _blog.GetById(id);
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
