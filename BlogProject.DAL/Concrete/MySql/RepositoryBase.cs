using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Concrete.MySql
{
    public class RepositoryBase
    {
        //protected static MySqlContext db;
        //private static object _lockSync = new object();
        //protected RepositoryBase() //Sadece kendisinden miras alanlar newleyebilir.
        //{
        //    CreateContext();
        //}

        //private static void CreateContext() //static method instance alınmadan direk erişilebilir.
        //{
        //    if (db == null)
        //    {
        //        lock (_lockSync) //1.Mssql 2.Mysql 3.MssSql-Northwind
        //        {
        //            if (db == null)
        //            {
        //                db = new MySqlContext();
        //            }

        //        }

        //    }
        //}
    }
}
