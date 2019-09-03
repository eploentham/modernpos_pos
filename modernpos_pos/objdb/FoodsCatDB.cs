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
    public class FoodsCatDB
    {
        public FoodsCat fooC;
        ConnectDB conn;
        public List<FoodsCat> lfooC;
        public FoodsCatDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooC = new List<FoodsCat>();
            fooC = new FoodsCat();
            fooC.foods_cat_id = "foods_cat_id";
            fooC.foods_cat_code = "foods_cat_code";
            fooC.foods_cat_name = "foods_cat_name";
            fooC.active = "active";
            fooC.remark = "remark";
            fooC.sort1 = "sort1";
            fooC.date_cancel = "date_cancel";
            fooC.date_create = "date_create";
            fooC.date_modi = "date_modi";
            fooC.user_cancel = "user_cancel";
            fooC.user_create = "user_create";
            fooC.user_modi = "user_modi";
            fooC.host_id = "host_id";
            fooC.branch_id = "branch_id";
            fooC.device_id = "device_id";
            fooC.filename = "filename";

            fooC.pkField = "foods_cat_id";
            fooC.table = "b_foods_category";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select fooC.*  " +
                "From " + fooC.table + " fooC " +
                " " +
                "Where fooC." + fooC.active + " ='1' " +
                "Order By fooC." + fooC.foods_cat_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select fooC.* " +
                "From " + fooC.table + " fooC " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where fooC." + fooC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsCat selectByPk1(String copId)
        {
            FoodsCat cop1 = new FoodsCat();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + fooC.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + fooC.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsCat(dt);
            return cop1;
        }
        private FoodsCat setArea1(DataTable dt)
        {
            FoodsCat dept1 = new FoodsCat();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_cat_id = dt.Rows[0][fooC.foods_cat_id].ToString();
                dept1.foods_cat_name = dt.Rows[0][fooC.foods_cat_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + fooC.pkField + ",sex." + fooC.foods_cat_name + " " +
                "From " + fooC.table + " sex " +
                " " +
                "Where sex." + fooC.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlFoodsCat()
        {
            //lDept = new List<Position>();
            lfooC.Clear();
            DataTable dt = new DataTable();
            if (lfooC.Count <= 0) dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FoodsCat itm1 = new FoodsCat();
                itm1.foods_cat_id = row[fooC.foods_cat_id].ToString();
                itm1.foods_cat_name = row[fooC.foods_cat_name].ToString();
                itm1.filename = row[fooC.filename].ToString();
                lfooC.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooC.Count <= 0) getlFoodsCat();
            foreach (FoodsCat sex in lfooC)
            {
                if (sex.foods_cat_id.Equals(id))
                {
                    re = sex.foods_cat_name;
                    break;
                }
            }
            return re;
        }
        public FoodsCat getFoodsCat(String id)
        {
            String re = "";
            FoodsCat fooc = new FoodsCat();
            if (lfooC.Count <= 0) getlFoodsCat();
            foreach (FoodsCat sex in lfooC)
            {
                if (sex.foods_cat_id.Equals(id))
                {
                    //re = sex.foods_cat_name;
                    fooc = sex;
                    break;
                }
            }
            return fooc;
        }
        private void chkNull(FoodsCat p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.foods_cat_name = p.foods_cat_name == null ? "" : p.foods_cat_name;
            p.foods_cat_code = p.foods_cat_code == null ? "" : p.foods_cat_code;
            p.filename = p.filename == null ? "" : p.filename;
            //p.status_aircondition = p.status_aircondition == null ? "0" : p.status_aircondition;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(FoodsCat p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + fooC.table + " set " +
                " " + fooC.foods_cat_code + " = '" + p.foods_cat_code + "'" +
                "," + fooC.foods_cat_name + " = '" + p.foods_cat_name.Replace("'", "''") + "'" +
                "," + fooC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fooC.date_create + " = now()" +
                "," + fooC.active + " = '1'" +
                "," + fooC.user_create + " = '" + userId + "' " +
                "," + fooC.host_id + " = '" + p.host_id + "' " +
                "," + fooC.branch_id + " = '" + p.branch_id + "' " +
                "," + fooC.device_id + " = '" + p.device_id + "' " +
                "," + fooC.filename + " = '" + p.filename + "' " +
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
        public String update(FoodsCat p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fooC.table + " Set " +
                " " + fooC.foods_cat_code + " = '" + p.foods_cat_code + "'" +
                "," + fooC.foods_cat_name + " = '" + p.foods_cat_name.Replace("'", "''") + "'" +
                "," + fooC.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fooC.date_modi + " = now()" +
                "," + fooC.user_modi + " = '" + userId + "' " +
                "," + fooC.host_id + " = '" + p.host_id + "' " +
                "," + fooC.branch_id + " = '" + p.branch_id + "' " +
                "," + fooC.device_id + " = '" + p.device_id + "' " +
                //"," + fooC.status_aircondition + " = '" + p.status_aircondition + "' " +

                "Where " + fooC.pkField + "='" + p.foods_cat_id + "'"
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
        public String insertFoodsCat(FoodsCat p, String userId)
        {
            String re = "";

            if (p.foods_cat_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateFileName(String fooid, String filename)
        {
            String re = "";
            String sql = "";
            int chk = 0;
            
            sql = "Update " + fooC.table + " Set " +
                " " + fooC.filename + " = '" + filename + "'" +
                "Where " + fooC.pkField + "='" + fooid + "'"
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
        public C1ComboBox setCboFoodsCat(C1ComboBox c)
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
                item.Text = row[fooC.foods_cat_name].ToString();
                item.Value = row[fooC.foods_cat_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoodsCat(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfooC.Count <= 0) getlFoodsCat();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FoodsCat row in lfooC)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_cat_id;
                item.Text = row.foods_cat_name;
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
        private FoodsCat setFoodsCat(DataTable dt)
        {
            FoodsCat dept1 = new FoodsCat();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_cat_id = dt.Rows[0][fooC.foods_cat_id].ToString();
                dept1.foods_cat_code = dt.Rows[0][fooC.foods_cat_code].ToString();
                dept1.foods_cat_name = dt.Rows[0][fooC.foods_cat_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][fooC.remark] != null ? dt.Rows[0][fooC.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][fooC.date_create] != null ? dt.Rows[0][fooC.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][fooC.date_modi] != null ? dt.Rows[0][fooC.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][fooC.date_cancel] != null ? dt.Rows[0][fooC.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][fooC.user_create] != null ? dt.Rows[0][fooC.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][fooC.user_modi] != null ? dt.Rows[0][fooC.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][fooC.user_cancel] != null ? dt.Rows[0][fooC.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][fooC.active] != null ? dt.Rows[0][fooC.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][fooC.sort1] != null ? dt.Rows[0][fooC.sort1].ToString() : "";
                dept1.filename = dt.Rows[0][fooC.filename] != null ? dt.Rows[0][fooC.filename].ToString() : "";
            }
            else
            {
                dept1.foods_cat_id = "";
                dept1.foods_cat_code = "";
                dept1.foods_cat_name = "";
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
                dept1.filename = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
