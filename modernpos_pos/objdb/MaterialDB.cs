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
    public class MaterialDB
    {
        public Material mat;
        ConnectDB conn;
        public List<Material> lfootp;

        public MaterialDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<Material>();
            mat = new Material();
            mat.material_id = "material_id";
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
            mat.material_code = "material_code";
            mat.material_type_id = "material_type_id";
            mat.unit_id = "unit_id";
            mat.unit_cal_id = "unit_cal_id";
            mat.on_hand = "onhand";

            mat.pkField = "material_id";
            mat.table = "b_material";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + mat.table + " foos " +
                " " +
                "Where foos." + mat.active + " ='1' " +
                "Order By foos." + mat.material_id;
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
        public DataTable selectByFoodsId()
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + mat.material_id + ",foos." + mat.material_name + ",foos." + mat.price + ",foos." + mat.weight +
                " From " + mat.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where  foos." + mat.active + "='1' ";
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
        public Material selectByPk1(String copId)
        {
            Material cop1 = new Material();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + mat.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + mat.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setMaterial(dt);
            return cop1;
        }
        private Material setArea1(DataTable dt)
        {
            Material dept1 = new Material();
            if (dt.Rows.Count > 0)
            {
                dept1.material_id = dt.Rows[0][mat.material_id].ToString();
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
            String sql = "select footp." + mat.material_id + ",'' as img,footp." + mat.material_name + ",footp." + mat.price + ", footp." + mat.weight +
                " From " + mat.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + mat.weight + " ='" + copId + "' and footp." + mat.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<Material> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<Material> lfooC1 = new List<Material>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                Material itm1 = new Material();
                itm1.material_id = row[mat.material_id].ToString();
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
                Material itm1 = new Material();
                itm1.material_id = row[mat.material_id].ToString();
                itm1.material_name = row[mat.material_name].ToString();
                itm1.price = row[mat.price].ToString();
                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (Material sex in lfootp)
            {
                if (sex.material_id.Equals(id))
                {
                    re = sex.material_name;
                    break;
                }
            }
            return re;
        }
        public String getPriceById(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (Material sex in lfootp)
            {
                if (sex.material_id.Trim().Equals(id.Trim()))
                {
                    re = sex.price;
                    break;
                }
            }
            return re;
        }
        public String getMatridByName(String name)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (Material sex in lfootp)
            {
                if (sex.material_name.Trim().Equals(name.Trim()))
                {
                    re = sex.material_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(Material p)
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

            p.material_type_id = long.TryParse(p.material_type_id, out chk) ? chk.ToString() : "0";
            p.unit_cal_id = long.TryParse(p.unit_cal_id, out chk) ? chk.ToString() : "0";
            p.unit_id = long.TryParse(p.unit_id, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.weight = Decimal.TryParse(p.weight, out chk1) ? chk1.ToString() : "0";
            p.on_hand = Decimal.TryParse(p.on_hand, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(Material p, String userId)
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
                "," + mat.material_type_id + " = '" + p.material_type_id + "' " +
                "," + mat.material_code + " = '" + p.material_code + "' " +
                "," + mat.sort1 + " = '" + p.sort1 + "' " +
                "," + mat.unit_id + " = '" + p.unit_id + "' " +
                "," + mat.unit_cal_id + " = '" + p.unit_cal_id + "' " +                
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
        public String update(Material p, String userId)
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
                "," + mat.material_code + " = '" + p.material_code + "' " +
                "," + mat.material_type_id + " = '" + p.material_type_id + "' " +
                "," + mat.sort1 + " = '" + p.sort1 + "' " +
                "," + mat.unit_cal_id + " = '" + p.unit_cal_id + "' " +
                "," + mat.unit_id + " = '" + p.unit_id + "' " +
                "Where " + mat.pkField + "='" + p.material_id + "'"
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
        public String insertMaterial(Material p, String userId)
        {
            String re = "";

            if (p.material_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String genStock()
        {
            String re = "", sql = "";
            //DataTable dt = new DataTable();

            //sql = "UPDATE sequence SET lot_id=LAST_INSERT_ID("+seq.lot_id+"+1);";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_stock", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?drawid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                //cmd.Parameters["?drawid"].Direction = ParameterDirection.Input;
                //cmd.Parameters["?drawid"].Value = DateTime.;
                //cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                //re = (string)cmd.Parameters["?ret"].Value;

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
        public String genMaterialDraw(String matrid)
        {
            String re = "", sql = "";
            //DataTable dt = new DataTable();

            //sql = "UPDATE sequence SET lot_id=LAST_INSERT_ID("+seq.lot_id+"+1);";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_onhand_material_draw", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?drawid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                cmd.Parameters["?drawid"].Direction = ParameterDirection.Input;
                cmd.Parameters["?drawid"].Value = matrid;
                cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                re = (string)cmd.Parameters["?ret"].Value;

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
        public String genMaterialRec(String matrid)
        {
            String re = "", sql = "";
            //DataTable dt = new DataTable();

            //sql = "UPDATE sequence SET lot_id=LAST_INSERT_ID("+seq.lot_id+"+1);";
            try
            {
                MySqlCommand cmd = new MySqlCommand("gen_onhand_material_rec", conn.conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("?recid", MySqlDbType.Int32));
                cmd.Parameters.Add(new MySqlParameter("?ret", MySqlDbType.VarChar));
                cmd.Parameters["?recid"].Direction = ParameterDirection.Input;
                cmd.Parameters["?recid"].Value = matrid;
                cmd.Parameters["?ret"].Direction = ParameterDirection.Output;
                conn.conn.Open();
                cmd.ExecuteNonQuery();
                re = (string)cmd.Parameters["?ret"].Value;

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
        public String voidMeterial(String foosid, String userId)
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
        public C1ComboBox setCboMaterial(C1ComboBox c)
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
                item.Value = row[mat.material_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboMaterial(C1ComboBox c, String selected)
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
            foreach (Material row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.material_id;
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
        private Material setMaterial(DataTable dt)
        {
            Material dept1 = new Material();
            if (dt.Rows.Count > 0)
            {
                dept1.material_id = dt.Rows[0][mat.material_id].ToString();
                dept1.weight = dt.Rows[0][mat.weight].ToString();
                dept1.material_name = dt.Rows[0][mat.material_name].ToString();
                dept1.material_code = dt.Rows[0][mat.material_code] != null ? dt.Rows[0][mat.material_code].ToString() : "";
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
                dept1.material_type_id = dt.Rows[0][mat.material_type_id] != null ? dt.Rows[0][mat.material_type_id].ToString() : "";
                dept1.unit_cal_id = dt.Rows[0][mat.unit_cal_id] != null ? dt.Rows[0][mat.unit_cal_id].ToString() : "";
                dept1.unit_id = dt.Rows[0][mat.unit_id] != null ? dt.Rows[0][mat.unit_id].ToString() : "";
                dept1.on_hand = dt.Rows[0][mat.on_hand] != null ? dt.Rows[0][mat.on_hand].ToString() : "";
            }
            else
            {
                dept1.material_id = "";
                dept1.weight = "";
                dept1.material_name = "";
                dept1.material_code = "";
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
                dept1.weight = "";
                dept1.material_type_id = "";
                dept1.unit_id = "";
                dept1.unit_cal_id = "";
                dept1.on_hand = "";
            }

            return dept1;
        }
    }
}
