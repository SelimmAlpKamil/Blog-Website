using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager:IAboutSevice
    {
        Repository<About> repo = new Repository<About> ();

        IAboutDAL _about;

        public AboutManager(IAboutDAL about)
        {
            _about = about;
        }


        public List<About> GetList()
        {
            return _about.List();
        }

        public void TAdd(About t)
        {
            _about.Insert(t);
        }

         public About GetById(int id)
        {
            return _about.GetById(id);
        }

        public void TDelete(About t)
        {
            _about.Delete(t);
        }

        public void TUppdate(About t)
        {
            _about.Update(t);
        }
    }
}
