using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Abstract
{
    internal interface IRepository<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> where);

        IQueryable<T> ListQueryable();
        T Find(Expression<Func<T, bool>> where);
        int Insert(T obj);
        int Update(T obj);
        int Delete(T obj);       
    }
}
