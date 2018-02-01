using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Business_entities
{
   public class registrationcls
    {
        public string name { get; set; }
       [Range (10,12)]
        public string mobile { get; set; }
       [Range(10, 30)]
        public string userid { get; set; }
       [Range(8, 30)]
        public string password { get; set; }
       [Range(3, 30)]
        public string answer { get; set; }
    }
}
