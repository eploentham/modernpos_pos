using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
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
    public partial class FrmNoodleMake : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1, fgrd;

        Color bg, fc, tilecolor;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grfNoom, grfWatm;
        int colNId = 1, colNImg = 2, colNName = 3, colNStatusUs = 4, colNflag=5;
        Image imgChk;
        public FrmNoodleMake(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);
            fgrd = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 15, FontStyle.Regular);

            lbQtyShow.Text = "จำนวน";
            lbQty.Text = "1";
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.minus_red_100.Width;
            int newWidth = 40;
            resizedImage = Resources.minus_red_100.GetThumbnailImage(newWidth, (newWidth * Resources.minus_red_100.Height) / originalWidth, null, IntPtr.Zero);
            picMinus.Image = resizedImage;

            originalWidth = Resources.plus_green_100.Width;
            resizedImage = Resources.plus_green_100.GetThumbnailImage(newWidth, (newWidth * Resources.plus_green_100.Height) / originalWidth, null, IntPtr.Zero);
            picPlus.Image = resizedImage;
            picPlus.SizeMode = PictureBoxSizeMode.StretchImage;
            picMinus.SizeMode = PictureBoxSizeMode.StretchImage;
            imgChk = Resources.images;
            originalWidth = imgChk.Width;
            newWidth = 40;
            imgChk = imgChk.GetThumbnailImage(newWidth, (newWidth * imgChk.Height) / originalWidth, null, IntPtr.Zero);

            picMinus.Click += PicMinus_Click;
            picPlus.Click += PicPlus_Click;
            lbQty.Font = fEdit;
            lbQtyShow.Font = fEdit;

            initGrfNoom();
            setGrfNoom();
            initGrfWatm();
            setGrfWatm();
        }

        private void PicPlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbQty.Text = (int.Parse(lbQty.Text) + 1).ToString();
        }

        private void PicMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbQty.Text = (int.Parse(lbQty.Text) - 1).ToString();
        }
        private void initGrfWatm()
        {
            grfWatm = new C1FlexGrid();
            grfWatm.Font = fgrd;
            grfWatm.Dock = System.Windows.Forms.DockStyle.Fill;
            grfWatm.Location = new System.Drawing.Point(0, 0);
            //grfWatm.Rows[0].Visible = false;
            //grfWatm.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            //grfWatm.Cols[colNName].Caption = "FET";
            grfWatm.Cols[colNName].Width = 40;
            grfWatm.Click += GrfWatm_Click;
            //CellRange rng1 = grfWatm.GetCellRange(0, colNId, 0, colNflag);
            //rng1.Data = "Time";
            //FilterRow fr = new FilterRow(grfExpn);
            grfWatm.TabStop = false;
            //grfWatm.EditOptions = EditFlags.None;
            grfWatm.Cols[colNName].AllowEditing = false;

            panel10.Controls.Add(grfWatm);
            grfWatm.Cols[colNId].Visible = false;

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void GrfWatm_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfWatm.Row <= 0) return;
            if (grfWatm[grfWatm.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grfWatm.Row;
            chk = grfWatm[grfWatm.Row, colNStatusUs].ToString();
            foreach(Row row in grfWatm.Rows)
            {
                row[colNImg] = null;
                row[colNStatusUs] = "";
            }
            if (chk.Equals(""))
            {
                grfWatm[grfWatm.Row, colNImg] = imgChk;
                grfWatm[grfWatm.Row, colNStatusUs] = "1";
            }
            else
            {
                grfWatm[grfWatm.Row, colNImg] = null;
                grfWatm[grfWatm.Row, colNStatusUs] = "";
            }
        }

        private void setGrfWatm()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "<ul><align='center'>น้ำ</align></ul>";
            //c1SuperLabel2.Font = fEdit;
            grfWatm.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("water");
            grfWatm.Cols.Count = 6;
            grfWatm.Rows.Count = 1;
            grfWatm.Rows[0].Visible = false;
            grfWatm.Cols[0].Visible = false;
            grfWatm.SelectionMode = SelectionModeEnum.Row;
            //grfWatm.Cols[colNName].Caption = "FET";
            //CellRange rng1 = grfWatm.GetCellRange(0, colNImg, 0, colNName);
            //rng1.Data = "Time";
            //if (dt.Rows.Count > 0)
            //grfWatm.Rows[0].Visible = false;
            Column col = grfWatm.Cols[colNImg];
            col.DataType = typeof(Image);
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfWatm.Cols[1].Width = 60;

            grfWatm.Cols[colNName].Width = 220;
            grfWatm.Cols[colNImg].Width = 50;
            grfWatm.EditOptions = EditFlags.None;
            grfWatm.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            //grfWatm.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfWatm.Rows.Add();
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                row.StyleNew.BackColor = this.BackColor;
                row[colNflag] = "";
            }
            if (grfWatm.Rows.Count < 10)
            {
                for (int i = grfWatm.Rows.Count; i <= 8; i++)
                {
                    Row row = grfWatm.Rows.Add();
                    row.StyleNew.BackColor = this.BackColor;
                    row[colNStatusUs] = "";
                    row[colNflag] = "1";
                }
            }
            grfWatm.Cols[colNId].Visible = false;
            grfWatm.Cols[colNflag].Visible = false;
            grfWatm.Cols[colNStatusUs].Visible = false;
            grfWatm.Cols[colNName].AllowEditing = false;
            grfWatm.Cols[colNImg].AllowEditing = false;
            grfWatm.Cols[colNImg].AllowSorting = false;
            grfWatm.Cols[colNName].AllowSorting = false;
            grfWatm.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            //grfWatm.EditOptions = EditFlags.None;
            grfWatm.TabStop = false;
            grfWatm.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //pageLoad = false;
        }
        private void initGrfNoom()
        {
            grfNoom = new C1FlexGrid();
            grfNoom.Font = fgrd;
            grfNoom.Dock = System.Windows.Forms.DockStyle.Fill;
            grfNoom.Location = new System.Drawing.Point(0, 0);
            grfNoom.Rows[0].Visible = false;
            grfNoom.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grfNoom.Cols[colNName].Width = 40;
            grfNoom.Click += GrfNoom_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grfNoom.TabStop = false;
            grfNoom.EditOptions = EditFlags.None;
            grfNoom.Cols[colNName].AllowEditing = false;

            panel8.Controls.Add(grfNoom);
            grfNoom.Cols[colNId].Visible = false;
            CellRange rng1 = grfNoom.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void GrfNoom_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfNoom.Row <= 0) return;
            if (grfNoom[grfNoom.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grfNoom.Row;
            chk = grfNoom[grfNoom.Row, colNStatusUs].ToString();
            foreach (Row row in grfNoom.Rows)
            {
                row[colNImg] = null;
                row[colNStatusUs] = "";
            }
            if (chk.Equals(""))
            {
                grfNoom[grfNoom.Row, colNImg] = imgChk;
                grfNoom[grfNoom.Row, colNStatusUs] = "1";
            }
            else
            {
                grfNoom[grfNoom.Row, colNImg] = null;
                grfNoom[grfNoom.Row, colNStatusUs] = "";
            }
        }

        private void setGrfNoom()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grfNoom.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("noodle");
            grfNoom.Cols.Count = 6;
            grfNoom.Rows.Count = 1;
            grfNoom.Rows[0].Visible = false;
            grfNoom.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grfNoom.Rows[0].Visible = false;
            Column col = grfNoom.Cols[colNImg];
            col.DataType = typeof(Image);
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfNoom.Cols[1].Width = 60;

            grfNoom.Cols[colNName].Width = 220;
            grfNoom.Cols[colNImg].Width = 50;
            grfNoom.EditOptions = EditFlags.None;
            grfNoom.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfNoom.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfNoom.Rows.Add();
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                row.StyleNew.BackColor = this.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            if(grfNoom.Rows.Count < 10)
            {
                for(int i = grfNoom.Rows.Count; i <= 8; i++)
                {
                    Row row = grfNoom.Rows.Add();
                    row.StyleNew.BackColor = this.BackColor;
                    row[colNStatusUs] = "";
                    row[colNflag] = "1";
                }
            }
            grfNoom.Cols[colNId].Visible = false;
            grfNoom.Cols[colNflag].Visible = false;
            grfNoom.Cols[colNStatusUs].Visible = false;
            grfNoom.Cols[colNName].AllowEditing = false;
            grfNoom.Cols[colNImg].AllowEditing = false;
            grfNoom.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfNoom.EditOptions = EditFlags.None;
            grfNoom.TabStop = false;
            grfNoom.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //pageLoad = false;
        }
        private void FrmNoodleMake_Load(object sender, EventArgs e)
        {

        }
    }
}
