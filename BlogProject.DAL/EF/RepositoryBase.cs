using BlogProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.EF
{
    public class RepositoryBase
    {
        protected static DatabaseContext _db; // Static bir yapı(static CreateContext) içerisinde kullandığım için tanım static olmak zorunda.
        private static object _lockSync = new object();


        protected RepositoryBase()
        {
            CreateContext();
        }

        public static DatabaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                   
                }
               
            }

            return _db;
        }
    }
}
