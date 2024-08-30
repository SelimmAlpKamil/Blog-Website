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
    public class SubscripeManager:ISubscripeService
    {
        Repository<Subscribe> repo = new Repository<Subscribe>();

        ISubscribeDAl _subscribe;

        public SubscripeManager(ISubscribeDAl subscribe)
        {
            _subscribe = subscribe;
        }

        public Subscribe GetById(int id)
        {
            return _subscribe.GetById(id);
        }

        public List<Subscribe> GetList()
        {
            return _subscribe.List();
        }

       

        public void TAdd(Subscribe t)
        {
            _subscribe.Insert(t);
        }

        public void TDelete(Subscribe t)
        {
            _subscribe.Delete(t);
        }

        public void TUppdate(Subscribe t)
        {
            _subscribe.Update(t);
        }
    }
}
