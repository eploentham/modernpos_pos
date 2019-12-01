using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Bill:Persistent
    {
        public String bill_id { get; set; }
        public String bill_code { get; set; }
        public String bill_date { get; set; }
        public String lot_id { get; set; }
        public String status_void { get; set; }
        public String void_date { get; set; }
        public String void_user { get; set; }
        public String table_id { get; set; }
        public String res_id { get; set; }
        public String area_id { get; set; }
        public String amount { get; set; }
        public String discount { get; set; }
        public String service_charge { get; set; }
        public String vat { get; set; }
        public String total { get; set; }
        public String nettotal { get; set; }
        public String cash_receive { get; set; }
        public String cash_ton { get; set; }
        public String bill_user { get; set; }
        public String status_closeday { get; set; }
        public String closeday_id { get; set; }
        public String status_payment { get; set; }

    }
}
