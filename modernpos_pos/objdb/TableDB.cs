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
    public class TableDB
    {
        Table tbl;
        ConnectDB conn;
        public List<Table> lArea;
        public TableDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lArea = new List<Table>();
            tbl = new Table();
            tbl.table_id = "table_id";
            tbl.area_id = "area_id";
            tbl.table_code = "table_code";
            tbl.table_name = "table_name";
            tbl.active = "active";
            tbl.remark = "remark";
            tbl.sort1 = "sort1";
            tbl.date_cancel = "date_cancel";
            tbl.date_create = "date_create";
            tbl.date_modi = "date_modi";
            tbl.user_cancel = "user_cancel";
            tbl.user_create = "user_create";
            tbl.user_modi = "user_modi";
            tbl.host_id = "host_id";
            tbl.branch_id = "branch_id";
            tbl.device_id = "device_id";
            tbl.status_togo = "status_togo";
            tbl.status_use = "status_use";
            tbl.status_use = "status_use";
            tbl.status_reser = "status_reser";

            tbl.pkField = "table_id";
            tbl.table = "b_table";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + tbl.table + " sex " +
                " " +
                "Where sex." + tbl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + tbl.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + tbl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Table selectByPk1(String copId)
        {
            Table cop1 = new Table();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + tbl.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + tbl.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTable(dt);
            return cop1;
        }
        private Table setArea1(DataTable dt)
        {
            Table dept1 = new Table();
            if (dt.Rows.Count > 0)
            {
                dept1.table_id = dt.Rows[0][tbl.table_id].ToString();
                dept1.table_name = dt.Rows[0][tbl.table_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + tbl.pkField + ",sex." + tbl.table_name + " " +
                "From " + tbl.table + " sex " +
                " " +
                "Where sex." + tbl.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lArea.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Table itm1 = new Table();
                itm1.table_id = row[tbl.table_id].ToString();
                itm1.table_name = row[tbl.table_name].ToString();

                lArea.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lArea.Count <= 0) getlArea();
            foreach (Table sex in lArea)
            {
                if (sex.table_id.Equals(id))
                {
                    re = sex.table_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Table p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.table_name = p.table_name == null ? "" : p.table_name;
            p.table_code = p.table_code == null ? "" : p.table_code;

            p.status_togo = p.status_togo == null ? "0" : p.status_togo;
            p.status_reser = p.status_reser == null ? "0" : p.status_reser;
            p.status_use = p.status_use == null ? "0" : p.status_use;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.area_id = long.TryParse(p.area_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(Table p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + tbl.table + " set " +
                " " + tbl.table_code + " = '" + p.table_code + "'" +
                "," + tbl.table_name + " = '" + p.table_name.Replace("'", "''") + "'" +
                "," + tbl.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + tbl.date_create + " = now()" +
                "," + tbl.active + " = '1'" +
                "," + tbl.user_create + " = '" + userId + "' " +
                "," + tbl.host_id + " = '" + p.host_id + "' " +
                "," + tbl.branch_id + " = '" + p.branch_id + "' " +
                "," + tbl.device_id + " = '" + p.device_id + "' " +
                "," + tbl.status_togo + " = '" + p.status_togo + "' " +
                "," + tbl.status_reser + " = '" + p.status_reser + "' " +
                "," + tbl.status_use + " = '" + p.status_use + "' " +
                "," + tbl.area_id + " = '" + p.area_id + "' " +
                " ";
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
        public String update(Table p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + tbl.table + " Set " +
                " " + tbl.table_code + " = '" + p.table_code + "'" +
                "," + tbl.table_name + " = '" + p.table_name.Replace("'", "''") + "'" +
                "," + tbl.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + tbl.date_modi + " = now()" +
                "," + tbl.user_modi + " = '" + userId + "' " +
                "," + tbl.host_id + " = '" + p.host_id + "' " +
                "," + tbl.branch_id + " = '" + p.branch_id + "' " +
                "," + tbl.device_id + " = '" + p.device_id + "' " +
                "," + tbl.status_togo + " = '" + p.status_togo + "' " +
                "," + tbl.area_id + " = '" + p.area_id + "' " +
                "Where " + tbl.pkField + "='" + p.table_id + "'"
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
        public String insertTable(Table p, String userId)
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
        public C1ComboBox setCboTable(C1ComboBox c)
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
                item.Text = row[tbl.table_name].ToString();
                item.Value = row[tbl.table_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboTable(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lArea.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Table row in lArea)
            {
                item = new ComboBoxItem();
                item.Value = row.table_id;
                item.Text = row.table_name;
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
        private Table setTable(DataTable dt)
        {
            Table dept1 = new Table();
            if (dt.Rows.Count > 0)
            {
                dept1.table_id = dt.Rows[0][tbl.table_id].ToString();
                dept1.table_code = dt.Rows[0][tbl.table_code].ToString();
                dept1.table_name = dt.Rows[0][tbl.table_name].ToString();
                dept1.area_id = dt.Rows[0][tbl.area_id] != null ? dt.Rows[0][tbl.area_id].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][tbl.remark] != null ? dt.Rows[0][tbl.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][tbl.date_create] != null ? dt.Rows[0][tbl.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][tbl.date_modi] != null ? dt.Rows[0][tbl.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][tbl.date_cancel] != null ? dt.Rows[0][tbl.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][tbl.user_create] != null ? dt.Rows[0][tbl.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][tbl.user_modi] != null ? dt.Rows[0][tbl.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][tbl.user_cancel] != null ? dt.Rows[0][tbl.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][tbl.active] != null ? dt.Rows[0][tbl.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][tbl.sort1] != null ? dt.Rows[0][tbl.sort1].ToString() : "";
                dept1.status_togo = dt.Rows[0][tbl.status_togo] != null ? dt.Rows[0][tbl.status_togo].ToString() : "";
                dept1.status_reser = dt.Rows[0][tbl.status_reser] != null ? dt.Rows[0][tbl.status_reser].ToString() : "";
                dept1.status_use = dt.Rows[0][tbl.status_use] != null ? dt.Rows[0][tbl.status_use].ToString() : "";
            }
            else
            {
                dept1.area_id = "";
                dept1.table_code = "";
                dept1.table_name = "";
                //posi.dept_parent_id = "dept_parent_id";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.status_togo = "";
                dept1.status_reser = "";
                dept1.status_use = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
