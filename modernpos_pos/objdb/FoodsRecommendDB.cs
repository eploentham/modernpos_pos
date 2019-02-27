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
    public class FoodsRecommendDB
    {
        FoodsRecommend foor;
        ConnectDB conn;
        public List<FoodsRecommend> lArea;
        public FoodsRecommendDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lArea = new List<FoodsRecommend>();
            foor = new FoodsRecommend();
            foor.recom_id = "recom_id";
            foor.foods_id = "foods_id";
            
            foor.foods_name = "foods_name";
            foor.active = "active";
            foor.remark = "remark";
            foor.sort1 = "sort1";
            foor.date_cancel = "date_cancel";
            foor.date_create = "date_create";
            foor.date_modi = "date_modi";
            foor.user_cancel = "user_cancel";
            foor.user_create = "user_create";
            foor.user_modi = "user_modi";
            foor.host_id = "host_id";
            foor.branch_id = "branch_id";
            foor.device_id = "device_id";            

            foor.pkField = "recom_id";
            foor.table = "b_foods_recommend";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select sex.*  " +
                "From " + foor.table + " sex " +
                " " +
                "Where sex." + foor.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foor.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foor.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public FoodsRecommend selectByPk1(String copId)
        {
            FoodsRecommend cop1 = new FoodsRecommend();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + foor.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + foor.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setTable(dt);
            return cop1;
        }
        private FoodsRecommend setArea1(DataTable dt)
        {
            FoodsRecommend dept1 = new FoodsRecommend();
            if (dt.Rows.Count > 0)
            {
                dept1.recom_id = dt.Rows[0][foor.recom_id].ToString();
                dept1.foods_name = dt.Rows[0][foor.foods_name].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + foor.pkField + ",sex." + foor.foods_name + " " +
                "From " + foor.table + " sex " +
                " " +
                "Where sex." + foor.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lArea.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                FoodsRecommend itm1 = new FoodsRecommend();
                itm1.recom_id = row[foor.recom_id].ToString();
                itm1.foods_name = row[foor.foods_name].ToString();

                lArea.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lArea.Count <= 0) getlArea();
            foreach (FoodsRecommend sex in lArea)
            {
                if (sex.recom_id.Equals(id))
                {
                    re = sex.foods_name;
                    break;
                }
            }
            return re;
        }
        private void chkNull(FoodsRecommend p)
        {
            long chk = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;

            p.foods_name = p.foods_name == null ? "" : p.foods_name;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            p.foods_id = long.TryParse(p.foods_id, out chk) ? chk.ToString() : "0";

        }
        public String insert(FoodsRecommend p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + foor.table + " set " +                
                " " + foor.foods_name + " = '" + p.foods_name.Replace("'", "''") + "'" +
                "," + foor.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foor.date_create + " = now()" +
                "," + foor.active + " = '1'" +
                "," + foor.user_create + " = '" + userId + "' " +
                "," + foor.host_id + " = '" + p.host_id + "' " +
                "," + foor.branch_id + " = '" + p.branch_id + "' " +
                "," + foor.device_id + " = '" + p.device_id + "' " +
                
                "," + foor.foods_id + " = '" + p.foods_id + "' " +
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
        public String update(FoodsRecommend p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + foor.table + " Set " +                
                " " + foor.foods_name + " = '" + p.foods_name.Replace("'", "''") + "'" +
                "," + foor.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + foor.date_modi + " = now()" +
                "," + foor.user_modi + " = '" + userId + "' " +
                "," + foor.host_id + " = '" + p.host_id + "' " +
                "," + foor.branch_id + " = '" + p.branch_id + "' " +
                "," + foor.device_id + " = '" + p.device_id + "' " +                
                "," + foor.foods_id + " = '" + p.foods_id + "' " +
                "Where " + foor.pkField + "='" + p.recom_id + "'"
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
        public String insertTable(FoodsRecommend p, String userId)
        {
            String re = "";

            if (p.foods_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
            }

            return re;
        }
        public C1ComboBox setCboTable(C1ComboBox c)
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
                item.Text = row[foor.foods_name].ToString();
                item.Value = row[foor.recom_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboTable(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lArea.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (FoodsRecommend row in lArea)
            {
                item = new ComboBoxItem();
                item.Value = row.recom_id;
                item.Text = row.foods_name;
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
        private FoodsRecommend setTable(DataTable dt)
        {
            FoodsRecommend dept1 = new FoodsRecommend();
            if (dt.Rows.Count > 0)
            {
                dept1.recom_id = dt.Rows[0][foor.recom_id].ToString();
                
                dept1.foods_name = dt.Rows[0][foor.foods_name].ToString();
                dept1.foods_id = dt.Rows[0][foor.foods_id] != null ? dt.Rows[0][foor.foods_id].ToString() : "";
                //dept1.status_doctor = dt.Rows[0][area.status_doctor] != null ? dt.Rows[0][area.status_doctor].ToString() : "";
                dept1.remark = dt.Rows[0][foor.remark] != null ? dt.Rows[0][foor.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][foor.date_create] != null ? dt.Rows[0][foor.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][foor.date_modi] != null ? dt.Rows[0][foor.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][foor.date_cancel] != null ? dt.Rows[0][foor.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][foor.user_create] != null ? dt.Rows[0][foor.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][foor.user_modi] != null ? dt.Rows[0][foor.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][foor.user_cancel] != null ? dt.Rows[0][foor.user_cancel].ToString() : "";
                dept1.active = dt.Rows[0][foor.active] != null ? dt.Rows[0][foor.active].ToString() : "";
                dept1.sort1 = dt.Rows[0][foor.sort1] != null ? dt.Rows[0][foor.sort1].ToString() : "";
                
            }
            else
            {
                dept1.foods_id = "";
                
                dept1.foods_name = "";
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
                
                //dept1.status_embryologist = "";
            }

            return dept1;
        }
    }
}
