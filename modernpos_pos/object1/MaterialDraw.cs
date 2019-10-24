using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class MaterialDraw:Persistent
    {
        public String matd_id { get; set; }
        public String matd_code { get; set; }
        public String matd_date { get; set; }
        public String year_id { get; set; }
        public String status_stock { get; set; }
        public String status_stock_year { get; set; }
    }
}
