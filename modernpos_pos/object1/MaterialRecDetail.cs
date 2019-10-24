using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class MaterialRecDetail:Persistent
    {
        public String matr_detail_id { get; set; }
        public String matr_id { get; set; }
        public String material_id { get; set; }
        public String row1 { get; set; }
        public String weight { get; set; }
        public String price { get; set; }
        public String qty { get; set; }
        public String sort1 { get; set; }
    }
}
