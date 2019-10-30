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
    public partial class FrmMatrDrawAdd : Form
    {
        mPOSControl mposC;
        MaterialDraw matd;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfMatd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1ComboBox cboMethod;

        int colID = 1, colName = 2, colPrice = 3, colQty = 4, colRemark = 5, colEdit = 6;

        String userIdVoid = "", matd_id = "";
        public FrmMatrDrawAdd(mPOSControl x, String matrid)
        {
            InitializeComponent();
            mposC = x;
            matd_id = matrid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            matd = new MaterialDraw();

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(panel2, mposC.iniC.themeApplication);
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel2.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }
            txtMatrDate.Value = System.DateTime.Now.Year + "-" + System.DateTime.Now.ToString("MM-dd");
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

            initGrfMatd();
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
                re = mposC.mposDB.matDB.genMaterialDraw(txtMatdId.Text);
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
                re = mposC.mposDB.matdDB.Void(txtMatdId.Text, "");
                if (long.TryParse(re, out chk))
                {
                    mposC.mposDB.matddDB.voidMatd(txtMatdId.Text, "");
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
            setMatd();
            String re = mposC.mposDB.matdDB.insertMatrDraw(matd, "");
            if (long.TryParse(re, out chk))
            {
                if (txtMatdId.Text.Length == 0 && chk > 1)
                {
                    txtMatdId.Value = re;
                    matd_id = re;
                }
                int i = 0;
                foreach (Row row in grfMatd.Rows)
                {
                    String matrid = "", matrdid = "", price = "", qty = "", edit = "", matrname = "";
                    matrdid = row[colID] != null ? row[colID].ToString() : "";
                    matrname = row[colName] != null ? row[colName].ToString() : "";
                    price = row[colPrice] != null ? row[colPrice].ToString() : "";
                    qty = row[colQty] != null ? row[colQty].ToString() : "";
                    edit = row[colEdit] != null ? row[colEdit].ToString() : "";
                    if (!edit.Equals("1")) continue;
                    matrid = mposC.mposDB.matDB.getMatridByName(matrname);
                    if (matrid.Equals("")) continue;
                    i++;
                    MaterialDrawDetail matdd = new MaterialDrawDetail();
                    matdd.matd_detail_id = matrdid;
                    matdd.weight = "";
                    matdd.matd_id = txtMatdId.Text;
                    matdd.active = "";
                    matdd.remark = "";
                    matdd.sort1 = "";
                    matdd.date_cancel = "";
                    matdd.date_create = "";
                    matdd.date_modi = "";
                    matdd.user_cancel = "";
                    matdd.user_create = "";
                    matdd.user_modi = "";
                    matdd.host_id = "";
                    matdd.branch_id = "";
                    matdd.device_id = "";
                    matdd.price = price;
                    matdd.qty = qty;
                    matdd.material_id = matrid;
                    matdd.row1 = i.ToString();
                    mposC.mposDB.matddDB.insertMaterialDraw(matdd, "");
                }
                setControl();
            }
        }
        private void setMatd()
        {
            matd.matd_id = txtMatdId.Text;
            if (txtMatdId.Text.Length == 0)
            {
                matd.matd_code = mposC.mposDB.copDB.genMatDrawDoc();
            }
            else
            {
                matd.matd_code = txtMatdCode.Text.Trim();
            }
            matd.matd_date = mposC.datetoDB(txtMatrDate.Text);
            matd.active = "acive";
            matd.remark = txtRemark.Text.Trim();
            matd.sort1 = "";
            matd.date_cancel = "";
            matd.date_create = "";
            matd.date_modi = "";
            matd.user_cancel = "";
            matd.user_create = "";
            matd.user_modi = "";
            matd.host_id = "";
            matd.branch_id = "";
            matd.device_id = "";
        }
        private void initGrfMatd()
        {
            grfMatd = new C1FlexGrid();
            grfMatd.Font = fEdit;
            grfMatd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfMatd.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfMatr.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfMatr.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfMatr.CellChanged += GrfMatr_CellChanged;
            grfMatd.AfterEdit += GrfMatd_AfterEdit;

            panel2.Controls.Add(this.grfMatd);

            setControl();

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfMatd, theme);
        }

        private void GrfMatd_AfterEdit(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colName)
            {
                grfMatd[e.Row, colEdit] = "1";
                grfMatd.Rows.Add();
            }
            else if (e.Col == colPrice)
            {
                grfMatd[e.Row, colEdit] = "1";
            }
            else if (e.Col == colQty)
            {
                grfMatd[e.Row, colEdit] = "1";
            }
        }

        private void GrfMatr_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void setControl()
        {
            matd = mposC.mposDB.matdDB.selectByPk1(matd_id);
            txtMatdId.Value = matd.matd_id;
            if (matd.matd_date.Length > 0)
            {
                txtMatrDate.Value = mposC.datetoShow(matd.matd_date);
            }
            txtRemark.Value = matd.remark;
            txtMatdCode.Value = matd.matd_code;

            setGrfMatd();
        }
        private void setGrfMatd()
        {
            DataTable dt = new DataTable();
            dt = mposC.mposDB.matddDB.selectByMatrId(matd_id);

            grfMatd.Rows.Count = 1;
            grfMatd.Cols.Count = 7;
            grfMatd.Cols[colName].Width = 200;
            grfMatd.Cols[colPrice].Width = 80;
            grfMatd.Cols[colQty].Width = 90;
            grfMatd.Cols[colRemark].Width = 200;
            grfMatd.Cols[colName].Caption = "รายการ";
            grfMatd.Cols[colPrice].Caption = "ราคา";
            grfMatd.Cols[colQty].Caption = "จำนวน";
            grfMatd.Cols[colRemark].Caption = "หมายเหตุ";
            grfMatd.Cols[colName].Editor = cboMethod;

            grfMatd.ShowCursor = true;
            if (dt.Rows.Count == 0) grfMatd.Rows.Count = 2;
            int i = 0;
            grfMatd.Rows.Count = dt.Rows.Count + 2;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfMatd.Rows[i];
                row1[0] = i;
                row1[colID] = row[mposC.mposDB.matddDB.matdd.matd_detail_id].ToString();
                row1[colName] = mposC.mposDB.matDB.getList(row[mposC.mposDB.matrdDB.matrd.material_id].ToString());
                row1[colPrice] = row[mposC.mposDB.matrdDB.matrd.price].ToString();
                row1[colQty] = row[mposC.mposDB.matrdDB.matrd.qty].ToString();
                row1[colRemark] = row[mposC.mposDB.matrdDB.matrd.remark].ToString();
                row1[colEdit] = "0";
                if (i % 2 == 0)
                    row1.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfMatd.Cols[colID].Visible = false;
            grfMatd.Cols[colPrice].Visible = false;
        }
        private void FrmMatrDrawAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
