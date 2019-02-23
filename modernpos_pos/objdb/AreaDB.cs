using C1.Win.C1Input;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class AreaDB
    {
        Area area;
        ConnectDB conn;
        public List<Area> lSex;
        public AreaDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lSex = new List<Area>();
            area = new Area();
            area.area_id = "area_id";
            area.area_code = "area_code";
            area.area_name = "area_name";
            area.active = "active";
            area.remark = "remark";
            area.date_cancel = "date_cancel";
            area.date_create = "date_create";
            area.date_modi = "date_modi";
            area.user_cancel = "user_cancel";
            area.user_create = "user_create";
            area.user_modi = "user_modi";
            area.host_id = "host_id";
            area.branch_id = "branch_id";
            area.device_id = "device_id";

            area.pkField = "area_id";
            area.table = "b_area";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + area.table + " sex " +
                " " +
                "Where sex." + area.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + area.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + area.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Area selectByPk1(String copId)
        {
            Area cop1 = new Area();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + area.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + area.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setSex(dt);
            return cop1;
        }
        private Area setSex(DataTable dt)
        {
            Area dept1 = new Area();
            if (dt.Rows.Count > 0)
            {
                dept1.area_id = dt.Rows[0][area.area_id].ToString();
                dept1.area_name = dt.Rows[0][area.area_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + area.pkField + ",sex." + area.area_name + " " +
                "From " + area.table + " sex " +
                " " +
                "Where sex." + area.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlSex()
        {
            //lDept = new List<Position>();
            lSex.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Area itm1 = new Area();
                itm1.area_id = row[area.area_id].ToString();
                itm1.area_name = row[area.area_name].ToString();

                lSex.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lSex.Count <= 0) getlSex();
            foreach (Area sex in lSex)
            {
                if (sex.area_id.Equals(id))
                {
                    re = sex.area_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Area p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            
            p.area_name = p.area_name == null ? "" : p.area_name;
            p.area_code = p.area_code == null ? "" : p.area_code;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(Area p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + area.table + " set " + 
                " " + area.area_code + " = '" + p.area_code + "'" +
                "," + area.area_name + " = '" + p.area_name.Replace("'", "''") + "'" +
                "," + area.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + area.date_create + " = now()" +
                "," + area.user_create + " = '" + userId + "' " +
                "," + area.host_id + " = '" + p.host_id + "' " +
                "," + area.branch_id + " = '" + p.branch_id + "' " +
                "," + area.device_id + " = '" + p.device_id + "' " +
                ")";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String update(Area p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + area.table + " Set " +
                " " + area.area_code + " = '" + p.area_code + "'" +
                "," + area.area_name + " = '" + p.area_name.Replace("'", "''") + "'" +
                "," + area.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + area.date_modi + " = now()" +
                "," + area.user_modi + " = '" + userId + "' " +
                "," + area.host_id + " = '" + p.host_id + "' " +
                "," + area.branch_id + " = '" + p.branch_id + "' " +
                "," + area.device_id + " = '" + p.device_id + "' " +
                
                "Where " + area.pkField + "='" + p.area_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }

            return re;
        }
        public String insertStaff(Area p, String userId)
        {
            String re = "";

            if (p.area_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public C1ComboBox setCboSex(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectC1();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            foreach (DataRow row in dt.Rows)
            {
                item = new ComboBoxItem();
                item.Text = row[area.area_name].ToString();
                item.Value = row[area.area_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboSex(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lSex.Count <= 0) getlSex();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Area row in lSex)
            {
                item = new ComboBoxItem();
                item.Value = row.area_id;
                item.Text = row.area_name;
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
                i++;
            }
            return c;
        }
    }
}
