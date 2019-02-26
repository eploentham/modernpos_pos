using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.object1
{
    public class Table : Persistent
    {
        public String table_id { get; set; }
        public String area_id { get; set; }
        public String table_code { get; set; }
        public String table_name { get; set; }
        public String status_use { get; set; }
        public String status_togo { get; set; }
        public String date_use { get; set; }
        public String status_reser { get; set; }
    }
}
