using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class NoodleMakeDB
    {
        public NoodleMake noom;
        ConnectDB conn;
        public List<NoodleMake> lfooC;

        public NoodleMakeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooC = new List<NoodleMake>();
            noom = new NoodleMake();
            noom.noodle_make_id = "noodle_make_id";
            noom.noodle_make_name = "noodle_make_name";
            noom.noodle_make_price = "noodle_make_price";
            noom.active = "active";
            noom.noodle_make_where = "noodle_make_where";
            noom.sort1 = "sort1";
            noom.date_cancel = "date_cancel";
            noom.date_create = "date_create";
            noom.date_modi = "date_modi";
            noom.user_cancel = "user_cancel";
            noom.user_create = "user_create";
            noom.user_modi = "user_modi";
            noom.noodle_make_where1 = "noodle_make_where1";
            
            //noom.status_aircondition = "status_aircondition";

            noom.pkField = "noodle_make_id";
            noom.table = "b_noodle_make";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select noom.*  " +
                "From " + noom.table + " noom " +
                " " +
                "Where noom." + noom.active + " ='1' " +
                "Order By noom." + noom.noodle_make_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select noom.* " +
                "From " + noom.table + " noom " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where noom." + noom.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByWhere1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select noom.* " + 
                " From " + noom.table + " noom " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where noom." + noom.noodle_make_where + " ='" + copId + "' and noom." + noom.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
    }
}
