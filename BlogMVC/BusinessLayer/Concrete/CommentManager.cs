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
    public class CommentManager:ICommentService
    {
        Repository<Comment> repository = new Repository<Comment>();

        ICommentDAL _commnet;

        public CommentManager(ICommentDAL commnet)
        {
            _commnet = commnet;
        }

      

        public List<Comment> CommentGetById(int id)
        {
            var commmentList = _commnet.List(x=> x.BlogId == id && x.CommnetStatuse ==true);

            return commmentList;
        }

        public List<Comment> CommnetListTrue()
        {
            var commentList = _commnet.List(x=>x.CommnetStatuse==true);
            return commentList;
        }

        public List<Comment> CommnetListFalse()
        {
            var commentList = _commnet.List(x => x.CommnetStatuse == false);
            return commentList;
        }


        public List<Comment> GetList()
        {
            return _commnet.List();
        }


        public Comment GetById(int id)
        {
            return _commnet.GetById(id);
        }


        public void TAdd(Comment t)
        {
            _commnet.Insert(t);
        }


        public void TDelete(Comment t)
        {
            _commnet.Delete(t);
        }

        public void TUppdate(Comment t)
        {
            _commnet.Update(t);
        }
    }
}
