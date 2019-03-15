using C1.Win.C1FlexGrid;
using C1.Win.C1Themes;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmTakeOutTopping : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grf;
        Foods foo;
        String fooid = "", fooTopping = "", toppingprice="";
        int colNo = 1, colImg = 2, colFoosName = 3, colPrice=4, colStatus = 5;
        Image imgR, imgC;

        public FrmTakeOutTopping(mPOSControl x, String fooid)
        {
            InitializeComponent();
            mposC = x;
            this.fooid = fooid;
            initConfig();
        }
        private void initConfig()
        {
            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);

            foo = new Foods();
            foo = mposC.mposDB.fooDB.selectByPk1(fooid);
            lbFooName.Text = "";
            lbFooName.Text = foo.foods_name;
            lbPrice.Text = "";

            imgR = Resources.red_checkmark_png_16;
            btnReturn.Click += BtnReturn_Click;
            //picFoo.Image = imgR;

            initGrf();
            setGrfTopping(foo.foods_id);
        }
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Decimal price = 0, sum = 0;
            Decimal.TryParse(lbPrice.Text, out sum);
            Decimal.TryParse(foo.foods_price, out price);
            sum = sum - price;
            mposC.fooName = lbFooName.Text.Trim();
            mposC.fooTopping = fooTopping.Trim();
            mposC.toppingPrice = sum.ToString("0.00");
            mposC.foosumprice = lbPrice.Text;
            mposC.fooName = fooTopping.Equals("") ? mposC.fooName.Replace("+", "").Trim() :  mposC.fooName.Replace(fooTopping.Trim(), "").Replace("+", "").Trim();
            Close();
        }
        private void initGrf()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grf.Rows.Count = 1;
            grf.Cols.Count = 6;
            grf.Cols[colImg].Width = 50;
            grf.Cols[colFoosName].Width = 200;

            grf.TabStop = false;
            grf.EditOptions = EditFlags.None;
            grf.Cols[colImg].AllowEditing = false;
            grf.Cols[colFoosName].AllowEditing = false;

            //grf.ExtendLastCol = true;
            grf.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;

            panel3.Controls.Add(grf);
            grf.Cols[colNo].Visible = false;
            grf.Cols[colStatus].Visible = false;
            grf.Cols[colPrice].AllowEditing = false;
            //grf.Cols[colQty].Visible = false;
            //pnBill.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setGrfTopping(String fooId)
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            DataTable dt = new DataTable();
            dt = mposC.mposDB.footpDB.selectByFoodsId1(fooId);
            grf.Cols.Count = 6;
            grf.Rows.Count = dt.Rows.Count + 1;
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grf.Cols[1].Width = 60;

            grf.Cols[colImg].Width = 50;
            grf.Cols[colFoosName].Width = 200;

            grf.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf.Cols[2].Caption = "รายการสั่งพิเศษ";
            grf.Click += Grf_Click;
            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grf[i + 1, 0] = (i + 1);
                grf[i + 1, colFoosName] = dt.Rows[i]["foods_topping_name"].ToString();
                grf[i + 1, colPrice] = dt.Rows[i]["price"].ToString();
                grf[i + 1, colStatus] = "";
                if (i % 2 == 0)
                    grf.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grf.Cols[colStatus].Visible = false;
            grf.Cols[colNo].Visible = false;
            grf.Cols[colFoosName].AllowEditing = false;
            grf.Cols[colImg].AllowEditing = false;
            //pageLoad = false;
        }
        private void Grf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf.Row < 0) return;
            if (grf.Col < 0) return;
            if (grf[grf.Row, colFoosName] == null) return;
            String name = "", id = "";
            name = grf[grf.Row, colFoosName].ToString();
            if (!name.Equals(""))
            {
                if (grf[grf.Row, colStatus].Equals(""))
                {
                    grf[grf.Row, colStatus] = "1";
                    grf.SetCellImage(grf.Row, colImg, imgR);
                    //lbFooName.Text = lbFooName.Text + " + " + name;
                    setToppingName();
                }
                else
                {
                    grf[grf.Row, colStatus] = "";
                    grf.SetCellImage(grf.Row, colImg, null);
                    setToppingName();
                }
            }
            //grf.AutoSizeRows();
        }
        private void setToppingName()
        {
            String topping = "";
            Decimal price = 0, sum=0;
            lbFooName.Text = foo.foods_name;
            Decimal.TryParse(foo.foods_price, out sum);
            foreach (Row row in grf.Rows)
            {
                if (row[colStatus] == null) continue;
                
                if (row[colStatus].Equals("1"))
                {
                    topping += row[colFoosName].ToString() +"[" +row[colPrice].ToString()+"]" + " + ";
                    Decimal.TryParse(row[colPrice].ToString(), out price);
                    sum += price;
                }
            }
            topping = topping.Trim();
            try
            {
                if (topping.Substring(topping.Length - 1).Equals("+"))
                {
                    topping = topping.Substring(0, topping.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            lbFooName.Text = foo.foods_name + " + " + topping;
            lbFooName.Text = lbFooName.Text.Trim();
            lbPrice.Text = sum.ToString("0.00");
            fooTopping = topping;
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();
                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void FrmTaleOutTopping_Load(object sender, EventArgs e)
        {

        }
    }
}
