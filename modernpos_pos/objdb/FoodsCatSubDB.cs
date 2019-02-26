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
    public class FoodsCatSubDB
    {
        FoodsCatSub fcb;
        ConnectDB conn;
        public List<FoodsCatSub> lFcb;
        public FoodsCatSubDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lFcb = new List<FoodsCatSub>();
            fcb = new FoodsCatSub();
            fcb.foods_cat_sub_id = "foods_cat_sub_id";
            fcb.foods_cat_id = "foods_cat_id";
            fcb.foods_cat_sub_code = "foods_cat_sub_code";
            fcb.foods_cat_sub_name = "foods_cat_sub_name";
            fcb.active = "active";
            fcb.remark = "remark";
            fcb.sort1 = "sort1";
            fcb.date_cancel = "date_cancel";
            fcb.date_create = "date_create";
            fcb.date_modi = "date_modi";
            fcb.user_cancel = "user_cancel";
            fcb.user_create = "user_create";
            fcb.user_modi = "user_modi";
            fcb.host_id = "host_id";
            fcb.branch_id = "branch_id";
            fcb.device_id = "device_id";

            fcb.pkField = "foods_cat_sub_id";
            fcb.table = "b_foods_category_sub";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + fcb.table + " sex " +
                " " +
                "Where sex." + fcb.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + fcb.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + fcb.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsCatSub selectByPk1(String copId)
        {
            FoodsCatSub cop1 = new FoodsCatSub();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + fcb.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + fcb.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTable(dt);
            return cop1;
        }
        private FoodsCatSub setArea1(DataTable dt)
        {
            FoodsCatSub dept1 = new FoodsCatSub();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_cat_id = dt.Rows[0][fcb.foods_cat_id].ToString();
                dept1.foods_cat_sub_name = dt.Rows[0][fcb.foods_cat_sub_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + fcb.pkField + ",sex." + fcb.foods_cat_sub_name + " " +
                "From " + fcb.table + " sex " +
                " " +
                "Where sex." + fcb.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lFcb.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FoodsCatSub itm1 = new FoodsCatSub();
                itm1.foods_cat_id = row[fcb.foods_cat_id].ToString();
                itm1.foods_cat_sub_name = row[fcb.foods_cat_sub_name].ToString();

                lFcb.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lFcb.Count <= 0) getlArea();
            foreach (FoodsCatSub sex in lFcb)
            {
                if (sex.foods_cat_id.Equals(id))
                {
                    re = sex.foods_cat_sub_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(FoodsCatSub p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.foods_cat_sub_name = p.foods_cat_sub_name == null ? "" : p.foods_cat_sub_name;
            p.foods_cat_sub_code = p.foods_cat_sub_code == null ? "" : p.foods_cat_sub_code;

            //p.status_togo = p.status_togo == null ? "0" : p.status_togo;
            //p.status_reser = p.status_reser == null ? "0" : p.status_reser;
            //p.status_use = p.status_use == null ? "0" : p.status_use;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.foods_cat_id = long.TryParse(p.foods_cat_id, out chk) ? chk.ToString() : "0";
        }
        public String insert(FoodsCatSub p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + fcb.table + " set " +
                " " + fcb.foods_cat_sub_code + " = '" + p.foods_cat_sub_code + "'" +
                "," + fcb.foods_cat_sub_name + " = '" + p.foods_cat_sub_name.Replace("'", "''") + "'" +
                "," + fcb.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fcb.date_create + " = now()" +
                "," + fcb.active + " = '1'" +
                "," + fcb.user_create + " = '" + userId + "' " +
                "," + fcb.host_id + " = '" + p.host_id + "' " +
                "," + fcb.branch_id + " = '" + p.branch_id + "' " +
                "," + fcb.device_id + " = '" + p.device_id + "' " +
                "," + fcb.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                
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
        public String update(FoodsCatSub p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + fcb.table + " Set " +
                " " + fcb.foods_cat_sub_code + " = '" + p.foods_cat_sub_code + "'" +
                "," + fcb.foods_cat_sub_name + " = '" + p.foods_cat_sub_name.Replace("'", "''") + "'" +
                "," + fcb.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + fcb.date_modi + " = now()" +
                "," + fcb.user_modi + " = '" + userId + "' " +
                "," + fcb.host_id + " = '" + p.host_id + "' " +
                "," + fcb.branch_id + " = '" + p.branch_id + "' " +
                "," + fcb.device_id + " = '" + p.device_id + "' " +
                "," + fcb.foods_cat_id + " = '" + p.foods_cat_id + "' " +

                "Where " + fcb.pkField + "='" + p.foods_cat_sub_id + "'"
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
        public String insertFoodsCatSub(FoodsCatSub p, String userId)
        {
            String re = "";

            if (p.foods_cat_sub_id.Equals(""))
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
                item.Text = row[fcb.foods_cat_sub_name].ToString();
                item.Value = row[fcb.foods_cat_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboTable(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lFcb.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FoodsCatSub row in lFcb)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_cat_id;
                item.Text = row.foods_cat_sub_name;
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
        private FoodsCatSub setTable(DataTable dt)
        {
            FoodsCatSub dept1 = new FoodsCatSub();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_cat_id = dt.Rows[0][fcb.foods_cat_id].ToString();
                dept1.foods_cat_sub_code = dt.Rows[0][fcb.foods_cat_sub_code].ToString();
                dept1.foods_cat_sub_name = dt.Rows[0][fcb.foods_cat_sub_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][fcb.remark] != null ? dt.Rows[0][fcb.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][fcb.date_create] != null ? dt.Rows[0][fcb.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][fcb.date_modi] != null ? dt.Rows[0][fcb.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][fcb.date_cancel] != null ? dt.Rows[0][fcb.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][fcb.user_create] != null ? dt.Rows[0][fcb.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][fcb.user_modi] != null ? dt.Rows[0][fcb.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][fcb.user_cancel] != null ? dt.Rows[0][fcb.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][fcb.active] != null ? dt.Rows[0][fcb.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][fcb.sort1] != null ? dt.Rows[0][fcb.sort1].ToString() : "";
                dept1.foods_cat_sub_id = dt.Rows[0][fcb.foods_cat_sub_id] != null ? dt.Rows[0][fcb.foods_cat_sub_id].ToString() : "";
                
            }
            else
            {
                dept1.foods_cat_id = "";
                dept1.foods_cat_sub_code = "";
                dept1.foods_cat_sub_name = "";
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
                dept1.foods_cat_sub_id = "";
                
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
