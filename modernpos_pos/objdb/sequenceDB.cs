using modernpos_pos.object1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class sequenceDB
    {
        public sequence1 seq;
        ConnectDB conn;

        public sequenceDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            seq = new sequence1();
            seq.lot_id = "lot_id";
        }
        public String genLotId()
        {
            String re = "",sql="";
            //DataTable dt = new DataTable();

            //sql = "UPDATE sequence SET lot_id=LAST_INSERT_ID("+seq.lot_id+"+1);";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_lot_id", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?lot_id", MySqlDbType.VarChar));
                cmd.Parameters["?lot_id"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                re = (string)cmd.Parameters["?lot_id"].Value;

            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
            }
            return re;
        }
    }
}
