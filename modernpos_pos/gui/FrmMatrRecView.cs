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
    public partial class FrmMatrRecView : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfMatr;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        int colID = 1, colcode = 2, colDate = 3, colRemark = 4, colEdit = 5;
        public FrmMatrRecView(mPOSControl x)
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
            mposC.mposDB.matrDB.setCboYear(cboYear);

            btnNew.Click += BtnNew_Click;

            initGrfMatr();
            setGrfMatr();
            sB1.Text = "";
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMatrRecAdd frm = new FrmMatrRecAdd(mposC, "");
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            setGrfMatr();
            this.Show();
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
            grfMatr.DoubleClick += GrfMatr_DoubleClick;

            panel2.Controls.Add(this.grfMatr);

            //setControl();

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfMatr, theme);
        }

        private void GrfMatr_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfMatr.Row <= 0) return;
            if (grfMatr.Col <= 0) return;
            String id = "";
            id = grfMatr[grfMatr.Row, colID].ToString();
            FrmMatrRecAdd frm = new FrmMatrRecAdd(mposC, id);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }
        private void setGrfMatr()
        {
            DataTable dt = new DataTable();
            dt = mposC.mposDB.matrDB.selectByYearId(cboYear.Text);

            grfMatr.Rows.Count = 1;
            grfMatr.Cols.Count = 6;
            grfMatr.Cols[colcode].Width = 60;
            grfMatr.Cols[colDate].Width = 60;
            grfMatr.Cols[colRemark].Width = 60;
            grfMatr.Cols[colcode].Caption = "รายการ";
            grfMatr.Cols[colDate].Caption = "ราคา";
            grfMatr.Cols[colRemark].Caption = "จำนวน";
            //grfMatr.Cols[colName].Editor = cboMethod;

            grfMatr.ShowCursor = true;
            if (dt.Rows.Count == 0) grfMatr.Rows.Count = 2;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                i++;
                Row row1 = grfMatr.Rows.Add();
                row1[0] = i;
                row1[colID] = row[mposC.mposDB.matrDB.matr.matr_id].ToString();
                row1[colcode] = row[mposC.mposDB.matrDB.matr.matr_code].ToString();
                row1[colDate] = mposC.datetoShow(row[mposC.mposDB.matrDB.matr.matr_date].ToString());
                row1[colRemark] = row[mposC.mposDB.matrDB.matr.remark].ToString();
                row1[colEdit] = "0";
                if (i % 2 == 0)
                    row1.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfMatr.Cols[colID].Visible = false;
            grfMatr.Cols[colEdit].Visible = false;
            grfMatr.Cols[colcode].AllowEditing = false;
            grfMatr.Cols[colDate].AllowEditing = false;
            grfMatr.Cols[colRemark].AllowEditing = false;
        }
        private void FrmMatrView_Load(object sender, EventArgs e)
        {

        }
    }
}
