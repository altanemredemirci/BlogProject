using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    [Table("Likes")]
    public class Liked
    {       
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public User LikedUser { get; set; }
    }
}
