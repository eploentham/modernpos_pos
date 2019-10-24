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
    public class MaterialRecDetailDB
    {
        public MaterialRecDetail matrd;
        ConnectDB conn;
        public List<MaterialRecDetail> lfootp;

        public MaterialRecDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<MaterialRecDetail>();
            matrd = new MaterialRecDetail();
            matrd.matr_detail_id = "matr_detail_id";
            matrd.weight = "weight";
            matrd.matr_id = "matr_id";
            matrd.active = "active";
            matrd.remark = "remark";
            matrd.sort1 = "sort1";
            matrd.date_cancel = "date_cancel";
            matrd.date_create = "date_create";
            matrd.date_modi = "date_modi";
            matrd.user_cancel = "user_cancel";
            matrd.user_create = "user_create";
            matrd.user_modi = "user_modi";
            matrd.host_id = "host_id";
            matrd.branch_id = "branch_id";
            matrd.device_id = "device_id";
            matrd.price = "price";
            matrd.material_id = "material_id";
            matrd.qty = "qty";
            matrd.row1 = "row1";

            matrd.pkField = "matr_detail_id";
            matrd.table = "t_material_rec_detail";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + matrd.table + " foos " +
                " " +
                "Where foos." + matrd.active + " ='1' " +
                "Order By foos." + matrd.matr_detail_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + matrd.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + matrd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByMatrId(String matrId)
        {
            DataTable dt = new DataTable();
            String sql = "select matrd.* " + 
               " From " + matrd.table + " matrd " +
                "Left Join t_material_rec matr On matr.matr_id = matrd.matr_id " +
                "Where matrd." + matrd.matr_id + " ='" + matrId + "' and matrd." + matrd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + matrd.weight + ",'' as img,foos." + matrd.matr_id + ",foos." + matrd.price +
                " From " + matrd.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + matrd.weight + " ='" + copId + "' and foos." + matrd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public MaterialRecDetail selectByPk1(String copId)
        {
            MaterialRecDetail cop1 = new MaterialRecDetail();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + matrd.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + matrd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsMaterial(dt);
            return cop1;
        }
        private MaterialRecDetail setArea1(DataTable dt)
        {
            MaterialRecDetail dept1 = new MaterialRecDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.matr_detail_id = dt.Rows[0][matrd.matr_detail_id].ToString();
                dept1.matr_id = dt.Rows[0][matrd.matr_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + matrd.pkField + ",sex." + matrd.matr_id + " " +
                "From " + matrd.table + " sex " +
                " " +
                "Where sex." + matrd.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + matrd.matr_detail_id + ",'' as img,footp." + matrd.matr_id + ",footp." + matrd.price + ", footp." + matrd.weight +
                " From " + matrd.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + matrd.weight + " ='" + copId + "' and footp." + matrd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<MaterialRecDetail> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<MaterialRecDetail> lfooC1 = new List<MaterialRecDetail>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                MaterialRecDetail itm1 = new MaterialRecDetail();
                itm1.matr_detail_id = row[matrd.matr_detail_id].ToString();
                itm1.matr_id = row[matrd.matr_id].ToString();
                itm1.price = row[matrd.price].ToString();
                itm1.weight = row[matrd.weight].ToString();
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
                MaterialRecDetail itm1 = new MaterialRecDetail();
                itm1.matr_detail_id = row[matrd.matr_detail_id].ToString();
                itm1.matr_id = row[matrd.matr_id].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (MaterialRecDetail sex in lfootp)
            {
                if (sex.matr_detail_id.Equals(id))
                {
                    re = sex.matr_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(MaterialRecDetail p)
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

            p.matr_id = p.matr_id == null ? "" : p.matr_id;
            p.weight = p.weight == null ? "" : p.weight;

            p.remark = p.remark == null ? "" : p.remark;

            p.material_id = long.TryParse(p.material_id, out chk) ? chk.ToString() : "0";
            p.material_id = long.TryParse(p.material_id, out chk) ? chk.ToString() : "0";
            p.sort1 = long.TryParse(p.sort1, out chk) ? chk.ToString() : "999999999";
            p.row1 = long.TryParse(p.row1, out chk) ? chk.ToString() : "9999";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.weight = Decimal.TryParse(p.weight, out chk1) ? chk1.ToString() : "0";
            p.qty = Decimal.TryParse(p.qty, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(MaterialRecDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + matrd.table + " set " +
                " " + matrd.weight + " = '" + p.weight + "'" +
                "," + matrd.matr_id + " = '" + p.matr_id.Replace("'", "''") + "'" +
                "," + matrd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matrd.date_create + " = now()" +
                "," + matrd.active + " = '1'" +
                "," + matrd.user_create + " = '" + userId + "' " +
                "," + matrd.host_id + " = '" + p.host_id + "' " +
                "," + matrd.branch_id + " = '" + p.branch_id + "' " +
                "," + matrd.device_id + " = '" + p.device_id + "' " +
                "," + matrd.price + " = '" + p.price + "' " +
                "," + matrd.sort1 + " = '" + p.sort1 + "' " +
                "," + matrd.qty + " = '" + p.qty + "' " +
                "," + matrd.material_id + " = '" + p.material_id + "' " +
                //"," + matrd.material_id + " = '" + p.material_id + "' " +
                "," + matrd.row1 + " = '" + p.row1 + "' " +
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
        public String update(MaterialRecDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + matrd.table + " Set " +
                " " + matrd.weight + " = '" + p.weight + "'" +
                "," + matrd.matr_id + " = '" + p.matr_id.Replace("'", "''") + "'" +
                "," + matrd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matrd.date_modi + " = now()" +
                "," + matrd.user_modi + " = '" + userId + "' " +
                "," + matrd.host_id + " = '" + p.host_id + "' " +
                "," + matrd.branch_id + " = '" + p.branch_id + "' " +
                "," + matrd.device_id + " = '" + p.device_id + "' " +
                "," + matrd.price + " = '" + p.price + "' " +
                "," + matrd.material_id + " = '" + p.material_id + "' " +
                "," + matrd.qty + " = '" + p.qty + "' " +
                "," + matrd.sort1 + " = '" + p.sort1 + "' " +
                "," + matrd.material_id + " = '" + p.material_id + "' " +
                "," + matrd.row1 + " = '" + p.row1 + "' " +
                "Where " + matrd.pkField + "='" + p.matr_detail_id + "'"
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
        public String insertFoodsMaterial(MaterialRecDetail p, String userId)
        {
            String re = "";

            if (p.matr_detail_id.Equals(""))
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

            sql = "Update " + matrd.table + " Set " +
                " " + matrd.active + " = '3'" +
                "," + matrd.date_cancel + " = now()" +
                "," + matrd.user_modi + " = '" + userId + "' " +
                "Where " + matrd.pkField + "='" + foosid + "'"
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
                item.Text = row[matrd.matr_id].ToString();
                item.Value = row[matrd.matr_detail_id].ToString();

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
            foreach (MaterialRecDetail row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.matr_detail_id;
                item.Text = row.matr_id;
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
        private MaterialRecDetail setFoodsMaterial(DataTable dt)
        {
            MaterialRecDetail dept1 = new MaterialRecDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.matr_detail_id = dt.Rows[0][matrd.matr_detail_id].ToString();
                dept1.weight = dt.Rows[0][matrd.weight].ToString();
                dept1.matr_id = dt.Rows[0][matrd.matr_id].ToString();
                dept1.material_id = dt.Rows[0][matrd.material_id] != null ? dt.Rows[0][matrd.material_id].ToString() : "";
                dept1.weight = dt.Rows[0][matrd.weight] != null ? dt.Rows[0][matrd.weight].ToString() : "";
                dept1.remark = dt.Rows[0][matrd.remark] != null ? dt.Rows[0][matrd.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][matrd.date_create] != null ? dt.Rows[0][matrd.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][matrd.date_modi] != null ? dt.Rows[0][matrd.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][matrd.date_cancel] != null ? dt.Rows[0][matrd.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][matrd.user_create] != null ? dt.Rows[0][matrd.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][matrd.user_modi] != null ? dt.Rows[0][matrd.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][matrd.user_cancel] != null ? dt.Rows[0][matrd.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][matrd.active] != null ? dt.Rows[0][matrd.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][matrd.sort1] != null ? dt.Rows[0][matrd.sort1].ToString() : "";
                dept1.price = dt.Rows[0][matrd.price] != null ? dt.Rows[0][matrd.price].ToString() : "";
                dept1.qty = dt.Rows[0][matrd.qty] != null ? dt.Rows[0][matrd.qty].ToString() : "";
                dept1.material_id = dt.Rows[0][matrd.material_id] != null ? dt.Rows[0][matrd.material_id].ToString() : "";
                dept1.host_id = dt.Rows[0][matrd.host_id] != null ? dt.Rows[0][matrd.host_id].ToString() : "";
                dept1.device_id = dt.Rows[0][matrd.device_id] != null ? dt.Rows[0][matrd.device_id].ToString() : "";
                dept1.row1 = dt.Rows[0][matrd.row1] != null ? dt.Rows[0][matrd.row1].ToString() : "";

            }
            else
            {
                dept1.matr_detail_id = "";
                dept1.weight = "";
                dept1.matr_id = "";
                dept1.material_id = "";
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
                dept1.row1 = "";
            }

            return dept1;
        }
    }
}
