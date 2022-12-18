using BlogProject.DAL;
using BlogProject.DAL.Abstract;
using BlogProject.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.EF
{
    public class Repository<T>:RepositoryBase,IRepository<T> where T:class 
    {
        //private DatabaseContext db = new DatabaseContext();          
        private DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = _db.Set<T>();
        }

        //Queryable:Veritabanına sorgu kodunu göndermeden koda sonradan sorgu eklenebilirlik özelliği verir.
        public virtual IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable(); // Set<T> ->  DbSet<Category> Categories -> db.Blogs.AsQueryable();
        }

        public List<T> List()
        {
            return _objectSet.ToList(); 
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
            return _db.SaveChanges();
        }


        public int Update(T obj)
        {
           return _db.SaveChanges();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return _db.SaveChanges();
        }

       
    }
}
