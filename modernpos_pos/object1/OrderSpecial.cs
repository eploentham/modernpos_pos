using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class OrderSpecial:Persistent
    {
        public String order_special_id { get; set; }
        public String order_id { get; set; }
        public String foods_spec_id { get; set; }
        public String row1 { get; set; }
        public String status_ok { get; set; }
        public String name { get; set; }
        public String foods_id { get; set; }
        public String row_ord { get; set; }
    }
}
