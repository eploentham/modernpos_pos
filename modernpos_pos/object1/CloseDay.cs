using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class CloseDay:Persistent
    {
        public String closeday_id { get; set; }
        public String amount { get; set; }
        public String amt_cash { get; set; }
        public String amt_credit_card { get; set; }
        public String closeday_date { get; set; }
        public String res_id { get; set; }
        public String deposit { get; set; }
        public String expense_1 { get; set; }
        public String expense_2 { get; set; }
        public String expense_3 { get; set; }
        public String expense_4 { get; set; }
        public String expense_5 { get; set; }
        public String total_cash { get; set; }    
        public String amount_order { get; set; }
        public String bill_amount { get; set; }
        public String cash_draw1 { get; set; }
        public String cash_draw1_remark { get; set; }
        public String cash_draw2 { get; set; }
        public String cash_draw2_remark { get; set; }
        public String cash_draw3 { get; set; }
        public String cash_draw3_remark { get; set; }
        public String cash_receive1 { get; set; }
        public String cash_receive1_remark { get; set; }
        public String cash_receive2 { get; set; }
        public String cash_receive2_remark { get; set; }
        public String cash_receive3 { get; set; }
        public String cash_receive3_remark { get; set; }
        public String closeday_user { get; set; }
        public String cnt_bill { get; set; }
        public String cnt_order { get; set; }
        public String discount { get; set; }
        public String nettotal { get; set; }
        public String service_charge { get; set; }
        public String status_void { get; set; }
        public String total { get; set; }
        public String vat { get; set; }
        public String void_date { get; set; }
        public String void_user { get; set; }
        public String weather { get; set; }
        public String cash_receive { get; set; }
        public String cash_ton { get; set; }

    }
}
