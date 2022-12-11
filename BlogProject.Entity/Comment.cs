using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    public class Comment:BaseEntity
    {
        public string Text { get; set; }

        public Blog Blog { get; set; }
        public User Owner { get; set; }
    }
}
