using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Area:Persistent
    {
        public String area_id { get; set; }
        public String area_code { get; set; }
        public String area_name { get; set; }

        public String status_aircondition { get; set; }
        //public String remark { get; set; }
        //public String sort1 { get; set; }
        //public String date_create { get; set; }
        //public String date_modi { get; set; }
        //public String date_cancel { get; set; }
        //public String host_id { get; set; }
        //public String branch_id { get; set; }
        //public String device_id { get; set; }
    }
}
