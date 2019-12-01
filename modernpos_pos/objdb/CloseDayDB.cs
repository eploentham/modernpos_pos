using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modernpos_pos.objdb
{
    public class CloseDayDB
    {
        public CloseDay cld;
        ConnectDB conn;
        public CloseDayDB(ConnectDB c)
        {
            conn = c;
            initConfig();
        }
        private void initConfig()
        {
            cld = new CloseDay();
            cld.closeday_id = "closeday_id";
            cld.amount = "amount";
            cld.amt_cash = "amt_cash";
            cld.amt_credit_card = "amt_credit_card";
            cld.closeday_date = "closeday_date";
            cld.cnt_order = "cnt_patient";
            cld.deposit = "deposit";

            cld.active = "active";
            cld.remark = "remark";
            cld.sort1 = "sort1";
            cld.date_cancel = "date_cancel";
            cld.date_create = "date_create";
            cld.date_modi = "date_modi";
            cld.user_cancel = "user_cancel";
            cld.user_create = "user_create";
            cld.user_modi = "user_modi";
            cld.host_id = "host_id";
            cld.branch_id = "branch_id";
            cld.device_id = "device_id";
            cld.res_id = "res_id";

            cld.expense_1 = "expense_1";
            cld.expense_2 = "expense_2";
            cld.expense_3 = "expense_3";
            cld.expense_4 = "expense_4";
            cld.expense_5 = "expense_5";
            cld.total_cash = "total_cash";
            cld.amount_order = "amount_order";
            cld.bill_amount = "bill_amount";
            cld.cash_draw1 = "cash_draw1";
            cld.cash_draw1_remark = "cash_draw1_remark";
            cld.cash_draw2 = "cash_draw2";
            cld.cash_draw2_remark = "cash_draw2_remark";
            cld.cash_draw3 = "cash_draw3";
            cld.cash_draw3_remark = "cash_draw3_remark";
            cld.cash_receive1 = "cash_receive1";
            cld.cash_receive1_remark = "cash_receive1_remark";
            cld.cash_receive2 = "cash_receive2";
            cld.cash_receive2_remark = "cash_receive2_remark";
            cld.cash_receive3 = "cash_receive3";
            cld.cash_receive3_remark = "cash_receive3_remark";
            cld.closeday_user = "closeday_user";
            cld.cnt_bill = "cnt_bill";
            cld.cnt_order = "cnt_order";
            cld.discount = "discount";
            cld.nettotal = "nettotal";
            cld.res_id = "res_id";
            cld.service_charge = "service_charge";
            cld.status_void = "status_void";
            cld.total = "total";
            cld.vat = "vat";
            cld.void_date = "void_date";
            cld.void_user = "void_user";
            cld.weather = "weather";

            cld.service_charge = "service_charge";
            cld.vat = "vat";
            cld.total = "total";
            cld.nettotal = "nettotal";
            cld.cash_receive = "cash_receive";
            cld.cash_ton = "cash_ton";

            cld.pkField = "closeday_id";
            cld.table = "t_closeday";
        }
        public DataTable selectAll()
        {
            DataTable dt = new DataTable();
            String sql = "select cld.*  " +
                "From " + cld.table + " cld " +
                " " +
                "Where cld." + cld.active + " ='1' ";
            dt = conn.selectData(conn.conn, sql);

            return dt;
        }
        
        public DataTable selectByPk(String copId)
        {
            DataTable dt = new DataTable();
            String sql = "select cld.* " +
                "From " + cld.table + " cld " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where foo." + cld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            return dt;
        }
        public CloseDay selectByPk1(String copId)
        {
            CloseDay cop1 = new CloseDay();
            DataTable dt = new DataTable();
            String sql = "select cld.* " +
                "From " + cld.table + " cld " +
                //"Left Join t_ssdata_visit ssv On ssv.ssdata_visit_id = bd.ssdata_visit_id " +
                "Where cld." + cld.pkField + " ='" + copId + "' ";
            dt = conn.selectData(conn.conn, sql);
            cop1 = setCloseday(dt);
            return cop1;
        }
        private void chkNull(CloseDay p)
        {
            long chk = 0;
            Decimal chk1 = 0;

            p.date_modi = p.date_modi == null ? "" : p.date_modi;
            p.date_cancel = p.date_cancel == null ? "" : p.date_cancel;
            p.user_create = p.user_create == null ? "" : p.user_create;
            p.user_modi = p.user_modi == null ? "" : p.user_modi;
            p.user_cancel = p.user_cancel == null ? "" : p.user_cancel;
                        
            p.status_void = p.status_void == null ? "" : p.status_void;
            p.void_date = p.void_date == null ? "" : p.void_date;
            p.closeday_date = p.closeday_date == null ? "" : p.closeday_date;
            p.cash_draw1_remark = p.cash_draw1_remark == null ? "" : p.cash_draw1_remark;
            p.cash_draw2_remark = p.cash_draw2_remark == null ? "" : p.cash_draw2_remark;
            p.cash_draw3_remark = p.cash_draw3_remark == null ? "" : p.cash_draw3_remark;
            p.cash_receive1_remark = p.cash_receive1_remark == null ? "" : p.cash_receive1_remark;
            p.cash_receive2_remark = p.cash_receive2_remark == null ? "" : p.cash_receive2_remark;
            p.cash_receive3_remark = p.cash_receive3_remark == null ? "" : p.cash_receive3_remark;
            p.closeday_user = p.closeday_user == null ? "" : p.closeday_user;
            p.status_void = p.status_void == null ? "" : p.status_void;
            p.void_date = p.void_date == null ? "" : p.void_date;
            p.void_user = p.void_user == null ? "" : p.void_user;
            p.weather = p.weather == null ? "" : p.weather;

            p.void_date = p.void_date == null ? "" : p.void_date;

            p.host_id = long.TryParse(p.host_id, out chk) ? chk.ToString() : "0";
            p.branch_id = long.TryParse(p.branch_id, out chk) ? chk.ToString() : "0";
            p.device_id = long.TryParse(p.device_id, out chk) ? chk.ToString() : "0";
            
            //p.closeday_id = long.TryParse(p.closeday_id, out chk) ? chk.ToString() : "0";
            //p.bill_id = long.TryParse(p.bill_id, out chk) ? chk.ToString() : "0";
            //p.area_id = long.TryParse(p.area_id, out chk) ? chk.ToString() : "0";
            p.res_id = long.TryParse(p.res_id, out chk) ? chk.ToString() : "0";
            
            p.cash_receive = Decimal.TryParse(p.cash_receive, out chk1) ? chk1.ToString() : "0";
            p.cash_ton = Decimal.TryParse(p.cash_ton, out chk1) ? chk1.ToString() : "0";
            p.nettotal = Decimal.TryParse(p.nettotal, out chk1) ? chk1.ToString() : "0";
            p.total = Decimal.TryParse(p.total, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
            p.amount = Decimal.TryParse(p.amount, out chk1) ? chk1.ToString() : "0";
            p.discount = Decimal.TryParse(p.discount, out chk1) ? chk1.ToString() : "0";
            p.service_charge = Decimal.TryParse(p.service_charge, out chk1) ? chk1.ToString() : "0";
            p.amt_cash = Decimal.TryParse(p.amt_cash, out chk1) ? chk1.ToString() : "0";
            p.amt_credit_card = Decimal.TryParse(p.amt_credit_card, out chk1) ? chk1.ToString() : "0";
            p.deposit = Decimal.TryParse(p.deposit, out chk1) ? chk1.ToString() : "0";
            p.expense_1 = Decimal.TryParse(p.expense_1, out chk1) ? chk1.ToString() : "0";
            p.expense_2 = Decimal.TryParse(p.expense_2, out chk1) ? chk1.ToString() : "0";
            p.expense_3 = Decimal.TryParse(p.expense_3, out chk1) ? chk1.ToString() : "0";
            p.expense_4 = Decimal.TryParse(p.expense_4, out chk1) ? chk1.ToString() : "0";
            p.expense_5 = Decimal.TryParse(p.expense_5, out chk1) ? chk1.ToString() : "0";
            p.total_cash = Decimal.TryParse(p.total_cash, out chk1) ? chk1.ToString() : "0";
            p.amount_order = Decimal.TryParse(p.amount_order, out chk1) ? chk1.ToString() : "0";
            p.bill_amount = Decimal.TryParse(p.bill_amount, out chk1) ? chk1.ToString() : "0";
            p.cash_draw1 = Decimal.TryParse(p.cash_draw1, out chk1) ? chk1.ToString() : "0";
            p.cash_draw2 = Decimal.TryParse(p.cash_draw2, out chk1) ? chk1.ToString() : "0";
            p.cash_draw3 = Decimal.TryParse(p.cash_draw3, out chk1) ? chk1.ToString() : "0";
            p.cash_receive1 = Decimal.TryParse(p.cash_receive1, out chk1) ? chk1.ToString() : "0";
            p.cash_receive2 = Decimal.TryParse(p.cash_receive2, out chk1) ? chk1.ToString() : "0";
            p.cash_receive3 = Decimal.TryParse(p.cash_receive3, out chk1) ? chk1.ToString() : "0";
            p.cnt_bill = Decimal.TryParse(p.cnt_bill, out chk1) ? chk1.ToString() : "0";
            p.cnt_order = Decimal.TryParse(p.cnt_order, out chk1) ? chk1.ToString() : "0";
            p.discount = Decimal.TryParse(p.discount, out chk1) ? chk1.ToString() : "0";
            p.nettotal = Decimal.TryParse(p.nettotal, out chk1) ? chk1.ToString() : "0";
            p.service_charge = Decimal.TryParse(p.service_charge, out chk1) ? chk1.ToString() : "0";
            p.total = Decimal.TryParse(p.total, out chk1) ? chk1.ToString() : "0";
            p.vat = Decimal.TryParse(p.vat, out chk1) ? chk1.ToString() : "0";
            p.cash_receive = Decimal.TryParse(p.cash_receive, out chk1) ? chk1.ToString() : "0";
            p.cash_ton = Decimal.TryParse(p.cash_ton, out chk1) ? chk1.ToString() : "0";
            //p.table_id = Decimal.TryParse(p.table_id, out chk1) ? chk1.ToString() : "0";
        }
        public String insert(CloseDay p, String userId)
        {
            String re = "";
            String sql = "";
            p.active = "1";
            //p.ssdata_id = "";
            int chk = 0;
            //bil.table = "t_bill";
            chkNull(p);
            sql = "Insert Into " + cld.table + " set " +
                " " + cld.amount + " = '" + p.amount + "'" +
                "," + cld.amt_cash + " = '" + p.amt_cash + "'" +
                "," + cld.date_create + " = now()" +
                "," + cld.active + " = '1'" +
                "," + cld.user_create + " = '" + userId + "' " +
                "," + cld.host_id + " = '" + p.host_id + "' " +
                "," + cld.branch_id + " = '" + p.branch_id + "' " +
                "," + cld.device_id + " = '" + p.device_id + "' " +
                "," + cld.date_cancel + " = '" + p.date_cancel + "' " +
                "," + cld.date_modi + " = '" + p.date_modi + "' " +
                "," + cld.user_cancel + " = '" + p.user_cancel + "' " +
                "," + cld.user_modi + " = '" + p.user_modi + "' " +
                "," + cld.remark + " = '" + p.remark.Replace("'", "''") + "'" +

                "," + cld.closeday_date + " = '" + p.closeday_date + "' " +
                "," + cld.res_id + " = '" + p.res_id + "' " +
                "," + cld.deposit + " = '" + p.deposit + "' " +
                "," + cld.expense_1 + " = '" + p.expense_1 + "' " +
                "," + cld.expense_2 + " = '" + p.expense_2 + "' " +
                "," + cld.expense_3 + " = '" + p.expense_3 + "' " +
                "," + cld.expense_4 + " = '" + p.expense_4 + "' " +
                "," + cld.expense_5 + " = '" + p.expense_5 + "' " +
                "," + cld.total_cash + " = '" + p.total_cash + "' " +
                "," + cld.amount_order + " = '" + p.amount_order + "' " +
                "," + cld.bill_amount + " = '" + p.bill_amount + "' " +
                "," + cld.cash_draw1 + " = '" + p.cash_draw1 + "' " +
                "," + cld.cash_draw1_remark + " = '" + p.cash_draw1_remark.Replace("'", "''") + "' " +
                "," + cld.cash_draw2 + " = '" + p.cash_draw2 + "' " +
                "," + cld.cash_draw2_remark + " = '" + p.cash_draw2_remark.Replace("'", "''") + "' " +
                "," + cld.cash_draw3 + " = '" + p.cash_draw3 + "' " +
                "," + cld.cash_draw3_remark + " = '" + p.cash_draw3_remark.Replace("'", "''") + "' " +
                "," + cld.cash_receive1 + " = '" + p.cash_receive1 + "' " +
                "," + cld.cash_receive1_remark + " = '" + p.cash_receive1_remark.Replace("'", "''") + "' " +
                "," + cld.cash_receive2 + " = '" + p.cash_receive2 + "' " +
                "," + cld.cash_receive2_remark + " = '" + p.cash_receive2_remark.Replace("'", "''") + "' " +
                "," + cld.cash_receive3 + " = '" + p.cash_receive3 + "' " +
                "," + cld.cash_receive3_remark + " = '" + p.cash_receive3_remark.Replace("'", "''") + "' " +
                "," + cld.closeday_user + " = '" + p.closeday_user + "' " +
                "," + cld.cnt_bill + " = '" + p.cnt_bill + "' " +
                "," + cld.cnt_order + " = '" + p.cnt_order + "' " +
                "," + cld.discount + " = '" + p.discount + "' " +
                "," + cld.nettotal + " = '" + p.nettotal + "' " +
                "," + cld.service_charge + " = '" + p.service_charge + "' " +
                "," + cld.status_void + " = '" + p.status_void + "' " +
                "," + cld.total + " = '" + p.total + "' " +
                "," + cld.vat + " = '" + p.vat + "' " +
                "," + cld.void_date + " = '" + p.void_date + "' " +
                "," + cld.void_user + " = '" + p.void_user + "' " +
                "," + cld.weather + " = '" + p.weather + "' " +
                "," + cld.cash_receive + " = '" + p.cash_receive + "' " +
                "," + cld.cash_ton + " = '" + p.cash_ton + "' " +
                " ";
            try
            {
                re = conn.ExecuteNonQuery(conn.conn, sql);
            }
            catch (Exception ex)
            {
                sql = ex.Message + " " + ex.InnerException;
                new LogFile("CloseDay -> insert" + ex.Message + " " + ex.InnerException);
            }

            return re;
        }
        public String insertCloseDay(CloseDay p, String userId)
        {
            String re = "";

            if (p.closeday_id.Equals(""))
            {
                re = insert(p, "");
            }
            else
            {
                //re = update(p, "");
            }

            return re;
        }
        public CloseDay setCloseday(DataTable dt)
        {
            CloseDay dgs1 = new CloseDay();
            if (dt.Rows.Count > 0)
            {
                dgs1.closeday_id = dt.Rows[0][cld.closeday_id].ToString();
                dgs1.amount = dt.Rows[0][cld.amount].ToString();
                dgs1.amt_cash = dt.Rows[0][cld.amt_cash].ToString();
                dgs1.amt_credit_card = dt.Rows[0][cld.amt_credit_card].ToString();
                dgs1.closeday_date = dt.Rows[0][cld.closeday_date].ToString();
                dgs1.res_id = dt.Rows[0][cld.res_id].ToString();
                dgs1.deposit = dt.Rows[0][cld.deposit].ToString();
                dgs1.expense_1 = dt.Rows[0][cld.expense_1].ToString();
                dgs1.expense_2 = dt.Rows[0][cld.expense_2].ToString();
                dgs1.expense_3 = dt.Rows[0][cld.expense_3].ToString();

                dgs1.expense_4 = dt.Rows[0][cld.expense_4].ToString();
                dgs1.expense_5 = dt.Rows[0][cld.expense_5].ToString();
                dgs1.total_cash = dt.Rows[0][cld.total_cash].ToString();
                dgs1.amount_order = dt.Rows[0][cld.amount_order].ToString();
                dgs1.bill_amount = dt.Rows[0][cld.bill_amount].ToString();
                dgs1.cash_draw1 = dt.Rows[0][cld.cash_draw1].ToString();
                dgs1.cash_draw1_remark = dt.Rows[0][cld.cash_draw1_remark].ToString();
                dgs1.cash_draw2 = dt.Rows[0][cld.cash_draw2].ToString();
                dgs1.cash_draw2_remark = dt.Rows[0][cld.cash_draw2_remark].ToString();
                dgs1.cash_draw3 = dt.Rows[0][cld.cash_draw3].ToString();

                dgs1.cash_draw3_remark = dt.Rows[0][cld.cash_draw3_remark].ToString();
                dgs1.cash_receive1 = dt.Rows[0][cld.cash_receive1].ToString();
                dgs1.cash_receive1_remark = dt.Rows[0][cld.cash_receive1_remark].ToString();
                dgs1.cash_receive2 = dt.Rows[0][cld.cash_receive2].ToString();
                dgs1.cash_receive2_remark = dt.Rows[0][cld.cash_receive2_remark].ToString();
                dgs1.cash_receive3 = dt.Rows[0][cld.cash_receive3].ToString();
                dgs1.cash_receive3_remark = dt.Rows[0][cld.cash_receive3_remark].ToString();
                dgs1.closeday_user = dt.Rows[0][cld.closeday_user].ToString();
                dgs1.cnt_bill = dt.Rows[0][cld.cnt_bill].ToString();
                dgs1.cnt_order = dt.Rows[0][cld.cnt_order].ToString();

                dgs1.discount = dt.Rows[0][cld.discount].ToString();
                dgs1.nettotal = dt.Rows[0][cld.nettotal].ToString();
                dgs1.service_charge = dt.Rows[0][cld.service_charge].ToString();
                dgs1.status_void = dt.Rows[0][cld.status_void].ToString();
                dgs1.total = dt.Rows[0][cld.total].ToString();
                dgs1.vat = dt.Rows[0][cld.vat].ToString();
                dgs1.void_date = dt.Rows[0][cld.void_date].ToString();
                dgs1.void_user = dt.Rows[0][cld.void_user].ToString();
                dgs1.weather = dt.Rows[0][cld.weather].ToString();
                dgs1.cash_receive = dt.Rows[0][cld.cash_receive].ToString();

                dgs1.cash_ton = dt.Rows[0][cld.cash_ton].ToString();
                
            }
            else
            {
                setCloseday(dgs1);
            }
            return dgs1;
        }
        public CloseDay setCloseday(CloseDay dgs1)
        {
            dgs1.closeday_id = "";
            dgs1.amount = "";
            dgs1.amt_cash = "";
            dgs1.amt_credit_card = "";
            dgs1.closeday_date = "";
            dgs1.cnt_order = "";
            dgs1.deposit = "";

            dgs1.active = "";
            dgs1.remark = "";
            dgs1.sort1 = "";
            dgs1.date_cancel = "";
            dgs1.date_create = "";
            dgs1.date_modi = "";
            dgs1.user_cancel = "";
            dgs1.user_create = "";
            dgs1.user_modi = "";
            dgs1.host_id = "";
            dgs1.branch_id = "";
            dgs1.device_id = "";
            dgs1.res_id = "";

            dgs1.expense_1 = "";
            dgs1.expense_2 = "";
            dgs1.expense_3 = "";
            dgs1.expense_4 = "";
            dgs1.expense_5 = "";
            dgs1.total_cash = "";
            dgs1.amount_order = "";
            dgs1.bill_amount = "";
            dgs1.cash_draw1 = "";
            dgs1.cash_draw1_remark = "";
            dgs1.cash_draw2 = "";
            dgs1.cash_draw2_remark = "";
            dgs1.cash_draw3 = "";
            dgs1.cash_draw3_remark = "";
            dgs1.cash_receive1 = "";
            dgs1.cash_receive1_remark = "";
            dgs1.cash_receive2 = "";
            dgs1.cash_receive2_remark = "";
            dgs1.cash_receive3 = "";
            dgs1.cash_receive3_remark = "";
            dgs1.closeday_user = "";
            dgs1.cnt_bill = "";
            dgs1.cnt_order = "";
            dgs1.discount = "";
            dgs1.nettotal = "";
            dgs1.res_id = "";
            dgs1.service_charge = "";
            dgs1.status_void = "";
            dgs1.total = "";
            dgs1.vat = "";
            dgs1.void_date = "";
            dgs1.void_user = "";
            dgs1.weather = "";

            dgs1.service_charge = "";
            dgs1.vat = "";
            dgs1.total = "";
            dgs1.nettotal = "";
            dgs1.cash_receive = "";
            dgs1.cash_ton = "";
            return dgs1;
        }
    }
}
