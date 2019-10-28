using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Unit:Persistent
    {
        public String unit_id { get; set; }
        public String unit_name { get; set; }
        public String unit_code { get; set; }
        public String cal_unit { get; set; }
    }
}
