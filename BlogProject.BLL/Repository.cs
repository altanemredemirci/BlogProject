using BlogProject.DAL;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class Repository<T> where T:class 
    {
        //private DatabaseContext db = new DatabaseContext();  
        private DatabaseContext db; //Singleton 
        private DbSet<T> _objectSet;

        public Repository()
        {
            db = RepositoryBase.CreateContext();
            _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList(); //   Set<T> ->  DbSet<Category> Categories -> db.Categories.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> where) // List(i=> i.Id==id)
        {
            return _objectSet.Where(where).ToList(); //   Set<T> ->  DbSet<Category> Categories -> db.Categories.ToList();
            //db.Products.Where(i=> i.CategoryId==catId).ToList()
        }

        public T Find(Expression<Func<T, bool>> where) 
        {
            return _objectSet.FirstOrDefault(where);             
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return db.SaveChanges();
        }


        public int Update(T obj)
        {
           return db.SaveChanges();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return db.SaveChanges();
        }

    }
}
