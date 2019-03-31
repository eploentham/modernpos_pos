using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Restaurant:Persistent
    {
        public String res_id { get; set; }
        public String res_code { get; set; }
        public String res_name { get; set; }
        public String active { get; set; }
        public String remark { get; set; }
        public String date_create { get; set; }
        public String date_modi { get; set; }
        public String default_res { get; set; }
        public String receipt_footer1 { get; set; }
        public String receipt_header1 { get; set; }
        public String receipt_footer2 { get; set; }
        public String receipt_header2 { get; set; }
        public String bill_code { get; set; }
        public String bill_month { get; set; }
        public String tax_id { get; set; }
        public String printer_foods1 { get; set; }
        public String printer_foods2 { get; set; }
        public String printer_foods3 { get; set; }
        public String printer_waterbar1 { get; set; }
        public String printer_waterbar2 { get; set; }
        public String printer_waterbar3 { get; set; }
        public String sort1 { get; set; }
        public String host_id { get; set; }
        public String branch_id { get; set; }
        public String date_cancel { get; set; }
        public String user_create { get; set; }
        public String user_modi { get; set; }
        public String user_cancel { get; set; }
        public String device_id { get; set; }
        public String receipt_header3 { get; set; }
        public String receipt_footer3 { get; set; }
        public String cop_id { get; set; }
        public String printer_bill_margin_top { get; set; }
        public String printer_bill_margin_left { get; set; }
        public String printer_bill_margin_right { get; set; }
        public String printer_bill_print_top { get; set; }
        public String printer_bill_print_left { get; set; }
        public String printer_bill_print_right { get; set; }
    }
}
