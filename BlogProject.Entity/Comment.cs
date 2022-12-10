using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    internal class Comment:BaseEntity
    {
        public string Text { get; set; }

        public Blog Blog { get; set; }
        public User User { get; set; }
    }
}
