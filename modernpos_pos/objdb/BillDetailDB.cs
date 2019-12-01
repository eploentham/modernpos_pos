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
        BillDetail bild;
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
            bild = new BillDetail();
            bild.bill_detail_id = "bill_detail_id";
            bild.bill_id = "bill_id";
            bild.order_id = "order_id";
            bild.lot_id = "lot_id";
            bild.status_void = "status_void";
            bild.row1 = "row1";
            bild.foods_id = "foods_id";
            bild.foods_code = "foods_code";

            bild.active = "active";
            bild.remark = "remark";
            bild.sort1 = "sort1";
            bild.date_cancel = "date_cancel";
            bild.date_create = "date_create";
            bild.date_modi = "date_modi";
            bild.user_cancel = "user_cancel";
            bild.user_create = "user_create";
            bild.user_modi = "user_modi";
            bild.host_id = "host_id";
            bild.branch_id = "branch_id";
            bild.device_id = "device_id";
            bild.price = "price";
            bild.qty = "qty";
            bild.amount = "amount";
            //bil.foods_cat_id = "foods_cat_id";
            //bil.filename = "filename";

            bild.pkField = "bill_detail_id";
            bild.table = "t_bill_detail";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foo.*  " +
                "From " + bild.table + " foo " +
                " " +
                "Where foo." + bild.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + bild.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + bild.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public BillDetail selectByPk1(String copId)
        {
            BillDetail cop1 = new BillDetail();
            DataTable dt = new DataTable();
            String sql = "select foo.* " +
                "From " + bild.table + " foo " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + bild.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setBillDetail(dt);
            return cop1;
        }
        public DataTable selectCloseDayCurr()
        {
            DataTable dt = new DataTable();
            String sql = "select sum(price*qty) as sum_price, count(bil.bill_id) as cnt_order  " +
                "From " + bild.table + " bild " +
                "Left Join t_bill bil on bil.bill_id = bild.bill_id " +
                "Where bild." + bild.active + " = '1' and bil.status_closeday = '0' and bil.active = '1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        private BillDetail setArea1(DataTable dt)
        {
            BillDetail dept1 = new BillDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.bill_detail_id = dt.Rows[0][bild.bill_detail_id].ToString();
                dept1.order_id = dt.Rows[0][bild.order_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select foo." + bild.pkField + ",foo." + bild.order_id + " " +
                "From " + bild.table + " foo " +
                " " +
                "Where foo." + bild.active + " ='1' ";
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
                itm1.bill_detail_id = row[bild.bill_detail_id].ToString();
                itm1.order_id = row[bild.order_id].ToString();
                itm1.status_void = row[bild.status_void].ToString();
                itm1.foods_id = row[bild.foods_id].ToString();
                itm1.bill_id = row[bild.bill_id].ToString();
                itm1.lot_id = row[bild.lot_id].ToString();
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
                itm1.bill_detail_id = row[bild.bill_detail_id].ToString();
                itm1.order_id = row[bild.order_id].ToString();

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
            sql = "Insert Into " + bild.table + " set " +
                " " + bild.bill_id + " = '" + p.bill_id + "'" +
                "," + bild.order_id + " = '" + p.order_id.Replace("'", "''") + "'" +
                "," + bild.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bild.date_create + " = now()" +
                "," + bild.active + " = '1'" +
                "," + bild.user_create + " = '" + userId + "' " +
                "," + bild.host_id + " = '" + p.host_id + "' " +
                "," + bild.branch_id + " = '" + p.branch_id + "' " +
                "," + bild.device_id + " = '" + p.device_id + "' " +
                "," + bild.foods_id + " = '" + p.foods_id + "' " +
                "," + bild.price + " = '" + p.price + "' " +
                "," + bild.foods_code + " = '" + p.foods_code + "' " +
                "," + bild.status_void + " = '" + p.status_void + "' " +
                "," + bild.qty + " = '" + p.qty + "' " +
                "," + bild.amount + " = '" + p.amount + "' " +
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
            sql = "Update " + bild.table + " Set " +
                " " + bild.bill_id + " = '" + p.bill_id + "'" +
                "," + bild.order_id + " = '" + p.order_id.Replace("'", "''") + "'" +
                "," + bild.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + bild.date_modi + " = now()" +
                "," + bild.user_modi + " = '" + userId + "' " +
                "," + bild.host_id + " = '" + p.host_id + "' " +
                "," + bild.branch_id + " = '" + p.branch_id + "' " +
                "," + bild.device_id + " = '" + p.device_id + "' " +
                "," + bild.row1 + " = '" + p.row1 + "' " +
                "," + bild.price + " = '" + p.price + "' " +
                "," + bild.foods_code + " = '" + p.foods_code + "' " +
                "," + bild.status_void + " = '" + p.status_void + "' " +
                "," + bild.qty + " = '" + p.qty + "' " +
                "," + bild.amount + " = '" + p.amount + "' " +
                //"," + bil.foods_cat_id + " = '" + p.foods_cat_id + "' " +
                "," + bild.lot_id + " = '" + p.lot_id + "' " +
                "Where " + bild.pkField + "='" + p.bill_detail_id + "'"
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
                item.Text = row[bild.order_id].ToString();
                item.Value = row[bild.bill_detail_id].ToString();

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
                dept1.bill_detail_id = dt.Rows[0][bild.bill_detail_id].ToString();
                dept1.bill_id = dt.Rows[0][bild.bill_id].ToString();
                dept1.order_id = dt.Rows[0][bild.order_id].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][bild.remark] != null ? dt.Rows[0][bild.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][bild.date_create] != null ? dt.Rows[0][bild.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][bild.date_modi] != null ? dt.Rows[0][bild.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][bild.date_cancel] != null ? dt.Rows[0][bild.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][bild.user_create] != null ? dt.Rows[0][bild.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][bild.user_modi] != null ? dt.Rows[0][bild.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][bild.user_cancel] != null ? dt.Rows[0][bild.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][bild.active] != null ? dt.Rows[0][bild.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][bild.sort1] != null ? dt.Rows[0][bild.sort1].ToString() : "";
                dept1.status_void = dt.Rows[0][bild.status_void] != null ? dt.Rows[0][bild.status_void].ToString() : "";
                dept1.lot_id = dt.Rows[0][bild.lot_id] != null ? dt.Rows[0][bild.lot_id].ToString() : "";
                dept1.row1 = dt.Rows[0][bild.row1] != null ? dt.Rows[0][bild.row1].ToString() : "";
                dept1.foods_id = dt.Rows[0][bild.foods_id] != null ? dt.Rows[0][bild.foods_id].ToString() : "";
                dept1.price = dt.Rows[0][bild.price] != null ? dt.Rows[0][bild.price].ToString() : "";
                dept1.foods_code = dt.Rows[0][bild.foods_code] != null ? dt.Rows[0][bild.foods_code].ToString() : "";
                dept1.qty = dt.Rows[0][bild.qty] != null ? dt.Rows[0][bild.qty].ToString() : "";
                dept1.amount = dt.Rows[0][bild.amount] != null ? dt.Rows[0][bild.amount].ToString() : "";
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
