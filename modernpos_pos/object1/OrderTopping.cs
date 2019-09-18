using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class OrderTopping:Persistent
    {
        public String order_topping_id { get; set; }
        public String order_id { get; set; }
        public String foods_topping_id { get; set; }
        public String row1 { get; set; }
    }
}
