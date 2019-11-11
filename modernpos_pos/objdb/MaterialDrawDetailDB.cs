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
    public class MaterialDrawDetailDB
    {
        public MaterialDrawDetail matdd;
        ConnectDB conn;
        public List<MaterialDrawDetail> lfootp;

        public MaterialDrawDetailDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfootp = new List<MaterialDrawDetail>();
            matdd = new MaterialDrawDetail();
            matdd.matd_detail_id = "matd_detail_id";
            matdd.weight = "weight";
            matdd.matd_id = "matd_id";
            matdd.active = "active";
            matdd.remark = "remark";
            matdd.sort1 = "sort1";
            matdd.date_cancel = "date_cancel";
            matdd.date_create = "date_create";
            matdd.date_modi = "date_modi";
            matdd.user_cancel = "user_cancel";
            matdd.user_create = "user_create";
            matdd.user_modi = "user_modi";
            matdd.host_id = "host_id";
            matdd.branch_id = "branch_id";
            matdd.device_id = "device_id";
            matdd.price = "price";
            matdd.material_id = "material_id";
            matdd.qty = "qty";
            matdd.row1 = "row1";

            matdd.pkField = "matd_detail_id";
            matdd.table = "t_material_draw_detail";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + matdd.table + " foos " +
                " " +
                "Where foos." + matdd.active + " ='1' " +
                "Order By foos." + matdd.matd_detail_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + matdd.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + matdd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByMatrId(String matrId)
        {
            DataTable dt = new DataTable();
            String sql = "select matrd.* " +
               " From " + matdd.table + " matrd " +
                "Left Join t_material_draw matd On matd.matd_id = matrd.matd_id " +
                "Where matrd." + matdd.matd_id + " ='" + matrId + "' and matrd." + matdd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + matdd.weight + ",'' as img,foos." + matdd.matd_id + ",foos." + matdd.price +
                " From " + matdd.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + matdd.weight + " ='" + copId + "' and foos." + matdd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public MaterialDrawDetail selectByPk1(String copId)
        {
            MaterialDrawDetail cop1 = new MaterialDrawDetail();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + matdd.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + matdd.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setFoodsMaterial(dt);
            return cop1;
        }
        private MaterialDrawDetail setArea1(DataTable dt)
        {
            MaterialDrawDetail dept1 = new MaterialDrawDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.matd_detail_id = dt.Rows[0][matdd.matd_detail_id].ToString();
                dept1.matd_id = dt.Rows[0][matdd.matd_id].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + matdd.pkField + ",sex." + matdd.matd_id + " " +
                "From " + matdd.table + " sex " +
                " " +
                "Where sex." + matdd.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + matdd.matd_detail_id + ",'' as img,footp." + matdd.matd_id + ",footp." + matdd.price + ", footp." + matdd.weight +
                " From " + matdd.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + matdd.weight + " ='" + copId + "' and footp." + matdd.active + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<MaterialDrawDetail> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<MaterialDrawDetail> lfooC1 = new List<MaterialDrawDetail>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                MaterialDrawDetail itm1 = new MaterialDrawDetail();
                itm1.matd_detail_id = row[matdd.matd_detail_id].ToString();
                itm1.matd_id = row[matdd.matd_id].ToString();
                itm1.price = row[matdd.price].ToString();
                itm1.weight = row[matdd.weight].ToString();
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
                MaterialDrawDetail itm1 = new MaterialDrawDetail();
                itm1.matd_detail_id = row[matdd.matd_detail_id].ToString();
                itm1.matd_id = row[matdd.matd_id].ToString();

                lfootp.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfootp.Count <= 0) getlArea();
            foreach (MaterialDrawDetail sex in lfootp)
            {
                if (sex.matd_detail_id.Equals(id))
                {
                    re = sex.matd_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(MaterialDrawDetail p)
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

            p.matd_id = p.matd_id == null ? "" : p.matd_id;
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
        public String insert(MaterialDrawDetail p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + matdd.table + " set " +
                " " + matdd.weight + " = '" + p.weight + "'" +
                "," + matdd.matd_id + " = '" + p.matd_id.Replace("'", "''") + "'" +
                "," + matdd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matdd.date_create + " = now()" +
                "," + matdd.active + " = '1'" +
                "," + matdd.user_create + " = '" + userId + "' " +
                "," + matdd.host_id + " = '" + p.host_id + "' " +
                "," + matdd.branch_id + " = '" + p.branch_id + "' " +
                "," + matdd.device_id + " = '" + p.device_id + "' " +
                "," + matdd.price + " = '" + p.price + "' " +
                "," + matdd.sort1 + " = '" + p.sort1 + "' " +
                "," + matdd.qty + " = '" + p.qty + "' " +
                "," + matdd.material_id + " = '" + p.material_id + "' " +
                //"," + matrd.material_id + " = '" + p.material_id + "' " +
                "," + matdd.row1 + " = '" + p.row1 + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogFile("error insert " + this.ToString()+" " + ex.Message + " " + ex.InnerException);
            }

            return re;
        }
        public String update(MaterialDrawDetail p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + matdd.table + " Set " +
                " " + matdd.weight + " = '" + p.weight + "'" +
                "," + matdd.matd_id + " = '" + p.matd_id.Replace("'", "''") + "'" +
                "," + matdd.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matdd.date_modi + " = now()" +
                "," + matdd.user_modi + " = '" + userId + "' " +
                "," + matdd.host_id + " = '" + p.host_id + "' " +
                "," + matdd.branch_id + " = '" + p.branch_id + "' " +
                "," + matdd.device_id + " = '" + p.device_id + "' " +
                "," + matdd.price + " = '" + p.price + "' " +
                "," + matdd.material_id + " = '" + p.material_id + "' " +
                "," + matdd.qty + " = '" + p.qty + "' " +
                "," + matdd.sort1 + " = '" + p.sort1 + "' " +
                "," + matdd.material_id + " = '" + p.material_id + "' " +
                "," + matdd.row1 + " = '" + p.row1 + "' " +
                "Where " + matdd.pkField + "='" + p.matd_detail_id + "'"
                ;

            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogFile("error update "+ this.ToString()+" " + ex.Message  + " " + ex.InnerException);
            }

            return re;
        }
        public String insertMaterialDraw(MaterialDrawDetail p, String userId)
        {
            String re = "";

            if (p.matd_detail_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public String voidMeterialDraw(String foosid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + matdd.table + " Set " +
                " " + matdd.active + " = '3'" +
                "," + matdd.date_cancel + " = now()" +
                "," + matdd.user_modi + " = '" + userId + "' " +
                "Where " + matdd.pkField + "='" + foosid + "'"
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
        public String voidMatd(String matrid, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            sql = "Update " + matdd.table + " Set " +
                " " + matdd.active + " = '3'" +
                "," + matdd.date_cancel + " = now()" +
                "," + matdd.user_modi + " = '" + userId + "' " +
                "Where " + matdd.matd_id + "='" + matrid + "'"
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
                item.Text = row[matdd.matd_id].ToString();
                item.Value = row[matdd.matd_detail_id].ToString();

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
            foreach (MaterialDrawDetail row in lfootp)
            {
                item = new ComboBoxItem();
                item.Value = row.matd_detail_id;
                item.Text = row.matd_id;
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
        private MaterialDrawDetail setFoodsMaterial(DataTable dt)
        {
            MaterialDrawDetail dept1 = new MaterialDrawDetail();
            if (dt.Rows.Count > 0)
            {
                dept1.matd_detail_id = dt.Rows[0][matdd.matd_detail_id].ToString();
                dept1.weight = dt.Rows[0][matdd.weight].ToString();
                dept1.matd_id = dt.Rows[0][matdd.matd_id].ToString();
                dept1.material_id = dt.Rows[0][matdd.material_id] != null ? dt.Rows[0][matdd.material_id].ToString() : "";
                dept1.weight = dt.Rows[0][matdd.weight] != null ? dt.Rows[0][matdd.weight].ToString() : "";
                dept1.remark = dt.Rows[0][matdd.remark] != null ? dt.Rows[0][matdd.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][matdd.date_create] != null ? dt.Rows[0][matdd.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][matdd.date_modi] != null ? dt.Rows[0][matdd.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][matdd.date_cancel] != null ? dt.Rows[0][matdd.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][matdd.user_create] != null ? dt.Rows[0][matdd.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][matdd.user_modi] != null ? dt.Rows[0][matdd.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][matdd.user_cancel] != null ? dt.Rows[0][matdd.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][matdd.active] != null ? dt.Rows[0][matdd.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][matdd.sort1] != null ? dt.Rows[0][matdd.sort1].ToString() : "";
                dept1.price = dt.Rows[0][matdd.price] != null ? dt.Rows[0][matdd.price].ToString() : "";
                dept1.qty = dt.Rows[0][matdd.qty] != null ? dt.Rows[0][matdd.qty].ToString() : "";
                dept1.material_id = dt.Rows[0][matdd.material_id] != null ? dt.Rows[0][matdd.material_id].ToString() : "";
                dept1.host_id = dt.Rows[0][matdd.host_id] != null ? dt.Rows[0][matdd.host_id].ToString() : "";
                dept1.device_id = dt.Rows[0][matdd.device_id] != null ? dt.Rows[0][matdd.device_id].ToString() : "";
                dept1.row1 = dt.Rows[0][matdd.row1] != null ? dt.Rows[0][matdd.row1].ToString() : "";

            }
            else
            {
                dept1.matd_detail_id = "";
                dept1.weight = "";
                dept1.matd_id = "";
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
