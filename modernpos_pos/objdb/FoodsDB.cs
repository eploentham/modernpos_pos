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
    public class FoodsDB
    {
        Foods foo;
        ConnectDB conn;
        public List<Foods> lfoo;
        public List<Foods> lfooC;
        public FoodsDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfoo = new List<Foods>();
            foo = new Foods();
            foo.foods_id = "foods_id";
            foo.foods_code = "foods_code";
            foo.foods_name = "foods_name";
            foo.foods_type_id = "foods_type_id";
            foo.foods_price = "foods_price";
            foo.res_id = "res_id";
            foo.res_code = "res_code";
            foo.printer_name = "printer_name";

            foo.active = "active";
            foo.remark = "remark";
            foo.sort1 = "sort1";
            foo.date_cancel = "date_cancel";
            foo.date_create = "date_create";
            foo.date_modi = "date_modi";
            foo.user_cancel = "user_cancel";
            foo.user_create = "user_create";
            foo.user_modi = "user_modi";
            foo.host_id = "host_id";
            foo.branch_id = "branch_id";
            foo.device_id = "device_id";
            foo.status_foods = "status_foods";
            foo.status_dine_in = "status_dine_in";
            foo.status_to_go = "status_to_go";
            foo.foods_cat_id = "foods_cat_id";
            foo.filename = "filename";

            foo.pkField = "foods_id";
            foo.table = "b_foods";
        }
        public DataTable selectByCategory(String catid)
        {
            DataTable dt = new DataTable();
            String sql = "select foo.*  " +
                "From " + foo.table + " foo " +
                " " +
                "Where foo." + foo.active + " ='1' and foo."+foo.foods_cat_id+"='"+catid+"'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foo.*  " +
                "From " + foo.table + " foo " +
                " " +
                "Where foo." + foo.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + foo.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + foo.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Foods selectByPk1(String copId)
        {
            Foods cop1 = new Foods();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + foo.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + foo.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoods(dt);
            return cop1;
        }
        private Foods setArea1(DataTable dt)
        {
            Foods dept1 = new Foods();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_id = dt.Rows[0][foo.foods_id].ToString();
                dept1.foods_name = dt.Rows[0][foo.foods_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + foo.pkField + ",foo." + foo.foods_name + " " +
                "From " + foo.table + " foo " +
                " " +
                "Where foo." + foo.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<Foods> getlFoods1()
        {
            List<Foods> lfoo1 = new List<Foods>();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Foods itm1 = new Foods();
                itm1.foods_id = row[foo.foods_id].ToString();
                itm1.foods_name = row[foo.foods_name].ToString();
                itm1.foods_price = row[foo.foods_price].ToString();
                itm1.printer_name = row[foo.printer_name].ToString();
                itm1.foods_code = row[foo.foods_code].ToString();
                itm1.foods_type_id = row[foo.foods_type_id].ToString();
                itm1.foods_cat_id = row[foo.foods_cat_id].ToString();
                itm1.filename = row[foo.filename].ToString();
                lfoo1.Add(itm1);
            }
            return lfoo1;
        }
        public List<Foods> getlFoodsByCat(String catid)
        {
            List<Foods> lfoo1 = new List<Foods>();
            DataTable dt = new DataTable();
            dt = selectByCategory(catid);
            foreach (DataRow row in dt.Rows)
            {
                Foods itm1 = new Foods();
                itm1.foods_id = row[foo.foods_id].ToString();
                itm1.foods_name = row[foo.foods_name].ToString();
                itm1.foods_price = row[foo.foods_price].ToString();
                itm1.printer_name = row[foo.printer_name].ToString();
                itm1.foods_code = row[foo.foods_code].ToString();
                itm1.foods_type_id = row[foo.foods_type_id].ToString();
                itm1.foods_cat_id = row[foo.foods_cat_id].ToString();
                itm1.filename = row[foo.filename].ToString();
                lfoo1.Add(itm1);
            }
            return lfoo1;
        }
        public void getlFoods()
        {
            //lDept = new List<Position>();
            lfoo.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Foods itm1 = new Foods();
                itm1.foods_id = row[foo.foods_id].ToString();
                itm1.foods_name = row[foo.foods_name].ToString();

                lfoo.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfoo.Count <= 0) getlFoods();
            foreach (Foods sex in lfoo)
            {
                if (sex.foods_id.Equals(id))
                {
                    re = sex.foods_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Foods p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.foods_name = p.foods_name == null ? "" : p.foods_name;
            p.foods_code = p.foods_code == null ? "" : p.foods_code;
            p.res_code = p.res_code == null ? "" : p.res_code;
            p.status_foods = p.status_foods == null ? "0" : p.status_foods;
            p.printer_name = p.printer_name == null ? "" : p.printer_name;
            p.status_to_go = p.status_to_go == null ? "0" : p.status_to_go;
            p.status_dine_in = p.status_dine_in == null ? "0" : p.status_dine_in;
            p.filename = p.filename == null ? "" : p.filename;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.foods_type_id = long.TryParse(p.foods_type_id, out chk) ? chk.ToString() : "0";
            p.res_id = long.TryParse(p.res_id, out chk) ? chk.ToString() : "0";
            p.foods_cat_id = long.TryParse(p.foods_cat_id, out chk) ? chk.ToString() : "0";

            p.foods_price = Decimal.TryParse(p.foods_price, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Foods p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foo.table + " set " +
                " " + foo.foods_code + " = '" + p.foods_code + "'" +
                "," + foo.foods_name + " = '" + p.foods_name.Replace("'", "''") + "'" +
                "," + foo.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foo.date_create + " = now()" +
                "," + foo.active + " = '1'" +
                "," + foo.user_create + " = '" + userId + "' " +
                "," + foo.host_id + " = '" + p.host_id + "' " +
                "," + foo.branch_id + " = '" + p.branch_id + "' " +
                "," + foo.device_id + " = '" + p.device_id + "' " +
                "," + foo.res_code + " = '" + p.res_code + "' " +
                "," + foo.status_foods + " = '" + p.status_foods + "' " +
                "," + foo.printer_name + " = '" + p.printer_name + "' " +
                "," + foo.foods_price + " = '" + p.foods_price + "' " +
                "," + foo.status_dine_in + " = '" + p.status_dine_in + "' " +
                "," + foo.status_to_go + " = '" + p.status_to_go + "' " +
                "," + foo.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                "," + foo.filename + " = '" + p.filename + "' " +
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
        public String update(Foods p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foo.table + " Set " +
                " " + foo.foods_code + " = '" + p.foods_code + "'" +
                "," + foo.foods_name + " = '" + p.foods_name.Replace("'", "''") + "'" +
                "," + foo.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foo.date_modi + " = now()" +
                "," + foo.user_modi + " = '" + userId + "' " +
                "," + foo.host_id + " = '" + p.host_id + "' " +
                "," + foo.branch_id + " = '" + p.branch_id + "' " +
                "," + foo.device_id + " = '" + p.device_id + "' " +
                "," + foo.res_id + " = '" + p.res_id + "' " +
                "," + foo.status_foods + " = '" + p.status_foods + "' " +
                "," + foo.printer_name + " = '" + p.printer_name + "' " +
                "," + foo.foods_price + " = '" + p.foods_price + "' " +
                "," + foo.status_dine_in + " = '" + p.status_dine_in + "' " +
                "," + foo.status_to_go + " = '" + p.status_to_go + "' " +
                "," + foo.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                "," + foo.foods_type_id + " = '" + p.foods_type_id + "' " +
                "Where " + foo.pkField + "='" + p.foods_id + "'"
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
        public String insertFoods(Foods p, String userId)
        {
            String re = "";

            if (p.foods_id.Equals(""))
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

            //chkNull(p);
            sql = "Update " + foo.table + " Set " +
                " " + foo.filename + " = '" + filename + "'" +                
                "Where " + foo.pkField + "='" + fooid + "'"
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
        public C1ComboBox setCboFoods(C1ComboBox c)
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
                item.Text = row[foo.foods_name].ToString();
                item.Value = row[foo.foods_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoods(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfoo.Count <= 0) getlFoods();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Foods row in lfoo)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_id;
                item.Text = row.foods_name;
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
        private Foods setFoods(DataTable dt)
        {
            Foods dept1 = new Foods();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_id = dt.Rows[0][foo.foods_id].ToString();
                dept1.foods_code = dt.Rows[0][foo.foods_code].ToString();
                dept1.foods_name = dt.Rows[0][foo.foods_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][foo.remark] != null ? dt.Rows[0][foo.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foo.date_create] != null ? dt.Rows[0][foo.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foo.date_modi] != null ? dt.Rows[0][foo.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foo.date_cancel] != null ? dt.Rows[0][foo.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foo.user_create] != null ? dt.Rows[0][foo.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foo.user_modi] != null ? dt.Rows[0][foo.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foo.user_cancel] != null ? dt.Rows[0][foo.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foo.active] != null ? dt.Rows[0][foo.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][foo.sort1] != null ? dt.Rows[0][foo.sort1].ToString() : "";
                dept1.foods_price = dt.Rows[0][foo.foods_price] != null ? dt.Rows[0][foo.foods_price].ToString() : "";
                dept1.foods_type_id = dt.Rows[0][foo.foods_type_id] != null ? dt.Rows[0][foo.foods_type_id].ToString() : "";
                dept1.res_id = dt.Rows[0][foo.res_id] != null ? dt.Rows[0][foo.res_id].ToString() : "";
                dept1.res_code = dt.Rows[0][foo.res_code] != null ? dt.Rows[0][foo.res_code].ToString() : "";
                dept1.status_foods = dt.Rows[0][foo.status_foods] != null ? dt.Rows[0][foo.status_foods].ToString() : "";
                dept1.printer_name = dt.Rows[0][foo.printer_name] != null ? dt.Rows[0][foo.printer_name].ToString() : "";
                dept1.status_dine_in = dt.Rows[0][foo.status_dine_in] != null ? dt.Rows[0][foo.status_dine_in].ToString() : "";
                dept1.status_to_go = dt.Rows[0][foo.status_to_go] != null ? dt.Rows[0][foo.status_to_go].ToString() : "";
                dept1.foods_cat_id = dt.Rows[0][foo.foods_cat_id] != null ? dt.Rows[0][foo.foods_cat_id].ToString() : "";
                dept1.filename = dt.Rows[0][foo.filename] != null ? dt.Rows[0][foo.filename].ToString() : "";
            }
            else
            {
                dept1.foods_id = "";
                dept1.foods_code = "";
                dept1.foods_name = "";
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
                dept1.foods_price = "";
                dept1.foods_type_id = "";
                dept1.res_id = "";
                dept1.res_code = "";
                dept1.status_foods = "";
                dept1.printer_name = "";
                dept1.status_to_go = "";
                dept1.status_dine_in = "";
                dept1.foods_cat_id = "";
                dept1.filename = "";
            }

            return dept1;
        }
    }
}
