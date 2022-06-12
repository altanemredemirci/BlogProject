using BlogProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL
{
    public class Test
    {
        public Test()
        {
            DatabaseContext db = new DatabaseContext();
            db.Database.CreateIfNotExists();
        }
    }
}
