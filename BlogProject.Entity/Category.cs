﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Entity
{
    internal class Category:BaseEntity
    {       
        public string Title { get; set; }
        public string Description { get; set; }      
    }
}
