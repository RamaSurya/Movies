using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntities
{
   public class UpdateSeatPrice
    {
        public string type { get; set; }
       
        public int price { get; set; }
    }
}
