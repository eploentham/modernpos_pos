using C1.Win.C1Input;
using modernpos_pos.object1;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class OrderMaterialDB
    {
        public OrderMaterial foom;
        ConnectDB conn;
        public List<OrderMaterial> lfootp;

        public OrderMaterialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<OrderMaterial>();
            foom = new OrderMaterial();
            foom.order_material_id = "order_material_id";
            foom.weight = "weight";
            foom.material_name = "material_name";
            foom.active = "active";
            foom.remark = "remark";
            foom.sort1 = "sort1";
            foom.date_cancel = "date_cancel";
            foom.date_create = "date_create";
            foom.date_modi = "date_modi";
            foom.user_cancel = "user_cancel";
            foom.user_create = "user_create";
            foom.user_modi = "user_modi";
            foom.host_id = "host_id";
            foom.branch_id = "branch_id";
            foom.device_id = "device_id";
            foom.price = "price";
            foom.foods_id = "foods_id";
            foom.qty = "qty";
            foom.order_id = "order_id";
            foom.foods_material_id = "foods_material_id";
            foom.foods_name = "foods_name";
            //foom.foods_id = "foods_id";
            foom.material_id = "material_id";

            foom.pkField = "order_material_id";
            foom.table = "b_foods_material";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + foom.table + " foos " +
                " " +
                "Where foos." + foom.active + " ='1' " +
                "Order By foos." + foom.order_material_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + foom.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foom.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foom.order_material_id + ",foos." + foom.material_name + ",foos." + foom.price + ",foos." + foom.weight + ",foos." + foom.qty +
               " From " + foom.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foom.foods_id + " ='" + copId + "' and foos." + foom.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + foom.weight + ",'' as img,foos." + foom.material_name + ",foos." + foom.price +
                " From " + foom.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + foom.weight + " ='" + copId + "' and foos." + foom.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public OrderMaterial selectByPk1(String copId)
        {
            OrderMaterial cop1 = new OrderMaterial();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foom.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foom.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsMaterial(dt);
            return cop1;
        }
        private OrderMaterial setArea1(DataTable dt)
        {
            OrderMaterial dept1 = new OrderMaterial();
            if (dt.Rows.Count > 0)
            {
                dept1.order_material_id = dt.Rows[0][foom.order_material_id].ToString();
                dept1.material_name = dt.Rows[0][foom.material_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + foom.pkField + ",sex." + foom.material_name + " " +
                "From " + foom.table + " sex " +
                " " +
                "Where sex." + foom.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + foom.order_material_id + ",'' as img,footp." + foom.material_name + ",footp." + foom.price + ", footp." + foom.weight +
                " From " + foom.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + foom.weight + " ='" + copId + "' and footp." + foom.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<OrderMaterial> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<OrderMaterial> lfooC1 = new List<OrderMaterial>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                OrderMaterial itm1 = new OrderMaterial();
                itm1.order_material_id = row[foom.order_material_id].ToString();
                itm1.material_name = row[foom.material_name].ToString();
                itm1.price = row[foom.price].ToString();
                itm1.weight = row[foom.weight].ToString();
                lfooC1.Add(itm1);
            }
            return lfooC1;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lfootp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                OrderMaterial itm1 = new OrderMaterial();
                itm1.order_material_id = row[foom.order_material_id].ToString();
                itm1.material_name = row[foom.material_name].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (OrderMaterial sex in lfootp)
            {
                if (sex.order_material_id.Equals(id))
                {
                    re = sex.material_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(OrderMaterial p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
            p.host_id = p.host_id == null ? "" : p.host_id;
            p.branch_id = p.branch_id == null ? "" : p.branch_id;
            p.device_id = p.device_id == null ? "" : p.device_id;

            p.material_name = p.material_name == null ? "" : p.material_name;
            p.weight = p.weight == null ? "" : p.weight;

            p.remark = p.remark == null ? "" : p.remark;

            p.foods_id = long.TryParse(p.foods_id, out chk) ? chk.ToString() : "0";
            p.material_id = long.TryParse(p.material_id, out chk) ? chk.ToString() : "0";
            p.order_id = long.TryParse(p.order_id, out chk) ? chk.ToString() : "0";
            p.foods_material_id = long.TryParse(p.foods_material_id, out chk) ? chk.ToString() : "0";
            //p.sort1 = long.TryParse(p.sort1, out chk) ? chk.ToString() : "999999999";
            //p.sort1 = long.TryParse(p.sort1, out chk) ? chk.ToString() : "999999999";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.weight = Decimal.TryParse(p.weight, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(OrderMaterial p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foom.table + " set " +
                " " + foom.weight + " = '" + p.weight + "'" +
                "," + foom.material_name + " = '" + p.material_name.Replace("'", "''") + "'" +
                "," + foom.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foom.date_create + " = now()" +
                "," + foom.active + " = '1'" +
                "," + foom.user_create + " = '" + userId + "' " +
                "," + foom.host_id + " = '" + p.host_id + "' " +
                "," + foom.branch_id + " = '" + p.branch_id + "' " +
                "," + foom.device_id + " = '" + p.device_id + "' " +
                "," + foom.price + " = '" + p.price + "' " +
                "," + foom.sort1 + " = '" + p.sort1 + "' " +
                "," + foom.qty + " = '" + p.qty + "' " +
                "," + foom.material_id + " = '" + p.material_id + "' " +
                "," + foom.foods_id + " = '" + p.foods_id + "' " +
                "," + foom.order_id + " = '" + p.order_id + "' " +
                "," + foom.foods_name + " = '" + p.foods_name.Replace("'", "''") + "' " +
                "," + foom.foods_material_id + " = '" + p.foods_material_id + "' " +
                ";";
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
        public String update(OrderMaterial p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foom.table + " Set " +
                " " + foom.weight + " = '" + p.weight + "'" +
                "," + foom.material_name + " = '" + p.material_name.Replace("'", "''") + "'" +
                "," + foom.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foom.date_modi + " = now()" +
                "," + foom.user_modi + " = '" + userId + "' " +
                "," + foom.host_id + " = '" + p.host_id + "' " +
                "," + foom.branch_id + " = '" + p.branch_id + "' " +
                "," + foom.device_id + " = '" + p.device_id + "' " +
                "," + foom.price + " = '" + p.price + "' " +
                "," + foom.foods_id + " = '" + p.foods_id + "' " +
                "," + foom.qty + " = '" + p.qty + "' " +
                "," + foom.sort1 + " = '" + p.sort1 + "' " +
                "," + foom.material_id + " = '" + p.material_id + "' " +
                "," + foom.order_id + " = '" + p.order_id + "' " +
                "," + foom.foods_name + " = '" + p.foods_name.Replace("'", "''") + "' " +
                "," + foom.foods_material_id + " = '" + p.foods_material_id + "' " +
                "Where " + foom.pkField + "='" + p.order_material_id + "'"
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
        public String insertFoodsMaterial(OrderMaterial p, String userId)
        {
            String re = "";

            if (p.order_material_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String genOrderMaterial(String lotid)
        {
            String re = "", sql = "";
            //DataTable dt = new DataTable();

            //sql = "UPDATE sequence SET lot_id=LAST_INSERT_ID("+seq.lot_id+"+1);";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_order_material", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?lotid", MySqlDbType.VarChar));
                cmd.Parameters["?lotid"].Direction = ParameterDirection.Input;
                cmd.Parameters["?lotid"].Value = lotid;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                //re = (string)cmd.Parameters["?lotid"].Value;

            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
            }
            finally
            {
                conn.conn.Close();
            }
            return re;
        }
        public String insertOrderMaterial(String foodsid, String ordid, String userId)
        {
            String re = "", sql="";
            sql = "Insert into "+foom.table + " ("+foom.foods_material_id+","+foom.foods_id+","+foom.material_id +
                ","+foom.order_id+","+foom.foods_name+","+foom.price +
                ","+foom.qty+","+foom.weight+") " +
                "Select foods_material_id, foods_id, material_id" +
                ","+ ordid + ", foods_name, price" +
                ",qty,weight " +
                "From b_foods_material " +
                "Where foods_id = '"+foodsid+"'" 
                ;
            

            return re;
        }
        public String voidFoodsMeterial(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + foom.table + " Set " +
                " " + foom.active + " = '3'" +
                "," + foom.date_cancel + " = now()" +
                "," + foom.user_modi + " = '" + userId + "' " +
                "Where " + foom.pkField + "='" + foosid + "'"
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
        public C1ComboBox setCboFoodsMaterial(C1ComboBox c)
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
                item.Text = row[foom.material_name].ToString();
                item.Value = row[foom.order_material_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoodsMaterial(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfootp.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (OrderMaterial row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.order_material_id;
                item.Text = row.material_name;
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
        private OrderMaterial setFoodsMaterial(DataTable dt)
        {
            OrderMaterial dept1 = new OrderMaterial();
            if (dt.Rows.Count > 0)
            {
                dept1.order_material_id = dt.Rows[0][foom.order_material_id].ToString();
                dept1.weight = dt.Rows[0][foom.weight].ToString();
                dept1.material_name = dt.Rows[0][foom.material_name].ToString();
                dept1.foods_id = dt.Rows[0][foom.foods_id] != null ? dt.Rows[0][foom.foods_id].ToString() : "";
                dept1.weight = dt.Rows[0][foom.weight] != null ? dt.Rows[0][foom.weight].ToString() : "";
                dept1.remark = dt.Rows[0][foom.remark] != null ? dt.Rows[0][foom.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foom.date_create] != null ? dt.Rows[0][foom.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foom.date_modi] != null ? dt.Rows[0][foom.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foom.date_cancel] != null ? dt.Rows[0][foom.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foom.user_create] != null ? dt.Rows[0][foom.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foom.user_modi] != null ? dt.Rows[0][foom.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foom.user_cancel] != null ? dt.Rows[0][foom.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foom.active] != null ? dt.Rows[0][foom.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][foom.sort1] != null ? dt.Rows[0][foom.sort1].ToString() : "";
                dept1.price = dt.Rows[0][foom.price] != null ? dt.Rows[0][foom.price].ToString() : "";
                dept1.qty = dt.Rows[0][foom.qty] != null ? dt.Rows[0][foom.qty].ToString() : "";
                dept1.material_id = dt.Rows[0][foom.material_id] != null ? dt.Rows[0][foom.material_id].ToString() : "";
                dept1.host_id = dt.Rows[0][foom.host_id] != null ? dt.Rows[0][foom.host_id].ToString() : "";
                dept1.device_id = dt.Rows[0][foom.device_id] != null ? dt.Rows[0][foom.device_id].ToString() : "";
                dept1.order_id = dt.Rows[0][foom.order_id] != null ? dt.Rows[0][foom.order_id].ToString() : "";
                dept1.foods_material_id = dt.Rows[0][foom.foods_material_id] != null ? dt.Rows[0][foom.foods_material_id].ToString() : "";
                dept1.foods_name = dt.Rows[0][foom.foods_name] != null ? dt.Rows[0][foom.foods_name].ToString() : "";
            }
            else
            {
                dept1.order_material_id = "";
                dept1.weight = "";
                dept1.material_name = "";
                dept1.foods_id = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
                dept1.price = "";
                dept1.host_id = "";
                dept1.branch_id = "";
                dept1.qty = "";
                dept1.device_id = "";
                dept1.material_id = "";
                dept1.order_id = "";
                dept1.foods_material_id = "";
                dept1.foods_name = "";
            }

            return dept1;
        }
    }
}
