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
    public class UnitDB
    {
        Unit fooT;
        ConnectDB conn;
        public List<Unit> lfooT;
        public UnitDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooT = new List<Unit>();
            fooT = new Unit();
            fooT.unit_id = "unit_id";
            fooT.unit_code = "unit_code";
            fooT.unit_name = "unit_name";
            fooT.active = "active";
            fooT.remark = "remark";
            fooT.sort1 = "sort1";
            fooT.date_cancel = "date_cancel";
            fooT.date_create = "date_create";
            fooT.date_modi = "date_modi";
            fooT.user_cancel = "user_cancel";
            fooT.user_create = "user_create";
            fooT.user_modi = "user_modi";
            fooT.host_id = "host_id";
            fooT.branch_id = "branch_id";
            fooT.device_id = "device_id";
            fooT.device_id = "device_id";
            fooT.cal_unit = "cal_unit";

            fooT.pkField = "unit_id";
            fooT.table = "b_unit";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + fooT.table + " sex " +
                " " +
                "Where sex." + fooT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + fooT.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + fooT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Unit selectByPk1(String copId)
        {
            Unit cop1 = new Unit();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + fooT.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + fooT.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsType(dt);
            return cop1;
        }
        private Unit setArea1(DataTable dt)
        {
            Unit dept1 = new Unit();
            if (dt.Rows.Count > 0)
            {
                dept1.unit_id = dt.Rows[0][fooT.unit_id].ToString();
                dept1.unit_name = dt.Rows[0][fooT.unit_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + fooT.pkField + ",sex." + fooT.unit_name + " " +
                "From " + fooT.table + " sex " +
                " " +
                "Where sex." + fooT.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lfooT.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Unit itm1 = new Unit();
                itm1.unit_id = row[fooT.unit_id].ToString();
                itm1.unit_name = row[fooT.unit_name].ToString();

                lfooT.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooT.Count <= 0) getlArea();
            foreach (Unit sex in lfooT)
            {
                if (sex.unit_id.Equals(id))
                {
                    re = sex.unit_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Unit p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.unit_name = p.unit_name == null ? "" : p.unit_name;
            p.unit_code = p.unit_code == null ? "" : p.unit_code;

            //p.status_aircondition = p.status_aircondition == null ? "0" : p.status_aircondition;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

            p.cal_unit = Decimal.TryParse(p.cal_unit, out chk1) ? chk.ToString() : "0";

        }
        public String insert(Unit p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + fooT.table + " set " +
                " " + fooT.unit_code + " = '" + p.unit_code + "'" +
                "," + fooT.unit_name + " = '" + p.unit_name.Replace("'", "''") + "'" +
                "," + fooT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fooT.date_create + " = now()" +
                "," + fooT.active + " = '1'" +
                "," + fooT.user_create + " = '" + userId + "' " +
                "," + fooT.host_id + " = '" + p.host_id + "' " +
                "," + fooT.branch_id + " = '" + p.branch_id + "' " +
                "," + fooT.device_id + " = '" + p.device_id + "' " +
                "," + fooT.cal_unit + " = '" + p.cal_unit + "' " +
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
        public String update(Unit p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fooT.table + " Set " +
                " " + fooT.unit_code + " = '" + p.unit_code + "'" +
                "," + fooT.unit_name + " = '" + p.unit_name.Replace("'", "''") + "'" +
                "," + fooT.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fooT.date_modi + " = now()" +
                "," + fooT.user_modi + " = '" + userId + "' " +
                "," + fooT.host_id + " = '" + p.host_id + "' " +
                "," + fooT.branch_id + " = '" + p.branch_id + "' " +
                "," + fooT.device_id + " = '" + p.device_id + "' " +
                "," + fooT.cal_unit + " = '" + p.cal_unit + "' " +

                "Where " + fooT.pkField + "='" + p.unit_id + "'"
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
        public String insertUnit(Unit p, String userId)
        {
            String re = "";

            if (p.unit_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String VoidUnit(String unitid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fooT.table + " Set " +
                " " + fooT.active + " = '3'" +                
                "," + fooT.date_cancel + " = now()" +
                "," + fooT.user_cancel + " = '" + userId + "' " +
                "Where " + fooT.pkField + "='" + unitid + "'"
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
        public C1ComboBox setCboUnit(C1ComboBox c)
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
                item.Text = row[fooT.unit_name].ToString();
                item.Value = row[fooT.unit_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboUnit(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfooT.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Unit row in lfooT)
            {
                item = new ComboBoxItem();
                item.Value = row.unit_id;
                item.Text = row.unit_name;
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
        private Unit setFoodsType(DataTable dt)
        {
            Unit dept1 = new Unit();
            if (dt.Rows.Count > 0)
            {
                dept1.unit_id = dt.Rows[0][fooT.unit_id].ToString();
                dept1.unit_code = dt.Rows[0][fooT.unit_code].ToString();
                dept1.unit_name = dt.Rows[0][fooT.unit_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][fooT.remark] != null ? dt.Rows[0][fooT.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][fooT.date_create] != null ? dt.Rows[0][fooT.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][fooT.date_modi] != null ? dt.Rows[0][fooT.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][fooT.date_cancel] != null ? dt.Rows[0][fooT.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][fooT.user_create] != null ? dt.Rows[0][fooT.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][fooT.user_modi] != null ? dt.Rows[0][fooT.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][fooT.user_cancel] != null ? dt.Rows[0][fooT.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][fooT.active] != null ? dt.Rows[0][fooT.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][fooT.sort1] != null ? dt.Rows[0][fooT.sort1].ToString() : "";
                dept1.cal_unit = dt.Rows[0][fooT.cal_unit] != null ? dt.Rows[0][fooT.cal_unit].ToString() : "";
            }
            else
            {
                dept1.unit_id = "";
                dept1.unit_code = "";
                dept1.unit_name = "";
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
                dept1.cal_unit = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
