using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities
{
    public class Comment:MyEntityBase
    {
        [Required, StringLength(150)]
        public string Text { get; set; }


        public virtual User Owner { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
