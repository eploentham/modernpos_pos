using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class MaterialType:Persistent
    {
        public String material_type_id { get; set; }
        public String material_type_name { get; set; }
        public String material_type_code { get; set; }
    }
}
