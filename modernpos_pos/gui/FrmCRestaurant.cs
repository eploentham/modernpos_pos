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
    public partial class FrmCRestaurant : Form
    {
        mPOSControl mposC;
        Restaurant res;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfRes;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCRestaurant(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }

        private void initConfig()
        {
            res = new Restaurant();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }

            bg = txtResCode.BackColor;
            fc = txtResCode.ForeColor;
            ff = txtResCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            //mposC.mposDB.areaDB.setCboArea(cboArea);

            initGrfRestaurant();
            setGrfRestaurant();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }
        
        private void initGrfRestaurant()
        {
            grfRes = new C1FlexGrid();
            grfRes.Font = fEdit;
            grfRes.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRes.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfRes.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfRes.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfRes.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel2.Controls.Add(this.grfRes);

            //C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            //C1ThemeController.ApplyThemeToObject(grfRes, theme);
        }
        private void setGrfRestaurant()
        {
            //grfDept.Rows.Count = 7;

            grfRes.DataSource = mposC.mposDB.resDB.selectAll();
            grfRes.Cols.Count = colCnt;
            CellStyle cs = grfRes.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfRes.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfRes.Cols[colE].Style = grfRes.Styles["btn"];
            grfRes.Cols[colS].Style = grfRes.Styles["date"];

            grfRes.Cols[colID].Width = 60;

            grfRes.Cols[colCode].Width = 80;
            grfRes.Cols[colName].Width = 300;

            grfRes.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRes.Cols[colCode].Caption = "รหัส";
            grfRes.Cols[colName].Caption = "ชื่อร้าน";
            grfRes.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfRes.GetCellRange(2, colE);
            for (int i = 1; i < grfRes.Rows.Count; i++)
            {
                grfRes[i, 0] = i;
                if (i % 2 == 0)
                    grfRes.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfRes.Cols[colID].Visible = false;
            grfRes.Cols[colE].Visible = false;
            grfRes.Cols[colS].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = mposC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtResCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtResCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtResNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtResNameT.Enter += new System.EventHandler(this.textBox_Enter);

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
            res = mposC.mposDB.resDB.selectByPk1(posiId);
            txtID.Value = res.res_id;
            txtResCode.Value = res.res_code;
            txtResNameT.Value = res.res_name;
            txtRemark.Value = res.remark;
            txtBillHeader1.Value = res.receipt_header1;
            txtBillHeader2.Value = res.receipt_header2;
            txtBillHeader3.Value = res.receipt_header3;
            txtBillFooter1.Value = res.receipt_footer1;
            txtBillFooter2.Value = res.receipt_footer2;
            txtBillFooter3.Value = res.receipt_footer3;
            txtTaxId.Value = res.tax_id;
            chkDefaultRes.Checked = res.default_res.Equals("1") ? true : false;
            //if (res.status_togo.Equals("1"))
            //{
            //    chkStatusTakeOut.Checked = true;
            //}
            //else
            //{
            //    chkStatusTakeOut.Checked = false;
            //}
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
            cboCop.Enabled = flag;
            txtResCode.Enabled = flag;
            txtResNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
            txtResNameT.Enabled = flag;
            txtTaxId.Enabled = flag;
            groupBox1.Enabled = flag;
        }

        private void setRestaurant()
        {
            res.res_id = txtID.Text;
            res.res_code = txtResCode.Text;
            res.res_name = txtResNameT.Text;
            //posi.posi_name_e = txtPosiNameE.Text;
            res.remark = txtRemark.Text;
            res.receipt_header1 = txtBillHeader1.Text;
            res.receipt_header2 = txtBillHeader2.Text;
            res.receipt_header3 = txtBillHeader3.Text;
            res.receipt_footer1 = txtBillFooter1.Text;
            res.receipt_footer2 = txtBillFooter2.Text;
            res.receipt_footer3 = txtBillFooter3.Text;
            res.cop_id = cboCop.SelectedItem == null ? "" : ((ComboBoxItem)cboCop.SelectedItem).Value;
            res.tax_id = txtTaxId.Text;
            res.default_res = chkDefaultRes.Checked == true ? "1" : "0";
            //area.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfRes[e.NewRange.r1, colID] != null ? grfRes[e.NewRange.r1, colID].ToString() : "";
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
            txtResCode.Value = "";
            txtResNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
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
                //mposC.mposDB.resDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfRestaurant();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setRestaurant();
                String re = mposC.mposDB.resDB.insertRestaurant(res, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfRestaurant();
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
        private void FrmArea_Load(object sender, EventArgs e)
        {

        }
    }
}
