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
    public class FoodsToppingDB
    {
        public FoodsTopping footp;
        ConnectDB conn;
        public List<FoodsTopping> lfootp;

        public FoodsToppingDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<FoodsTopping>();
            footp = new FoodsTopping();
            footp.foods_topping_id = "foods_topping_id";
            footp.foods_id = "foods_id";
            footp.foods_topping_name = "foods_topping_name";
            footp.active = "active";
            footp.remark = "remark";
            footp.sort1 = "sort1";
            footp.date_cancel = "date_cancel";
            footp.date_create = "date_create";
            footp.date_modi = "date_modi";
            footp.user_cancel = "user_cancel";
            footp.user_create = "user_create";
            footp.user_modi = "user_modi";
            footp.host_id = "host_id";
            footp.branch_id = "branch_id";
            footp.device_id = "device_id";
            footp.price = "price";

            footp.pkField = "foods_topping_id";
            footp.table = "b_foods_topping";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + footp.table + " foos " +
                " " +
                "Where foos." + footp.active + " ='1' " +
                "Order By foos." + footp.foods_topping_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + footp.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + footp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + footp.foods_id + ",foos." + footp.foods_topping_name + ",foos." + footp.price +
                " From " + footp.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + footp.foods_id + " ='" + copId + "' and foos." + footp.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + footp.foods_id + ",'' as img,foos." + footp.foods_topping_name + ",foos." + footp.price +
                " From " + footp.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + footp.foods_id + " ='" + copId + "' and foos." + footp.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsTopping selectByPk1(String copId)
        {
            FoodsTopping cop1 = new FoodsTopping();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + footp.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + footp.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsTopping(dt);
            return cop1;
        }
        private FoodsTopping setArea1(DataTable dt)
        {
            FoodsTopping dept1 = new FoodsTopping();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_topping_id = dt.Rows[0][footp.foods_topping_id].ToString();
                dept1.foods_topping_name = dt.Rows[0][footp.foods_topping_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + footp.pkField + ",sex." + footp.foods_topping_name + " " +
                "From " + footp.table + " sex " +
                " " +
                "Where sex." + footp.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + footp.foods_topping_id + ",'' as img,footp." + footp.foods_topping_name + ",footp." + footp.price +
                " From " + footp.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + footp.foods_id + " ='" + copId + "' and footp." + footp.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<FoodsTopping> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<FoodsTopping> lfooC1 = new List<FoodsTopping>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                FoodsTopping itm1 = new FoodsTopping();
                itm1.foods_topping_id = row[footp.foods_topping_id].ToString();
                itm1.foods_topping_name = row[footp.foods_topping_name].ToString();
                itm1.price = row[footp.price].ToString();
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
                FoodsTopping itm1 = new FoodsTopping();
                itm1.foods_topping_id = row[footp.foods_topping_id].ToString();
                itm1.foods_topping_name = row[footp.foods_topping_name].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (FoodsTopping sex in lfootp)
            {
                if (sex.foods_topping_id.Equals(id))
                {
                    re = sex.foods_topping_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(FoodsTopping p)
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

            p.foods_topping_name = p.foods_topping_name == null ? "" : p.foods_topping_name;
            p.foods_id = p.foods_id == null ? "" : p.foods_id;

            p.remark = p.remark == null ? "" : p.remark;

            //p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            //p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            //p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(FoodsTopping p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + footp.table + " set " +
                " " + footp.foods_id + " = '" + p.foods_id + "'" +
                "," + footp.foods_topping_name + " = '" + p.foods_topping_name.Replace("'", "''") + "'" +
                "," + footp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + footp.date_create + " = now()" +
                "," + footp.active + " = '1'" +
                "," + footp.user_create + " = '" + userId + "' " +
                "," + footp.host_id + " = '" + p.host_id + "' " +
                "," + footp.branch_id + " = '" + p.branch_id + "' " +
                "," + footp.device_id + " = '" + p.device_id + "' " +
                "," + footp.price + " = '" + p.price + "' " +
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
        public String update(FoodsTopping p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + footp.table + " Set " +
                " " + footp.foods_id + " = '" + p.foods_id + "'" +
                "," + footp.foods_topping_name + " = '" + p.foods_topping_name.Replace("'", "''") + "'" +
                "," + footp.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + footp.date_modi + " = now()" +
                "," + footp.user_modi + " = '" + userId + "' " +
                "," + footp.host_id + " = '" + p.host_id + "' " +
                "," + footp.branch_id + " = '" + p.branch_id + "' " +
                "," + footp.device_id + " = '" + p.device_id + "' " +
                "," + footp.price + " = '" + p.price + "' " +

                "Where " + footp.pkField + "='" + p.foods_topping_id + "'"
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
        public String insertFoodsTopping(FoodsTopping p, String userId)
        {
            String re = "";

            if (p.foods_topping_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidFoodsTopping(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + footp.table + " Set " +
                " " + footp.active + " = '3'" +
                "," + footp.date_cancel + " = now()" +
                "," + footp.user_modi + " = '" + userId + "' " +
                "Where " + footp.pkField + "='" + foosid + "'"
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
        public C1ComboBox setCboFoodsTopping(C1ComboBox c)
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
                item.Text = row[footp.foods_topping_name].ToString();
                item.Value = row[footp.foods_topping_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboFoodsTopping(C1ComboBox c, String selected)
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
            foreach (FoodsTopping row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_topping_id;
                item.Text = row.foods_topping_name;
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
        private FoodsTopping setFoodsTopping(DataTable dt)
        {
            FoodsTopping dept1 = new FoodsTopping();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_topping_id = dt.Rows[0][footp.foods_topping_id].ToString();
                dept1.foods_id = dt.Rows[0][footp.foods_id].ToString();
                dept1.foods_topping_name = dt.Rows[0][footp.foods_topping_name].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][footp.remark] != null ? dt.Rows[0][footp.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][footp.date_create] != null ? dt.Rows[0][footp.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][footp.date_modi] != null ? dt.Rows[0][footp.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][footp.date_cancel] != null ? dt.Rows[0][footp.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][footp.user_create] != null ? dt.Rows[0][footp.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][footp.user_modi] != null ? dt.Rows[0][footp.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][footp.user_cancel] != null ? dt.Rows[0][footp.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][footp.active] != null ? dt.Rows[0][footp.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][footp.sort1] != null ? dt.Rows[0][footp.sort1].ToString() : "";
                dept1.price = dt.Rows[0][footp.price] != null ? dt.Rows[0][footp.price].ToString() : "";
            }
            else
            {
                dept1.foods_topping_id = "";
                dept1.foods_id = "";
                dept1.foods_topping_name = "";
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
                dept1.price = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
