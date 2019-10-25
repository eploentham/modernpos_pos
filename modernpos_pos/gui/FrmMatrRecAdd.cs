using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using modernpos_pos.control;
using modernpos_pos.object1;
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
    public partial class FrmMatrRecAdd : Form
    {
        mPOSControl mposC;
        MaterialRec matr;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfMatr;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1ComboBox cboMethod;

        int colID = 1, colName = 2, colPrice = 3, colQty = 4, colRemark=5, colEdit=6;

        String userIdVoid = "", matr_id="";
        public FrmMatrRecAdd(mPOSControl x, String matrid)
        {
            InitializeComponent();
            mposC = x;
            matr_id = matrid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            matr = new MaterialRec();

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(panel2, mposC.iniC.themeApplication);
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }
            txtMatrDate.Value = System.DateTime.Now.Year +"-"+System.DateTime.Now.ToString("MM-dd");
            cboMethod = new C1ComboBox();
            cboMethod.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMethod.AutoCompleteSource = AutoCompleteSource.ListItems;
            mposC.mposDB.matDB.setCboMaterial(cboMethod, "");
            btnVoid.Hide();
            txtPasswordVoid.Hide();

            btnSave.Click += BtnSave_Click;
            chkVoid.CheckedChanged += ChkVoid_CheckedChanged;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnVoid.Click += BtnVoid_Click;
            btnDoc.Click += BtnDoc_Click;

            initGrfMatr();
            sB1.Text = "";
        }

        private void BtnDoc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ Update Stock material ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //ic.ivfDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                long chk = 0;
                String re = "";
                re = mposC.mposDB.matDB.genMaterialRec(txtMatrId.Text);
                if (long.TryParse(re, out chk))
                {
                    btnDoc.Enabled = false;
                    MessageBox.Show("gen stock เรียบร้อย", "");
                    //mposC.mposDB.matrdDB.voidMatr(txtMatrId.Text, "");
                }
                //setGrfAgent();
            }
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                //ic.ivfDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                long chk = 0;
                String re = "";
                re = mposC.mposDB.matrDB.Void(txtMatrId.Text,"");
                if (long.TryParse(re, out chk))
                {
                    mposC.mposDB.matrdDB.voidMatr(txtMatrId.Text, "");
                }
                //setGrfAgent();
            }
        }

        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = "";
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

        private void ChkVoid_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (chkVoid.Checked)
            {
                txtPasswordVoid.Show();
            }
            else
            {
                txtPasswordVoid.Hide();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            long chk = 0;
            setMatr();
            String re = mposC.mposDB.matrDB.insertMatarialRec(matr, "");
            if(long.TryParse(re, out chk))
            {
                if(txtMatrId.Text.Length==0 && chk > 1)
                {
                    txtMatrId.Value = re;
                    matr_id = re;
                }
                int i = 0;
                foreach(Row row in grfMatr.Rows)
                {
                    String matrid = "", matrdid="", price="", qty="", edit="", matrname="";
                    matrdid = row[colID] != null ? row[colID].ToString() : "";
                    matrname = row[colName] != null ? row[colName].ToString() : "";
                    price = row[colPrice] != null ? row[colPrice].ToString() : "";
                    qty = row[colQty] != null ? row[colQty].ToString() : "";
                    edit = row[colEdit] != null ? row[colEdit].ToString() : "";
                    if (!edit.Equals("1")) continue;
                    matrid = mposC.mposDB.matDB.getMatridByName(matrname);
                    if (matrid.Equals("")) continue;
                    i++;
                    MaterialRecDetail matrd = new MaterialRecDetail();
                    matrd.matr_detail_id = matrdid;
                    matrd.weight = "";
                    matrd.matr_id = txtMatrId.Text;
                    matrd.active = "";
                    matrd.remark = "";
                    matrd.sort1 = "";
                    matrd.date_cancel = "";
                    matrd.date_create = "";
                    matrd.date_modi = "";
                    matrd.user_cancel = "";
                    matrd.user_create = "";
                    matrd.user_modi = "";
                    matrd.host_id = "";
                    matrd.branch_id = "";
                    matrd.device_id = "";
                    matrd.price = price;                    
                    matrd.qty = qty;
                    matrd.material_id = matrid;
                    matrd.row1 = i.ToString();
                    mposC.mposDB.matrdDB.insertFoodsMaterial(matrd, "");
                }
                setControl();
            }
        }
        private void setMatr()
        {
            matr.matr_id = txtMatrId.Text;
            if (txtMatrId.Text.Length == 0)
            {
                matr.matr_code = mposC.mposDB.copDB.genMatRecDoc();
            }
            else
            {
                matr.matr_code = txtMatrCode.Text.Trim();
            }
            matr.matr_date = mposC.datetoDB(txtMatrDate.Text);
            matr.active = "acive";
            matr.remark = txtRemark.Text.Trim();
            matr.sort1 = "";
            matr.date_cancel = "";
            matr.date_create = "";
            matr.date_modi = "";
            matr.user_cancel = "";
            matr.user_create = "";
            matr.user_modi = "";
            matr.host_id = "";
            matr.branch_id = "";
            matr.device_id = "";
        }
        private void initGrfMatr()
        {
            grfMatr = new C1FlexGrid();
            grfMatr.Font = fEdit;
            grfMatr.Dock = System.Windows.Forms.DockStyle.Fill;
            grfMatr.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfMatr.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfMatr.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfMatr.CellChanged += GrfMatr_CellChanged;
            grfMatr.AfterEdit += GrfMatr_AfterEdit;

            panel2.Controls.Add(this.grfMatr);

            setControl();

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfMatr, theme);
        }

        private void GrfMatr_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colName)
            {
                grfMatr[e.Row, colEdit] = "1";
                grfMatr.Rows.Add();
            }
            else if (e.Col == colPrice)
            {
                grfMatr[e.Row, colEdit] = "1";
            }
            else if (e.Col == colQty)
            {
                grfMatr[e.Row, colEdit] = "1";
            }
        }

        private void GrfMatr_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            
        }

        private void setControl()
        {
            matr = mposC.mposDB.matrDB.selectByPk1(matr_id);
            txtMatrId.Value = matr.matr_id;
            if (matr.matr_date.Length > 0)
            {
                txtMatrDate.Value = mposC.datetoShow(matr.matr_date);
            }
            txtRemark.Value = matr.remark;
            txtMatrCode.Value = matr.matr_code;

            setGrfMatr();
        }
        private void setGrfMatr()
        {
            DataTable dt = new DataTable();
            dt = mposC.mposDB.matrdDB.selectByMatrId(matr_id);

            grfMatr.Rows.Count = 1;
            grfMatr.Cols.Count = 7;
            grfMatr.Cols[colName].Width = 200;
            grfMatr.Cols[colPrice].Width = 80;
            grfMatr.Cols[colQty].Width = 90;
            grfMatr.Cols[colRemark].Width = 200;
            grfMatr.Cols[colName].Caption = "รายการ";
            grfMatr.Cols[colPrice].Caption = "ราคา";
            grfMatr.Cols[colQty].Caption = "จำนวน";
            grfMatr.Cols[colRemark].Caption = "หมายเหตุ";
            grfMatr.Cols[colName].Editor = cboMethod;

            grfMatr.ShowCursor = true;
            if(dt.Rows.Count==0) grfMatr.Rows.Count = 2;
            int i = 0;
            grfMatr.Rows.Count = dt.Rows.Count+2;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfMatr.Rows[i];
                row1[0] = i;
                row1[colID] = row[mposC.mposDB.matrdDB.matrd.matr_detail_id].ToString();
                row1[colName] = mposC.mposDB.matDB.getList(row[mposC.mposDB.matrdDB.matrd.material_id].ToString());
                row1[colPrice] = row[mposC.mposDB.matrdDB.matrd.price].ToString();
                row1[colQty] = row[mposC.mposDB.matrdDB.matrd.qty].ToString();
                row1[colRemark] = row[mposC.mposDB.matrdDB.matrd.remark].ToString();
                row1[colEdit] = "0";
                if (i % 2 == 0)
                    row1.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfMatr.Cols[colID].Visible = false;
        }
        private void FrmMatr_Load(object sender, EventArgs e)
        {

        }
    }
}
