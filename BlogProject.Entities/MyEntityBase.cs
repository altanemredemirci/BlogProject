using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entities
{
    public class MyEntityBase
    {
        //[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //id,ID,Id,CategoryId
        public DateTime CreateOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedUsername { get; set; }
    }
}
