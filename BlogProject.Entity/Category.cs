using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{

    public class Category:BaseEntity
    {
        [Required,StringLength(50)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Description { get; set; }

        public virtual List<Blog> Blogs { get; set; }

        public Category()
        {
            Blogs = new List<Blog>();
        }
    }
}
