using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class NoodleMake:Persistent
    {
        public String noodle_make_id { get; set; }
        public String noodle_make_name { get; set; }
        public String noodle_make_price { get; set; }
        public String noodle_make_where { get; set; }
        public String noodle_make_where1 { get; set; }
        public String status_us { get; set; }
    }
}
