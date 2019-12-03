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
    public class FoodsSpecialDB
    {
        public FoodsSpecial foos;
        ConnectDB conn;
        public List<FoodsSpecial> lfooC;

        public FoodsSpecialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooC = new List<FoodsSpecial>();
            foos = new FoodsSpecial();
            foos.foods_spec_id = "foods_spec_id";
            foos.foods_id = "foods_id";
            foos.foods_spec_name = "foods_spec_name";
            foos.active = "active";
            foos.remark = "remark";
            foos.sort1 = "sort1";
            foos.date_cancel = "date_cancel";
            foos.date_create = "date_create";
            foos.date_modi = "date_modi";
            foos.user_cancel = "user_cancel";
            foos.user_create = "user_create";
            foos.user_modi = "user_modi";
            foos.host_id = "host_id";
            foos.branch_id = "branch_id";
            foos.device_id = "device_id";
            //foos.status_aircondition = "status_aircondition";

            foos.pkField = "foods_spec_id";
            foos.table = "b_foods_special";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + foos.table + " foos " +
                " " +
                "Where foos." + foos.active + " ='1' " +
                "Order By foos." + foos.foods_spec_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos."+foos.foods_spec_id+ ",foos." + foos.foods_spec_name +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.foods_id + " ='" + copId + "' and foos."+foos.active+"='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foos.foods_id + ",'' as img,foos." + foos.foods_spec_name +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.foods_id + " ='" + copId + "' and foos." + foos.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foos.foods_spec_id + ",'' as img,foos." + foos.foods_spec_name + ", foos." + foos.foods_id +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.foods_id + " ='" + copId + "' and foos." + foos.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsSpecial selectByPk1(String copId)
        {
            FoodsSpecial cop1 = new FoodsSpecial();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foos.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foos.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsSpecial(dt);
            return cop1;
        }
        private FoodsSpecial setArea1(DataTable dt)
        {
            FoodsSpecial dept1 = new FoodsSpecial();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_spec_id = dt.Rows[0][foos.foods_spec_id].ToString();
                dept1.foods_spec_name = dt.Rows[0][foos.foods_spec_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + foos.pkField + ",sex." + foos.foods_spec_name + " " +
                "From " + foos.table + " sex " +
                " " +
                "Where sex." + foos.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<FoodsSpecial> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<FoodsSpecial> lfooC1 = new List<FoodsSpecial>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                FoodsSpecial itm1 = new FoodsSpecial();
                itm1.foods_spec_id = row[foos.foods_spec_id].ToString();
                itm1.foods_spec_name = row[foos.foods_spec_name].ToString();
                itm1.foods_id = row[foos.foods_id].ToString();
                lfooC1.Add(itm1);
            }
            return lfooC1;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lfooC.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FoodsSpecial itm1 = new FoodsSpecial();
                itm1.foods_spec_id = row[foos.foods_spec_id].ToString();
                itm1.foods_spec_name = row[foos.foods_spec_name].ToString();

                lfooC.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooC.Count <= 0) getlArea();
            foreach (FoodsSpecial sex in lfooC)
            {
                if (sex.foods_spec_id.Equals(id))
                {
                    re = sex.foods_spec_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(FoodsSpecial p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.host_id = p.host_id == null ? "" : p.host_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.device_id = p.device_id == null ? "" : p.device_id;

            p.foods_spec_name = p.foods_spec_name == null ? "" : p.foods_spec_name;
            p.foods_id = p.foods_id == null ? "" : p.foods_id;

            p.remark = p.remark == null ? "" : p.remark;

            //p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            //p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            //p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(FoodsSpecial p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foos.table + " set " +
                " " + foos.foods_id + " = '" + p.foods_id + "'" +
                "," + foos.foods_spec_name + " = '" + p.foods_spec_name.Replace("'", "''") + "'" +
                "," + foos.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foos.date_create + " = now()" +
                "," + foos.active + " = '1'" +
                "," + foos.user_create + " = '" + userId + "' " +
                "," + foos.host_id + " = '" + p.host_id + "' " +
                "," + foos.branch_id + " = '" + p.branch_id + "' " +
                "," + foos.device_id + " = '" + p.device_id + "' " +
                //"," + foos.status_aircondition + " = '" + p.status_aircondition + "' " +
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
        public String update(FoodsSpecial p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foos.table + " Set " +
                " " + foos.foods_id + " = '" + p.foods_id + "'" +
                "," + foos.foods_spec_name + " = '" + p.foods_spec_name.Replace("'", "''") + "'" +
                "," + foos.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foos.date_modi + " = now()" +
                "," + foos.user_modi + " = '" + userId + "' " +
                "," + foos.host_id + " = '" + p.host_id + "' " +
                "," + foos.branch_id + " = '" + p.branch_id + "' " +
                "," + foos.device_id + " = '" + p.device_id + "' " +
                //"," + foos.status_aircondition + " = '" + p.status_aircondition + "' " +

                "Where " + foos.pkField + "='" + p.foods_spec_id + "'"
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
        public String insertFoodsSpecial(FoodsSpecial p, String userId)
        {
            String re = "";

            if (p.foods_spec_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidFoodsSpecial( String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + foos.table + " Set " +
                " " + foos.active + " = '3'" +
                "," + foos.date_cancel + " = now()" +
                "," + foos.user_modi + " = '" + userId + "' " +
                "Where " + foos.pkField + "='" + foosid + "'"
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
        public C1ComboBox setCboFoodsSpecial(C1ComboBox c)
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
                item.Text = row[foos.foods_spec_name].ToString();
                item.Value = row[foos.foods_spec_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoodsSpecial(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfooC.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FoodsSpecial row in lfooC)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_spec_id;
                item.Text = row.foods_spec_name;
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
        private FoodsSpecial setFoodsSpecial(DataTable dt)
        {
            FoodsSpecial dept1 = new FoodsSpecial();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_spec_id = dt.Rows[0][foos.foods_spec_id].ToString();
                dept1.foods_id = dt.Rows[0][foos.foods_id].ToString();
                dept1.foods_spec_name = dt.Rows[0][foos.foods_spec_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][foos.remark] != null ? dt.Rows[0][foos.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foos.date_create] != null ? dt.Rows[0][foos.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foos.date_modi] != null ? dt.Rows[0][foos.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foos.date_cancel] != null ? dt.Rows[0][foos.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foos.user_create] != null ? dt.Rows[0][foos.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foos.user_modi] != null ? dt.Rows[0][foos.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foos.user_cancel] != null ? dt.Rows[0][foos.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foos.active] != null ? dt.Rows[0][foos.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][foos.sort1] != null ? dt.Rows[0][foos.sort1].ToString() : "";
                //dept1.status_aircondition = dt.Rows[0][foos.status_aircondition] != null ? dt.Rows[0][foos.status_aircondition].ToString() : "";
            }
            else
            {
                dept1.foods_spec_id = "";
                dept1.foods_id = "";
                dept1.foods_spec_name = "";
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
                //dept1.status_aircondition = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
