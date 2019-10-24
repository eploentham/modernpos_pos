using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Material:Persistent
    {
        public String material_id { get; set; }
        public String material_name { get; set; }
        public String weight { get; set; }
        public String price { get; set; }
        public String filename { get; set; }
        public String material_code { get; set; }
        public String material_type_id { get; set; }
        public String unit_id { get; set; }
        public String unit_cal_id { get; set; }
    }
}
