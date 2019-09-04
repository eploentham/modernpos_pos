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
using System.IO;

namespace modernpos_pos.gui
{
    public partial class FrmCFoodsCat : Form
    {
        mPOSControl mposC;
        FoodsCat fooC;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;

        C1FlexGrid grfFooC;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false, pageLoad = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCFoodsCat(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }

        private void initConfig()
        {
            fooC = new FoodsCat();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                if (c is C1PictureBox) continue;
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }

            bg = txtAreaCode.BackColor;
            fc = txtAreaCode.ForeColor;
            ff = txtAreaCode.Font;
            btnImg.Click += BtnImg_Click;

            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;

            initGrfFoodsCat();
            setGrfFoodsCat();
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Length <= 0) return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    mposC.savePicFoodsCattoServer(txtID.Text, ofd.FileName);
                    showImg();
                }
            }
        }
        private void showImg()
        {
            if (pageLoad) return;
            try
            {
                picFoo.Image = null;
                MemoryStream stream = new MemoryStream();
                Image loadedImage = null, resizedImage;
                if (fooC.filename.Equals("")) return;
                string ext = Path.GetExtension(fooC.filename);
                String filename = "/foods/" + fooC.filename.Replace(ext, "") + "_210" + ext;
                stream = mposC.ftpC.download(mposC.iniC.ShareFile + filename);
                loadedImage = new Bitmap(stream);
                if (loadedImage != null)
                {
                    int originalWidth = loadedImage.Width;
                    int newWidth = 210;
                    resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                    picFoo.Image = resizedImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "showImg");
            }
        }
        private void initGrfFoodsCat()
        {
            grfFooC = new C1FlexGrid();
            grfFooC.Font = fEdit;
            grfFooC.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooC.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFooC.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfFooC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfFooC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel4.Controls.Add(this.grfFooC);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooC, theme);
        }
        private void setGrfFoodsCat()
        {
            //grfDept.Rows.Count = 7;

            grfFooC.DataSource = mposC.mposDB.foocDB.selectAll();
            grfFooC.Cols.Count = colCnt;
            CellStyle cs = grfFooC.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFooC.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFooC.Cols[colE].Style = grfFooC.Styles["btn"];
            grfFooC.Cols[colS].Style = grfFooC.Styles["date"];

            grfFooC.Cols[colID].Width = 60;

            grfFooC.Cols[colCode].Width = 80;
            grfFooC.Cols[colName].Width = 300;

            grfFooC.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooC.Cols[colCode].Caption = "รหัส";
            grfFooC.Cols[colName].Caption = "ชื่อกลุ่ม อาหาร";
            grfFooC.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFooC.GetCellRange(2, colE);
            for (int i = 1; i < grfFooC.Rows.Count; i++)
            {
                grfFooC[i, 0] = i;
                if (i % 2 == 0)
                    grfFooC.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfFooC.Cols[colID].Visible = false;
            grfFooC.Cols[colE].Visible = false;
            grfFooC.Cols[colS].Visible = false;
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
            fooC = mposC.mposDB.foocDB.selectByPk1(posiId);
            txtID.Value = fooC.foods_cat_id;
            txtAreaCode.Value = fooC.foods_cat_code;
            txtFooTNameT.Value = fooC.foods_cat_name;
            txtRemark.Value = fooC.remark;
            chkRecommand.Value = fooC.status_recommand.Equals("0") ? true : false;
            showImg();
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

        

        private void setFoodsCat()
        {
            fooC.foods_cat_id = txtID.Text;
            fooC.foods_cat_code = txtAreaCode.Text;
            fooC.foods_cat_name = txtFooTNameT.Text;
            //posi.posi_name_e = txtPosiNameE.Text;
            fooC.remark = txtRemark.Text;
            fooC.status_recommand = chkRecommand.Checked == true ? "1" : "0";
            //area.status_embryologist = chkEmbryologist.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfFooC[e.NewRange.r1, colID] != null ? grfFooC[e.NewRange.r1, colID].ToString() : "";
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
            txtAreaCode.Value = "";
            txtFooTNameT.Value = "";
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
                mposC.mposDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfFoodsCat();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setFoodsCat();
                String re = mposC.mposDB.foocDB.insertFoodsCat(fooC, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfFoodsCat();
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
            tC.SelectedTab = tabAdd;
        }
    }
}
