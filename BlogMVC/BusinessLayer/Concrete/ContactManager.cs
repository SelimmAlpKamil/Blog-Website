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
    public class ContactManager:IContactServicecs
    {
        Repository<Contact> repository = new Repository<Contact>();

        IContactDAL _contact;

        public ContactManager(IContactDAL contact)
        {
            _contact = contact;
        }


        public List<Contact> FindMailList(int id)
        {
            return _contact.List(x=>x.ContactId==id);
        }


        public List<Contact> GetList()
        {
            return _contact.List();
        }

        public void TAdd(Contact t)
        {
            _contact.Insert(t);
        }

        public Contact GetById(int id)
        {
           return _contact.GetById(id);
        }

        public void TDelete(Contact t)
        {
            _contact.Delete(t);
        }

        public void TUppdate(Contact t)
        {
            _contact.Update(t);
        }
    }
}
