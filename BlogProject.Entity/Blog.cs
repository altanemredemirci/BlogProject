using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    internal class Blog:BaseEntity
    {      
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }

        public int CategoryId { get; set; } 
        public Category Category { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }

        public User Owner { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Liked> Likes { get; set; }
    }
}
