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
    public class AboutInfoManager:IAboutInfoService
    {
        Repository<AboutInfo> repository = new Repository<AboutInfo>();

        IAboutInfoDAL _aboutInfo;

        public AboutInfoManager(IAboutInfoDAL aboutInfo)
        {
            _aboutInfo = aboutInfo;
        }


        public AboutInfo GetById(int id)
        {
            return _aboutInfo.GetById(id);
        }

        public List<AboutInfo> GetList()
        {
            return _aboutInfo.List();
        }

        public void TAdd(AboutInfo t)
        {
            _aboutInfo.Insert(t);
        }

        public void TDelete(AboutInfo t)
        {
            _aboutInfo.Delete(t);
        }

        public void TUppdate(AboutInfo t)
        {
            _aboutInfo.Update(t);
        }
    }
}
