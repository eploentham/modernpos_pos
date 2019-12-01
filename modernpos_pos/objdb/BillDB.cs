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
    public class BillDB
    {
        Bill bil;
        ConnectDB conn;
        public List<Bill> lOrd;
        public BillDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lOrd = new List<Bill>();
            bil = new Bill();
            bil.bill_id = "bill_id";
            bil.bill_code = "bill_code";
            bil.bill_date = "bill_date";
            bil.lot_id = "lot_id";
            bil.status_void = "status_void";
            bil.void_date = "void_date";
            bil.void_user = "void_user";            

            bil.active = "active";
            bil.remark = "remark";
            bil.sort1 = "sort1";
            bil.date_cancel = "date_cancel";
            bil.date_create = "date_create";
            bil.date_modi = "date_modi";
            bil.user_cancel = "user_cancel";
            bil.user_create = "user_create";
            bil.user_modi = "user_modi";
            bil.host_id = "host_id";
            bil.branch_id = "branch_id";
            bil.device_id = "device_id";

            bil.table_id = "table_id";
            bil.res_id = "res_id";
            bil.area_id = "area_id";
            bil.amount = "amount";
            bil.discount = "discount";

            bil.service_charge = "service_charge";
            bil.vat = "vat";
            bil.total = "total";
            bil.nettotal = "nettotal";
            bil.cash_receive = "cash_receive";
            bil.cash_ton = "cash_ton";
            bil.bill_user = "bill_user";
            bil.status_closeday = "status_closeday";
            bil.closeday_id = "closeday_id";
            bil.status_payment = "status_payment";

            bil.pkField = "bill_id";
            bil.table = "t_order";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foo.*  " +
                "From " + bil.table + " foo " +
                " " +
                "Where foo." + bil.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + bil.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + bil.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public Bill selectByPk1(String copId)
        {
            Bill cop1 = new Bill();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + bil.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + bil.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoods(dt);
            return cop1;
        }
        private Bill setArea1(DataTable dt)
        {
            Bill dept1 = new Bill();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_id = dt.Rows[0][bil.bill_id].ToString();
                dept1.bill_date = dt.Rows[0][bil.bill_date].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + bil.pkField + ",foo." + bil.bill_date + " " +
                "From " + bil.table + " foo " +
                " " +
                "Where foo." + bil.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<Bill> getlFoods1()
        {
            List<Bill> lfoo1 = new List<Bill>();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Bill itm1 = new Bill();
                itm1.bill_id = row[bil.bill_id].ToString();
                itm1.bill_date = row[bil.bill_date].ToString();
                itm1.bill_user = row[bil.bill_user].ToString();
                itm1.table_id = row[bil.table_id].ToString();
                itm1.bill_code = row[bil.bill_code].ToString();
                itm1.lot_id = row[bil.lot_id].ToString();
                itm1.amount = row[bil.amount].ToString();
                lfoo1.Add(itm1);
            }
            return lfoo1;
        }
        public void getlFoods()
        {
            //lDept = new List<Position>();
            lOrd.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                Bill itm1 = new Bill();
                itm1.bill_id = row[bil.bill_id].ToString();
                itm1.bill_date = row[bil.bill_date].ToString();

                lOrd.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lOrd.Count <= 0) getlFoods();
            foreach (Bill sex in lOrd)
            {
                if (sex.bill_id.Equals(id))
                {
                    re = sex.bill_date;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Bill p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.bill_date = p.bill_date == null ? "" : p.bill_date;
            p.bill_code = p.bill_code == null ? "" : p.bill_code;
            p.void_user = p.void_user == null ? "" : p.void_user;
            //p.table_id = p.table_id == null ? "0" : p.table_id;
            //p.table_id = p.table_id == null ? "" : p.table_id;
            //p.area_id = p.area_id == null ? "0" : p.area_id;
            //p.res_id = p.res_id == null ? "0" : p.res_id;
            //p.discount = p.discount == null ? "" : p.discount;
            //p.amount = p.amount == null ? "" : p.amount;
            //p.service_charge = p.service_charge == null ? "" : p.service_charge;
            //p.vat = p.vat == null ? "" : p.vat;
            //p.total = p.total == null ? "" : p.total;
            //p.nettotal = p.nettotal == null ? "" : p.nettotal;
            //p.bill_user = p.bill_user == null ? "" : p.bill_user;
            p.status_void = p.status_void == null ? "" : p.status_void;
            p.void_date = p.void_date == null ? "" : p.void_date;
            p.bill_user = p.bill_user == null ? "" : p.bill_user;
            p.status_closeday = p.status_closeday == null ? "" : p.status_closeday;
            //p.closeday_id = p.closeday_id == null ? "" : p.closeday_id;
            //p.bill_id = p.bill_id == null ? "" : p.bill_id;
            //p.order_user = p.order_user == null ? "" : p.order_user;
            p.status_closeday = p.status_closeday == null ? "" : p.status_closeday;
            //p.closeday_id = p.closeday_id == null ? "" : p.closeday_id;
            p.status_payment = p.status_payment == null ? "0" : p.status_payment;
            p.void_date = p.void_date == null ? "" : p.void_date;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

            p.lot_id = long.TryParse(p.lot_id, out chk) ? chk.ToString() : "0";
            p.closeday_id = long.TryParse(p.closeday_id, out chk) ? chk.ToString() : "0";
            //p.bill_id = long.TryParse(p.bill_id, out chk) ? chk.ToString() : "0";
            p.area_id = long.TryParse(p.area_id, out chk) ? chk.ToString() : "0";
            p.res_id = long.TryParse(p.res_id, out chk) ? chk.ToString() : "0";
            p.table_id = long.TryParse(p.table_id, out chk) ? chk.ToString() : "0";

            p.cash_receive = Decimal.TryParse(p.cash_receive, out chk1) ? chk1.ToString() : "0";
            p.cash_ton = Decimal.TryParse(p.cash_ton, out chk1) ? chk1.ToString() : "0";
            p.nettotal = Decimal.TryParse(p.nettotal, out chk1) ? chk1.ToString() : "0";
            p.total = Decimal.TryParse(p.total, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.discount = Decimal.TryParse(p.discount, out chk1) ? chk1.ToString() : "0";
            p.service_charge = Decimal.TryParse(p.service_charge, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Bill p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //bil.table = "t_bill";
            chkNull(p);
            sql = "Insert Into " + bil.table + " set " +
                " " + bil.bill_code + " = '" + p.bill_code + "'" +
                "," + bil.bill_date + " = '" + p.bill_date.Replace("'", "''") + "'" +
                "," + bil.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bil.date_create + " = now()" +
                "," + bil.active + " = '1'" +
                "," + bil.user_create + " = '" + userId + "' " +
                "," + bil.host_id + " = '" + p.host_id + "' " +
                "," + bil.branch_id + " = '" + p.branch_id + "' " +
                "," + bil.device_id + " = '" + p.device_id + "' " +
                "," + bil.date_cancel + " = '" + p.date_cancel + "' " +
                "," + bil.date_modi + " = '" + p.date_modi + "' " +
                "," + bil.user_cancel + " = '" + p.user_cancel + "' " +
                "," + bil.user_modi + " = '" + p.user_modi + "' " +
                "," + bil.service_charge + " = '" + p.service_charge + "' " +
                "," + bil.vat + " = '" + p.vat + "' " +
                "," + bil.total + " = '" + p.total + "' " +
                "," + bil.nettotal + " = '" + p.nettotal + "' " +
                "," + bil.cash_receive + " = '" + p.cash_receive + "' " +
                "," + bil.cash_ton + " = '" + p.cash_ton + "' " +
                "," + bil.void_date + " = '" + p.void_date + "' " +
                "," + bil.bill_user + " = '" + p.bill_user + "' " +
                "," + bil.status_closeday + " = '" + p.status_closeday + "' " +
                "," + bil.closeday_id + " = '" + p.closeday_id + "' " +
                "," + bil.lot_id + " = '" + p.lot_id + "' " +
                //"," + ord.order_user + " = '" + p.order_user + "' " +
                //"," + bil.status_closeday + " = '" + p.status_closeday + "' " +
                //"," + bil.closeday_id + " = '" + p.closeday_id + "' " +
                //"," + ord.cnt_cust + " = '" + p.cnt_cust + "' " +

                "," + bil.void_user + " = '" + p.void_user + "' " +
                "," + bil.table_id + " = '" + p.table_id + "' " +
                //"," + bil.table_id + " = '" + p.table_id + "' " +
                "," + bil.status_payment + " = '" + p.status_payment + "' " +
                "," + bil.res_id + " = '" + p.res_id + "' " +
                "," + bil.area_id + " = '" + p.area_id + "' " +
                "," + bil.amount + " = '" + p.amount + "' " +
                "," + bil.discount + " = '" + p.discount + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogFile("Bill -> insert" + ex.Message + " " + ex.InnerException);
            }

            return re;
        }
        public String update(Bill p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + bil.table + " Set " +
                " " + bil.bill_code + " = '" + p.bill_code + "'" +
                "," + bil.bill_date + " = '" + p.bill_date.Replace("'", "''") + "'" +
                "," + bil.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bil.date_modi + " = now()" +
                "," + bil.user_modi + " = '" + userId + "' " +
                "," + bil.host_id + " = '" + p.host_id + "' " +
                "," + bil.branch_id + " = '" + p.branch_id + "' " +
                "," + bil.device_id + " = '" + p.device_id + "' " +
                "," + bil.void_user + " = '" + p.void_user + "' " +
                "," + bil.table_id + " = '" + p.table_id + "' " +
                "," + bil.table_id + " = '" + p.table_id + "' " +
                "," + bil.bill_user + " = '" + p.bill_user + "' " +
                "," + bil.res_id + " = '" + p.res_id + "' " +
                "," + bil.area_id + " = '" + p.area_id + "' " +
                "," + bil.amount + " = '" + p.amount + "' " +
                //"," + foo.discount + " = '" + p.discount + "' " +
                "Where " + bil.pkField + "='" + p.bill_id + "'"
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
        public String insertBill(Bill p, String userId)
        {
            String re = "";

            if (p.bill_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String updateFileName(String fooid, String discount)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            //chkNull(p);
            sql = "Update " + bil.table + " Set " +
                " " + bil.discount + " = '" + discount + "'" +
                "Where " + bil.pkField + "='" + fooid + "'"
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
                item.Text = row[bil.bill_date].ToString();
                item.Value = row[bil.bill_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoods(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lOrd.Count <= 0) getlFoods();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (Bill row in lOrd)
            {
                item = new ComboBoxItem();
                item.Value = row.bill_id;
                item.Text = row.bill_date;
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
        private Bill setFoods(DataTable dt)
        {
            Bill dept1 = new Bill();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_id = dt.Rows[0][bil.bill_id].ToString();
                dept1.bill_code = dt.Rows[0][bil.bill_code].ToString();
                dept1.bill_date = dt.Rows[0][bil.bill_date].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][bil.remark] != null ? dt.Rows[0][bil.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][bil.date_create] != null ? dt.Rows[0][bil.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][bil.date_modi] != null ? dt.Rows[0][bil.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][bil.date_cancel] != null ? dt.Rows[0][bil.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][bil.user_create] != null ? dt.Rows[0][bil.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][bil.user_modi] != null ? dt.Rows[0][bil.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][bil.user_cancel] != null ? dt.Rows[0][bil.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][bil.active] != null ? dt.Rows[0][bil.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][bil.sort1] != null ? dt.Rows[0][bil.sort1].ToString() : "";
                dept1.status_void = dt.Rows[0][bil.status_void] != null ? dt.Rows[0][bil.status_void].ToString() : "";
                dept1.lot_id = dt.Rows[0][bil.lot_id] != null ? dt.Rows[0][bil.lot_id].ToString() : "";
                dept1.void_date = dt.Rows[0][bil.void_date] != null ? dt.Rows[0][bil.void_date].ToString() : "";
                dept1.void_user = dt.Rows[0][bil.void_user] != null ? dt.Rows[0][bil.void_user].ToString() : "";
                dept1.table_id = dt.Rows[0][bil.table_id] != null ? dt.Rows[0][bil.table_id].ToString() : "";
                dept1.table_id = dt.Rows[0][bil.table_id] != null ? dt.Rows[0][bil.table_id].ToString() : "";
                dept1.res_id = dt.Rows[0][bil.res_id] != null ? dt.Rows[0][bil.res_id].ToString() : "";
                dept1.area_id = dt.Rows[0][bil.area_id] != null ? dt.Rows[0][bil.area_id].ToString() : "";
                dept1.amount = dt.Rows[0][bil.amount] != null ? dt.Rows[0][bil.amount].ToString() : "";
                dept1.discount = dt.Rows[0][bil.discount] != null ? dt.Rows[0][bil.discount].ToString() : "";
                dept1.status_payment = dt.Rows[0][bil.status_payment] != null ? dt.Rows[0][bil.status_payment].ToString() : "";
            }
            else
            {
                dept1.bill_id = "";
                dept1.bill_code = "";
                dept1.bill_date = "";
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
                dept1.status_void = "";
                dept1.lot_id = "";
                dept1.void_date = "";
                dept1.void_user = "";
                dept1.table_id = "";
                dept1.table_id = "";
                dept1.area_id = "";
                dept1.res_id = "";
                dept1.amount = "";
                dept1.discount = "";
                dept1.status_payment = "";
            }

            return dept1;
        }
    }
}
