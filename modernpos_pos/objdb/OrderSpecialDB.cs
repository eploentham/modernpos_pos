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
    public class OrderSpecialDB
    {
        public OrderSpecial foos;
        ConnectDB conn;
        public List<OrderSpecial> lfooC;

        public OrderSpecialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooC = new List<OrderSpecial>();
            foos = new OrderSpecial();
            foos.order_special_id = "order_special_id";
            foos.order_id = "order_id";
            foos.foods_spec_id = "foods_spec_id";
            foos.active = "active";
            foos.remark = "remark";
            foos.row1 = "row1";
            foos.date_cancel = "date_cancel";
            foos.date_create = "date_create";
            foos.date_modi = "date_modi";
            foos.user_cancel = "user_cancel";
            foos.user_create = "user_create";
            foos.user_modi = "user_modi";
            foos.host_id = "host_id";
            foos.branch_id = "branch_id";
            foos.device_id = "device_id";
            //foos.status_aircondition = "status_aircondition";

            foos.pkField = "order_special_id";
            foos.table = "t_order_special";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + foos.table + " foos " +
                " " +
                "Where foos." + foos.active + " ='1' " +
                "Order By foos." + foos.order_special_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foos.order_id + ",foos." + foos.foods_spec_id +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.order_id + " ='" + copId + "' and foos." + foos.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foos.order_id + ",'' as img,foos." + foos.foods_spec_id +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.order_id + " ='" + copId + "' and foos." + foos.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foos.order_special_id + ",'' as img,foos." + foos.foods_spec_id +
                " From " + foos.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foos.order_id + " ='" + copId + "' and foos." + foos.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrderSpecial selectByPk1(String copId)
        {
            OrderSpecial cop1 = new OrderSpecial();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foos.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foos.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsSpecial(dt);
            return cop1;
        }
        private OrderSpecial setArea1(DataTable dt)
        {
            OrderSpecial dept1 = new OrderSpecial();
            if (dt.Rows.Count > 0)
            {
                dept1.order_special_id = dt.Rows[0][foos.order_special_id].ToString();
                dept1.foods_spec_id = dt.Rows[0][foos.foods_spec_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + foos.pkField + ",sex." + foos.foods_spec_id + " " +
                "From " + foos.table + " sex " +
                " " +
                "Where sex." + foos.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public List<OrderSpecial> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<OrderSpecial> lfooC1 = new List<OrderSpecial>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                OrderSpecial itm1 = new OrderSpecial();
                itm1.order_special_id = row[foos.order_special_id].ToString();
                itm1.foods_spec_id = row[foos.foods_spec_id].ToString();

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
                OrderSpecial itm1 = new OrderSpecial();
                itm1.order_special_id = row[foos.order_special_id].ToString();
                itm1.foods_spec_id = row[foos.foods_spec_id].ToString();

                lfooC.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooC.Count <= 0) getlArea();
            foreach (OrderSpecial sex in lfooC)
            {
                if (sex.order_special_id.Equals(id))
                {
                    re = sex.foods_spec_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(OrderSpecial p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.host_id = p.host_id == null ? "" : p.host_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.device_id = p.device_id == null ? "" : p.device_id;

            p.foods_spec_id = p.foods_spec_id == null ? "" : p.foods_spec_id;
            p.order_id = p.order_id == null ? "" : p.order_id;

            p.remark = p.remark == null ? "" : p.remark;
            p.row1 = p.row1 == null ? "" : p.row1;

            //p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            //p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            //p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(OrderSpecial p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foos.table + " set " +
                " " + foos.order_id + " = '" + p.order_id + "'" +
                "," + foos.foods_spec_id + " = '" + p.foods_spec_id.Replace("'", "''") + "'" +
                "," + foos.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foos.date_create + " = now()" +
                "," + foos.active + " = '1'" +
                "," + foos.user_create + " = '" + userId + "' " +
                "," + foos.host_id + " = '" + p.host_id + "' " +
                "," + foos.branch_id + " = '" + p.branch_id + "' " +
                "," + foos.device_id + " = '" + p.device_id + "' " +
                "," + foos.row1 + " = '" + p.row1 + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                //sql = ex.Message + " " + ex.InnerException;
                new LogFile("OrderSpecialDB -> insert " + ex.Message + " " + ex.InnerException + " \n sql " + sql);
            }

            return re;
        }
        public String update(OrderSpecial p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foos.table + " Set " +
                " " + foos.order_id + " = '" + p.order_id + "'" +
                "," + foos.foods_spec_id + " = '" + p.foods_spec_id.Replace("'", "''") + "'" +
                "," + foos.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foos.date_modi + " = now()" +
                "," + foos.user_modi + " = '" + userId + "' " +
                "," + foos.host_id + " = '" + p.host_id + "' " +
                "," + foos.branch_id + " = '" + p.branch_id + "' " +
                "," + foos.device_id + " = '" + p.device_id + "' " +
                "," + foos.row1 + " = '" + p.row1 + "' " +

                "Where " + foos.pkField + "='" + p.order_special_id + "'"
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
        public String insertFoodsSpecial(OrderSpecial p, String userId)
        {
            String re = "";

            if (p.order_special_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidFoodsSpecial(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + foos.table + " Set " +
                " " + foos.active + " = '3'" +
                "," + foos.date_cancel + " = now()" +
                "," + foos.user_modi + " = '" + userId + "' " +
                "Where " + foos.pkField + "='" + foosid + "'"
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
                item.Text = row[foos.foods_spec_id].ToString();
                item.Value = row[foos.order_special_id].ToString();

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
            foreach (OrderSpecial row in lfooC)
            {
                item = new ComboBoxItem();
                item.Value = row.order_special_id;
                item.Text = row.foods_spec_id;
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
        private OrderSpecial setFoodsSpecial(DataTable dt)
        {
            OrderSpecial dept1 = new OrderSpecial();
            if (dt.Rows.Count > 0)
            {
                dept1.order_special_id = dt.Rows[0][foos.order_special_id].ToString();
                dept1.order_id = dt.Rows[0][foos.order_id].ToString();
                dept1.foods_spec_id = dt.Rows[0][foos.foods_spec_id].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][foos.remark] != null ? dt.Rows[0][foos.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foos.date_create] != null ? dt.Rows[0][foos.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foos.date_modi] != null ? dt.Rows[0][foos.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foos.date_cancel] != null ? dt.Rows[0][foos.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foos.user_create] != null ? dt.Rows[0][foos.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foos.user_modi] != null ? dt.Rows[0][foos.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foos.user_cancel] != null ? dt.Rows[0][foos.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foos.active] != null ? dt.Rows[0][foos.active].ToString() : "";
                dept1.row1 = dt.Rows[0][foos.row1] != null ? dt.Rows[0][foos.row1].ToString() : "";
                //dept1.status_aircondition = dt.Rows[0][foos.status_aircondition] != null ? dt.Rows[0][foos.status_aircondition].ToString() : "";
            }
            else
            {
                dept1.order_special_id = "";
                dept1.order_id = "";
                dept1.foods_spec_id = "";
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
                //dept1.status_aircondition = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
