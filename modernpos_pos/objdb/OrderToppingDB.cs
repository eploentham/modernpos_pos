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
    public class OrderToppingDB
    {
        public OrderTopping foot;
        ConnectDB conn;
        public List<OrderTopping> lfooC;

        public OrderToppingDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooC = new List<OrderTopping>();
            foot = new OrderTopping();
            foot.order_topping_id = "order_topping_id";
            foot.order_id = "order_id";
            foot.foods_topping_id = "foods_topping_id";
            foot.active = "active";
            foot.remark = "remark";
            foot.row1 = "row1";
            foot.date_cancel = "date_cancel";
            foot.date_create = "date_create";
            foot.date_modi = "date_modi";
            foot.user_cancel = "user_cancel";
            foot.user_create = "user_create";
            foot.user_modi = "user_modi";
            foot.host_id = "host_id";
            foot.branch_id = "branch_id";
            foot.device_id = "device_id";
            foot.qty = "qty";
            foot.price = "price";
            //foos.status_aircondition = "status_aircondition";

            foot.pkField = "order_topping_id";
            foot.table = "t_order_topping";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + foot.table + " foos " +
                " " +
                "Where foos." + foot.active + " ='1' " +
                "Order By foos." + foot.order_topping_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + foot.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foot.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foot.order_id + ",foos." + foot.foods_topping_id +
                " From " + foot.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foot.order_id + " ='" + copId + "' and foos." + foot.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foot.order_id + ",'' as img,foos." + foot.foods_topping_id +
                " From " + foot.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foot.order_id + " ='" + copId + "' and foos." + foot.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foot.order_topping_id + ",'' as img,foos." + foot.foods_topping_id +
                " From " + foot.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foot.order_id + " ='" + copId + "' and foos." + foot.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrderTopping selectByPk1(String copId)
        {
            OrderTopping cop1 = new OrderTopping();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foot.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foot.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsSpecial(dt);
            return cop1;
        }
        private OrderTopping setArea1(DataTable dt)
        {
            OrderTopping dept1 = new OrderTopping();
            if (dt.Rows.Count > 0)
            {
                dept1.order_topping_id = dt.Rows[0][foot.order_topping_id].ToString();
                dept1.foods_topping_id = dt.Rows[0][foot.foods_topping_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + foot.pkField + ",sex." + foot.foods_topping_id + " " +
                "From " + foot.table + " sex " +
                " " +
                "Where sex." + foot.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<OrderTopping> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<OrderTopping> lfooC1 = new List<OrderTopping>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                OrderTopping itm1 = new OrderTopping();
                itm1.order_topping_id = row[foot.order_topping_id].ToString();
                itm1.foods_topping_id = row[foot.foods_topping_id].ToString();

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
                OrderTopping itm1 = new OrderTopping();
                itm1.order_topping_id = row[foot.order_topping_id].ToString();
                itm1.foods_topping_id = row[foot.foods_topping_id].ToString();

                lfooC.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooC.Count <= 0) getlArea();
            foreach (OrderTopping sex in lfooC)
            {
                if (sex.order_topping_id.Equals(id))
                {
                    re = sex.foods_topping_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(OrderTopping p)
        {
            long chk = 0;
            decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.host_id = p.host_id == null ? "" : p.host_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.device_id = p.device_id == null ? "" : p.device_id;

            p.foods_topping_id = p.foods_topping_id == null ? "" : p.foods_topping_id;
            p.order_id = p.order_id == null ? "" : p.order_id;

            p.remark = p.remark == null ? "" : p.remark;
            p.row1 = p.row1 == null ? "" : p.row1;

            p.qty = long.TryParse(p.qty, out chk) ? chk.ToString() : "0";
            
            p.price = decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            //p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(OrderTopping p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foot.table + " set " +
                " " + foot.order_id + " = '" + p.order_id + "'" +
                "," + foot.foods_topping_id + " = '" + p.foods_topping_id.Replace("'", "''") + "'" +
                "," + foot.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foot.date_create + " = now()" +
                "," + foot.active + " = '1'" +
                "," + foot.user_create + " = '" + userId + "' " +
                "," + foot.host_id + " = '" + p.host_id + "' " +
                "," + foot.branch_id + " = '" + p.branch_id + "' " +
                "," + foot.device_id + " = '" + p.device_id + "' " +
                "," + foot.row1 + " = '" + p.row1 + "' " +
                "," + foot.qty + " = '" + p.qty + "' " +
                "," + foot.price + " = '" + p.price + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                //sql = ex.Message + " " + ex.InnerException;
                new LogFile("OrderToppingDB -> insert " + ex.Message + " " + ex.InnerException + " \n sql " + sql);
            }

            return re;
        }
        public String update(OrderTopping p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foot.table + " Set " +
                " " + foot.order_id + " = '" + p.order_id + "'" +
                "," + foot.foods_topping_id + " = '" + p.foods_topping_id.Replace("'", "''") + "'" +
                "," + foot.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foot.date_modi + " = now()" +
                "," + foot.user_modi + " = '" + userId + "' " +
                "," + foot.host_id + " = '" + p.host_id + "' " +
                "," + foot.branch_id + " = '" + p.branch_id + "' " +
                "," + foot.device_id + " = '" + p.device_id + "' " +
                "," + foot.row1 + " = '" + p.row1 + "' " +
                "," + foot.qty + " = '" + p.qty + "' " +
                "," + foot.price + " = '" + p.price + "' " +
                "Where " + foot.pkField + "='" + p.order_topping_id + "'"
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
        public String insertFoodsTopping(OrderTopping p, String userId)
        {
            String re = "";

            if (p.order_topping_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidFoodsToping(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + foot.table + " Set " +
                " " + foot.active + " = '3'" +
                "," + foot.date_cancel + " = now()" +
                "," + foot.user_modi + " = '" + userId + "' " +
                "Where " + foot.pkField + "='" + foosid + "'"
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
                item.Text = row[foot.foods_topping_id].ToString();
                item.Value = row[foot.order_topping_id].ToString();

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
            foreach (OrderTopping row in lfooC)
            {
                item = new ComboBoxItem();
                item.Value = row.order_topping_id;
                item.Text = row.foods_topping_id;
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
        private OrderTopping setFoodsSpecial(DataTable dt)
        {
            OrderTopping dept1 = new OrderTopping();
            if (dt.Rows.Count > 0)
            {
                dept1.order_topping_id = dt.Rows[0][foot.order_topping_id].ToString();
                dept1.order_id = dt.Rows[0][foot.order_id].ToString();
                dept1.foods_topping_id = dt.Rows[0][foot.foods_topping_id].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][foot.remark] != null ? dt.Rows[0][foot.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foot.date_create] != null ? dt.Rows[0][foot.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foot.date_modi] != null ? dt.Rows[0][foot.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foot.date_cancel] != null ? dt.Rows[0][foot.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foot.user_create] != null ? dt.Rows[0][foot.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foot.user_modi] != null ? dt.Rows[0][foot.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foot.user_cancel] != null ? dt.Rows[0][foot.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foot.active] != null ? dt.Rows[0][foot.active].ToString() : "";
                dept1.row1 = dt.Rows[0][foot.row1] != null ? dt.Rows[0][foot.row1].ToString() : "";
                dept1.qty = dt.Rows[0][foot.qty] != null ? dt.Rows[0][foot.qty].ToString() : "";
                dept1.price = dt.Rows[0][foot.price] != null ? dt.Rows[0][foot.price].ToString() : "";
                //dept1.status_aircondition = dt.Rows[0][foos.status_aircondition] != null ? dt.Rows[0][foos.status_aircondition].ToString() : "";
            }
            else
            {
                dept1.order_topping_id = "";
                dept1.order_id = "";
                dept1.foods_topping_id = "";
                //posi.dept_parent_id = "dept_parent_id";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.row1 = "";
                dept1.qty = "";
                dept1.price = "";
                //dept1.status_aircondition = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
