using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmMaterialType : Form
    {
        mPOSControl mposC;
        MaterialType fooT;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfFooT;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmMaterialType(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fooT = new MaterialType();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(panel3, mposC.iniC.themeApplication);
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }

            bg = txtAreaCode.BackColor;
            fc = txtAreaCode.ForeColor;
            ff = txtAreaCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnNew.Click += BtnNew_Click;
            btnEdit.Click += BtnEdit_Click;
            btnVoid.Click += BtnVoid_Click;
            btnSave.Click += BtnSave_Click;

            initGrfMaterialType();
            setGrfMaterialType();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setMaterialType();
                String re = mposC.mposDB.mattDB.insertFoodsMaterial(fooT, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfMaterialType();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                mposC.mposDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfMaterialType();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            flagEdit = true;
            setControlEnable(flagEdit);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtID.Value = "";
            txtAreaCode.Value = "";
            txtFooTNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            setControlEnable(true);
        }

        private void initGrfMaterialType()
        {
            grfFooT = new C1FlexGrid();
            grfFooT.Font = fEdit;
            grfFooT.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooT.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFooT.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfFooT.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfFooT.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel4.Controls.Add(this.grfFooT);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooT, theme);
        }
        private void setGrfMaterialType()
        {
            //grfDept.Rows.Count = 7;

            grfFooT.DataSource = mposC.mposDB.mattDB.selectAll();
            grfFooT.Cols.Count = colCnt;
            CellStyle cs = grfFooT.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFooT.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFooT.Cols[colE].Style = grfFooT.Styles["btn"];
            grfFooT.Cols[colS].Style = grfFooT.Styles["date"];

            grfFooT.Cols[colID].Width = 60;

            grfFooT.Cols[colCode].Width = 80;
            grfFooT.Cols[colName].Width = 300;

            grfFooT.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooT.Cols[colCode].Caption = "รหัส";
            grfFooT.Cols[colName].Caption = "ชื่อประเภท Material";
            grfFooT.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFooT.GetCellRange(2, colE);
            for (int i = 1; i < grfFooT.Rows.Count; i++)
            {
                grfFooT[i, 0] = i;
                if (i % 2 == 0)
                    grfFooT.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfFooT.Cols[colID].Visible = false;
            grfFooT.Cols[colE].Visible = false;
            grfFooT.Cols[colS].Visible = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = mposC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtAreaCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtAreaCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFooTNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFooTNameT.Enter += new System.EventHandler(this.textBox_Enter);

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
            fooT = mposC.mposDB.mattDB.selectByPk1(posiId);
            txtID.Value = fooT.material_type_id;
            txtAreaCode.Value = fooT.material_type_code;
            txtFooTNameT.Value = fooT.material_type_name;
            txtRemark.Value = fooT.remark;
            //if (fooT.status_aircondition.Equals("1"))
            //{
            //    chkStatusAirCondition.Checked = true;
            //}
            //else
            //{
            //    chkStatusAirCondition.Checked = false;
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
            txtAreaCode.Enabled = flag;
            txtFooTNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }
        private void setMaterialType()
        {
            fooT.material_type_id = txtID.Text;
            fooT.material_type_code = txtAreaCode.Text;
            fooT.material_type_name = txtFooTNameT.Text.Trim();
            //posi.posi_name_e = txtPosiNameE.Text;
            fooT.remark = txtRemark.Text;
            //fooT.status_aircondition = chkStatusAirCondition.Checked == true ? "1" : "0";
            //area.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfFooT[e.NewRange.r1, colID] != null ? grfFooT[e.NewRange.r1, colID].ToString() : "";
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
                if (userIdVoid.Length > 0)
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
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
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
        private void FrmMaterialType_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabType;
        }
    }
}
