﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
   public class AddMovie
    {

        public string showid { get; set; }

        public string moviename { get; set; }

        public DateTime date { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }
        
        
    }
}
