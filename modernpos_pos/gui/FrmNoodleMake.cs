using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
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
        //C1SuperLabel lbNoom, lbWatm, lbOpt, lbGrf5, lbGrf6, lbGrf7, lbGrf8, lbFooName, lbPrice;
        Label lbNoom, lbWatm, lbOpt, lbGrf5, lbGrf6, lbGrf7, lbGrf8, lbFooName, lbPrice;
        C1FlexGrid grfNoom, grfWatm, grfOpt, grf5, grf6, grf7, grf8;
        int colNId = 1, colNImg = 2, colNName = 3, colNStatusUs = 4, colNflag=5,colNPrice=6;
        int colOId = 1, colOImgL = 2, colOName = 3, colOImgR=4, colOStatusUs = 5, colOflag = 6;
        Image imgChk, imgChkUn, imgChkNo;
        C1Button btnExit;
        String price = "";
        public FrmNoodleMake(mPOSControl x, String price)
        {
            InitializeComponent();
            mposC = x;
            this.price = price;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);
            fgrd = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 15, FontStyle.Regular);
            lbNoom = new Label();
            lbNoom.Dock = DockStyle.Fill;
            lbNoom.AutoSize = false;
            lbNoom.Text = "เส้น";
            lbNoom.Font = fEdit;
            //lbNoom.Location = new System.Drawing.Point(0, 0);
            lbNoom.TextAlign = ContentAlignment.MiddleCenter;
            lbNoom.Font = fEdit;
            //lbNoom.
            pnMid1T.Controls.Add(lbNoom);

            lbWatm = new Label();
            lbWatm.Dock = DockStyle.Fill;
            lbWatm.AutoSize = false;
            lbWatm.Text = "น้ำ";
            lbWatm.Font = fEdit;
            lbWatm.TextAlign = ContentAlignment.MiddleCenter;
            pnMid2T.Controls.Add(lbWatm);

            btnExit = new C1Button();
            btnExit.Dock = DockStyle.Fill;
            btnExit.AutoSize = false;
            btnExit.Text = "Exit";
            btnExit.Font = fEdit;
            btnExit.Click += BtnExit_Click;
            pnExit.Controls.Add(btnExit);

            lbOpt = new Label();
            lbOpt.Dock = DockStyle.Fill;
            lbOpt.AutoSize = false;
            lbOpt.Text = "รายละเอียด";
            lbOpt.Font = fEdit;
            lbOpt.TextAlign = ContentAlignment.MiddleCenter;
            pnMid3T.Controls.Add(lbOpt);

            lbGrf5 = new Label();
            lbGrf5.Dock = DockStyle.Fill;
            lbGrf5.AutoSize = false;
            lbGrf5.Text = "ลูกชิ้น/เกี๊ยว";
            lbGrf5.Font = fEdit;
            lbGrf5.TextAlign = ContentAlignment.MiddleCenter;
            pnMid5T.Controls.Add(lbGrf5);

            lbGrf6 = new Label();
            lbGrf6.Dock = DockStyle.Fill;
            lbGrf6.AutoSize = false;
            lbGrf6.Text = "ทะเล";
            lbGrf6.Font = fEdit;
            lbGrf6.TextAlign = ContentAlignment.MiddleCenter;
            pnMid6T.Controls.Add(lbGrf6);

            lbGrf7 = new Label();
            lbGrf7.Dock = DockStyle.Fill;
            lbGrf7.AutoSize = false;
            lbGrf7.Text = "หมู/เป็ด/ไก่";
            lbGrf7.Font = fEdit;
            lbGrf7.TextAlign = ContentAlignment.MiddleCenter;
            pnMid7T.Controls.Add(lbGrf7);

            lbGrf8 = new Label();
            lbGrf8.Dock = DockStyle.Fill;
            lbGrf8.AutoSize = false;
            lbGrf8.Text = "ผัก";
            lbGrf8.Font = fEdit;
            lbGrf8.TextAlign = ContentAlignment.MiddleCenter;
            pnMid8T.Controls.Add(lbGrf8);

            lbFooName = new Label();
            lbFooName.Dock = DockStyle.Fill;
            lbFooName.AutoSize = false;
            lbFooName.Text = "รายละเอียด";
            lbFooName.Font = fEdit;
            lbFooName.TextAlign = ContentAlignment.MiddleLeft;
            pnName.Controls.Add(lbFooName);

            lbPrice = new Label();
            lbPrice.Dock = DockStyle.Fill;
            lbPrice.AutoSize = false;
            lbPrice.Text = "";
            lbPrice.Font = fEdit;
            lbPrice.TextAlign = ContentAlignment.MiddleRight;
            pnPrice.Controls.Add(lbPrice);

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

            imgChkNo = Resources.close;
            originalWidth = imgChkNo.Width;
            newWidth = 40;
            imgChkNo = imgChkNo.GetThumbnailImage(newWidth, (newWidth * imgChkNo.Height) / originalWidth, null, IntPtr.Zero);

            imgChkUn = Resources.open48;
            originalWidth = imgChkUn.Width;
            newWidth = 40;
            imgChkUn = imgChkUn.GetThumbnailImage(newWidth, (newWidth * imgChkUn.Height) / originalWidth, null, IntPtr.Zero);

            picMinus.Click += PicMinus_Click;
            picPlus.Click += PicPlus_Click;
            lbQty.Font = fEdit;
            lbQtyShow.Font = fEdit;

            pnMid1G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn1g);
            pnMid1L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn1l);
            pnMid1T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn1t);
            pnMid2G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn2g);
            pnMid2L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn2l);
            pnMid2T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn2t);
            pnMid3G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn3g);
            pnMid3L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn3l);
            pnMid3T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn3t);
            pnMid4G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn4g);
            pnMid4L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn4l);
            pnMid4T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn4t);
            pnMid5G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn5g);
            pnMid5L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn5l);
            pnMid5T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn5t);
            pnMid6G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn6g);
            pnMid6L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn6l);
            pnMid6T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn6t);
            pnMid7G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn7g);
            pnMid7L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn7l);
            pnMid7T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn7t);
            pnMid8G.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn8g);
            pnMid8L.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn8l);
            pnMid8T.BackColor = ColorTranslator.FromHtml(mposC.iniC.noodlemakepn8t);

            initGrfNoom();
            setGrfNoom();
            initGrfWatm();
            setGrfWatm();
            initGrfOpt();
            setGrfOpt();
            initGrf5();
            initGrf6();
            initGrf7();
            initGrf8();
            setGrf8();
            setGrf7();
            setGrf6();
            setGrf5();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Dispose();
        }

        private void setFoodName()
        {
            Decimal price = 0, price5=0, price6=0, price7=0, price8=0, chk=0, pricefix=0;
            String fooname = "",fooname1 = "", fooname2 = "", fooname3 = "",fooname5 = "", fooname6 = "", fooname7 = "", fooname8 = "";
            mposC.NooId = "";
            mposC.NooName = "";
            mposC.NooPrice = "";
            mposC.NooQty = "";
            mposC.NooRemark = "";
            mposC.NooPrinter = "";
            Decimal.TryParse(this.price,out pricefix);
            foreach (Row row in grfNoom.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1")){
                    fooname1 = row[colNName].ToString();
                    break;
                }
            }
            foreach (Row row in grfWatm.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1"))
                {
                    fooname2 = row[colNName].ToString();
                    break;
                }
            }
            foreach (Row row in grfOpt.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colOStatusUs].Equals("1"))
                {
                    fooname3 += "เพิ่ม " + row[colNName].ToString();
                }
                else if (row[colOStatusUs].Equals("3"))
                {
                    fooname3 += "ไม่ใส่ " + row[colNName].ToString();
                }
            }
            foreach (Row row in grf5.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1"))
                {
                    fooname5 += row[colNName].ToString() + " ";
                    Decimal.TryParse(row[colNPrice].ToString(), out chk);
                    price5 += chk;
                    //break;
                }
            }
            foreach (Row row in grf6.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1"))
                {
                    fooname6 += row[colNName].ToString() + " ";
                    Decimal.TryParse(row[colNPrice].ToString(), out chk);
                    price6 += chk;
                    //break;
                }
            }
            foreach (Row row in grf7.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1"))
                {
                    fooname7 += row[colNName].ToString() + " ";
                    Decimal.TryParse(row[colNPrice].ToString(), out chk);
                    price7 += chk;
                    //break;
                }
            }
            foreach (Row row in grf8.Rows)
            {
                if (row[colNStatusUs] == null) continue;
                if (row[colNStatusUs].Equals("1"))
                {
                    fooname8 += row[colNName].ToString()+" ";
                    Decimal.TryParse(row[colNPrice].ToString(), out chk);
                    price8 += chk;
                    //break;
                }
            }
            price = pricefix + price5 + price6 + price7 + price8;
            fooname = fooname1 +" "+ fooname2 + " " + fooname3 + " " + fooname5 + " " + fooname6 + " " + fooname7 + " " + fooname8 ;
            lbFooName.Text = fooname;
            lbPrice.Text = price.ToString("#,###.00");
            mposC.NooId = "";
            mposC.NooName = fooname;
            mposC.NooPrice = lbPrice.Text;
            mposC.NooQty = lbQty.Text;
            mposC.NooRemark = "";
            mposC.NooPrinter = "";
            this.Focus();
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
            grfNoom.BackColor = pnMid1G.BackColor;
            grfNoom.Styles.Normal.BackColor = pnMid1G.BackColor;

            pnMid1G.Controls.Add(grfNoom);
            grfNoom.Cols[colNId].Visible = false;
            CellRange rng1 = grfNoom.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
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
            grfWatm.BackColor = pnMid2G.BackColor;
            //grfWatm.EditOptions = EditFlags.None;
            grfWatm.Cols[colNName].AllowEditing = false;

            pnMid2G.Controls.Add(grfWatm);
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
            setFoodName();
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
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = pnMid2G.BackColor;
                row[colNflag] = "";
            }
            //if (grfWatm.Rows.Count < 10)
            //{
            //    for (int i = grfWatm.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grfWatm.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
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
            CellStyle cs = null;
            cs = grfWatm.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = pnMid2G.BackColor;
            grfWatm.FocusRect = FocusRectEnum.None;
            grfWatm.SelectionMode = SelectionModeEnum.Cell;

            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grfWatm.HighLight = HighLightEnum.Never;
            //CellStyle cs = null;
            //cs.s
            //grfWatm.se
            //pageLoad = false;
        }
        private void initGrf5()
        {
            grf5 = new C1FlexGrid();
            grf5.Font = fgrd;
            grf5.Dock = System.Windows.Forms.DockStyle.Fill;
            grf5.Location = new System.Drawing.Point(0, 0);
            grf5.Rows[0].Visible = false;
            grf5.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grf5.Cols[colNName].Width = 40;
            grf5.Click += Grf5_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grf5.TabStop = false;
            grf5.EditOptions = EditFlags.None;
            grf5.Cols[colNName].AllowEditing = false;

            pnMid5G.Controls.Add(grf5);
            grf5.Cols[colNId].Visible = false;
            CellRange rng1 = grf5.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void Grf5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf5.Row <= 0) return;
            if (grf5[grf5.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grf5.Row;
            chk = grf5[grf5.Row, colNStatusUs].ToString();
            //foreach (Row row in grfNoom.Rows)
            //{
            //    row[colNImg] = null;
            //    row[colNStatusUs] = "";
            //}
            if (chk.Equals(""))
            {
                grf5[grf5.Row, colNImg] = imgChk;
                grf5[grf5.Row, colNStatusUs] = "1";
            }
            else
            {
                grf5[grf5.Row, colNImg] = null;
                grf5[grf5.Row, colNStatusUs] = "";
            }
            setFoodName();
        }


        private void setGrf5()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grf5.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("noodle_meat_ball");
            grf5.Cols.Count = 7;
            grf5.Rows.Count = 1;
            grf5.Rows[0].Visible = false;
            grf5.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grf5.Rows[0].Visible = false;
            Column col = grf5.Cols[colNImg];
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

            grf5.Cols[1].Width = 60;

            grf5.Cols[colNName].Width = 220;
            grf5.Cols[colNImg].Width = 50;
            grf5.Cols[colNPrice].Width = 100;
            grf5.EditOptions = EditFlags.None;
            grf5.ShowCursor = true;
            grf5.BackColor = pnMid5G.BackColor;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf5.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Decimal price = 0;
                Row row = grf5.Rows.Add();
                Decimal.TryParse(dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_price].ToString(), out price);
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                row[colNPrice] = price > 0 ? price.ToString("#,###.00") : "";
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = pnMid5G.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if (grf5.Rows.Count < 10)
            //{
            //    for (int i = grf5.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grf5.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
            grf5.Cols[colNId].Visible = false;
            grf5.Cols[colNflag].Visible = false;
            grf5.Cols[colNStatusUs].Visible = false;
            grf5.Cols[colNName].AllowEditing = false;
            grf5.Cols[colNImg].AllowEditing = false;
            grf5.Cols[colNPrice].AllowEditing = false;
            grf5.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grf5.EditOptions = EditFlags.None;
            grf5.TabStop = false;
            grf5.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //grfNoom.st
            CellStyle cs = null;
            cs = grf5.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = pnMid5G.BackColor;
            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grf5.HighLight = HighLightEnum.Never;
            grf5.FocusRect = FocusRectEnum.None;
            grf5.SelectionMode = SelectionModeEnum.Cell;
            //pageLoad = false;
        }
        private void initGrf6()
        {
            grf6 = new C1FlexGrid();
            grf6.Font = fgrd;
            grf6.Dock = System.Windows.Forms.DockStyle.Fill;
            grf6.Location = new System.Drawing.Point(0, 0);
            grf6.Rows[0].Visible = false;
            grf6.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grf6.Cols[colNName].Width = 40;
            grf6.Click += Grf6_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grf6.TabStop = false;
            grf6.EditOptions = EditFlags.None;
            grf6.BackColor = pnMid6G.BackColor;
            grf6.Cols[colNName].AllowEditing = false;
            grf6.Cols[colNPrice].AllowEditing = false;

            pnMid6G.Controls.Add(grf6);
            grf6.Cols[colNId].Visible = false;
            CellRange rng1 = grf6.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void Grf6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf6.Row <= 0) return;
            if (grf6[grf6.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grf6.Row;
            chk = grf6[grf6.Row, colNStatusUs].ToString();
            //foreach (Row row in grfNoom.Rows)
            //{
            //    row[colNImg] = null;
            //    row[colNStatusUs] = "";
            //}
            if (chk.Equals(""))
            {
                grf6[grf6.Row, colNImg] = imgChk;
                grf6[grf6.Row, colNStatusUs] = "1";
            }
            else
            {
                grf6[grf6.Row, colNImg] = null;
                grf6[grf6.Row, colNStatusUs] = "";
            }
            setFoodName();
        }

        private void setGrf6()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grf6.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("noodle_sea");
            grf6.Cols.Count = 7;
            grf6.Rows.Count = 1;
            grf6.Rows[0].Visible = false;
            grf6.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grf6.Rows[0].Visible = false;
            Column col = grf6.Cols[colNImg];
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

            grf6.Cols[1].Width = 60;

            grf6.Cols[colNName].Width = 220;
            grf6.Cols[colNImg].Width = 50;
            grf6.Cols[colNPrice].Width = 100;
            grf6.EditOptions = EditFlags.None;
            grf6.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf6.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Decimal price = 0;
                Row row = grf6.Rows.Add();
                Decimal.TryParse(dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_price].ToString(), out price);
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                if (price > 0)
                {
                    row[colNPrice] = price.ToString("#,###.00");
                }
                else
                {
                    row[colNPrice] = "";
                }
                //row[colNPrice] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_price].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = grf6.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if (grf6.Rows.Count < 10)
            //{
            //    for (int i = grf6.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grf6.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
            grf6.Cols[colNId].Visible = false;
            grf6.Cols[colNflag].Visible = false;
            grf6.Cols[colNStatusUs].Visible = false;

            grf6.Cols[colNName].AllowEditing = false;
            grf6.Cols[colNPrice].AllowEditing = false;
            grf6.Cols[colNImg].AllowEditing = false;
            grf6.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grf6.EditOptions = EditFlags.None;
            grf6.TabStop = false;
            grf6.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //grfNoom.st
            CellStyle cs = null;
            cs = grf6.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = grf6.BackColor;
            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grf6.HighLight = HighLightEnum.Never;
            grf6.FocusRect = FocusRectEnum.None;
            grf6.SelectionMode = SelectionModeEnum.Cell;
            //pageLoad = false;
        }
        private void initGrf8()
        {
            grf8 = new C1FlexGrid();
            grf8.Font = fgrd;
            grf8.Dock = System.Windows.Forms.DockStyle.Fill;
            grf8.Location = new System.Drawing.Point(0, 0);
            grf8.Rows[0].Visible = false;
            grf8.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grf8.Cols[colNName].Width = 40;
            grf8.Click += Grf8_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grf8.TabStop = false;
            grf8.EditOptions = EditFlags.None;
            grf8.BackColor = pnMid8G.BackColor;
            grf8.Cols[colNName].AllowEditing = false;

            pnMid8G.Controls.Add(grf8);
            grf8.Cols[colNId].Visible = false;
            CellRange rng1 = grf8.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void Grf8_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf8.Row <= 0) return;
            if (grf8[grf8.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grf8.Row;
            chk = grf8[grf8.Row, colNStatusUs].ToString();
            //foreach (Row row in grfNoom.Rows)
            //{
            //    row[colNImg] = null;
            //    row[colNStatusUs] = "";
            //}
            if (chk.Equals(""))
            {
                grf8[grf8.Row, colNImg] = imgChk;
                grf8[grf8.Row, colNStatusUs] = "1";
            }
            else
            {
                grf8[grf8.Row, colNImg] = null;
                grf8[grf8.Row, colNStatusUs] = "";
            }
            setFoodName();
        }

        private void setGrf8()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grf8.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("noodle_vagetable");
            grf8.Cols.Count = 7;
            grf8.Rows.Count = 1;
            grf8.Rows[0].Visible = false;
            grf8.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grf8.Rows[0].Visible = false;
            Column col = grf8.Cols[colNImg];
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

            grf8.Cols[1].Width = 60;

            grf8.Cols[colNName].Width = 220;
            grf8.Cols[colNImg].Width = 50;
            grf8.Cols[colNPrice].Width = 100;
            grf8.EditOptions = EditFlags.None;
            grf8.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf8.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Decimal price = 0;
                Row row = grf8.Rows.Add();
                Decimal.TryParse(dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_price].ToString(), out price);
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                row[colNPrice] = price > 0 ? price.ToString("#,###.00") : "";
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = grf8.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if (grf8.Rows.Count < 10)
            //{
            //    for (int i = grf8.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grf8.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
            grf8.Cols[colNId].Visible = false;
            grf8.Cols[colNflag].Visible = false;
            grf8.Cols[colNStatusUs].Visible = false;

            grf8.Cols[colNName].AllowEditing = false;
            grf8.Cols[colNImg].AllowEditing = false;
            grf8.Cols[colNPrice].AllowEditing = false;
            grf8.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grf8.EditOptions = EditFlags.None;
            grf8.TabStop = false;
            grf8.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //grfNoom.st
            CellStyle cs = null;
            cs = grf8.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = grf8.BackColor;
            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grf8.HighLight = HighLightEnum.Never;
            grf8.FocusRect = FocusRectEnum.None;
            grf8.SelectionMode = SelectionModeEnum.Cell;
            //pageLoad = false;
        }
        private void initGrf7()
        {
            grf7 = new C1FlexGrid();
            grf7.Font = fgrd;
            grf7.Dock = System.Windows.Forms.DockStyle.Fill;
            grf7.Location = new System.Drawing.Point(0, 0);
            grf7.Rows[0].Visible = false;
            grf7.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grf7.Cols[colNName].Width = 40;
            grf7.Click += Grf7_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grf7.TabStop = false;
            grf7.EditOptions = EditFlags.None;
            grf7.BackColor = pnMid7G.BackColor;
            grf7.Cols[colNName].AllowEditing = false;

            pnMid7G.Controls.Add(grf7);
            grf7.Cols[colNId].Visible = false;
            CellRange rng1 = grf7.GetCellRange(0, colNId, 1, colNflag);
            rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void Grf7_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf7.Row <= 0) return;
            if (grf7[grf7.Row, colNflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grf7.Row;
            chk = grf7[grf7.Row, colNStatusUs].ToString();
            //foreach (Row row in grfNoom.Rows)
            //{
            //    row[colNImg] = null;
            //    row[colNStatusUs] = "";
            //}
            if (chk.Equals(""))
            {
                grf7[grf7.Row, colNImg] = imgChk;
                grf7[grf7.Row, colNStatusUs] = "1";
            }
            else
            {
                grf7[grf7.Row, colNImg] = null;
                grf7[grf7.Row, colNStatusUs] = "";
            }
            setFoodName();
        }

        private void setGrf7()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grf7.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("noodle_meat");
            grf7.Cols.Count = 7;
            grf7.Rows.Count = 1;
            grf7.Rows[0].Visible = false;
            grf7.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grf7.Rows[0].Visible = false;
            Column col = grf7.Cols[colNImg];
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

            grf7.Cols[1].Width = 60;

            grf7.Cols[colNName].Width = 220;
            grf7.Cols[colNImg].Width = 50;
            grf7.Cols[colNPrice].Width = 100;
            grf7.EditOptions = EditFlags.None;
            grf7.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grf7.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Decimal price = 0;
                Row row = grf7.Rows.Add();
                Decimal.TryParse(dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_price].ToString(), out price);
                //row[i + 1, 0] = (i + 1);
                row[colNName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colNStatusUs] = "";
                row[colNImg] = null;
                row[colNPrice] = price > 0 ? price.ToString("#,###.00") : "";
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = grf7.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if (grf7.Rows.Count < 10)
            //{
            //    for (int i = grf7.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grf7.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
            grf7.Cols[colNId].Visible = false;
            grf7.Cols[colNflag].Visible = false;
            grf7.Cols[colNStatusUs].Visible = false;
            grf7.Cols[colNName].AllowEditing = false;
            grf7.Cols[colNImg].AllowEditing = false;
            grf7.Cols[colNPrice].AllowEditing = false;
            grf7.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grf7.EditOptions = EditFlags.None;
            grf7.TabStop = false;
            grf7.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //grfNoom.st
            CellStyle cs = null;
            cs = grf7.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = grf7.BackColor;
            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grf7.HighLight = HighLightEnum.Never;
            grf7.FocusRect = FocusRectEnum.None;
            grf7.SelectionMode = SelectionModeEnum.Cell;
            //pageLoad = false;
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
            setFoodName();
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
                //row.StyleNew.BackColor = this.BackColor;
                row.StyleNew.BackColor = pnMid1G.BackColor;
                row[colNflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if(grfNoom.Rows.Count < 10)
            //{
            //    for(int i = grfNoom.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grfNoom.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colNStatusUs] = "";
            //        row[colNflag] = "1";
            //    }
            //}
            grfNoom.Cols[colNId].Visible = false;
            grfNoom.Cols[colNflag].Visible = false;
            grfNoom.Cols[colNStatusUs].Visible = false;
            grfNoom.Cols[colNName].AllowEditing = false;
            grfNoom.Cols[colNImg].AllowEditing = false;
            grfNoom.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfNoom.EditOptions = EditFlags.None;
            grfNoom.TabStop = false;
            grfNoom.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            //grfNoom.st
            CellStyle cs = null;
            cs = grfNoom.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = pnMid1G.BackColor;
            CellBorder cb = cs.Border;
            //CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grfNoom.HighLight = HighLightEnum.Never;
            grfNoom.FocusRect = FocusRectEnum.None;
            grfNoom.SelectionMode = SelectionModeEnum.Cell;
            //pageLoad = false;
        }
        private void initGrfOpt()
        {
            grfOpt = new C1FlexGrid();
            grfOpt.Font = fgrd;
            grfOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOpt.Location = new System.Drawing.Point(0, 0);
            grfOpt.Rows[0].Visible = false;
            grfOpt.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grfOrder.Rows.Count = 1;
            //grfOrder.Cols.Count = 15;
            grfOpt.Cols[colNName].Width = 40;
            grfOpt.Click += GrfOpt_Click;

            //FilterRow fr = new FilterRow(grfExpn);
            grfOpt.TabStop = false;
            grfOpt.EditOptions = EditFlags.None;
            grfOpt.BackColor = pnMid3G.BackColor;
            grfOpt.Cols[colNName].AllowEditing = false;

            pnMid3G.Controls.Add(grfOpt);
            grfOpt.Cols[colOId].Visible = false;
            //CellRange rng1 = grfOpt.GetCellRange(0, colOId, 1, colOflag);
            //rng1.Data = "Time";

            //theme.SetTheme(grf, "Office2010Blue");
        }

        private void GrfOpt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfOpt.Row <= 0) return;
            if (grfOpt.Col <= 0) return;
            if (grfOpt[grfOpt.Row, colOflag].ToString().Equals("1")) return;
            String chk = "";
            int row1 = 0;
            row1 = grfOpt.Row;
            chk = grfOpt[grfOpt.Row, colOStatusUs].ToString();
            //foreach (Row row in grfOpt.Rows)
            //{
            //    row[colNImg] = null;
            //    row[colNStatusUs] = "";
            //}
            if (grfOpt.Col== colOImgL)
            {
                grfOpt[grfOpt.Row, colOImgL] = imgChk;
                grfOpt[grfOpt.Row, colOImgR] = imgChkUn;
                grfOpt[grfOpt.Row, colOStatusUs] = "1";
            }
            else if (grfOpt.Col == colOImgR)
            {
                grfOpt[grfOpt.Row, colOImgL] = imgChkUn;
                grfOpt[grfOpt.Row, colOImgR] = imgChkNo;
                grfOpt[grfOpt.Row, colOStatusUs] = "3";
            }
            setFoodName();
        }

        private void setGrfOpt()
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            //c1SuperLabel2.Text = "เส้น";
            //c1SuperLabel2.Font = fEdit;
            grfOpt.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.noomDB.selectByWhere1("option_noodle");
            grfOpt.Cols.Count = 7;
            grfOpt.Rows.Count = 1;
            grfOpt.Rows[0].Visible = false;
            grfOpt.Cols[0].Visible = false;
            //if (dt.Rows.Count > 0)
            grfOpt.Rows[0].Visible = false;
            Column col = grfOpt.Cols[colOImgL];
            col.DataType = typeof(Image);
            Column col1 = grfOpt.Cols[colOImgR];
            col1.DataType = typeof(Image);
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfOpt.Cols[1].Width = 60;

            grfOpt.Cols[colOName].Width = pnMid3G.Width - 50 - 50 -17;
            grfOpt.Cols[colOImgL].Width = 50;
            grfOpt.Cols[colOImgR].Width = 50;
            grfOpt.EditOptions = EditFlags.None;
            grfOpt.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfOpt.Cols[colNName].Caption = "";

            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            Image loadedImage = null, resizedImage;
            int originalWidth = Resources.images.Width;
            int newWidth = 40;
            resizedImage = Resources.images.GetThumbnailImage(newWidth, (newWidth * Resources.images.Height) / originalWidth, null, IntPtr.Zero);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Row row = grfOpt.Rows.Add();
                //row[i + 1, 0] = (i + 1);
                row[colOName] = dt.Rows[i][mposC.mposDB.noomDB.noom.noodle_make_name].ToString();
                row[colOStatusUs] = "";
                row[colOImgL] = imgChkUn;
                row[colOImgR] = imgChkUn;
                //if (i % 2 == 0)
                //row.StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                //row.StyleNew.BackColor = this.BackColor;
                CellStyle rs = row.StyleNew;
                //rs.BackColor = this.BackColor;
                rs.BackColor = pnMid3G.BackColor;
                //rs.Border 
                row[colOflag] = "";
                //grfNoom.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //if (grfOpt.Rows.Count < 9)
            //{
            //    for (int i = grfOpt.Rows.Count; i <= 8; i++)
            //    {
            //        Row row = grfOpt.Rows.Add();
            //        row.StyleNew.BackColor = this.BackColor;
            //        row[colOStatusUs] = "";
            //        row[colOflag] = "1";
            //        row.StyleDisplay.BackColor = this.BackColor;
            //    }
            //}
            grfOpt.Cols[colOId].Visible = false;
            grfOpt.Cols[colOflag].Visible = false;
            grfOpt.Cols[colOStatusUs].Visible = false;
            grfOpt.Cols[colOName].AllowEditing = false;
            grfOpt.Cols[colOImgL].AllowEditing = false;
            grfOpt.Cols[colOImgR].AllowEditing = false;
            grfOpt.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            grfOpt.EditOptions = EditFlags.None;
            grfOpt.TabStop = false;
            grfOpt.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grfOpt.BackColor = this.BackColor;
            CellStyle cs = null;
            cs = grfOpt.Styles.EmptyArea;
            //cs.BackColor = this.BackColor;
            cs.BackColor = pnMid3G.BackColor;
            CellBorder cb = cs.Border;
            cb.Style = BorderStyleEnum.None;
            grfOpt.HighLight = HighLightEnum.Never;
            grfOpt.FocusRect = FocusRectEnum.None;
            grfOpt.SelectionMode = SelectionModeEnum.Cell;
            //grfOpt.Styles.EmptyArea = this.BackColor;
            //pageLoad = false;
        }
        private void FrmNoodleMake_Load(object sender, EventArgs e)
        {

        }
    }
}
