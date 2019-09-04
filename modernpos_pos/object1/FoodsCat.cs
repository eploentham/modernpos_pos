using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class FoodsCat:Persistent
    {
        public String foods_cat_id { get; set; }
        public String foods_cat_code { get; set; }
        public String foods_cat_name { get; set; }
        public String filename { get; set; }
        public String status_recommend { get; set; }
    }
}
