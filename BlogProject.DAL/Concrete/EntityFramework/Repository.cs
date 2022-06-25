using BlogProject.Common;
using BlogProject.DAL.Abstract;
using BlogProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.EntityFramework
{
    public class Repository<T> : RepositoryBase,IRepository<T> where T : class
    {
        //private DatabaseContext db = new DatabaseContext(); //singleton
        
        private DbSet<T> _objectSet;

        public Repository()
        {
           _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable<T>();
        }

        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            if(obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;
                o.CreateOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetUsername(); // TODO: İşlem yapan username yazılmalı
            }
            return Save();
        }
        public int Update(T obj)
        {
            if (obj is MyEntityBase)
            {
                MyEntityBase o = obj as MyEntityBase;
                DateTime now = DateTime.Now;
                o.CreateOn = now;
                o.ModifiedOn = now;
                o.ModifiedUsername = App.Common.GetUsername(); // TODO: İşlem yapan username yazılmalı
            }
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public int Save()
        {            
            return db.SaveChanges();
        }
    }
}
