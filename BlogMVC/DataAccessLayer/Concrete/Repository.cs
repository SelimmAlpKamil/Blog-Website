using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context c = new Context();

        DbSet<T> _object;

        public Repository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T p)
        {
            var DeleteEntity=c.Entry(p);
            DeleteEntity.State=EntityState.Deleted;
             c.SaveChanges();


        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _object.FirstOrDefault(where);   
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            var AddEntity = c.Entry(p);
            AddEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List(T p)
        {
            return _object.ToList();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        

        public List<T> ListTakeValue(int listValue)
        {
            return _object.Take(listValue).ToList();
        }

        public void Update(T p)
        {
            var UpdateEntity = c.Entry(p);
            UpdateEntity.State = EntityState.Modified;
             c.SaveChanges();
        }
    }
}
