using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities
{
    public class User:MyEntityBase
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [Required,StringLength(25)]
        public string Username { get; set; }

        [Required, StringLength(70),DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(25)]
        public string Password { get; set; }
        public bool IsActive { get; set; }

        [StringLength(30)] //user_12.png
        public string ProfileImageFileName { get; set; }

        [Required]
        public Guid ActivateGuid { get; set; }//www.google.com/1678-AB12-6789-56BA
        public bool IsAdmin { get; set; }

        public virtual List<Comment> Comments { get; set; }
        public virtual List<Blog> Blogs { get; set; }
        public virtual List<Like> Likes { get; set; }
    }
}
