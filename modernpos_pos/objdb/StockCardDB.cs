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
    public class StockCardDB
    {
        public StockCard stkc;
        ConnectDB conn;
        public List<StockCard> lstkc;

        public StockCardDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            lstkc = new List<StockCard>();
            stkc = new StockCard();
            stkc.stock_id = "stock_id";
            stkc.material_id = "material_id";
            stkc.price = "price";
            stkc.qty = "qty";
            stkc.remark = "remark";
            stkc.sort1 = "sort1";
            stkc.date_cancel = "date_cancel";
            stkc.date_create = "date_create";
            stkc.date_modi = "date_modi";
            stkc.user_cancel = "user_cancel";
            stkc.user_create = "user_create";
            stkc.user_modi = "user_modi";
            stkc.host_id = "host_id";
            stkc.branch_id = "branch_id";
            stkc.device_id = "device_id";
            stkc.weight = "weight";
            stkc.rec_draw_matr_id = "rec_draw_matr_id";
            stkc.status_rec_draw = "status_rec_draw";
            stkc.rec_draw_date = "rec_draw_date";
            stkc.onhand = "onhand";
            stkc.host_id = "host_id";
            stkc.branch_id = "branch_id";
            stkc.device_id = "device_id";

            stkc.pkField = "stock_id";
            stkc.table = "b_material";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select foos.*  " +
                "From " + stkc.table + " foos " +
                " " +
                "Where foos." + stkc.qty + " ='1' " +
                "Order By foos." + stkc.stock_id;
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos.* " +
                "From " + stkc.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + stkc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId()
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + stkc.stock_id + ",foos." + stkc.price + ",foos." + stkc.price + ",foos." + stkc.material_id +
                " From " + stkc.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where  foos." + stkc.qty + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public DataTable selectByFoodsId1(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select foos." + stkc.material_id + ",'' as img,foos." + stkc.price + ",foos." + stkc.price +
                " From " + stkc.table + " foos " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foos." + stkc.material_id + " ='" + copId + "' and foos." + stkc.qty + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public StockCard selectByPk1(String copId)
        {
            StockCard cop1 = new StockCard();
            DataTable dt = new DataTable();
            String sql = "select sex.* " +
                "From " + stkc.table + " sex " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where sex." + stkc.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setMaterial(dt);
            return cop1;
        }
        private StockCard setArea1(DataTable dt)
        {
            StockCard dept1 = new StockCard();
            if (dt.Rows.Count > 0)
            {
                dept1.stock_id = dt.Rows[0][stkc.stock_id].ToString();
                dept1.price = dt.Rows[0][stkc.price].ToString();
            }

            return dept1;
        }
        public DataTable selectC1()
        {
            DataTable dt = new DataTable();
            String sql = "select sex." + stkc.pkField + ",sex." + stkc.price + " " +
                "From " + stkc.table + " sex " +
                " " +
                "Where sex." + stkc.qty + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        public DataTable selectByFoodsId2(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select footp." + stkc.stock_id + ",'' as img,footp." + stkc.price + ",footp." + stkc.price + ", footp." + stkc.material_id +
                " From " + stkc.table + " footp " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where footp." + stkc.material_id + " ='" + copId + "' and footp." + stkc.qty + "='1' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public List<StockCard> getlFooSpecByFooId(String fooid)
        {
            //lDept = new List<Position>();
            List<StockCard> lfooC1 = new List<StockCard>();
            DataTable dt = new DataTable();
            dt = selectByFoodsId2(fooid);
            foreach (DataRow row in dt.Rows)
            {
                StockCard itm1 = new StockCard();
                itm1.stock_id = row[stkc.stock_id].ToString();
                itm1.price = row[stkc.price].ToString();
                itm1.price = row[stkc.price].ToString();
                itm1.material_id = row[stkc.material_id].ToString();
                lfooC1.Add(itm1);
            }
            return lfooC1;
        }
        public void getlArea()
        {
            //lDept = new List<Position>();
            lstkc.Clear();
            DataTable dt = new DataTable();
            dt = selectAll();
            foreach (DataRow row in dt.Rows)
            {
                StockCard itm1 = new StockCard();
                itm1.stock_id = row[stkc.stock_id].ToString();
                itm1.price = row[stkc.price].ToString();

                lstkc.Add(itm1);
            }
        }
        public String getList(String id)
        {
            String re = "";
            if (lstkc.Count <= 0) getlArea();
            foreach (StockCard sex in lstkc)
            {
                if (sex.stock_id.Equals(id))
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
            if (lstkc.Count <= 0) getlArea();
            foreach (StockCard sex in lstkc)
            {
                if (sex.price.Trim().Equals(name.Trim()))
                {
                    re = sex.stock_id;
                    break;
                }
            }
            return re;
        }
        private void chkNull(StockCard p)
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

            p.price = p.price == null ? "" : p.price;
            p.material_id = p.material_id == null ? "" : p.material_id;

            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;
            p.remark = p.remark == null ? "" : p.remark;

            p.rec_draw_matr_id = long.TryParse(p.rec_draw_matr_id, out chk) ? chk.ToString() : "0";
            p.rec_draw_date = long.TryParse(p.rec_draw_date, out chk) ? chk.ToString() : "0";
            p.status_rec_draw = long.TryParse(p.status_rec_draw, out chk) ? chk.ToString() : "0";

            p.price = Decimal.TryParse(p.price, out chk1) ? chk1.ToString() : "0";
            p.material_id = Decimal.TryParse(p.material_id, out chk1) ? chk1.ToString() : "0";
            p.onhand = Decimal.TryParse(p.onhand, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(StockCard p, String userId)
        {
            String re = "";
            String sql = "";
            p.qty = "1";
            //p.ssdata_id = "";
            int chk = 0;

            chkNull(p);
            sql = "Insert Into " + stkc.table + " set " +
                " " + stkc.material_id + " = '" + p.material_id + "'" +
                "," + stkc.price + " = '" + p.price.Replace("'", "''") + "'" +
                "," + stkc.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stkc.date_create + " = now()" +
                "," + stkc.qty + " = '1'" +
                "," + stkc.user_create + " = '" + userId + "' " +
                "," + stkc.host_id + " = '" + p.host_id + "' " +
                "," + stkc.branch_id + " = '" + p.branch_id + "' " +
                "," + stkc.device_id + " = '" + p.device_id + "' " +
                "," + stkc.price + " = '" + p.price + "' " +
                "," + stkc.rec_draw_matr_id + " = '" + p.rec_draw_matr_id + "' " +
                "," + stkc.weight + " = '" + p.weight + "' " +
                "," + stkc.sort1 + " = '" + p.sort1 + "' " +
                "," + stkc.status_rec_draw + " = '" + p.status_rec_draw + "' " +
                "," + stkc.rec_draw_date + " = '" + p.rec_draw_date + "' " +
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
        public String update(StockCard p, String userId)
        {
            String re = "";
            String sql = "";
            int chk = 0;

            chkNull(p);
            sql = "Update " + stkc.table + " Set " +
                " " + stkc.material_id + " = '" + p.material_id + "'" +
                "," + stkc.price + " = '" + p.price.Replace("'", "''") + "'" +
                "," + stkc.remark + " = '" + p.remark.Replace("'", "''") + "'" +
                "," + stkc.date_modi + " = now()" +
                "," + stkc.user_modi + " = '" + userId + "' " +
                "," + stkc.host_id + " = '" + p.host_id + "' " +
                "," + stkc.branch_id + " = '" + p.branch_id + "' " +
                "," + stkc.device_id + " = '" + p.device_id + "' " +
                "," + stkc.price + " = '" + p.price + "' " +
                "," + stkc.weight + " = '" + p.weight + "' " +
                "," + stkc.rec_draw_matr_id + " = '" + p.rec_draw_matr_id + "' " +
                "," + stkc.sort1 + " = '" + p.sort1 + "' " +
                "," + stkc.rec_draw_date + " = '" + p.rec_draw_date + "' " +
                "," + stkc.status_rec_draw + " = '" + p.status_rec_draw + "' " +
                "Where " + stkc.pkField + "='" + p.stock_id + "'"
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
        public String insertMaterial(StockCard p, String userId)
        {
            String re = "";

            if (p.stock_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                re = update(p, "");
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

            sql = "Update " + stkc.table + " Set " +
                " " + stkc.qty + " = '3'" +
                "," + stkc.date_cancel + " = now()" +
                "," + stkc.user_modi + " = '" + userId + "' " +
                "Where " + stkc.pkField + "='" + foosid + "'"
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
                item.Text = row[stkc.price].ToString();
                item.Value = row[stkc.stock_id].ToString();

                c.Items.Add(item);
            }
            return c;
        }
        public C1ComboBox setCboMaterial(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectC1();
            if (lstkc.Count <= 0) getlArea();
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "000";
            c.Items.Clear();
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)
            int i = 0;
            foreach (StockCard row in lstkc)
            {
                item = new ComboBoxItem();
                item.Value = row.stock_id;
                item.Text = row.price;
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
        private StockCard setMaterial(DataTable dt)
        {
            StockCard dept1 = new StockCard();
            if (dt.Rows.Count > 0)
            {
                dept1.stock_id = dt.Rows[0][stkc.stock_id].ToString();
                dept1.material_id = dt.Rows[0][stkc.material_id].ToString();
                dept1.price = dt.Rows[0][stkc.price].ToString();
                dept1.weight = dt.Rows[0][stkc.weight] != null ? dt.Rows[0][stkc.weight].ToString() : "";
                dept1.material_id = dt.Rows[0][stkc.material_id] != null ? dt.Rows[0][stkc.material_id].ToString() : "";
                dept1.remark = dt.Rows[0][stkc.remark] != null ? dt.Rows[0][stkc.remark].ToString() : "";
                dept1.date_create = dt.Rows[0][stkc.date_create] != null ? dt.Rows[0][stkc.date_create].ToString() : "";
                dept1.date_modi = dt.Rows[0][stkc.date_modi] != null ? dt.Rows[0][stkc.date_modi].ToString() : "";
                dept1.date_cancel = dt.Rows[0][stkc.date_cancel] != null ? dt.Rows[0][stkc.date_cancel].ToString() : "";
                dept1.user_create = dt.Rows[0][stkc.user_create] != null ? dt.Rows[0][stkc.user_create].ToString() : "";
                dept1.user_modi = dt.Rows[0][stkc.user_modi] != null ? dt.Rows[0][stkc.user_modi].ToString() : "";
                dept1.user_cancel = dt.Rows[0][stkc.user_cancel] != null ? dt.Rows[0][stkc.user_cancel].ToString() : "";
                dept1.qty = dt.Rows[0][stkc.qty] != null ? dt.Rows[0][stkc.qty].ToString() : "";
                dept1.sort1 = dt.Rows[0][stkc.sort1] != null ? dt.Rows[0][stkc.sort1].ToString() : "";
                dept1.price = dt.Rows[0][stkc.price] != null ? dt.Rows[0][stkc.price].ToString() : "";
                dept1.rec_draw_matr_id = dt.Rows[0][stkc.rec_draw_matr_id] != null ? dt.Rows[0][stkc.rec_draw_matr_id].ToString() : "";
                dept1.rec_draw_date = dt.Rows[0][stkc.rec_draw_date] != null ? dt.Rows[0][stkc.rec_draw_date].ToString() : "";
                dept1.status_rec_draw = dt.Rows[0][stkc.status_rec_draw] != null ? dt.Rows[0][stkc.status_rec_draw].ToString() : "";
                dept1.onhand = dt.Rows[0][stkc.onhand] != null ? dt.Rows[0][stkc.onhand].ToString() : "";
            }
            else
            {
                dept1.stock_id = "";
                dept1.material_id = "";
                dept1.price = "";
                dept1.weight = "";
                dept1.remark = "";
                dept1.date_create = "";
                dept1.date_modi = "";
                dept1.date_cancel = "";
                dept1.user_create = "";
                dept1.user_modi = "";
                dept1.user_cancel = "";
                dept1.qty = "";
                dept1.sort1 = "";
                dept1.price = "";
                dept1.material_id = "";
                dept1.rec_draw_matr_id = "";
                dept1.status_rec_draw = "";
                dept1.rec_draw_date = "";
                dept1.onhand = "";
            }

            return dept1;
        }
    }
}
