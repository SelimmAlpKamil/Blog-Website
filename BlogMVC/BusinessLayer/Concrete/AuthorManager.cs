using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        Repository<Author> repository = new Repository<Author>();

        IAuthorDAL _authorDAL;

        public AuthorManager(IAuthorDAL authorDAL)
        {
            _authorDAL = authorDAL;
        }

        

        public List<Author> GetThreeAuthorList(Author p)
        {
            return repository.ListTakeValue(3);
        }


        public List<Blog> GetAuthorPostList(int id) 
        {
            Repository<Blog> blogRepository = new Repository<Blog>();

            return blogRepository.List(x=>x.AuthorId == id);
        }

        public List<Author> GetList()
        {
          return _authorDAL.List();
        }

        

        public Author GetById(int id)
        {
            return _authorDAL.GetById(id);
        }


        public void TAdd(Author t)
        {
            _authorDAL.Insert(t);
        }

        public void TDelete(Author t)
        {
            _authorDAL.Delete(t);
        }

        public void TUppdate(Author t)
        {
            _authorDAL.Update(t);
        }
    }
}
