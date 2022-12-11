using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    internal class Liked
    {
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public User LikedUser { get; set; }
    }
}
