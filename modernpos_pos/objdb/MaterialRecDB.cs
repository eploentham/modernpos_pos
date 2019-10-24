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
    public class MaterialRecDB
    {
        public MaterialRec matr;
        ConnectDB conn;
        public List<MaterialRec> lfooT;
        public MaterialRecDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lfooT = new List<MaterialRec>();
            matr = new MaterialRec();
            matr.matr_id = "matr_id";
            matr.matr_code = "matr_code";
            matr.matr_date = "matr_date";
            matr.active = "active";
            matr.remark = "remark";
            matr.sort1 = "sort1";
            matr.date_cancel = "date_cancel";
            matr.date_create = "date_create";
            matr.date_modi = "date_modi";
            matr.user_cancel = "user_cancel";
            matr.user_create = "user_create";
            matr.user_modi = "user_modi";
            matr.host_id = "host_id";
            matr.branch_id = "branch_id";
            matr.device_id = "device_id";
            matr.year_id = "year_id";

            matr.pkField = "matr_id";
            matr.table = "t_material_rec";
        }
        public DataTable selectByYearId(String yearid)
        {
            DataTable dt = new DataTable();
            String sql = "select matr.*  " +
                "From " + matr.table + " matr " +
                " " +
                "Where matr." + matr.active + " ='1' and matr."+matr.year_id + "='"+yearid+"'";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select matr.*  " +
                "From " + matr.table + " matr " +
                " " +
                "Where matr." + matr.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + matr.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + matr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public MaterialRec selectByPk1(String copId)
        {
            MaterialRec cop1 = new MaterialRec();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + matr.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + matr.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTMaterial(dt);
            return cop1;
        }
        private MaterialRec setArea1(DataTable dt)
        {
            MaterialRec dept1 = new MaterialRec();
            if (dt.Rows.Count > 0)
            {
                dept1.matr_id = dt.Rows[0][matr.matr_id].ToString();
                dept1.matr_date = dt.Rows[0][matr.matr_date].ToString();
            }

            return dept1;
        }
        
        public void getlArea()
        {
            //lDept = new List<Position>();
            lfooT.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                MaterialRec itm1 = new MaterialRec();
                itm1.matr_id = row[matr.matr_id].ToString();
                itm1.matr_date = row[matr.matr_date].ToString();

                lfooT.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lfooT.Count <= 0) getlArea();
            foreach (MaterialRec sex in lfooT)
            {
                if (sex.matr_id.Equals(id))
                {
                    re = sex.matr_date;
                    break;
                }
            }
            return re;
        }
        private void chkNull(MaterialRec p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.matr_date = p.matr_date == null ? "" : p.matr_date;
            p.matr_code = p.matr_code == null ? "" : p.matr_code;

            p.year_id = p.year_id == null ? "" : p.year_id;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(MaterialRec p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + matr.table + " set " +
                " " + matr.matr_code + " = '" + p.matr_code + "'" +
                "," + matr.matr_date + " = '" + p.matr_date.Replace("'", "''") + "'" +
                "," + matr.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matr.date_create + " = now()" +
                "," + matr.active + " = '1'" +
                "," + matr.user_create + " = '" + userId + "' " +
                "," + matr.host_id + " = '" + p.host_id + "' " +
                "," + matr.branch_id + " = '" + p.branch_id + "' " +
                "," + matr.device_id + " = '" + p.device_id + "' " +
                "," + matr.year_id + " = year() " +
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
        public String update(MaterialRec p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + matr.table + " Set " +
                " " + matr.matr_code + " = '" + p.matr_code + "'" +
                "," + matr.matr_date + " = '" + p.matr_date.Replace("'", "''") + "'" +
                "," + matr.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + matr.date_modi + " = now()" +
                "," + matr.user_modi + " = '" + userId + "' " +
                "," + matr.host_id + " = '" + p.host_id + "' " +
                "," + matr.branch_id + " = '" + p.branch_id + "' " +
                "," + matr.device_id + " = '" + p.device_id + "' " +
                //"," + fooC.status_aircondition + " = '" + p.status_aircondition + "' " +

                "Where " + matr.pkField + "='" + p.matr_id + "'"
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
        public String insertTMatarial(MaterialRec p, String userId)
        {
            String re = "";

            if (p.matr_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public DataTable selectYear()
        {
            DataTable dt = new DataTable();
            String sql = "select matr." + matr.year_id + " " +
                "From " + matr.table + " matr " +
                " " +
                "Where matr." + matr.active + " ='1' " +
                "Group By "+matr.year_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public C1ComboBox setCboYear(C1ComboBox c)
        {
            ComboBoxItem item = new ComboBoxItem();
            DataTable dt = selectYear();
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
                item.Text = row[matr.year_id].ToString();
                item.Value = row[matr.year_id].ToString();

                c.Items.Add(item);
            }
            if (c.Items.Count > 0)
            {
                c.SelectedIndex = 1;
            }
            return c;
        }
        public C1ComboBox setCboFoodsType(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lfooT.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (MaterialRec row in lfooT)
            {
                item = new ComboBoxItem();
                item.Value = row.matr_id;
                item.Text = row.matr_date;
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
        private MaterialRec setTMaterial(DataTable dt)
        {
            MaterialRec dept1 = new MaterialRec();
            if (dt.Rows.Count > 0)
            {
                dept1.matr_id = dt.Rows[0][matr.matr_id].ToString();
                dept1.matr_code = dt.Rows[0][matr.matr_code].ToString();
                dept1.matr_date = dt.Rows[0][matr.matr_date].ToString();
                //dept1.posi_name_e = dt.Rows[0][area.posi_name_e] != null ? dt.Rows[0][area.posi_name_e].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][matr.remark] != null ? dt.Rows[0][matr.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][matr.date_create] != null ? dt.Rows[0][matr.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][matr.date_modi] != null ? dt.Rows[0][matr.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][matr.date_cancel] != null ? dt.Rows[0][matr.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][matr.user_create] != null ? dt.Rows[0][matr.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][matr.user_modi] != null ? dt.Rows[0][matr.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][matr.user_cancel] != null ? dt.Rows[0][matr.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][matr.active] != null ? dt.Rows[0][matr.active].ToString() : "";
                //dept1.sort1 = dt.Rows[0][matr.sort1] != null ? dt.Rows[0][matr.sort1].ToString() : "";
                //dept1.status_aircondition = dt.Rows[0][fooC.status_aircondition] != null ? dt.Rows[0][fooC.status_aircondition].ToString() : "";
            }
            else
            {
                dept1.matr_id = "";
                dept1.matr_code = "";
                dept1.matr_date = "";
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
                //dept1.status_aircondition = "";
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
