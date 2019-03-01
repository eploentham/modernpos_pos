using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class BillDetail:Persistent
    {
        public String bill_detail_id { get; set; }
        public String bill_id { get; set; }
        public String order_id { get; set; }
        public String lot_id { get; set; }
        public String status_void { get; set; }
        public String row1 { get; set; }
        public String foods_id { get; set; }
        public String foods_code { get; set; }
        public String price { get; set; }
        public String qty { get; set; }
        public String amount { get; set; }

    }
}
