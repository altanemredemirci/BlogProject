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
            DAL.DatabaseContext db = new DAL.DatabaseContext();
            db.Users.ToList();
        }
    }
}
