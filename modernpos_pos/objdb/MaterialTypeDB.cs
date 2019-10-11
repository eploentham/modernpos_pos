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
    public class MaterialTypeDB
    {
        public MaterialType matt;
        ConnectDB conn;
        public List<MaterialType> lfootp;

        public MaterialTypeDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<MaterialType>();
            matt = new MaterialType();
            matt.material_type_id = "material_type_id";
            matt.material_type_name = "material_type_name";
            matt.active = "active";
            matt.remark = "remark";
            matt.sort1 = "sort1";
            matt.date_cancel = "date_cancel";
            matt.date_create = "date_create";
            matt.date_modi = "date_modi";
            matt.user_cancel = "user_cancel";
            matt.user_create = "user_create";
            matt.user_modi = "user_modi";
            matt.host_id = "host_id";
            matt.branch_id = "branch_id";
            matt.device_id = "device_id";
            matt.material_type_code = "material_type_code";

            matt.pkField = "material_type_id";
            matt.table = "b_material_type";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + matt.table + " foos " +
                " " +
                "Where foos." + matt.active + " ='1' " +
                "Order By foos." + matt.material_type_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + matt.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + matt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public MaterialType selectByPk1(String copId)
        {
            MaterialType cop1 = new MaterialType();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + matt.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + matt.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsMaterial(dt);
            return cop1;
        }
        private MaterialType setArea1(DataTable dt)
        {
            MaterialType dept1 = new MaterialType();
            if (dt.Rows.Count > 0)
            {
                dept1.material_type_id = dt.Rows[0][matt.material_type_id].ToString();
                dept1.material_type_name = dt.Rows[0][matt.material_type_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + matt.pkField + ",sex." + matt.material_type_name + " " +
                "From " + matt.table + " sex " +
                " " +
                "Where sex." + matt.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lfootp.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                MaterialType itm1 = new MaterialType();
                itm1.material_type_id = row[matt.material_type_id].ToString();
                itm1.material_type_name = row[matt.material_type_name].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (MaterialType sex in lfootp)
            {
                if (sex.material_type_id.Equals(id))
                {
                    re = sex.material_type_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(MaterialType p)
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

            p.material_type_name = p.material_type_name == null ? "" : p.material_type_name;
            p.material_type_code = p.material_type_code == null ? "" : p.material_type_code;

            p.remark = p.remark == null ? "" : p.remark;

            //p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            //p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            //p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

            //p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            //p.weight = Decimal.TryParse(p.weight, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(MaterialType p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + matt.table + " set " +                
                " " + matt.material_type_name + " = '" + p.material_type_name.Replace("'", "''") + "'" +
                "," + matt.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matt.date_create + " = now()" +
                "," + matt.active + " = '1'" +
                "," + matt.user_create + " = '" + userId + "' " +
                "," + matt.host_id + " = '" + p.host_id + "' " +
                "," + matt.branch_id + " = '" + p.branch_id + "' " +
                "," + matt.device_id + " = '" + p.device_id + "' " +
                "," + matt.material_type_code + " = '" + p.material_type_code + "' " +
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
        public String update(MaterialType p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + matt.table + " Set " +
                " " + matt.material_type_name + " = '" + p.material_type_name.Replace("'", "''") + "'" +
                "," + matt.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matt.date_modi + " = now()" +
                "," + matt.user_modi + " = '" + userId + "' " +
                "," + matt.host_id + " = '" + p.host_id + "' " +
                "," + matt.branch_id + " = '" + p.branch_id + "' " +
                "," + matt.device_id + " = '" + p.device_id + "' " +
                "," + matt.material_type_code + " = '" + p.material_type_code + "' " +
                "Where " + matt.pkField + "='" + p.material_type_id + "'"
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
        public String insertFoodsMaterial(MaterialType p, String userId)
        {
            String re = "";

            if (p.material_type_id.Equals(""))
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

            sql = "Update " + matt.table + " Set " +
                " " + matt.active + " = '3'" +
                "," + matt.date_cancel + " = now()" +
                "," + matt.user_modi + " = '" + userId + "' " +
                "Where " + matt.pkField + "='" + foosid + "'"
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
                item.Text = row[matt.material_type_name].ToString();
                item.Value = row[matt.material_type_id].ToString();

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
            foreach (MaterialType row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.material_type_id;
                item.Text = row.material_type_name;
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
        private MaterialType setFoodsMaterial(DataTable dt)
        {
            MaterialType dept1 = new MaterialType();
            if (dt.Rows.Count > 0)
            {
                dept1.material_type_id = dt.Rows[0][matt.material_type_id].ToString();
                dept1.material_type_name = dt.Rows[0][matt.material_type_name].ToString();
                dept1.material_type_code = dt.Rows[0][matt.material_type_code] != null ? dt.Rows[0][matt.material_type_code].ToString() : "";
                dept1.remark = dt.Rows[0][matt.remark] != null ? dt.Rows[0][matt.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][matt.date_create] != null ? dt.Rows[0][matt.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][matt.date_modi] != null ? dt.Rows[0][matt.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][matt.date_cancel] != null ? dt.Rows[0][matt.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][matt.user_create] != null ? dt.Rows[0][matt.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][matt.user_modi] != null ? dt.Rows[0][matt.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][matt.user_cancel] != null ? dt.Rows[0][matt.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][matt.active] != null ? dt.Rows[0][matt.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][matt.sort1] != null ? dt.Rows[0][matt.sort1].ToString() : "";
            }
            else
            {
                dept1.material_type_id = "";
                dept1.material_type_name = "";
                dept1.material_type_code = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.active = "";
                dept1.sort1 = "";
            }

            return dept1;
        }
    }
}
