using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
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
    

    public class CategoryManager: ICategoryService
    {

        Repository<Category> repoCategory = new Repository<Category>();

        ICategoryDAL _category;

        public CategoryManager(ICategoryDAL category)
        {
            _category = category;
        }

        public List<Category> CategoryListFalse()
        {
            return _category.List(x=>x.CategoryStatus==false);
        }

        public List<Category> GetList()
        {
            return _category.List(x=>x.CategoryStatus==true);
        }

        public Category GetById(int id)
        {
            return _category.GetById(id);
        }


        public void TAdd(Category t)
        {
            _category.Insert(t);
        }

        

        public void TDelete(Category t)
        {
            _category.Delete(t);
        }

        public void TUppdate(Category t)
        {
            _category.Update(t);
        }
    }
}
