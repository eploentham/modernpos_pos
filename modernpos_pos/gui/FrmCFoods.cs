using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;

namespace modernpos_pos.gui
{
    public partial class FrmCFoods : Form
    {
        mPOSControl mposC;
        Foods foo;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfFoo;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCFoods(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }

        private void initConfig()
        {
            foo = new Foods();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtFooCode.BackColor;
            fc = txtFooCode.ForeColor;
            ff = txtFooCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            mposC.mposDB.resDB.setCboRestaurant(cboRes);
            mposC.mposDB.footDB.setCboFoodsType(cboFoodsType);
            mposC.mposDB.foocDB.setCboFoodsCat(cboFoodsCat);
            mposC.setC1ComboPrinter(cboPrinter,"");

            initGrfFoo();
            setGrfFoo();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void initGrfFoo()
        {
            grfFoo = new C1FlexGrid();
            grfFoo.Font = fEdit;
            grfFoo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFoo.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFoo.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfFoo.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfFoo.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel2.Controls.Add(this.grfFoo);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFoo, theme);
        }
        private void setGrfFoo()
        {
            //grfDept.Rows.Count = 7;

            grfFoo.DataSource = mposC.mposDB.fooDB.selectAll();
            grfFoo.Cols.Count = colCnt;
            CellStyle cs = grfFoo.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFoo.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFoo.Cols[colE].Style = grfFoo.Styles["btn"];
            grfFoo.Cols[colS].Style = grfFoo.Styles["date"];

            grfFoo.Cols[colID].Width = 60;

            grfFoo.Cols[colCode].Width = 80;
            grfFoo.Cols[colName].Width = 300;

            grfFoo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFoo.Cols[colCode].Caption = "รหัส";
            grfFoo.Cols[colName].Caption = "ชื่ออาหาร";
            grfFoo.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFoo.GetCellRange(2, colE);
            for (int i = 1; i < grfFoo.Rows.Count; i++)
            {
                grfFoo[i, 0] = i;
                if (i % 2 == 0)
                    grfFoo.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfFoo.Cols[colID].Visible = false;
            grfFoo.Cols[colE].Visible = false;
            grfFoo.Cols[colS].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = mposC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtFooCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFooCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFooNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFooNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String posiId)
        {
            foo = mposC.mposDB.fooDB.selectByPk1(posiId);
            txtID.Value = foo.foods_id;
            txtFooCode.Value = foo.foods_code;
            txtFooNameT.Value = foo.foods_name;
            txtRemark.Value = foo.remark;
            //if (foo.status_foods.Equals("1"))
            //{
            //    chkStatusToGo.Checked = true;
            //}
            //else
            //{
            //    chkStatusToGo.Checked = false;
            //}
            chkStatusToGo.Checked = foo.status_to_go.Equals("1") ? true : false;
            chkDineIn.Checked = foo.status_dine_in.Equals("1") ? true : false;
            mposC.setC1Combo(cboRes, foo.res_id);
            mposC.setC1Combo(cboFoodsType, foo.foods_type_id);
            mposC.setC1Combo(cboFoodsCat, foo.foods_cat_id);
            mposC.setC1Combo(cboPrinter, foo.printer_name);
            //if (area.status_embryologist.Equals("1"))
            //{
            //    chkEmbryologist.Checked = true;
            //}
            //else
            //{
            //    chkEmbryologist.Checked = false;
            //}
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            cboFoodsType.Enabled = flag;
            txtFooCode.Enabled = flag;
            txtFooNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }

        private void setFoods()
        {
            foo.foods_id = txtID.Text;
            foo.foods_code = txtFooCode.Text;
            foo.foods_name = txtFooNameT.Text;
            foo.foods_price = txtPrice.Text;
            foo.remark = txtRemark.Text;
            foo.status_foods = "1";
            foo.status_dine_in = chkDineIn.Checked == true ? "1" : "0";
            foo.status_to_go = chkStatusToGo.Checked == true ? "1" : "0";
            foo.foods_cat_id = cboFoodsCat.SelectedItem == null ? "" : ((ComboBoxItem)cboFoodsCat.SelectedItem).Value;
            foo.foods_type_id = cboFoodsType.SelectedItem == null ? "" : ((ComboBoxItem)cboFoodsType.SelectedItem).Value;
            foo.res_id = cboRes.SelectedItem == null ? "" : ((ComboBoxItem)cboRes.SelectedItem).Value;
            foo.printer_name = cboPrinter.SelectedItem == null ? "" : ((ComboBoxItem)cboPrinter.SelectedItem).Value;
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfFoo[e.NewRange.r1, colID] != null ? grfFoo[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfPosi_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfPosi_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == 0) return;
            //CellStyle cs = grfDept.Styles.Add("text");
            //cs.BackColor = Color.DimGray;
            //sB1.Text = grfDept[e.Row, e.Col].ToString();
            ////grfDept[e.Row, coledit] = "1";
            //grfDept.Rows[e.Row].Style = cs;
            //if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            //{
            //    ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            //}
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = mposC.mposDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length>0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtFooCode.Value = "";
            txtFooNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            chkDineIn.Checked = true;
            chkStatusToGo.Checked = true;
            setControlEnable(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                mposC.mposDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfFoo();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setFoods();
                String re = mposC.mposDB.fooDB.insertFoods(foo, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfFoo();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void FrmCFoods_Load(object sender, EventArgs e)
        {

        }
    }
}
