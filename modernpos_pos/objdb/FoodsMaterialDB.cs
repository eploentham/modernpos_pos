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
    public class FoodsMaterialDB
    {
        public FoodsMaterial mat;
        ConnectDB conn;
        public List<FoodsMaterial> lfootp;

        public FoodsMaterialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<FoodsMaterial>();
            mat = new FoodsMaterial();
            mat.foods_material_id = "foods_material_id";
            mat.weight = "weight";
            mat.material_name = "material_name";
            mat.active = "active";
            mat.remark = "remark";
            mat.sort1 = "sort1";
            mat.date_cancel = "date_cancel";
            mat.date_create = "date_create";
            mat.date_modi = "date_modi";
            mat.user_cancel = "user_cancel";
            mat.user_create = "user_create";
            mat.user_modi = "user_modi";
            mat.host_id = "host_id";
            mat.branch_id = "branch_id";
            mat.device_id = "device_id";
            mat.price = "price";
            mat.foods_id = "foods_id";
            mat.qty = "qty";
            mat.material_id = "material_id";

            mat.pkField = "foods_material_id";
            mat.table = "b_foods_material";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + mat.table + " foos " +
                " " +
                "Where foos." + mat.active + " ='1' " +
                "Order By foos." + mat.foods_material_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + mat.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + mat.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + mat.foods_material_id + ",foos." + mat.material_name + ",foos." + mat.price+ ",foos." + mat.qty + ",foos." + mat.weight +
               " From " + mat.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + mat.foods_id + " ='" + copId + "' and foos." + mat.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + mat.weight + ",'' as img,foos." + mat.material_name + ",foos." + mat.price +
                " From " + mat.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + mat.weight + " ='" + copId + "' and foos." + mat.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsMaterial selectByPk1(String copId)
        {
            FoodsMaterial cop1 = new FoodsMaterial();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + mat.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + mat.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsMaterial(dt);
            return cop1;
        }
        private FoodsMaterial setArea1(DataTable dt)
        {
            FoodsMaterial dept1 = new FoodsMaterial();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_material_id = dt.Rows[0][mat.foods_material_id].ToString();
                dept1.material_name = dt.Rows[0][mat.material_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + mat.pkField + ",sex." + mat.material_name + " " +
                "From " + mat.table + " sex " +
                " " +
                "Where sex." + mat.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + mat.foods_material_id + ",'' as img,footp." + mat.material_name + ",footp." + mat.price + ", footp." + mat.weight +
                " From " + mat.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + mat.weight + " ='" + copId + "' and footp." + mat.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<FoodsMaterial> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<FoodsMaterial> lfooC1 = new List<FoodsMaterial>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                FoodsMaterial itm1 = new FoodsMaterial();
                itm1.foods_material_id = row[mat.foods_material_id].ToString();
                itm1.material_name = row[mat.material_name].ToString();
                itm1.price = row[mat.price].ToString();
                itm1.weight = row[mat.weight].ToString();
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
                FoodsMaterial itm1 = new FoodsMaterial();
                itm1.foods_material_id = row[mat.foods_material_id].ToString();
                itm1.material_name = row[mat.material_name].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (FoodsMaterial sex in lfootp)
            {
                if (sex.foods_material_id.Equals(id))
                {
                    re = sex.material_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(FoodsMaterial p)
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
            p.sort1 = long.TryParse(p.sort1, out chk) ? chk.ToString() : "999999999";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.weight = Decimal.TryParse(p.weight, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(FoodsMaterial p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + mat.table + " set " +
                " " + mat.weight + " = '" + p.weight + "'" +
                "," + mat.material_name + " = '" + p.material_name.Replace("'", "''") + "'" +
                "," + mat.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + mat.date_create + " = now()" +
                "," + mat.active + " = '1'" +
                "," + mat.user_create + " = '" + userId + "' " +
                "," + mat.host_id + " = '" + p.host_id + "' " +
                "," + mat.branch_id + " = '" + p.branch_id + "' " +
                "," + mat.device_id + " = '" + p.device_id + "' " +
                "," + mat.price + " = '" + p.price + "' " +
                "," + mat.sort1 + " = '" + p.sort1 + "' " +
                "," + mat.qty + " = '" + p.qty + "' " +
                "," + mat.material_id + " = '" + p.material_id + "' " +
                "," + mat.foods_id + " = '" + p.foods_id + "' " +
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
        public String update(FoodsMaterial p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + mat.table + " Set " +
                " " + mat.weight + " = '" + p.weight + "'" +
                "," + mat.material_name + " = '" + p.material_name.Replace("'", "''") + "'" +
                "," + mat.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + mat.date_modi + " = now()" +
                "," + mat.user_modi + " = '" + userId + "' " +
                "," + mat.host_id + " = '" + p.host_id + "' " +
                "," + mat.branch_id + " = '" + p.branch_id + "' " +
                "," + mat.device_id + " = '" + p.device_id + "' " +
                "," + mat.price + " = '" + p.price + "' " +
                "," + mat.foods_id + " = '" + p.foods_id + "' " +
                "," + mat.qty + " = '" + p.qty + "' " +
                "," + mat.sort1 + " = '" + p.sort1 + "' " +
                "," + mat.material_id + " = '" + p.material_id + "' " +
                "Where " + mat.pkField + "='" + p.foods_material_id + "'"
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
        public String insertFoodsMaterial(FoodsMaterial p, String userId)
        {
            String re = "";

            if (p.foods_material_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidFoodsMeterial(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + mat.table + " Set " +
                " " + mat.active + " = '3'" +
                "," + mat.date_cancel + " = now()" +
                "," + mat.user_modi + " = '" + userId + "' " +
                "Where " + mat.pkField + "='" + foosid + "'"
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
                item.Text = row[mat.material_name].ToString();
                item.Value = row[mat.foods_material_id].ToString();

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
            foreach (FoodsMaterial row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.foods_material_id;
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
        private FoodsMaterial setFoodsMaterial(DataTable dt)
        {
            FoodsMaterial dept1 = new FoodsMaterial();
            if (dt.Rows.Count > 0)
            {
                dept1.foods_material_id = dt.Rows[0][mat.foods_material_id].ToString();
                dept1.weight = dt.Rows[0][mat.weight].ToString();
                dept1.material_name = dt.Rows[0][mat.material_name].ToString();
                dept1.foods_id = dt.Rows[0][mat.foods_id] != null ? dt.Rows[0][mat.foods_id].ToString() : "";
                dept1.weight = dt.Rows[0][mat.weight] != null ? dt.Rows[0][mat.weight].ToString() : "";
                dept1.remark = dt.Rows[0][mat.remark] != null ? dt.Rows[0][mat.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][mat.date_create] != null ? dt.Rows[0][mat.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][mat.date_modi] != null ? dt.Rows[0][mat.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][mat.date_cancel] != null ? dt.Rows[0][mat.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][mat.user_create] != null ? dt.Rows[0][mat.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][mat.user_modi] != null ? dt.Rows[0][mat.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][mat.user_cancel] != null ? dt.Rows[0][mat.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][mat.active] != null ? dt.Rows[0][mat.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][mat.sort1] != null ? dt.Rows[0][mat.sort1].ToString() : "";
                dept1.price = dt.Rows[0][mat.price] != null ? dt.Rows[0][mat.price].ToString() : "";
                dept1.qty = dt.Rows[0][mat.qty] != null ? dt.Rows[0][mat.qty].ToString() : "";
                dept1.material_id = dt.Rows[0][mat.material_id] != null ? dt.Rows[0][mat.material_id].ToString() : "";
                dept1.host_id = dt.Rows[0][mat.host_id] != null ? dt.Rows[0][mat.host_id].ToString() : "";
                dept1.device_id = dt.Rows[0][mat.device_id] != null ? dt.Rows[0][mat.device_id].ToString() : "";

            }
            else
            {
                dept1.foods_material_id = "";
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
            }

            return dept1;
        }
    }
}
