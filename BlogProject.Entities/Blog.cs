using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities
{
    public class Blog:MyEntityBase
    {
        [Required,StringLength(60)]
        public string Title { get; set; }
        [Required, StringLength(2000)]
        public string Text { get; set; }
        public bool IsDraft { get; set; }
        public int LikeCount { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual User Owner { get; set; }        
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Like> Likes { get; set; }

        public Blog()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
    }
}
