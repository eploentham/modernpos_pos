using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Order1:Persistent
    {
        public String order_id { get; set; }
        public String lot_id { get; set; }
        public String row1 { get; set; }
        public String foods_id { get; set; }
        public String foods_code { get; set; }
        public String foods_name { get; set; }
        public String order_date { get; set; }
        public String price { get; set; }
        public String qty { get; set; }        
        public String table_id { get; set; }
        public String res_id { get; set; }
        public String area_id { get; set; }
        public String status_foods_1 { get; set; }
        public String status_foods_2 { get; set; }
        public String status_foods_3 { get; set; }
        public String status_bill { get; set; }
        public String bill_check_date { get; set; }
        public String status_cook { get; set; }
        public String cook_receive_date { get; set; }
        public String cook_finish_date { get; set; }
        public String void_date { get; set; }
        public String status_void { get; set; }
        public String printer_name { get; set; }
        public String status_to_go { get; set; }
        public String bill_id { get; set; }
        public String order_user { get; set; }
        public String status_closeday { get; set; }
        public String closeday_id { get; set; }
        public String cnt_cust { get; set; }
        public String special { get; set; }
        public String topping { get; set; }
    }
}
