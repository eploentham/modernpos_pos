using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using modernpos_pos.control;
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
    public partial class FrmMatrDrawView : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfMatd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        int colID = 1, colcode = 2, colDate = 3, colRemark = 4, colEdit = 5;
        public FrmMatrDrawView(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();

            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(panel2, mposC.iniC.themeApplication);
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel1.Controls)
            {
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }
            mposC.mposDB.matdDB.setCboYear(cboYear);

            btnNew.Click += BtnNew_Click;

            initGrfMatr();
            setGrfMatr();
            sB1.Text = "";
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMatrDrawAdd frm = new FrmMatrDrawAdd(mposC, "");
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            setGrfMatr();
            this.Show();
        }

        private void initGrfMatr()
        {
            grfMatd = new C1FlexGrid();
            grfMatd.Font = fEdit;
            grfMatd.Dock = System.Windows.Forms.DockStyle.Fill;
            grfMatd.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfMatr.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfMatr.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfMatd.DoubleClick += GrfMatd_DoubleClick;

            panel2.Controls.Add(this.grfMatd);

            //setControl();

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfMatd, theme);
        }

        private void GrfMatd_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfMatd.Row <= 0) return;
            if (grfMatd.Col <= 0) return;
            String id = "";
            id = grfMatd[grfMatd.Row, colID].ToString();
            FrmMatrDrawAdd frm = new FrmMatrDrawAdd(mposC, id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }
        private void setGrfMatr()
        {
            DataTable dt = new DataTable();
            dt = mposC.mposDB.matdDB.selectByYearId(cboYear.Text);

            grfMatd.Rows.Count = 1;
            grfMatd.Cols.Count = 6;
            grfMatd.Cols[colcode].Width = 60;
            grfMatd.Cols[colDate].Width = 60;
            grfMatd.Cols[colRemark].Width = 60;
            grfMatd.Cols[colcode].Caption = "รายการ";
            grfMatd.Cols[colDate].Caption = "ราคา";
            grfMatd.Cols[colRemark].Caption = "จำนวน";
            //grfMatr.Cols[colName].Editor = cboMethod;

            grfMatd.ShowCursor = true;
            if (dt.Rows.Count == 0) grfMatd.Rows.Count = 2;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfMatd.Rows.Add();
                row1[0] = i;
                row1[colID] = row[mposC.mposDB.matdDB.matd.matd_id].ToString();
                row1[colcode] = row[mposC.mposDB.matdDB.matd.matd_code].ToString();
                row1[colDate] = mposC.datetoShow(row[mposC.mposDB.matdDB.matd.matd_date].ToString());
                row1[colRemark] = row[mposC.mposDB.matdDB.matd.remark].ToString();
                row1[colEdit] = "0";
                if (i % 2 == 0)
                    row1.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfMatd.Cols[colID].Visible = false;
            grfMatd.Cols[colEdit].Visible = false;
            grfMatd.Cols[colcode].AllowEditing = false;
            grfMatd.Cols[colDate].AllowEditing = false;
            grfMatd.Cols[colRemark].AllowEditing = false;
        }
        private void FrmMatrDrawView_Load(object sender, EventArgs e)
        {

        }
    }
}
