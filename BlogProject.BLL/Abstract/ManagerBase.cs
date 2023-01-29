using BlogProject.Core.DataAccess;
using BlogProject.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Abstract
{
    public abstract class ManagerBase<T> : IRepository<T> where T : class
    {
        private Repository<T> repo = new Repository<T>(); 
        public virtual int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return repo.Find(where);
        }

        public virtual int Insert(T obj)
        {
            return repo.Insert(obj);
        }

        public List<T> List()
        {
            return repo.List();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return repo.List(where);
        }

        public IQueryable<T> ListQueryable()
        {
            return repo.ListQueryable();
        }

        public virtual int Update(T obj)
        {
            return repo.Update(obj);
        }
    }
}
