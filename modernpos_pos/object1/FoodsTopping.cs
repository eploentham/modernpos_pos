using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class FoodsTopping:Persistent
    {
        public String foods_topping_id { get; set; }
        public String foods_id { get; set; }
        public String foods_topping_name { get; set; }
        public String price { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String host_id { get; set; }
        public String branch_id { get; set; }
        public String device_id { get; set; }
    }
}
