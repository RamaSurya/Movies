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
       [Range (3,25)]
        public string name { get; set; }
       [RegularExpression("^[0-9]{10}$", ErrorMessage = "Invalid Mobile No")]
        public string mobile { get; set; }
       [Range(8, 50)]
        public string userid { get; set; }
       [Range(8, 20)]
        public string password { get; set; }
       [Range(5, 100)]
        public string answer { get; set; }
    }
}
