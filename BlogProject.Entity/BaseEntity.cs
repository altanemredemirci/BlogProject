using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required,StringLength(30),DisplayName("Düzenleyen")]
        public string ModifiedUsername { get; set; }
    }
}
