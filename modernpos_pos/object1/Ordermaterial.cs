using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class OrderMaterial:Persistent
    {
        public String order_material_id { get; set; }
        public String foods_material_id { get; set; }
        public String foods_id { get; set; }
        public String material_id { get; set; }
        public String order_id { get; set; }
        public String material_name { get; set; }
        public String foods_name { get; set; }
        public String weight { get; set; }
        public String price { get; set; }
        public String qty { get; set; }
    }
}
