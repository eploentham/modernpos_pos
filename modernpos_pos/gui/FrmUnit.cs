using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmUnit : Form
    {
        mPOSControl mposC;
        Unit unit;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colCalUnit=4, colRemark = 5, colE = 6, colS = 7, coledit = 8, colCnt = 9;

        C1FlexGrid grfFooT;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String userIdVoid = "";
        public FrmUnit(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            unit = new Unit();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(panel1, mposC.iniC.themeApplication);
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
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

            initGrfUnit();
            setGrfUnit();
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
            Decimal chk1 = 0;
            if(!Decimal.TryParse(txtCalUnit.Text.Trim(), out chk1))
            {
                MessageBox.Show("หน่วยคำนวณไปหา กรัม ไม่ถูกต้อง", "");
                return;
            }
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setUnit();
                String re = mposC.mposDB.unitDB.insertUnit(unit, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfUnit();
                //setGrdView();
                //this.Dispose();
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                mposC.mposDB.unitDB.VoidUnit(txtID.Text, userIdVoid);
                setGrfUnit();
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

        private void initGrfUnit()
        {
            grfFooT = new C1FlexGrid();
            grfFooT.Font = fEdit;
            grfFooT.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooT.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFooT.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfFooT.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfFooT.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel2.Controls.Add(this.grfFooT);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooT, theme);
        }
        private void setGrfUnit()
        {
            //grfDept.Rows.Count = 7;
            DataTable dt = new DataTable();
            dt = mposC.mposDB.unitDB.selectAll();
            grfFooT.Cols.Count = colCnt;
            grfFooT.Rows.Count = 1;
            grfFooT.Rows.Count = dt.Rows.Count + 1;

            grfFooT.Cols[colE].Style = grfFooT.Styles["btn"];
            grfFooT.Cols[colS].Style = grfFooT.Styles["date"];

            grfFooT.Cols[colID].Width = 60;

            grfFooT.Cols[colCode].Width = 80;
            grfFooT.Cols[colName].Width = 300;
            grfFooT.Cols[colCalUnit].Width = 100;

            grfFooT.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooT.Cols[colCode].Caption = "รหัส";
            grfFooT.Cols[colName].Caption = "ชื่อUnit";
            grfFooT.Cols[colCalUnit].Caption = "คำนวณ";
            grfFooT.Cols[colRemark].Caption = "หมายเหตุ";

            int i = 1;
            foreach(DataRow row in dt.Rows)
            {
                grfFooT[i, 0] = i;
                grfFooT[i, colID] = row[mposC.mposDB.unitDB.unit.unit_id].ToString();
                grfFooT[i, colCode] = row[mposC.mposDB.unitDB.unit.unit_code].ToString();
                grfFooT[i, colName] = row[mposC.mposDB.unitDB.unit.unit_name].ToString();
                grfFooT[i, colRemark] = row[mposC.mposDB.unitDB.unit.remark].ToString();
                grfFooT[i, colCalUnit] = row[mposC.mposDB.unitDB.unit.cal_unit].ToString();
                if (i % 2 == 0)
                    grfFooT.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                i++;
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
            unit = mposC.mposDB.unitDB.selectByPk1(posiId);
            txtID.Value = unit.unit_id;
            txtAreaCode.Value = unit.unit_code;
            txtFooTNameT.Value = unit.unit_name;
            txtRemark.Value = unit.remark;
            txtCalUnit.Value = unit.cal_unit;
            lbDesc.Text = "กรัม เป็น 1 " + txtFooTNameT.Text;
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
        private void setUnit()
        {
            unit.unit_id = txtID.Text;
            unit.unit_code = txtAreaCode.Text;
            unit.unit_name = txtFooTNameT.Text.Trim();
            //posi.posi_name_e = txtPosiNameE.Text;
            unit.remark = txtRemark.Text;
            unit.cal_unit = txtCalUnit.Text;
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
        private void FrmUnit_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabUnit;
            sC1.HeaderHeight = 0;
        }
    }
}
