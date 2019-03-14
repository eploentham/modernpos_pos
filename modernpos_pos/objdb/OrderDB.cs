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
    public class OrderDB
    {
        Order1 ord;
        ConnectDB conn;
        public List<Order1> lOrd;
        public OrderDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lOrd = new List<Order1>();
            ord = new Order1();
            ord.order_id = "order_id";
            ord.lot_id = "lot_id";
            ord.row1 = "row1";
            ord.foods_id = "foods_id";
            ord.foods_code = "foods_code";
            ord.foods_name = "foods_name";
            ord.order_date = "order_date";
            ord.price = "price";
            ord.qty = "qty";

            ord.active = "active";
            ord.remark = "remark";
            ord.sort1 = "sort1";
            ord.date_cancel = "date_cancel";
            ord.date_create = "date_create";
            ord.date_modi = "date_modi";
            ord.user_cancel = "user_cancel";
            ord.user_create = "user_create";
            ord.user_modi = "user_modi";
            ord.host_id = "host_id";
            ord.branch_id = "branch_id";
            ord.device_id = "device_id";

            ord.table_id = "table_code";
            ord.res_id = "res_code";
            ord.area_id = "area_code";
            ord.status_foods_1 = "status_foods_1";
            ord.status_foods_2 = "status_foods_2";

            ord.status_foods_3 = "status_foods_3";
            ord.status_bill = "status_bill";
            ord.bill_check_date = "bill_check_date";
            ord.status_cook = "status_cook";
            ord.cook_receive_date = "cook_receive_date";
            ord.cook_finish_date = "cook_finish_date";
            ord.void_date = "void_date";
            ord.status_void = "status_void";
            ord.printer_name = "printer_name";
            ord.status_to_go = "status_to_go";
            ord.bill_id = "bill_id";
            ord.order_user = "order_user";
            ord.status_closeday = "status_closeday";
            ord.closeday_id = "closeday_id";
            ord.cnt_cust = "cnt_cust";

            ord.pkField = "order_id";
            ord.table = "t_order";
        }
        //public DataTable selectAll()
        //{
        //    DataTable dt = new DataTable();
        //    String sql = "select foo.*  " +
        //        "From " + ord.table + " foo " +
        //        " " +
        //        "Where foo." + ord.active + " ='1' ";
        //    dt = conn.selectData(conn.conn, sql);

        //    return dt;
        //}
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + ord.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Order1 selectByPk1(String copId)
        {
            Order1 cop1 = new Order1();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + ord.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoods(dt);
            return cop1;
        }
        private Order1 setArea1(DataTable dt)
        {
            Order1 dept1 = new Order1();
            if (dt.Rows.Count > 0)
            {
                dept1.order_id = dt.Rows[0][ord.order_id].ToString();
                dept1.row1 = dt.Rows[0][ord.row1].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + ord.pkField + ",foo." + ord.row1 + " " +
                "From " + ord.table + " foo " +
                " " +
                "Where foo." + ord.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        //public List<Order1> getlFoods1()
        //{
        //    List<Order1> lfoo1 = new List<Order1>();
        //    DataTable dt = new DataTable();
        //    dt = selectAll();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Order1 itm1 = new Order1();
        //        itm1.order_id = row[ord.order_id].ToString();
        //        itm1.row1 = row[ord.row1].ToString();
        //        itm1.foods_code = row[ord.foods_code].ToString();
        //        itm1.price = row[ord.price].ToString();
        //        itm1.lot_id = row[ord.lot_id].ToString();
        //        itm1.foods_id = row[ord.foods_id].ToString();
        //        itm1.status_foods_1 = row[ord.status_foods_1].ToString();
        //        lfoo1.Add(itm1);
        //    }
        //    return lfoo1;
        //}
        //public void getlFoods()
        //{
        //    //lDept = new List<Position>();
        //    lOrd.Clear();
        //    DataTable dt = new DataTable();
        //    dt = selectAll();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Order1 itm1 = new Order1();
        //        itm1.order_id = row[ord.order_id].ToString();
        //        itm1.row1 = row[ord.row1].ToString();

        //        lOrd.Add(itm1);
        //    }
        //}
        //public String getList(String id)
        //{
        //    String re = "";
        //    if (lOrd.Count <= 0) getlFoods();
        //    foreach (Order1 sex in lOrd)
        //    {
        //        if (sex.order_id.Equals(id))
        //        {
        //            re = sex.row1;
        //            break;
        //        }
        //    }
        //    return re;
        //}
        private void chkNull(Order1 p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.row1 = p.row1 == null ? "" : p.row1;
            p.foods_code = p.foods_code == null ? "" : p.foods_code;
            p.order_date = p.order_date == null ? "" : p.order_date;
            //p.table_id = p.table_id == null ? "0" : p.table_id;
            //p.price = p.price == null ? "" : p.price;
            //p.area_id = p.area_id == null ? "0" : p.area_id;
            //p.res_id = p.res_id == null ? "0" : p.res_id;
            p.status_foods_2 = p.status_foods_2 == null ? "" : p.status_foods_2;
            p.status_foods_1 = p.status_foods_1 == null ? "" : p.status_foods_1;
            p.status_foods_3 = p.status_foods_3 == null ? "" : p.status_foods_3;
            p.status_bill = p.status_bill == null ? "" : p.status_bill;
            p.bill_check_date = p.bill_check_date == null ? "" : p.bill_check_date;
            p.status_cook = p.status_cook == null ? "" : p.status_cook;
            p.cook_receive_date = p.cook_receive_date == null ? "" : p.cook_receive_date;
            p.cook_finish_date = p.cook_finish_date == null ? "" : p.cook_finish_date;
            p.void_date = p.void_date == null ? "" : p.void_date;
            p.status_void = p.status_void == null ? "" : p.status_void;
            p.printer_name = p.printer_name == null ? "" : p.printer_name;
            p.status_to_go = p.status_to_go == null ? "" : p.status_to_go;
            //p.bill_id = p.bill_id == null ? "" : p.bill_id;
            p.order_user = p.order_user == null ? "" : p.order_user;
            p.status_closeday = p.status_closeday == null ? "" : p.status_closeday;
            p.closeday_id = p.closeday_id == null ? "" : p.closeday_id;
            p.cnt_cust = p.cnt_cust == null ? "" : p.cnt_cust;
            p.foods_name = p.foods_name == null ? "" : p.foods_name;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

            p.foods_id = long.TryParse(p.foods_id, out chk) ? chk.ToString() : "0";
            p.lot_id = long.TryParse(p.lot_id, out chk) ? chk.ToString() : "0";
            p.bill_id = long.TryParse(p.bill_id, out chk) ? chk.ToString() : "0";
            p.area_id = long.TryParse(p.area_id, out chk) ? chk.ToString() : "0";
            p.res_id = long.TryParse(p.res_id, out chk) ? chk.ToString() : "0";
            p.table_id = long.TryParse(p.table_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Order1 p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + ord.table + " set " +
                " " + ord.lot_id + " = '" + p.lot_id + "'" +
                "," + ord.row1 + " = '" + p.row1.Replace("'", "''") + "'" +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ord.date_create + " = now()" +
                "," + ord.active + " = '1'" +
                "," + ord.user_create + " = '" + userId + "' " +
                "," + ord.host_id + " = '" + p.host_id + "' " +
                "," + ord.branch_id + " = '" + p.branch_id + "' " +
                "," + ord.device_id + " = '" + p.device_id + "' " +
                "," + ord.date_cancel + " = '" + p.date_cancel + "' " +
                "," + ord.date_modi + " = '" + p.date_modi + "' " +
                "," + ord.user_cancel + " = '" + p.user_cancel + "' " +
                "," + ord.user_modi + " = '" + p.user_modi + "' " +
                "," + ord.status_bill + " = '" + p.status_bill + "' " +
                "," + ord.bill_check_date + " = '" + p.bill_check_date + "' " +
                "," + ord.status_cook + " = '" + p.status_cook + "' " +
                "," + ord.cook_receive_date + " = '" + p.cook_receive_date + "' " +
                "," + ord.cook_finish_date + " = '" + p.cook_finish_date + "' " +
                "," + ord.void_date + " = '" + p.void_date + "' " +
                "," + ord.status_void + " = '" + p.status_void + "' " +
                "," + ord.printer_name + " = '" + p.printer_name + "' " +
                "," + ord.status_to_go + " = '" + p.status_to_go + "' " +
                "," + ord.bill_id + " = '" + p.bill_id + "' " +
                "," + ord.order_user + " = '" + p.order_user + "' " +
                "," + ord.status_closeday + " = '" + p.status_closeday + "' " +
                "," + ord.closeday_id + " = '" + p.closeday_id + "' " +
                "," + ord.cnt_cust + " = '" + p.cnt_cust + "' " +
                "," + ord.order_date + " = now() " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.price + " = '" + p.price + "' " +
                "," + ord.foods_code + " = '" + p.foods_code + "' " +
                "," + ord.res_id + " = '" + p.res_id + "' " +
                "," + ord.area_id + " = '" + p.area_id + "' " +
                "," + ord.status_foods_1 + " = '" + p.status_foods_1 + "' " +
                "," + ord.status_foods_2 + " = '" + p.status_foods_2 + "' " +
                "," + ord.status_foods_3 + " = '" + p.status_foods_3 + "' " +
                
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
        public String update(Order1 p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + ord.table + " Set " +
                " " + ord.lot_id + " = '" + p.lot_id + "'" +
                "," + ord.row1 + " = '" + p.row1.Replace("'", "''") + "'" +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ord.date_modi + " = now()" +
                "," + ord.user_modi + " = '" + userId + "' " +
                "," + ord.host_id + " = '" + p.host_id + "' " +
                "," + ord.branch_id + " = '" + p.branch_id + "' " +
                //"," + ord.device_id + " = '" + p.device_id + "' " +
                "," + ord.order_date + " = '" + p.order_date + "' " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.price + " = '" + p.price + "' " +
                "," + ord.foods_code + " = '" + p.foods_code + "' " +
                "," + ord.res_id + " = '" + p.res_id + "' " +
                "," + ord.area_id + " = '" + p.area_id + "' " +
                "," + ord.status_foods_1 + " = '" + p.status_foods_1 + "' " +
                //"," + foo.status_foods_2 + " = '" + p.status_foods_2 + "' " +
                "Where " + ord.pkField + "='" + p.order_id + "'"
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
        public String insertOrder(Order1 p, String userId)
        {
            String re = "";

            if (p.order_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateFileName(String fooid, String status_foods_2)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + ord.table + " Set " +
                " " + ord.status_foods_2 + " = '" + status_foods_2 + "'" +
                "Where " + ord.pkField + "='" + fooid + "'"
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
        //public C1ComboBox setCboFoods(C1ComboBox c)
        //{
        //    ComboBoxItem item = new ComboBoxItem();
        //    DataTable dt = selectC1();
        //    //String aaa = "";
        //    ComboBoxItem item1 = new ComboBoxItem();
        //    item1.Text = "";
        //    item1.Value = "000";
        //    c.Items.Clear();
        //    c.Items.Add(item1);
        //    //for (int i = 0; i < dt.Rows.Count; i++)
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        item = new ComboBoxItem();
        //        item.Text = row[ord.row1].ToString();
        //        item.Value = row[ord.order_id].ToString();

        //        c.Items.Add(item);
        //    }
        //    return c;
        //}
        //public C1ComboBox setCboFoods(C1ComboBox c, String selected)
        //{
        //    ComboBoxItem item = new ComboBoxItem();
        //    //DataTable dt = selectC1();
        //    if (lOrd.Count <= 0) getlFoods();
        //    ComboBoxItem item1 = new ComboBoxItem();
        //    item1.Text = "";
        //    item1.Value = "000";
        //    c.Items.Clear();
        //    c.Items.Add(item1);
        //    //for (int i = 0; i < dt.Rows.Count; i++)
        //    int i = 0;
        //    foreach (Order1 row in lOrd)
        //    {
        //        item = new ComboBoxItem();
        //        item.Value = row.order_id;
        //        item.Text = row.row1;
        //        c.Items.Add(item);
        //        if (item.Value.Equals(selected))
        //        {
        //            //c.SelectedItem = item.Value;
        //            c.SelectedText = item.Text;
        //            c.SelectedIndex = i + 1;
        //        }
        //        i++;
        //    }
        //    return c;
        //}
        private Order1 setFoods(DataTable dt)
        {
            Order1 dept1 = new Order1();
            if (dt.Rows.Count > 0)
            {
                dept1.order_id = dt.Rows[0][ord.order_id].ToString();
                dept1.lot_id = dt.Rows[0][ord.lot_id].ToString();
                dept1.row1 = dt.Rows[0][ord.row1].ToString();
                dept1.qty = dt.Rows[0][ord.qty] != null ? dt.Rows[0][ord.qty].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][ord.remark] != null ? dt.Rows[0][ord.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][ord.date_create] != null ? dt.Rows[0][ord.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][ord.date_modi] != null ? dt.Rows[0][ord.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][ord.date_cancel] != null ? dt.Rows[0][ord.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][ord.user_create] != null ? dt.Rows[0][ord.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][ord.user_modi] != null ? dt.Rows[0][ord.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][ord.user_cancel] != null ? dt.Rows[0][ord.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][ord.active] != null ? dt.Rows[0][ord.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][ord.sort1] != null ? dt.Rows[0][ord.sort1].ToString() : "";
                dept1.foods_code = dt.Rows[0][ord.foods_code] != null ? dt.Rows[0][ord.foods_code].ToString() : "";
                dept1.foods_id = dt.Rows[0][ord.foods_id] != null ? dt.Rows[0][ord.foods_id].ToString() : "";
                dept1.foods_name = dt.Rows[0][ord.foods_name] != null ? dt.Rows[0][ord.foods_name].ToString() : "";
                dept1.order_date = dt.Rows[0][ord.order_date] != null ? dt.Rows[0][ord.order_date].ToString() : "";
                dept1.table_id = dt.Rows[0][ord.table_id] != null ? dt.Rows[0][ord.table_id].ToString() : "";
                dept1.price = dt.Rows[0][ord.price] != null ? dt.Rows[0][ord.price].ToString() : "";
                dept1.res_id = dt.Rows[0][ord.res_id] != null ? dt.Rows[0][ord.res_id].ToString() : "";
                dept1.area_id = dt.Rows[0][ord.area_id] != null ? dt.Rows[0][ord.area_id].ToString() : "";
                dept1.status_foods_1 = dt.Rows[0][ord.status_foods_1] != null ? dt.Rows[0][ord.status_foods_1].ToString() : "";
                dept1.status_foods_2 = dt.Rows[0][ord.status_foods_2] != null ? dt.Rows[0][ord.status_foods_2].ToString() : "";
                dept1.status_foods_3 = dt.Rows[0][ord.status_foods_3] != null ? dt.Rows[0][ord.status_foods_3].ToString() : "";
                dept1.status_bill = dt.Rows[0][ord.status_bill] != null ? dt.Rows[0][ord.status_bill].ToString() : "";
                dept1.bill_check_date = dt.Rows[0][ord.bill_check_date] != null ? dt.Rows[0][ord.bill_check_date].ToString() : "";
                dept1.status_cook = dt.Rows[0][ord.status_cook] != null ? dt.Rows[0][ord.status_cook].ToString() : "";
                dept1.cook_receive_date = dt.Rows[0][ord.cook_receive_date] != null ? dt.Rows[0][ord.cook_receive_date].ToString() : "";
                dept1.cook_finish_date = dt.Rows[0][ord.cook_finish_date] != null ? dt.Rows[0][ord.cook_finish_date].ToString() : "";
                dept1.void_date = dt.Rows[0][ord.void_date] != null ? dt.Rows[0][ord.void_date].ToString() : "";
                dept1.status_void = dt.Rows[0][ord.status_void] != null ? dt.Rows[0][ord.status_void].ToString() : "";
                dept1.printer_name = dt.Rows[0][ord.printer_name] != null ? dt.Rows[0][ord.printer_name].ToString() : "";
                dept1.status_to_go = dt.Rows[0][ord.status_to_go] != null ? dt.Rows[0][ord.status_to_go].ToString() : "";
                dept1.bill_id = dt.Rows[0][ord.bill_id] != null ? dt.Rows[0][ord.bill_id].ToString() : "";
                dept1.order_user = dt.Rows[0][ord.order_user] != null ? dt.Rows[0][ord.order_user].ToString() : "";
                dept1.status_closeday = dt.Rows[0][ord.status_closeday] != null ? dt.Rows[0][ord.status_closeday].ToString() : "";
                dept1.closeday_id = dt.Rows[0][ord.closeday_id] != null ? dt.Rows[0][ord.closeday_id].ToString() : "";
                dept1.cnt_cust = dt.Rows[0][ord.cnt_cust] != null ? dt.Rows[0][ord.cnt_cust].ToString() : "";
            }
            else
            {
                dept1.cnt_cust = "";
                dept1.closeday_id = "";
                dept1.status_closeday = "";
                dept1.order_user = "";
                dept1.bill_id = "";
                dept1.status_to_go = "";
                dept1.printer_name = "";
                dept1.void_date = "";
                dept1.status_void = "";
                dept1.cook_finish_date = "";
                dept1.cook_receive_date = "";
                dept1.status_cook = "";
                dept1.bill_check_date = "";
                dept1.status_bill = "";
                dept1.status_foods_3 = "";
                dept1.order_id = "";
                dept1.lot_id = "";
                dept1.row1 = "";
                dept1.qty = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.foods_code = "";
                dept1.foods_id = "";
                dept1.foods_name = "";
                dept1.order_date = "";
                dept1.table_id = "";
                dept1.price = "";
                dept1.area_id = "";
                dept1.res_id = "";
                dept1.status_foods_1 = "";
                dept1.status_foods_2 = "";
            }

            return dept1;
        }
    }
}
