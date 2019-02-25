using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Foods:Persistent
    {
        public String foods_id { get; set; }
        public String foods_code { get; set; }
        public String foods_name { get; set; }
        public String foods_price { get; set; }
        public String foods_type_id { get; set; }
        public String res_id { get; set; }
        public String res_code { get; set; }
        public String status_foods { get; set; }
        public String printer_name { get; set; }
        public String status_to_go { get; set; }
        public String status_dine_in { get; set; }
        public String foods_cat_id { get; set; }
    }
}
