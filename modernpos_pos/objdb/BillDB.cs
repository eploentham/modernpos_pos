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
        Bill ord;
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
            ord = new Bill();
            ord.bill_id = "bill_id";
            ord.bill_code = "bill_code";
            ord.bill_date = "bill_date";
            ord.lot_id = "lot_id";
            ord.status_void = "status_void";
            ord.void_date = "void_date";
            ord.void_user = "void_user";            

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

            ord.table_id = "table_id";
            ord.res_id = "res_id";
            ord.area_id = "area_id";
            ord.amount = "amount";
            ord.discount = "discount";

            ord.service_charge = "service_charge";
            ord.vat = "vat";
            ord.total = "total";
            ord.nettotal = "nettotal";
            ord.cash_receive = "cash_receive";
            ord.cash_ton = "cash_ton";
            ord.bill_user = "bill_user";
            ord.status_closeday = "status_closeday";
            ord.closeday_id = "closeday_id";
            
            ord.pkField = "bill_id";
            ord.table = "t_order";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foo.*  " +
                "From " + ord.table + " foo " +
                " " +
                "Where foo." + ord.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
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
        public Bill selectByPk1(String copId)
        {
            Bill cop1 = new Bill();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + ord.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + ord.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoods(dt);
            return cop1;
        }
        private Bill setArea1(DataTable dt)
        {
            Bill dept1 = new Bill();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_id = dt.Rows[0][ord.bill_id].ToString();
                dept1.bill_date = dt.Rows[0][ord.bill_date].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + ord.pkField + ",foo." + ord.bill_date + " " +
                "From " + ord.table + " foo " +
                " " +
                "Where foo." + ord.active + " ='1' ";
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
                itm1.bill_id = row[ord.bill_id].ToString();
                itm1.bill_date = row[ord.bill_date].ToString();
                itm1.bill_user = row[ord.bill_user].ToString();
                itm1.table_id = row[ord.table_id].ToString();
                itm1.bill_code = row[ord.bill_code].ToString();
                itm1.lot_id = row[ord.lot_id].ToString();
                itm1.amount = row[ord.amount].ToString();
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
                itm1.bill_id = row[ord.bill_id].ToString();
                itm1.bill_date = row[ord.bill_date].ToString();

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
            //p.cnt_cust = p.cnt_cust == null ? "" : p.cnt_cust;
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

            chkNull(p);
            sql = "Insert Into " + ord.table + " set " +
                " " + ord.bill_code + " = '" + p.bill_code + "'" +
                "," + ord.bill_date + " = '" + p.bill_date.Replace("'", "''") + "'" +
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
                "," + ord.service_charge + " = '" + p.service_charge + "' " +
                "," + ord.vat + " = '" + p.vat + "' " +
                "," + ord.total + " = '" + p.total + "' " +
                "," + ord.nettotal + " = '" + p.nettotal + "' " +
                "," + ord.cash_receive + " = '" + p.cash_receive + "' " +
                "," + ord.cash_ton + " = '" + p.cash_ton + "' " +
                "," + ord.void_date + " = '" + p.void_date + "' " +
                "," + ord.bill_user + " = '" + p.bill_user + "' " +
                "," + ord.status_closeday + " = '" + p.status_closeday + "' " +
                "," + ord.closeday_id + " = '" + p.closeday_id + "' " +
                "," + ord.bill_id + " = '" + p.bill_id + "' " +
                //"," + ord.order_user + " = '" + p.order_user + "' " +
                "," + ord.status_closeday + " = '" + p.status_closeday + "' " +
                "," + ord.closeday_id + " = '" + p.closeday_id + "' " +
                //"," + ord.cnt_cust + " = '" + p.cnt_cust + "' " +

                "," + ord.void_user + " = '" + p.void_user + "' " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.bill_user + " = '" + p.bill_user + "' " +
                "," + ord.res_id + " = '" + p.res_id + "' " +
                "," + ord.area_id + " = '" + p.area_id + "' " +
                "," + ord.amount + " = '" + p.amount + "' " +
                "," + ord.discount + " = '" + p.discount + "' " +
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
        public String update(Bill p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + ord.table + " Set " +
                " " + ord.bill_code + " = '" + p.bill_code + "'" +
                "," + ord.bill_date + " = '" + p.bill_date.Replace("'", "''") + "'" +
                "," + ord.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + ord.date_modi + " = now()" +
                "," + ord.user_modi + " = '" + userId + "' " +
                "," + ord.host_id + " = '" + p.host_id + "' " +
                "," + ord.branch_id + " = '" + p.branch_id + "' " +
                "," + ord.device_id + " = '" + p.device_id + "' " +
                "," + ord.void_user + " = '" + p.void_user + "' " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.table_id + " = '" + p.table_id + "' " +
                "," + ord.bill_user + " = '" + p.bill_user + "' " +
                "," + ord.res_id + " = '" + p.res_id + "' " +
                "," + ord.area_id + " = '" + p.area_id + "' " +
                "," + ord.amount + " = '" + p.amount + "' " +
                //"," + foo.discount + " = '" + p.discount + "' " +
                "Where " + ord.pkField + "='" + p.bill_id + "'"
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
        public String insertOrder(Bill p, String userId)
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
            sql = "Update " + ord.table + " Set " +
                " " + ord.discount + " = '" + discount + "'" +
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
                item.Text = row[ord.bill_date].ToString();
                item.Value = row[ord.bill_id].ToString();

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
                dept1.bill_id = dt.Rows[0][ord.bill_id].ToString();
                dept1.bill_code = dt.Rows[0][ord.bill_code].ToString();
                dept1.bill_date = dt.Rows[0][ord.bill_date].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
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
                dept1.status_void = dt.Rows[0][ord.status_void] != null ? dt.Rows[0][ord.status_void].ToString() : "";
                dept1.lot_id = dt.Rows[0][ord.lot_id] != null ? dt.Rows[0][ord.lot_id].ToString() : "";
                dept1.void_date = dt.Rows[0][ord.void_date] != null ? dt.Rows[0][ord.void_date].ToString() : "";
                dept1.void_user = dt.Rows[0][ord.void_user] != null ? dt.Rows[0][ord.void_user].ToString() : "";
                dept1.table_id = dt.Rows[0][ord.table_id] != null ? dt.Rows[0][ord.table_id].ToString() : "";
                dept1.table_id = dt.Rows[0][ord.table_id] != null ? dt.Rows[0][ord.table_id].ToString() : "";
                dept1.res_id = dt.Rows[0][ord.res_id] != null ? dt.Rows[0][ord.res_id].ToString() : "";
                dept1.area_id = dt.Rows[0][ord.area_id] != null ? dt.Rows[0][ord.area_id].ToString() : "";
                dept1.amount = dt.Rows[0][ord.amount] != null ? dt.Rows[0][ord.amount].ToString() : "";
                dept1.discount = dt.Rows[0][ord.discount] != null ? dt.Rows[0][ord.discount].ToString() : "";
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
            }

            return dept1;
        }
    }
}
