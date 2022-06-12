using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public virtual User LikedUser { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
