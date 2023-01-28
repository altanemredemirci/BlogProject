using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    public class User:BaseEntity
    {
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Surname { get; set; }

        [Required,StringLength(30)]
        public string Username { get; set; }

        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(25), Required, DataType(DataType.Password)]
        public string Password { get; set; }
        
        [StringLength(30)] //user12.png
        public string ProfileImageFilename { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Is Admin")]
        public bool IsAdmin { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Liked> Likes { get; set; }

    }
}
