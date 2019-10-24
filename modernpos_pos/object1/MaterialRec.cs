using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class MaterialRec:Persistent
    {
        public String matr_id { get; set; }
        public String matr_code { get; set; }
        public String matr_date { get; set; }
        public String year_id { get; set; }
    }
}
