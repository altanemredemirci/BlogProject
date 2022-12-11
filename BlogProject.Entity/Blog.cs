using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    public class Blog:BaseEntity
    {
        [StringLength(60), Required]
        public string Title { get; set; }

        [StringLength(2000), Required]
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

        public Blog()
        {
            Comments = new List<Comment>();
            Likes = new List<Liked>();
        }
    }
}
