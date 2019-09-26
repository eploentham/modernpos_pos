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
    public class BillDetailDB
    {
        BillDetail bil;
        ConnectDB conn;
        public List<BillDetail> lBil;
        public BillDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lBil = new List<BillDetail>();
            bil = new BillDetail();
            bil.bill_detail_id = "bill_detail_id";
            bil.bill_id = "bill_id";
            bil.order_id = "order_id";
            bil.lot_id = "lot_id";
            bil.status_void = "status_void";
            bil.row1 = "row1";
            bil.foods_id = "foods_id";
            bil.foods_code = "foods_code";

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
            bil.price = "price";
            bil.qty = "qty";
            bil.amount = "amount";
            //bil.foods_cat_id = "foods_cat_id";
            //bil.filename = "filename";

            bil.pkField = "bill_detail_id";
            bil.table = "t_bill_detail";
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
        public BillDetail selectByPk1(String copId)
        {
            BillDetail cop1 = new BillDetail();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + bil.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + bil.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBillDetail(dt);
            return cop1;
        }
        private BillDetail setArea1(DataTable dt)
        {
            BillDetail dept1 = new BillDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_detail_id = dt.Rows[0][bil.bill_detail_id].ToString();
                dept1.order_id = dt.Rows[0][bil.order_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + bil.pkField + ",foo." + bil.order_id + " " +
                "From " + bil.table + " foo " +
                " " +
                "Where foo." + bil.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<BillDetail> getlFoods1()
        {
            List<BillDetail> lfoo1 = new List<BillDetail>();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                BillDetail itm1 = new BillDetail();
                itm1.bill_detail_id = row[bil.bill_detail_id].ToString();
                itm1.order_id = row[bil.order_id].ToString();
                itm1.status_void = row[bil.status_void].ToString();
                itm1.foods_id = row[bil.foods_id].ToString();
                itm1.bill_id = row[bil.bill_id].ToString();
                itm1.lot_id = row[bil.lot_id].ToString();
                //itm1.foods_cat_id = row[bil.foods_cat_id].ToString();
                lfoo1.Add(itm1);
            }
            return lfoo1;
        }
        public void getlFoods()
        {
            //lDept = new List<Position>();
            lBil.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                BillDetail itm1 = new BillDetail();
                itm1.bill_detail_id = row[bil.bill_detail_id].ToString();
                itm1.order_id = row[bil.order_id].ToString();

                lBil.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lBil.Count <= 0) getlFoods();
            foreach (BillDetail sex in lBil)
            {
                if (sex.bill_detail_id.Equals(id))
                {
                    re = sex.order_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(BillDetail p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            //p.order_id = p.order_id == null ? "" : p.order_id;
            //p.bill_id = p.bill_id == null ? "" : p.bill_id;
            //p.foods_id = p.foods_id == null ? "" : p.foods_id;
            //p.price = p.price == null ? "0" : p.price;
            p.foods_code = p.foods_code == null ? "" : p.foods_code;
            //p.amount = p.amount == null ? "0" : p.amount;
            //p.qty = p.qty == null ? "0" : p.qty;
            p.status_void = p.status_void == null ? "" : p.status_void;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.lot_id = long.TryParse(p.lot_id, out chk) ? chk.ToString() : "0";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "0";
            p.bill_id = long.TryParse(p.bill_id, out chk) ? chk.ToString() : "0";
            p.order_id = long.TryParse(p.order_id, out chk) ? chk.ToString() : "0";
            p.lot_id = long.TryParse(p.lot_id, out chk) ? chk.ToString() : "0";
            p.foods_id = long.TryParse(p.foods_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(BillDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + bil.table + " set " +
                " " + bil.bill_id + " = '" + p.bill_id + "'" +
                "," + bil.order_id + " = '" + p.order_id.Replace("'", "''") + "'" +
                "," + bil.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bil.date_create + " = now()" +
                "," + bil.active + " = '1'" +
                "," + bil.user_create + " = '" + userId + "' " +
                "," + bil.host_id + " = '" + p.host_id + "' " +
                "," + bil.branch_id + " = '" + p.branch_id + "' " +
                "," + bil.device_id + " = '" + p.device_id + "' " +
                "," + bil.foods_id + " = '" + p.foods_id + "' " +
                "," + bil.price + " = '" + p.price + "' " +
                "," + bil.foods_code + " = '" + p.foods_code + "' " +
                "," + bil.status_void + " = '" + p.status_void + "' " +
                "," + bil.qty + " = '" + p.qty + "' " +
                "," + bil.amount + " = '" + p.amount + "' " +
                //"," + bil.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                //"," + bil.filename + " = '" + p.filename + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogFile("BillDetail -> insert" + ex.Message + " " + ex.InnerException);
            }

            return re;
        }
        public String update(BillDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + bil.table + " Set " +
                " " + bil.bill_id + " = '" + p.bill_id + "'" +
                "," + bil.order_id + " = '" + p.order_id.Replace("'", "''") + "'" +
                "," + bil.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bil.date_modi + " = now()" +
                "," + bil.user_modi + " = '" + userId + "' " +
                "," + bil.host_id + " = '" + p.host_id + "' " +
                "," + bil.branch_id + " = '" + p.branch_id + "' " +
                "," + bil.device_id + " = '" + p.device_id + "' " +
                "," + bil.row1 + " = '" + p.row1 + "' " +
                "," + bil.price + " = '" + p.price + "' " +
                "," + bil.foods_code + " = '" + p.foods_code + "' " +
                "," + bil.status_void + " = '" + p.status_void + "' " +
                "," + bil.qty + " = '" + p.qty + "' " +
                "," + bil.amount + " = '" + p.amount + "' " +
                //"," + bil.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                "," + bil.lot_id + " = '" + p.lot_id + "' " +
                "Where " + bil.pkField + "='" + p.bill_detail_id + "'"
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
        public String insertBillDetail(BillDetail p, String userId)
        {
            String re = "";

            if (p.bill_detail_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        //public String updateFileName(String fooid, String filename)
        //{
        //    String re = "";
        //    String sql = "";
        //    int chk = 0;

        //    //chkNull(p);
        //    sql = "Update " + bil.table + " Set " +
        //        " " + bil.filename + " = '" + filename + "'" +
        //        "Where " + bil.pkField + "='" + fooid + "'"
        //        ;
        //    try
        //    {
        //        re = conn.ExecuteNonQuery(conn.conn, sql);
        //    }
        //    catch (Exception ex)
        //    {
        //        sql = ex.Message + " " + ex.InnerException;
        //    }

        //    return re;
        //}
        public C1ComboBox setCboBillDetail(C1ComboBox c)
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
                item.Text = row[bil.order_id].ToString();
                item.Value = row[bil.bill_detail_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboBillDetail(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lBil.Count <= 0) getlFoods();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (BillDetail row in lBil)
            {
                item = new ComboBoxItem();
                item.Value = row.bill_detail_id;
                item.Text = row.order_id;
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
        private BillDetail setBillDetail(DataTable dt)
        {
            BillDetail dept1 = new BillDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_detail_id = dt.Rows[0][bil.bill_detail_id].ToString();
                dept1.bill_id = dt.Rows[0][bil.bill_id].ToString();
                dept1.order_id = dt.Rows[0][bil.order_id].ToString();
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
                dept1.row1 = dt.Rows[0][bil.row1] != null ? dt.Rows[0][bil.row1].ToString() : "";
                dept1.foods_id = dt.Rows[0][bil.foods_id] != null ? dt.Rows[0][bil.foods_id].ToString() : "";
                dept1.price = dt.Rows[0][bil.price] != null ? dt.Rows[0][bil.price].ToString() : "";
                dept1.foods_code = dt.Rows[0][bil.foods_code] != null ? dt.Rows[0][bil.foods_code].ToString() : "";
                dept1.qty = dt.Rows[0][bil.qty] != null ? dt.Rows[0][bil.qty].ToString() : "";
                dept1.amount = dt.Rows[0][bil.amount] != null ? dt.Rows[0][bil.amount].ToString() : "";
                //dept1.foods_cat_id = dt.Rows[0][bil.foods_cat_id] != null ? dt.Rows[0][bil.foods_cat_id].ToString() : "";
                //dept1.filename = dt.Rows[0][bil.filename] != null ? dt.Rows[0][bil.filename].ToString() : "";
            }
            else
            {
                dept1.bill_detail_id = "";
                dept1.bill_id = "";
                dept1.order_id = "";
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
                dept1.row1 = "";
                dept1.foods_id = "";
                dept1.price = "";
                dept1.foods_code = "";
                dept1.amount = "";
                dept1.qty = "";
                //dept1.foods_cat_id = "";
                //dept1.filename = "";
            }

            return dept1;
        }
    }
}
