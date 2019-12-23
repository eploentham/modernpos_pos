using C1.Win.C1Input;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.objdb
{
    public class RestaurantDB
    {
        public Restaurant res;
        ConnectDB conn;
        public List<Restaurant> lArea;
        public RestaurantDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lArea = new List<Restaurant>();
            res = new Restaurant();
            res.res_id = "res_id";
            res.default_res = "default_res";
            res.res_code = "res_code";
            res.res_name = "res_name";
            res.active = "active";
            res.remark = "remark";
            res.sort1 = "sort1";
            res.date_cancel = "date_cancel";
            res.date_create = "date_create";
            res.date_modi = "date_modi";
            res.user_cancel = "user_cancel";
            res.user_create = "user_create";
            res.user_modi = "user_modi";
            res.host_id = "host_id";
            res.branch_id = "branch_id";
            res.device_id = "device_id";

            res.receipt_footer1 = "receipt_footer1";
            res.receipt_header1 = "receipt_header1";
            res.receipt_footer2 = "receipt_footer2";
            res.receipt_footer3 = "receipt_footer3";
            res.receipt_header2 = "receipt_header2";
            res.receipt_header3 = "receipt_header3";

            res.bill_code = "bill_code";
            res.bill_month = "bill_month";
            res.tax_id = "tax_id";
            res.printer_foods1 = "printer_foods1";
            res.printer_foods2 = "printer_foods2";
            res.printer_foods3 = "printer_foods3";
            res.printer_waterbar1 = "printer_waterbar1";
            res.printer_waterbar2 = "printer_waterbar2";
            res.printer_waterbar3 = "printer_waterbar3";
            res.cop_id = "cop_id";
            res.printer_bill_margin_top = "printer_bill_margin_top";
            res.printer_bill_margin_left = "printer_bill_margin_left";
            res.printer_bill_margin_right = "printer_bill_margin_right";
            res.printer_bill_print_top = "printer_bill_print_top";
            res.printer_bill_print_left = "printer_bill_print_left";
            res.printer_bill_print_right = "printer_bill_print_right";
            res.printer_bill_print_right = "printer_bill_print_right";
            res.status_print_order = "status_print_order";

            res.pkField = "res_id";
            res.table = "b_restaurant";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + res.table + " sex " +
                " " +
                "Where sex." + res.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + res.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + res.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Restaurant selectByPk1(String copId)
        {
            Restaurant cop1 = new Restaurant();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + res.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + res.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setRestaurant(dt);
            return cop1;
        }
        public Restaurant selectByDefault()
        {
            Restaurant cop1 = new Restaurant();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + res.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + res.default_res + " ='1' ";
            dt = conn.selectData(conn.conn, sql);
            //MessageBox.Show("selectByDefault ", "");
            cop1 = setRestaurant(dt);
            return cop1;
        }
        private Restaurant setArea1(DataTable dt)
        {
            Restaurant dept1 = new Restaurant();
            if (dt.Rows.Count > 0)
            {
                dept1.default_res = dt.Rows[0][res.default_res].ToString();
                dept1.res_name = dt.Rows[0][res.res_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + res.pkField + ",sex." + res.res_name + " " +
                "From " + res.table + " sex " +
                " " +
                "Where sex." + res.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlRestaurant()
        {
            //lDept = new List<Position>();
            lArea.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Restaurant itm1 = new Restaurant();
                itm1.res_id = row[res.res_id].ToString();
                itm1.res_name = row[res.res_name].ToString();

                lArea.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lArea.Count <= 0) getlRestaurant();
            foreach (Restaurant sex in lArea)
            {
                if (sex.default_res.Equals(id))
                {
                    re = sex.res_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Restaurant p)
        {
            long chk = 0;


            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.res_name = p.res_name == null ? "" : p.res_name;
            p.res_code = p.res_code == null ? "" : p.res_code;

            p.receipt_footer1 = p.receipt_footer1 == null ? "" : p.receipt_footer1;
            p.receipt_header2 = p.receipt_header2 == null ? "" : p.receipt_header2;
            p.receipt_header1 = p.receipt_header1 == null ? "" : p.receipt_header1;
            p.receipt_header3 = p.receipt_header3 == null ? "" : p.receipt_header3;
            p.receipt_footer2 = p.receipt_footer2 == null ? "" : p.receipt_footer2;
            p.receipt_footer3 = p.receipt_footer3 == null ? "" : p.receipt_footer3;

            p.bill_code = p.bill_code == null ? "" : p.bill_code;
            p.bill_month = p.bill_month == null ? "" : p.bill_month;
            p.tax_id = p.tax_id == null ? "" : p.tax_id;
            p.printer_foods1 = p.printer_foods1 == null ? "" : p.printer_foods1;
            p.printer_foods2 = p.printer_foods2 == null ? "" : p.printer_foods2;
            p.printer_foods3 = p.printer_foods3 == null ? "" : p.printer_foods3;
            p.printer_waterbar1 = p.printer_waterbar1 == null ? "" : p.printer_waterbar1;
            p.printer_waterbar2 = p.printer_waterbar2 == null ? "" : p.printer_waterbar2;
            p.printer_waterbar3 = p.printer_waterbar3 == null ? "" : p.printer_waterbar3;
            p.status_print_order = p.status_print_order == null ? "" : p.status_print_order;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.cop_id = long.TryParse(p.cop_id, out chk) ? chk.ToString() : "0";

            p.printer_bill_margin_top = long.TryParse(p.printer_bill_margin_top, out chk) ? chk.ToString() : "0";
            p.printer_bill_margin_left = long.TryParse(p.printer_bill_margin_left, out chk) ? chk.ToString() : "0";
            p.printer_bill_margin_right = long.TryParse(p.printer_bill_margin_right, out chk) ? chk.ToString() : "0";
            p.printer_bill_print_top = long.TryParse(p.printer_bill_print_top, out chk) ? chk.ToString() : "0";
            p.printer_bill_print_left = long.TryParse(p.printer_bill_print_left, out chk) ? chk.ToString() : "0";
            p.printer_bill_print_right = long.TryParse(p.printer_bill_print_right, out chk) ? chk.ToString() : "0";
        }
        public String insert(Restaurant p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + res.table + " set " +
                " " + res.res_code + " = '" + p.res_code + "'" +
                "," + res.res_name + " = '" + p.res_name.Replace("'", "''") + "'" +
                "," + res.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + res.date_create + " = now()" +
                "," + res.active + " = '1'" +
                "," + res.user_create + " = '" + userId + "' " +
                "," + res.host_id + " = '" + p.host_id + "' " +
                "," + res.branch_id + " = '" + p.branch_id + "' " +
                "," + res.device_id + " = '" + p.device_id + "' " +
                "," + res.receipt_footer1 + " = '" + p.receipt_footer1.Replace("'", "''") + "' " +
                "," + res.receipt_header2 + " = '" + p.receipt_header2.Replace("'", "''") + "' " +
                "," + res.receipt_header1 + " = '" + p.receipt_header1.Replace("'", "''") + "' " +
                "," + res.receipt_footer2 + " = '" + p.receipt_footer2.Replace("'", "''") + "' " +
                "," + res.bill_code + " = '" + p.bill_code + "' " +
                "," + res.bill_month + " = '" + p.bill_month + "' " +
                "," + res.tax_id + " = '" + p.tax_id + "' " +
                "," + res.printer_foods1 + " = '" + p.printer_foods1.Replace("'", "''") + "' " +
                "," + res.printer_foods2 + " = '" + p.printer_foods2.Replace("'", "''") + "' " +
                "," + res.printer_foods3 + " = '" + p.printer_foods3.Replace("'", "''") + "' " +
                "," + res.printer_waterbar1 + " = '" + p.printer_waterbar1.Replace("'", "''") + "' " +
                "," + res.printer_waterbar2 + " = '" + p.printer_waterbar2.Replace("'", "''") + "' " +
                "," + res.printer_waterbar3 + " = '" + p.printer_waterbar3.Replace("'", "''") + "' " +
                "," + res.receipt_footer3 + " = '" + p.receipt_footer3.Replace("'", "''") + "' " +
                "," + res.receipt_header3 + " = '" + p.receipt_header3.Replace("'", "''") + "' " +
                "," + res.cop_id + " = '" + p.cop_id + "' " +
                "," + res.status_print_order + " = '" + p.status_print_order + "' " +
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
        public String update(Restaurant p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + res.table + " Set " +
                " " + res.res_code + " = '" + p.res_code + "'" +
                "," + res.res_name + " = '" + p.res_name.Replace("'", "''") + "'" +
                "," + res.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + res.date_modi + " = now()" +
                "," + res.user_modi + " = '" + userId + "' " +
                "," + res.host_id + " = '" + p.host_id + "' " +
                "," + res.branch_id + " = '" + p.branch_id + "' " +
                "," + res.device_id + " = '" + p.device_id + "' " +
                "," + res.receipt_footer1 + " = '" + p.receipt_footer1 + "' " +
                "," + res.receipt_header2 + " = '" + p.receipt_header2 + "' " +
                "," + res.receipt_header1 + " = '" + p.receipt_header1 + "' " +
                "," + res.receipt_header2 + " = '" + p.receipt_header2 + "' " +
                //"," + res.bill_code + " = '" + p.bill_code + "' " +
                //"," + res.bill_month + " = '" + p.bill_month + "' " +
                "," + res.tax_id + " = '" + p.tax_id + "' " +
                "," + res.printer_foods1 + " = '" + p.printer_foods1 + "' " +
                "," + res.printer_foods2 + " = '" + p.printer_foods2 + "' " +
                "," + res.printer_foods3 + " = '" + p.printer_foods3 + "' " +
                "," + res.printer_waterbar1 + " = '" + p.printer_waterbar1 + "' " +
                "," + res.printer_waterbar2 + " = '" + p.printer_waterbar2 + "' " +
                "," + res.printer_waterbar3 + " = '" + p.printer_waterbar3 + "' " +
                "," + res.receipt_footer3 + " = '" + p.receipt_footer3 + "' " +
                "," + res.receipt_header3 + " = '" + p.receipt_header3 + "' " +
                "," + res.receipt_footer2 + " = '" + p.receipt_footer2 + "' " +
                "," + res.cop_id + " = '" + p.cop_id + "' " +
                "," + res.status_print_order + " = '" + p.status_print_order + "' " +

                "Where " + res.pkField + "='" + p.res_id + "'"
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
        public String insertRestaurant(Restaurant p, String userId)
        {
            String re = "";

            if (p.res_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updatePrinterBill(String mtop, String mleft, String mright, String top, String left, String right)
        {
            String re = "";
            String sql = "";
            long chk = 0, mtop1=0, mleft1=0,mright1=0, top1 = 0, left1 = 0, right1 = 0;

            long.TryParse(mtop, out mtop1);
            long.TryParse(mleft, out chk);
            long.TryParse(mright, out mright1);
            long.TryParse(top, out top1);
            long.TryParse(left, out left1);
            long.TryParse(right, out right1);
            //chkNull(p);

            sql = "Update " + res.table + " Set " +
                " " + res.printer_bill_margin_top + " = '" + mtop1 + "'" +
                "," + res.printer_bill_margin_left + " = '" + mleft1 + "'" +
                "," + res.printer_bill_margin_right + " = '" + mright1 + "'" +               
                "," + res.printer_bill_print_top + " = '" + top1 + "' " +
                "," + res.printer_bill_print_left + " = '" + left1 + "' " +
                "," + res.printer_bill_print_right + " = '" + right1 + "' " +
                "Where " + res.res_code + "='001'";
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
        public C1ComboBox setCboRestaurant(C1ComboBox c)
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
                item.Text = row[res.res_name].ToString();
                item.Value = row[res.res_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboRestaurant(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lArea.Count <= 0) getlRestaurant();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Restaurant row in lArea)
            {
                item = new ComboBoxItem();
                item.Value = row.res_id;
                item.Text = row.res_name;
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
        private Restaurant setRestaurant(DataTable dt)
        {
            Restaurant dept1 = new Restaurant();
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("setRestaurant ", "");
                dept1.default_res = dt.Rows[0][res.default_res].ToString();
                dept1.res_code = dt.Rows[0][res.res_code].ToString();
                dept1.res_name = dt.Rows[0][res.res_name].ToString();
                dept1.res_id = dt.Rows[0][res.res_id] != null ? dt.Rows[0][res.res_id].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][res.remark] != null ? dt.Rows[0][res.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][res.date_create] != null ? dt.Rows[0][res.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][res.date_modi] != null ? dt.Rows[0][res.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][res.date_cancel] != null ? dt.Rows[0][res.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][res.user_create] != null ? dt.Rows[0][res.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][res.user_modi] != null ? dt.Rows[0][res.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][res.user_cancel] != null ? dt.Rows[0][res.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][res.active] != null ? dt.Rows[0][res.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][res.sort1] != null ? dt.Rows[0][res.sort1].ToString() : "";
                dept1.receipt_footer1 = dt.Rows[0][res.receipt_footer1] != null ? dt.Rows[0][res.receipt_footer1].ToString() : "";
                dept1.receipt_header2 = dt.Rows[0][res.receipt_header2] != null ? dt.Rows[0][res.receipt_header2].ToString() : "";
                dept1.receipt_header1 = dt.Rows[0][res.receipt_header1] != null ? dt.Rows[0][res.receipt_header1].ToString() : "";
                //MessageBox.Show("setRestaurant 22", "");
                dept1.receipt_header2 = dt.Rows[0][res.receipt_header2] != null ? dt.Rows[0][res.receipt_header2].ToString() : "";
                dept1.bill_code = dt.Rows[0][res.bill_code] != null ? dt.Rows[0][res.bill_code].ToString() : "";
                dept1.bill_month = dt.Rows[0][res.bill_month] != null ? dt.Rows[0][res.bill_month].ToString() : "";
                dept1.tax_id = dt.Rows[0][res.tax_id] != null ? dt.Rows[0][res.tax_id].ToString() : "";
                dept1.printer_foods1 = dt.Rows[0][res.printer_foods1] != null ? dt.Rows[0][res.printer_foods1].ToString() : "";
                dept1.printer_foods2 = dt.Rows[0][res.printer_foods2] != null ? dt.Rows[0][res.printer_foods2].ToString() : "";
                dept1.printer_foods3 = dt.Rows[0][res.printer_foods3] != null ? dt.Rows[0][res.printer_foods3].ToString() : "";
                dept1.printer_waterbar1 = dt.Rows[0][res.printer_waterbar1] != null ? dt.Rows[0][res.printer_waterbar1].ToString() : "";
                dept1.printer_waterbar2 = dt.Rows[0][res.printer_waterbar2] != null ? dt.Rows[0][res.printer_waterbar2].ToString() : "";
                dept1.printer_waterbar3 = dt.Rows[0][res.printer_waterbar3] != null ? dt.Rows[0][res.printer_waterbar3].ToString() : "";
                //MessageBox.Show("setRestaurant 4444", "");
                dept1.receipt_header3 = dt.Rows[0][res.receipt_header3] != null ? dt.Rows[0][res.receipt_header3].ToString() : "";
                dept1.receipt_footer3 = dt.Rows[0][res.receipt_footer3] != null ? dt.Rows[0][res.receipt_footer3].ToString() : "";
                dept1.receipt_footer2 = dt.Rows[0][res.receipt_footer2] != null ? dt.Rows[0][res.receipt_footer2].ToString() : "";
                dept1.cop_id = dt.Rows[0][res.cop_id] != null ? dt.Rows[0][res.cop_id].ToString() : "";
                dept1.printer_bill_margin_top = dt.Rows[0][res.printer_bill_margin_top] != null ? dt.Rows[0][res.printer_bill_margin_top].ToString() : "";
                dept1.printer_bill_margin_left = dt.Rows[0][res.printer_bill_margin_left] != null ? dt.Rows[0][res.printer_bill_margin_left].ToString() : "";
                dept1.printer_bill_margin_right = dt.Rows[0][res.printer_bill_margin_right] != null ? dt.Rows[0][res.printer_bill_margin_right].ToString() : "";
                dept1.printer_bill_print_top = dt.Rows[0][res.printer_bill_print_top] != null ? dt.Rows[0][res.printer_bill_print_top].ToString() : "";
                dept1.printer_bill_print_left = dt.Rows[0][res.printer_bill_print_left] != null ? dt.Rows[0][res.printer_bill_print_left].ToString() : "";
                dept1.printer_bill_print_right = dt.Rows[0][res.printer_bill_print_right] != null ? dt.Rows[0][res.printer_bill_print_right].ToString() : "";
                dept1.status_print_order = dt.Rows[0][res.status_print_order] != null ? dt.Rows[0][res.status_print_order].ToString() : "";
                //MessageBox.Show("setRestaurant 33", "");
            }
            else
            {
                dept1.default_res = "";
                dept1.res_code = "";
                dept1.res_name = "";
                dept1.res_id = "res_id";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.receipt_footer1 = "";
                dept1.receipt_header2 = "";
                dept1.receipt_header1 = "";
                dept1.receipt_header2 = "";
                dept1.bill_code = "";
                dept1.bill_month = "";
                dept1.tax_id = "";
                dept1.printer_foods1 = "";
                dept1.printer_foods2 = "";
                dept1.printer_foods3 = "";
                dept1.printer_waterbar1 = "";
                dept1.printer_waterbar2 = "";
                dept1.printer_waterbar3 = "";
                dept1.receipt_header3 = "";
                dept1.receipt_footer3 = "";
                dept1.cop_id = "";
                dept1.printer_bill_margin_top = "";
                dept1.printer_bill_margin_left = "";                
                dept1.printer_bill_margin_right = "";
                dept1.printer_bill_print_top = "";
                dept1.printer_bill_print_left = "";
                dept1.printer_bill_print_right = "";
                dept1.receipt_footer2 = "";
                dept1.status_print_order = "";
            }
            //MessageBox.Show("setRestaurant End", "");
            return dept1;
        }
    }
}
