﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c =new Context();
        DbSet<T> _object;
        public void Delete(T p)
        {
            var deletedentity=c.Entry(p);
            deletedentity.State=EntityState.Deleted;
           // _object.Remove(p);
            c.SaveChanges();
        }
        public GenericRepository() 
        {
            _object= c.Set<T>();
        }

        public void Insert(T p)
        {
            var addedentity = c.Entry(p);
            addedentity.State = EntityState.Added;
           // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedentity = c.Entry(p);
            updatedentity.State=EntityState.Modified;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> Filter)
        {
            return _object.SingleOrDefault(Filter);
        }
    }
}
