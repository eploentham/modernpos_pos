using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using C1.Win.C1Tile;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmTakeOut4 : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1, fgrd, ford;

        Color bg, fc, tilecolor, tileFoodsPriceColor, tileFoodsNameColor, tileCatColor;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public List<Foods> lfooT;
        public List<Foods> lfooR;
        Foods foo;
        //Theme theme1;

        PanelElement peOrd, peRec, peCat, peTopping;
        ImageElement ieOrd, ieRec, ieCat, ieTopping, ieTopping8;
        TextElement teOrd, teOrdFoodsName, teOrdFoodsPrice, teCat, teCatName, teTopping;

        Template tempFlickr, tempRec, tempCat, tempDrink;
        ImageElement imageElement8, imageElementDrink, imageElementRec, imageElementCat;
        PanelElement pnFoodsName, pnFoodsPrice, pnElementDrink, pnElementPrice, pnElementRec, pnElementCat;
        C1FlexGrid grfOrder, grfSpec, grfTopping, grfBill;
        C1DockingTab tC;

        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;
        int colOrdNo = 1, colOrdFooName = 2, colOrdPrice = 3, colOrdQty = 5, colOrdqtyplus = 6, colOrdqtyminus = 4, colOrdRemark = 7, colOrdTopping = 8, colOrdArrowDown = 9, colOrdThrumb = 10, colOrdStatus = 11, colOrdFooId = 12, colOrdPrinterName = 13, colOrdFooName1 = 14;
        int colSNo = 1, colSImg = 2, colSFoosName = 3, colSStatus = 4;
        int colTNo = 1, colTImg = 2, colTFoosName = 3, colTPrice = 4, colTStatus = 5;
        int colBNo = 1, colBFooName = 2, colBPrice = 3, colBQty = 4, colBRemark = 5, colBStatus = 6, colBFooId = 7, colBPrinterName = 8;

        List<Order1> lOrd;
        List<FoodsSpecial> lFoos;
        List<FoodsTopping> lFoot;
        List<OrderTopping> lordt;
        List<OrderSpecial> lords;

        Order1 ord;
        DataTable dtCat = new DataTable();
        DataTable dtRec = new DataTable();
        IntPtr intptr = new IntPtr();
        //C1DockingTabPage[] tabPage;
        C1TileControl[] TileFoods;
        C1TileControl TileCat, TileSpec, TileTopping, TileFoodsOld;
        Group[] gr11;
        Group grRec, grSpec, grDring, gr1;
        Boolean flagModi = false, flagShowTitle = false;
        Image imgR, imgC;
        String fooid = "", fooSpec = "", fooTopping = "";
        Form frmmain;

        Timer timerVNE, timerOnLine;
        public enum VNECommand { Payment = 1, PollingStatusPayment = 2, DeletePendingPayment = 3, ListPendingPayment = 5 };
        String webapi = "/selfcashapi/", txtAmt = "จำนวนเงินต้องชำระ";
        Order1 ord1;
        int iprn = 1, VNEtimer = 0, indexTile = 0;
        Image imgMinus, imgPlus, imgArrowDown, imgAdd, imgThumb;
        private string _tip = "";
        String testdebug = "debug", que = "";
        TableLayoutPanel tplOrd;
        public FrmTakeOut4(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);
            fgrd = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 15, FontStyle.Regular);
            ford = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);

            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            //theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in pnMain.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            try
            {
                tilecolor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsBackColor);
                tileFoodsPriceColor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsPriceColor);
                tileFoodsNameColor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsNameColor);
                tileCatColor = ColorTranslator.FromHtml(mposC.iniC.TileCategoryColor);
            }
            catch (Exception ex)
            {

            }

            bg = txtTableCode.BackColor;
            fc = txtTableCode.ForeColor;
            ff = txtTableCode.Font;
            //MessageBox.Show("FrmTakeOut initConfig 2", "");
            lfooT = new List<Foods>();
            lfooR = new List<Foods>();
            lOrd = new List<Order1>();
            lFoos = new List<FoodsSpecial>();
            lFoot = new List<FoodsTopping>();
            lordt = new List<OrderTopping>();
            lords = new List<OrderSpecial>();
            foo = new Foods();
            ord = new Order1();
            lfooT = mposC.mposDB.fooDB.getlFoods1();
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();
            imgMinus = Resources.minus_red_100;
            imgPlus = Resources.plus_green_100;
            imgArrowDown = Resources.arrow_down_100;
            imgAdd = Resources.minus_cir_red_100;
            imgThumb = Resources.recycle_bin_50;
            int originalWidth = imgMinus.Width;
            int newWidth = 25;
            imgMinus = imgMinus.GetThumbnailImage(newWidth, (newWidth * imgMinus.Height) / originalWidth, null, IntPtr.Zero);
            originalWidth = imgPlus.Width;
            imgPlus = imgPlus.GetThumbnailImage(newWidth, (newWidth * imgPlus.Height) / originalWidth, null, IntPtr.Zero);
            originalWidth = imgArrowDown.Width;
            imgArrowDown = imgArrowDown.GetThumbnailImage(newWidth, (newWidth * imgArrowDown.Height) / originalWidth, null, IntPtr.Zero);
            //originalWidth = imgAdd.Width;
            //imgAdd = imgAdd.GetThumbnailImage(newWidth, (newWid
            if (mposC.iniC.pnOrderborderstyle.Equals("0"))
            {
                pnOrderMain.BorderStyle = BorderStyle.None;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("1"))
            {
                pnOrderMain.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("2"))
            {
                pnOrderMain.BorderStyle = BorderStyle.FixedSingle;
            }
            dtCat = mposC.mposDB.foocDB.selectAll();
            dtRec = mposC.mposDB.foocDB.selectAll();

            if (int.TryParse(mposC.iniC.VNEtimer, out VNEtimer))
            {
                VNEtimer = VNEtimer * 1000;
            }
            else
            {
                VNEtimer = 5000;
            }
            timerVNE = new Timer();
            timerVNE.Interval = VNEtimer;
            timerVNE.Tick += TimerVNE_Tick;
            timerVNE.Enabled = false;

            btnPay.Click += BtnPay_Click;
            //btnVoid.Click += BtnVoid_Click;
            //btnSpec.Click += BtnSpec_Click;
            //btnReturn.Click += BtnReturn_Click;
            btnBack.Click += BtnBack_Click;

            btnBillCheck.Click += BtnBillCheck_Click;
            btnVoidPay.Click += BtnVoidPay_Click;
            this.FormClosed += FrmTakeOut4_FormClosed;

            imgR = Resources.red_checkmark_png_16;
            //MessageBox.Show("FrmTakeOut initConfig", "");
            TileFoods = new C1TileControl[dtCat.Rows.Count + 1];
            TileCat = new C1TileControl();
            //initTempFlicker();
            initTlpOrder();
            initTileCategory();
            //initTileCategory();
            //setTileCategory();
            initTileFoods();
            setTileFoods();
            indexTile = 0;
            scFoodsItem.Controls.Add(TileFoods[indexTile]);
            //setTileFoodsRecommendDefault();
            //initTC();
            //initSpec();
            //initTopping();
            initGrfBill();
            //initGrfTopping();
            pnOrdBill.Height = 100;
            flagModi = false;
            setBtnEnable(flagModi);
            this.FormBorderStyle = FormBorderStyle.None;
            setListBox1Show(false);
        }

        private void FrmTakeOut4_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            frmmain.Show();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tCMain.SelectedTab = tabOrder;
        }
        private void setListBox1Show(Boolean flag)
        {
            listBox1.Visible = flag;
            pnVoidPay.Visible = flag;
        }
        private void initGrfBill()
        {
            grfBill = new C1FlexGrid();
            //grfBill.Font = fEdit;
            grfBill.Font = fgrd;
            grfBill.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBill.Location = new System.Drawing.Point(0, 0);
            grfBill.Rows[0].Visible = false;
            grfBill.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfBill.Rows.Count = 1;
            grfBill.Cols.Count = 9;
            grfBill.Cols[colBNo].Width = 40;
            grfBill.Cols[colBFooName].Width = 600;
            grfBill.Cols[colBPrice].Width = 200;
            //FilterRow fr = new FilterRow(grfExpn);
            grfBill.TabStop = false;
            grfBill.EditOptions = EditFlags.None;
            grfBill.Cols[colBNo].AllowEditing = false;
            grfBill.Cols[colBFooName].AllowEditing = false;
            grfBill.Cols[colBPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grfBill.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;

            grfBill.SubtotalPosition = SubtotalPositionEnum.BelowData;

            pnCheckOrder.Controls.Add(grfBill);
            grfBill.Cols[colBFooId].Visible = false;
            grfBill.Cols[colBStatus].Visible = false;
            grfBill.Cols[colBQty].Visible = false;
            grfBill.Cols[colBPrinterName].Visible = false;
            grfBill.Cols[colBRemark].Visible = false;

            pnCheckOrder.Width = mposC.panel1Width + 130;
            //theme.SetTheme(grf, "Office2010Blue");

        }
        private void setTileFoods()
        {
            int index = 0;
            foreach (DataRow drow in dtCat.Rows)
            {
                List<Foods> lfoo1 = new List<Foods>();
                if (drow[mposC.mposDB.foocDB.fooC.status_recommend].ToString().Equals("1"))
                {
                    lfoo1 = mposC.mposDB.fooDB.getlFoodsRecommend();
                }
                else
                {
                    lfoo1 = mposC.mposDB.fooDB.getlFoodsByCat(drow[mposC.mposDB.foocDB.fooC.foods_cat_id].ToString());
                }

                TileCollection tiles = TileFoods[index].Groups[0].Tiles;
                foreach (Foods foorow in lfoo1)
                {
                    var tile = new Tile();

                    tile.HorizontalSize = mposC.TileFoodstakeouttilhorizontalsize;
                    tile.VerticalSize = mposC.TileFoodstakeouttilverticalsize;
                    tile.Template = tempFlickr;
                    //tile.Text = drow[mposC.mposDB.foocDB.fooC.foods_cat_name].ToString();
                    tile.HorizontalSize = mposC.TileFoodstakeouttilhorizontalsize;
                    tile.VerticalSize = mposC.TileFoodstakeouttilverticalsize;

                    tile.Tag = foorow;
                    tile.Name = foorow.foods_id;
                    tile.Text = foorow.foods_name;
                    tile.Text1 = "ราคา " + foorow.foods_price;
                    tile.Click += TileFoods_Click;
                    tile.Image = null;
                    try
                    {
                        String filename = "";
                        tile.Image = null;
                        tiles.Add(tile);
                        MemoryStream stream = new MemoryStream();
                        Image loadedImage = null, resizedImage;
                        if (foorow.filename.Equals("")) continue;
                        String ext = Path.GetExtension(foorow.filename);
                        filename = foorow.filename.Replace(ext, "");
                        stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + filename + "_210" + ext);
                        loadedImage = new Bitmap(stream);
                        if (loadedImage != null)
                        {
                            //SizeF size = tile.Width;
                            int originalWidth = loadedImage.Width;
                            int newWidth = 180;
                            //resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                            //tile.Image = resizedImage;
                            tile.Image = loadedImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("" + ex.Message, "showImg");
                    }
                }
                index++;
            }
        }
        private void TileFoods_Click(object sender, EventArgs e)
        {
            Tile tile = sender as Tile;
            if (tile != null)
            {
                Foods foo = new Foods();
                foo = (Foods)tile.Tag;
                if (foo.status_create.Equals("1"))
                {
                    mposC.NooId = "";
                    mposC.NooName = "";
                    mposC.NooPrice = "";
                    mposC.NooQty = "";
                    mposC.NooRemark = "";
                    mposC.NooPrinter = "";
                    FrmNoodleMake frm = new FrmNoodleMake(mposC, foo.foods_price);
                    frm.ShowDialog(this);

                    setTplOrder(foo.foods_id, mposC.NooName, mposC.NooPrice, mposC.NooQty, mposC.NooRemark, foo.printer_name, foo.status_create
                        , frm.lnooNoodle, frm.lnooWater, frm.lnooOptNoodle, frm.lnooNoodleMeatBall, frm.lnooNoodleSea, frm.lnooNoodleMeat, frm.lnooNoodleVagetable);
                }
                else
                {
                    if (mposC.iniC.statusTogoOrderingRepeat.Equals("1"))
                    {
                        Boolean chk = false;
                        foreach(Order1 ord in lOrd)
                        {
                            if (ord.foods_id.Equals(foo.foods_id))
                            {
                                int qty = 0;
                                int.TryParse(ord.qty, out qty);
                                Decimal price = 0;
                                Decimal.TryParse(ord.price, out price);
                                qty++;
                                ord.qty = qty.ToString();
                                ord.sumPrice = (price * qty).ToString();
                                chk = true;
                                foreach (Control ctl in tplOrd.Controls)
                                {
                                    if (ctl is ucOrderTakeOut1)
                                    {
                                        ucOrderTakeOut1 ucord;
                                        //if(ucord.f)
                                        ucord = (ucOrderTakeOut1)ctl;
                                        ucord.setQty(foo.foods_id, ord.qty);
                                        //ucord.setPrice(ord.sumPrice);
                                    }
                                }
                            }
                        }
                        if (!chk)
                        {
                            setTplOrder(tile.Name, tile.Text, tile.Text1.Replace("ราคา", "").Trim(), "1", "", foo.printer_name, foo.status_create);
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        setTplOrder(tile.Name, tile.Text, tile.Text1.Replace("ราคา", "").Trim(), "1", "", foo.printer_name, foo.status_create);
                    }
                }

                //FlickrPhoto photo = (FlickrPhoto)tile.Tag;
                //string uri = photo.ContentUri;
                //if (!string.IsNullOrEmpty(uri))
                //{
                //    pictureBox.Image = pictureBox.InitialImage;
                //    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                //    imgPanel.Visible = true;
                //    imgPanel.BringToFront();
                //    titleLabel.Text = photo.Title;
                //    authorLabel.Text = photo.AuthorName;
                //    waitLabel.Visible = true;
                //    pictureBox.LoadAsync(uri);
                //    tagBox.Enabled = false;
                //    setTagButton.Enabled = false;
                //    refreshButton.Enabled = false;
                //    loadNewButton.Enabled = false;
                //    flickrTiles.Enabled = false;
                //    backButton.Enabled = true;
                //    this.Focus();
                //}
                calBill();
            }
        }
        private void setTplOrder(String id, String name, String price, String qty, String remark, String printer, String statuscreate
            , List<NoodleMake> lnooNoodle, List<NoodleMake> lnooWater, List<NoodleMake> lnooOptNoodle, List<NoodleMake> lnooNoodleMeatBall, List<NoodleMake> lnooNoodleSea
            , List<NoodleMake> lnooNoodleMeat, List<NoodleMake> lnooNoodleVagetable)
        {
            String re = "";
            if (!name.Equals(""))
            {
                //String[] ext = name.Split('#');
                int row1 = tplOrd.RowCount;
                tplOrd.RowCount++;
                Order1 ord1 = new Order1();
                ord1.order_id = "";
                ord1.price = price;
                ord1.qty = "1";
                ord1.status_bill = "0";
                ord1.foods_id = id;
                ord1.foods_name = name;
                ord1.remark = remark;
                ord1.row1 = row1.ToString();
                ord1.printer_name = printer;
                ord1.sumPrice = price;
                ord1.toppingPrice = "";
                ord1.topping = "";
                ord1.special = "";
                ord1.status_create = statuscreate;
                lOrd.Add(ord1);

                ucOrderTakeOut1 ucto = new ucOrderTakeOut1(mposC, row1.ToString(), id, qty, ref ord1, ref lords, ref lordt, this
                    , lnooNoodle, lnooWater, lnooOptNoodle, lnooNoodleMeatBall, lnooNoodleSea, lnooNoodleMeat, lnooNoodleVagetable);
                //tplOrd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tplOrd.Controls.Add(ucto, 0, row1);
                tplOrd.ResumeLayout();
                tplOrd.AutoScrollPosition = new Point(0, tplOrd.VerticalScroll.Maximum);
                //UpdateTotals();
            }
        }
        private void setTplOrder(String id, String name, String price, String qty, String remark, String printer, String statuscreate)
        {
            String re = "";
            if (!name.Equals(""))
            {
                //String[] ext = name.Split('#');
                int row1 = tplOrd.RowCount;
                tplOrd.RowCount++;
                Order1 ord1 = new Order1();
                ord1.order_id = "";
                ord1.price = price;
                ord1.qty = "1";
                ord1.status_bill = "0";
                ord1.foods_id = id;
                ord1.foods_name = name;
                ord1.remark = remark;
                ord1.row1 = row1.ToString();
                ord1.printer_name = printer;
                ord1.sumPrice = price;
                ord1.toppingPrice = "";
                ord1.topping = "";
                ord1.special = "";
                ord1.status_create = statuscreate;
                lOrd.Add(ord1);
                
                ucOrderTakeOut1 ucto = new ucOrderTakeOut1(mposC, row1.ToString(), id, qty,ref ord1, ref lords, ref lordt, this);
                //tplOrd.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                tplOrd.Controls.Add(ucto, 0, row1);
                tplOrd.ResumeLayout();
                tplOrd.AutoScrollPosition = new Point(0, tplOrd.VerticalScroll.Maximum);
                //UpdateTotals();
            }
        }
        private void initTileCategory()
        {
            TileCat = new C1TileControl();
            TileCat.Dock = DockStyle.Fill;
            TileCat.Font = fEdit;
            if (mposC.iniC.TileCategoryOrientation.Equals("0"))
            {
                TileCat.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileCat.Orientation = LayoutOrientation.Vertical;
            }
            grRec = new Group();
            TileCat.Groups.Add(this.grRec);
            peRec = new C1.Win.C1Tile.PanelElement();
            ieRec = new C1.Win.C1Tile.ImageElement();
            tempRec = new C1.Win.C1Tile.Template();
            imageElementRec = new C1.Win.C1Tile.ImageElement();
            pnElementRec = new C1.Win.C1Tile.PanelElement();
            ieOrd = new C1.Win.C1Tile.ImageElement();
            teOrd = new TextElement();
            teOrd.Font = fEdit;
            teOrdFoodsName = new TextElement();
            teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
            teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teOrdFoodsName.SingleLine = true;

            imageElementRec.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            peOrd = new PanelElement();
            peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            peOrd.Children.Add(ieOrd);
            peOrd.Children.Add(teOrd);
            peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            pnElementRec.BackColor = tileFoodsNameColor;
            pnElementRec.Children.Add(teOrdFoodsName);
            pnElementRec.Dock = System.Windows.Forms.DockStyle.Top;
            pnElementRec.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);

            TileCat.DefaultTemplate.Elements.Add(peOrd);
            TileCat.Templates.Add(this.tempRec);
            tempRec.Elements.Add(imageElementRec);
            tempRec.Elements.Add(pnElementRec);
            //tempRec.Elements.Add(pnFoodsPrice);
            tempRec.Name = "tempFlickrrec";
            TileCat.ScrollOffset = 0;
            TileCat.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileCat.Padding = new System.Windows.Forms.Padding(0);
            TileCat.GroupPadding = new System.Windows.Forms.Padding(20);
            TileCat.BackColor = tileCatColor;       // tab recommend color
            TileCat.Templates.Add(this.tempRec);

            scFoodsCat.BackColor = tilecolor;
            scFoodsCat.Controls.Add(TileCat);
            setTileCategory();
            //for (int i = 0; i < dtCat.Rows.Count; i++)
            //{
            //    LoadFoods(false, i, dtCat.Rows[i]["foods_cat_id"].ToString());
            //}
        }
        public void delTplRow(ucOrderTakeOut1 uco, String row)
        {
            tplOrd.Controls.Remove(uco);
            foreach(Order1 ord in lOrd)
            {
                if (ord.row1.Equals(row))
                {
                    ord.row1 = "";
                    lOrd.Remove(ord);
                    break;
                }
            }
            //tplOrd.RowCount--;
        }
        public void calBill()
        {
            decimal sumprice = 0;
            int rowno = 1;
            for(int i=0;i< tplOrd.RowCount-1; i++)
            {
                decimal price = 0;
                ucOrderTakeOut1 ucto;
                ucto = (ucOrderTakeOut1)tplOrd.GetControlFromPosition(0, i+1);
                if (ucto == null) continue;
                C1Label lbPrice = new C1Label();
                Panel pn = (Panel)ucto.Controls["phHead"];
                lbPrice = (C1Label)pn.Controls["lbPrice"];
                if(decimal.TryParse(lbPrice.Text, out price))
                {
                    sumprice += price;
                }
                ucto.setRow(rowno.ToString());
                rowno++;
            }
            btnPay.Text = mposC.iniC.textTogoPay+ " "+ sumprice.ToString("#,###.00");
        }
        private void initTlpOrder()
        {
            tplOrd = new TableLayoutPanel();
            tplOrd.ColumnCount = 1;
            //tplOrd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize, 360F));
            //tplOrd.Location = new System.Drawing.Point(0, 0);
            tplOrd.Name = "tplOrder";
            tplOrd.RowCount = 1;
            //tplOrd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 50F));
            //tplOrd.RowStyles.Insert(2, new RowStyle(SizeType.Percent));
            tplOrd.TabIndex = 0;
            tplOrd.Dock = DockStyle.Fill;
            tplOrd.AutoScroll = true;
            tplOrd.ResumeLayout();
            tplOrd.SuspendLayout();
            tplOrd.GrowStyle = TableLayoutPanelGrowStyle.AddRows;
            tplOrd.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tplOrd.RowCount = tplOrd.RowStyles.Count;
            pnOrdOrder.Controls.Add(tplOrd);
        }
        private void initTileFoods()
        {
            int index = 0;

            //initTileRec();

            foreach (DataRow drow in dtCat.Rows)
            {
                grRec = new Group();
                //TileRec.Groups.Add(this.grRec);
                //peRec = new C1.Win.C1Tile.PanelElement();
                //ieRec = new C1.Win.C1Tile.ImageElement();
                tempFlickr = new C1.Win.C1Tile.Template();
                imageElementRec = new C1.Win.C1Tile.ImageElement();
                pnFoodsName = new C1.Win.C1Tile.PanelElement();
                pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
                ieCat = new C1.Win.C1Tile.ImageElement();
                teCat = new TextElement();
                teCat.Font = fEdit;

                teOrdFoodsName = new C1.Win.C1Tile.TextElement();
                teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
                teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
                teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
                teOrdFoodsName.SingleLine = true;
                teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
                teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
                peOrd = new C1.Win.C1Tile.PanelElement();
                peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
                peOrd.Children.Add(ieCat);
                peOrd.Children.Add(teCat);
                peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
                ieOrd = new C1.Win.C1Tile.ImageElement();
                teOrd = new C1.Win.C1Tile.TextElement();
                teOrd.Font = fEdit;

                //pnFoodsPrice.Children.Add(teOrdFoodsPrice);
                ieOrd.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
                peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
                peOrd.Children.Add(ieOrd);
                peOrd.Children.Add(teOrd);
                peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
                pnFoodsName.BackColor = tileFoodsNameColor;
                pnFoodsName.Children.Add(teOrdFoodsName);
                pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
                pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
                pnFoodsPrice.Children.Add(teOrdFoodsPrice);
                pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
                pnFoodsPrice.BackColor = tileFoodsPriceColor;
                pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnFoodsPrice.FixedHeight = 32;
                //pnFoodsName.Children.Add(teOrdFoodsPrice);
                tempFlickr.Elements.Add(ieOrd);
                tempFlickr.Elements.Add(pnFoodsName);
                tempFlickr.Elements.Add(pnFoodsPrice);
                tempFlickr.Name = "tempFlickrrec";

                TileFoods[index] = new C1TileControl();
                TileFoods[index].Dock = DockStyle.Fill;
                if (mposC.iniC.TileFoodsOrientation.Equals("0"))
                {
                    TileFoods[index].Orientation = LayoutOrientation.Horizontal;
                }
                else
                {
                    TileFoods[index].Orientation = LayoutOrientation.Vertical;
                }

                TileFoods[index].Groups.Add(grRec);
                TileFoods[index].Font = fEdit;
                TileFoods[index].DefaultTemplate.Elements.Add(peOrd);

                TileFoods[index].Name = "tiledrink";
                TileFoods[index].Dock = DockStyle.Fill;
                TileFoods[index].ScrollOffset = 0;
                TileFoods[index].SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
                TileFoods[index].Padding = new System.Windows.Forms.Padding(0);
                TileFoods[index].GroupPadding = new System.Windows.Forms.Padding(20);
                TileFoods[index].BackColor = tilecolor;
                TileFoods[index].Templates.Add(tempFlickr);
                //TileFoods[index].Font = fEdit;
                index++;
            }
        }
        private void setTileCategory()
        {
            int index = 0;
            TileCollection tiles = TileCat.Groups[0].Tiles;
            foreach (DataRow drow in dtCat.Rows)
            {
                var tile = new Tile();
                FoodsCat fooc = new FoodsCat();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempRec;
                tile.Text = drow[mposC.mposDB.foocDB.fooC.foods_cat_name].ToString();
                //tile.HorizontalSize = 2;
                //tile.VerticalSize = 1;
                //tile.Template = tempFlickr;
                //tile.Text1 = "ราคา " + foo1.foods_price;
                //tile.Tag = foo1;
                fooc = mposC.mposDB.foocDB.getFoodsCat(drow[mposC.mposDB.foocDB.fooC.foods_cat_id].ToString());
                tile.Tag = fooc;
                tile.Name = drow[mposC.mposDB.foocDB.fooC.foods_cat_id].ToString();
                tile.Index = index;
                tile.Click += TileCat_Click;
                tile.Image = null;
                try
                {
                    String filename = "";
                    tile.Image = null;
                    tiles.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (fooc.filename.Equals("")) continue;
                    String ext = Path.GetExtension(fooc.filename);
                    filename = fooc.filename.Replace(ext, "");
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + filename + "_210" + ext);
                    loadedImage = new Bitmap(stream);
                    if (loadedImage != null)
                    {
                        //SizeF size = tile.Width;
                        int originalWidth = loadedImage.Width;
                        int newWidth = 180;
                        //resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        //tile.Image = resizedImage;
                        tile.Image = loadedImage;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
                index++;
            }
        }
        private void TileCat_Click(object sender, EventArgs e)
        {
            //scFoodsItem.Controls.re
            Tile tile = sender as Tile;
            if (tile != null)
            {
                FoodsCat fooc = new FoodsCat();
                fooc = (FoodsCat)tile.Tag;
                if (scFoodsItem.Controls.Count > 1)
                {
                    foreach (Control c in scFoodsItem.Controls)
                    {
                        scFoodsItem.Controls.Remove(c);
                    }
                }
                if (indexTile != tile.Index)
                {
                    if (scFoodsItem.Controls.Count > 0)
                    {
                        foreach (Control c in scFoodsItem.Controls)
                        {
                            scFoodsItem.Controls.Remove(c);
                        }
                    }
                    indexTile = tile.Index;
                    //scFoodsItem.Controls.Remove(TileFoodsOld);
                    //TileFoodsOld = new C1TileControl();
                    TileFoodsOld = TileFoods[indexTile];

                    scFoodsItem.Controls.Add(TileFoods[indexTile]);
                }
            }

        }
        private void setTitle(Boolean flag)
        {
            tCMain.ShowTabs = flag;
            if (flag)
            {
                sCOrder.HeaderHeight = 21;
                sCFoodsMain.HeaderHeight = 21;
                //spSpecialTopping.HeaderHeight = 21;
                sCCheck.HeaderHeight = 21;
            }
            else
            {
                sCOrder.HeaderHeight = 0;
                sCFoodsMain.HeaderHeight = 0;
                //spSpecialTopping.HeaderHeight = 0;
                sCCheck.HeaderHeight = 0;
            }

            //spMain.HeaderHeight = 21;
            //pnItem.he
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    //frmmain.Show();
                    Close();
                    return true;
                }
            }
            else
            {
                switch (keyData)
                {
                    case Keys.K | Keys.Control:
                        if (flagShowTitle)
                            flagShowTitle = false;
                        else
                            flagShowTitle = true;
                        setTitle(flagShowTitle);
                        return true;
                    case Keys.X | Keys.Control:
                        //frmmain.Show();
                        Close();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void BtnVoidPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "";
            if (vneRspPay == null) return;
            if (MessageBox.Show("ต้องการ ลบ Payment ID " + vneRspPay.id, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    String statuspay = "";
                    statuspay = chkPayBefore.Checked ? "1" : "2";
                    statuspay = chkPaypaying.Checked ? "1" : "2";
                    VNEPaymentPendingDeleteRequest vnepdreq = new VNEPaymentPendingDeleteRequest();
                    vnepdreq.id = vneRspPay.id;
                    vnepdreq.opName = "admin";
                    vnepdreq.tipo = "3";
                    //vnepdreq.tipo_annullamento = statuspay+"/2";
                    vnepdreq.tipo_annullamento = statuspay;
                    var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                    String txtjson = JsonConvert.SerializeObject(vnepdreq, Formatting.Indented);
                    WebClient webClient = new WebClient();
                    var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                    http.Accept = "application/json";
                    http.ContentType = "application/json";
                    http.Method = "POST";
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    Byte[] bytes = encoding.GetBytes(txtjson);
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    listBox1.Items.Add(txtjson);
                    var response = http.GetResponse();

                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    var content = sr.ReadToEnd();

                    listBox1.Items.Add(content);
                    dynamic obj = JsonConvert.DeserializeObject(content);
                    String status = obj.payment_status;
                    if (status.Equals("1"))
                    {
                        //MessageBox.Show("ทำการยกเลิก รับชำระเงิน เรียบร้อย", "");
                        lbStatus.Text = "ยกเลิก รับชำระเงิน เรียบร้อย";
                        timerVNE.Stop();
                        pnVoidPay.Hide();
                    }

                    //cboPpl.Text = "";
                    //BtnListPayment_Click(null, null);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(err + " " + ex.Message);
                }
            }
        }

        private void BtnBillCheck_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "", sql = "";
            try
            {
                err = "00";
                var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                VNErequestPayment vne = new VNErequestPayment();
                vne.tipo = "1";
                vne.importo = lbAmt.Text.Replace(txtAmt, "").Replace(".", "").Trim();
                vne.opname = "admin";
                vne.operatore = "";
                String txtjson = JsonConvert.SerializeObject(vne, Formatting.Indented);
                listBox1.Items.Add(txtjson);
                err = "01";
                WebClient webClient = new WebClient();
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                listBox1.Items.Add("Host " + http.Host + "  VNEwebapi " + mposC.iniC.VNEwebapi);
                ASCIIEncoding encoding = new ASCIIEncoding();
                String chk = "";
                String lotid = genLotId();
                if (!mposC.iniC.statusdebug.Equals("1"))
                {
                    Byte[] bytes = encoding.GetBytes(txtjson);
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();

                    err = "02";
                    var response = http.GetResponse();
                    err = "03";
                    var stream = response.GetResponseStream();
                    err = "04";
                    var sr = new StreamReader(stream);
                    var content = sr.ReadToEnd();
                    err = "05";
                    listBox1.Items.Add(content);
                    vneRspPay = new VNEresponsePayment();
                    dynamic obj = JsonConvert.DeserializeObject(content);
                    vneRspPay.id = obj.id;
                    vneRspPay.importo = obj.importo;
                    vneRspPay.tipo = obj.tipo;
                    vneRspPay.req_status = obj.req_status;
                    listBox1.Items.Add("VNE response " + vneRspPay.id);
                    cboRsp.Text = vneRspPay.id;
                    //vneRspPay = (VNEresponsePayment)JsonConvert.DeserializeObject(content);
                    err = "06";
                    sql = "Insert Into vne_response_payment Set " +
                        "id='" + vneRspPay.id + "'" +
                        ",importo='" + vneRspPay.importo + "'" +
                        ",tipo='" + vneRspPay.tipo + "'" +
                        ",req_status='" + vneRspPay.importo + "'" +
                        ",active='1'" +
                        ",date_Create=now()" +
                        ",user_create='" + vne.opname + "'"
                        ;
                    //MySqlCommand com = new MySqlCommand();
                    //com.CommandText = sql;
                    //com.CommandType = CommandType.Text;
                    //com.Connection = mposC.conn.conn;

                    //conn.Open();

                    try
                    {
                        //chk = com.ExecuteNonQuery();
                        chk = mposC.conn.ExecuteNonQuery(mposC.conn.conn, sql);
                    }
                    catch (Exception ex)
                    {
                        listBox1.Items.Add(err + " " + ex.Message);
                    }
                }
                else
                {
                    chk = "1";
                }

                //conn.Close();
                //com.Dispose();
                timerVNE.Enabled = true;
                timerVNE.Start();
                //label9.Text = "Start waiting payment";
                int dd = 0;
                if (int.TryParse(chk, out dd))
                {
                    listBox1.Items.Add("insert payment OK");
                    Order1 ord = new Order1();
                    String lot = ord.getGenID();
                    foreach (Order1 row in lOrd)
                    {
                        ord = new Order1();
                        ord.order_id = row.order_id;
                        ord.lot_id = row.lot_id;
                        ord.res_id = mposC.res.res_id;
                        ord.host_id = "";
                        ord.device_id = mposC.MACAddress;
                        ord.branch_id = "";
                        ord.foods_id = row.foods_id;
                        ord.foods_name = row.foods_name;
                        ord.price = row.price;
                        ord.qty = row.qty;
                        ord.remark = row.remark;
                        ord.row1 = row.row1;
                        ord.printer_name = row.printer_name;
                        ord.status_bill = row.status_bill;
                        ord.table_id = mposC.tableidToGo;
                        String re = mposC.mposDB.ordDB.insertOrder(ord, "");
                        row.order_id = re;
                    }
                    long chk1 = 0;
                    if(long.TryParse(lotid, out chk1))
                    {
                        mposC.mposDB.ordmDB.genOrderMaterial(lotid);
                    }
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }
        private String genLotId()
        {
            String lotid = "";
            lotid = mposC.mposDB.seqDB.genLotId();
            foreach (Order1 ord in lOrd)
            {
                ord.lot_id = lotid;
            }
            return lotid;
        }
        private void setFooNameRemark()
        {
            foreach (Row row in grfOrder.Rows)
            {
                try
                {
                    if (row[colOrdFooName] == null) continue;
                    int rowid1 = 0;
                    String fooname = "", rowid = "", spec = "";
                    fooname = row[colOrdFooName].ToString();
                    rowid = row[colOrdNo].ToString();
                    spec = row[colOrdRemark].ToString();
                    if (!spec.Equals(""))
                    {
                        if (int.TryParse(rowid, out rowid1))
                        {
                            Order1 ord = new Order1();
                            ord = lOrd[rowid1];
                            ord.foods_name = fooname;
                            ord.remark = spec;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void BtnPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbAmt.Text = "";
            lbStatus.Text = "";
            mposC.statusVNEPaysuccess = "";
            //genLotId();
            //setFooNameRemark();
            tCMain.SelectedTab = tabCheck;
            tCMain.ShowTabs = false;
            //grfBill.Clear();
            grfBill.Rows.Count = 0;
            setGrfBill();
        }
        private void setGrfBill()
        {
            //String re = "";
            if (lOrd.Count > 0)
            {
                foreach (Order1 ord in lOrd)
                {
                    int qty = 0;
                    int.TryParse(ord.qty, out qty);
                    if (qty <= 0) continue;
                    Row row = grfBill.Rows.Add();
                    if (ord.topping.Equals(""))
                    {
                        if (!ord.special.Equals(""))
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.special;
                        }
                        else
                        {
                            row[colBFooName] = ord.foods_name;
                        }
                    }
                    else
                    {
                        if (!ord.special.Equals(""))
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.topping + " + " + ord.special;
                        }
                        else
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.topping;
                        }
                    }
                    row[colBPrice] = ord.sumPrice;
                    row[colBFooId] = ord.foods_id;
                    row[colBRemark] = ord.remark;
                    //row[colBNo] = grfBill.Rows.Count - 1;
                    row[colBNo] = grfBill.Rows.Count;
                }
                //String[] ext = name.Split('#');
                UpdateTotalsBill();
                lbAmt.Text = "";
                lbStatus.Text = "";
                String amt = "";
                try
                {
                    amt = grfBill[grfBill.Rows.Count - 1, colBPrice].ToString();
                    Decimal amt1 = 0;
                    Decimal.TryParse(amt, out amt1);

                    lbAmt.Text = txtAmt + " " + amt1.ToString("0.00");
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void UpdateTotalsBill()
        {
            // clear existing totals
            grfBill.Subtotal(AggregateEnum.Clear);
            grfBill.Subtotal(AggregateEnum.Sum, 0, -1, colOrdPrice, "Grand Total");

        }
        private void setBtnEnable(Boolean flag)
        {
            //btnVoid.Enabled = flag;
            //btnSpec.Enabled = flag;
            //btnTopping.Enabled = flag;
        }
        private void TimerVNE_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "00";
            //throw new NotImplementedException();
            btnVoidPay.Enabled = true;
            pnVoidPay.Show();
            btnVoidPay.Show();

            if (!mposC.iniC.statusdebug.Equals("1"))
            {
                try
                {
                    VNETimer();
                    //listBox1.Items.Add("รอรับชำระ " + vnePpReq.id);
                    //label10.Text = "ID " + vnePRep.id + " amount " + vnePRepd.amount + " status " + vnePRepd.status;
                    //listBox1.Items.Add(content);
                    vnePRepd.status.Equals("completed");
                    if (vnePRepd.status.Equals("completed"))
                    {
                        timerVNE.Stop();
                        mposC.statusVNEPaysuccess = "1";
                        genBill();
                        printOrder();
                        printBill();
                        lbStatus.Text = "รับชำระเรียบร้อย ";
                        if (mposC.statusVNEPaysuccess.Equals("1"))
                        {
                            lOrd.Clear();
                            //grfOrder.Dispose();
                            //initGrfOrder();
                            if (mposC.iniC.statuspaytoclose.Equals("1"))
                            {
                                Close();
                            }
                        }
                        //Close();
                    }
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(err + " " + ex.Message);
                }
            }
            else
            {
                timerVNE.Stop();
                mposC.statusVNEPaysuccess = "1";
                genBill();
                printOrder();
                printBill();
                lbStatus.Text = "รับชำระเรียบร้อย ";
                if (mposC.statusVNEPaysuccess.Equals("1"))
                {
                    lOrd.Clear();
                    //grfOrder.Dispose();
                    //initGrfOrder();
                    if (mposC.iniC.statuspaytoclose.Equals("1"))
                    {
                        Close();
                    }
                }
            }
        }
        private void VNETimer()
        {
            String err = "00";
            try
            {
                listBox1.Items.Add("vneRspPay.id " + vneRspPay.id);
                VNEPaymentPollingRequest vnePpReq = new VNEPaymentPollingRequest();
                vnePRepd = new VNEPaymentPollingResponsePaymentDetail();
                vnePpReq.tipo = "2";
                vnePpReq.id = vneRspPay.id;
                vnePpReq.opName = mposC.iniC.VNEopName;

                lbStatus.Text = "สถานะ รอการชำระเงิน";
                var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                String txtjson = JsonConvert.SerializeObject(vnePpReq, Formatting.Indented);
                WebClient webClient = new WebClient();
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(txtjson);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                listBox1.Items.Add("รอรับชำระ " + txtjson);
                err = "01";
                var response = http.GetResponse();
                err = "02";
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                vnePRep = new VNEPaymentPollingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                err = "03";
                listBox1.Items.Add("รอรับชำระ content " + content);
                vnePRep.id = obj.id;
                vnePRep.req_status = obj.req_status;
                vnePRep.tipo = obj.tipo;
                vnePRep.payment_status = obj.payment_status;
                //vnePRep.payment_detail = obj.payment_details.toString();
                err = "04";
                String aaa = String.Concat(obj.payment_details);
                err = "05";
                dynamic obj1 = JsonConvert.DeserializeObject(aaa);
                err = "06";
                vnePRepd.amount = obj1.amount;
                vnePRepd.inserted = obj1.inserted;
                vnePRepd.rest = obj1.rest;
                vnePRepd.status = obj1.status;
                listBox1.Items.Add("content vnePRepd " + aaa);
                err = "07";
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }
        private void genBill()
        {
            Bill bil = new Bill();
            bil = setBill();
            long chk = 0;
            String re = "";
            re = mposC.mposDB.bilDB.insertBill(bil, "");
            if (long.TryParse(re, out chk))
            {
                foreach (Order1 row in lOrd)
                {
                    BillDetail bild1 = new BillDetail();
                    bild1 = setBillDetail(re, row);
                    String re1 = "";
                    re1 = mposC.mposDB.bildDB.insertBillDetail(bild1, "");
                    mposC.mposDB.ordDB.updateStatusBillComplete(bild1.order_id, re1);
                    if (!long.TryParse(re1, out chk))
                    {
                        MessageBox.Show("error", "");
                    }
                }
                
            }
        }
        private BillDetail setBillDetail(String billid, Order1 row)
        {

            BillDetail bild1 = new BillDetail();
            bild1.bill_detail_id = "";
            bild1.bill_id = billid;
            bild1.order_id = row.order_id;
            bild1.lot_id = row.lot_id;
            bild1.status_void = "";
            bild1.row1 = row.row1;
            bild1.foods_id = row.foods_id;
            bild1.foods_code = row.foods_code;

            bild1.active = "";
            bild1.remark = "";
            bild1.sort1 = "";
            bild1.date_cancel = "";
            bild1.date_create = "";
            bild1.date_modi = "";
            bild1.user_cancel = "";
            bild1.user_create = "";
            bild1.user_modi = "";
            bild1.host_id = "";
            bild1.branch_id = "";
            bild1.device_id = "";
            bild1.price = row.price;
            bild1.qty = row.qty;
            bild1.amount = row.sumPrice;

            //bild.Add(bild1);


            return bild1;
        }
        private Bill setBill()
        {
            Order1 ord = new Order1();
            ord = lOrd[0];
            decimal amt = 0;
            foreach (Order1 row in lOrd)
            {
                String amt1 = "";
                decimal price = 0, qty = 0;
                decimal.TryParse(row.price, out price);
                decimal.TryParse(row.qty, out qty);
                amt += (price * qty);
            }
            Bill bil = new Bill();
            bil.bill_id = "";
            bil.bill_code = "";
            bil.bill_date = DateTime.Now.Year.ToString() +"-"+DateTime.Now.ToString("MM-dd");
            bil.lot_id = ord.lot_id;
            bil.status_void = "";
            bil.void_date = "";
            bil.void_user = "";

            bil.active = "";
            bil.remark = "";
            bil.sort1 = "";
            bil.date_cancel = "";
            bil.date_create = "";
            bil.date_modi = "";
            bil.user_cancel = "";
            bil.user_create = "";
            bil.user_modi = "";
            bil.host_id = "";
            bil.branch_id = "";
            bil.device_id = mposC.MACAddress;

            bil.table_id = mposC.tableidToGo;
            bil.res_id = mposC.res.res_id;
            bil.area_id = "";
            bil.amount = amt.ToString();
            bil.discount = "0";

            bil.service_charge = "";
            bil.vat = "";
            bil.total = amt.ToString();
            bil.nettotal = amt.ToString();
            bil.cash_receive = amt.ToString();
            bil.cash_ton = "";
            bil.bill_user = "";
            bil.status_closeday = "0";
            bil.closeday_id = "";
            bil.status_void = "";

            return bil;
        }
        private void printBill()
        {
            PrintDocument document = new PrintDocument();
            document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
            document.PrintPage += new PrintPageEventHandler(printBill_PrintPage);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer

            //document.PrinterSettings.PrinterName = ord1.printer_name;
            document.Print();

            document = new PrintDocument();
            document.PrinterSettings.PrinterName = mposC.iniC.printerOrder;
            document.PrintPage += new PrintPageEventHandler(printBill_PrintPage);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer

            //document.PrinterSettings.PrinterName = ord1.printer_name;
            document.Print();
        }
        private void printBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float marginR = e.MarginBounds.Right;

            //topMargin = 5;
            //leftMargin = 5;
            //marginR = 80;
            float.TryParse(mposC.res.printer_bill_print_left, out leftMargin);
            float.TryParse(mposC.res.printer_bill_print_right, out marginR);
            float.TryParse(mposC.res.printer_bill_print_top, out topMargin);
            float avg = marginR / 2;

            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            String date = "";
            date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            String amt = "";
            Decimal amt1 = 0;
            float yPos = 0, gap = 6;
            int count = 0;
            string line = null;
            try
            {
                //amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                amt = ord1.price;
                Decimal.TryParse(amt, out amt1);

                //lbAmt.Text = "จำนวนเงินต้องชำระ " + amt1.ToString("0.00");
            }
            catch (Exception ex)
            {

            }
            Pen blackPen = new Pen(Color.Black, 1);
            Image resizedImage;
            int originalWidth = Resources.logo2.Width;
            int newWidth = 100;
            Size proposedSize = new Size(100, 100);
            StringFormat flags = new StringFormat(StringFormatFlags.LineLimit);  //wraps
            Size textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            Int32 xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            Int32 yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?

            resizedImage = Resources.logo2.GetThumbnailImage(newWidth, (newWidth * Resources.logo2.Height) / originalWidth, null, IntPtr.Zero);

            //e.Graphics.DrawImage(Resources.siph2, avg - (Resources.siph2.Width / 2), topMargin);
            e.Graphics.DrawImage(resizedImage, avg - (resizedImage.Width / 2), topMargin);

            count++; count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.res_name;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());leftMargin
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_header1;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_header2 + " " + que;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "Staff : Machine VNE1";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "Date :" + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm");
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);

            count++; count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "GOTO";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            e.Graphics.DrawLine(blackPen, leftMargin - 5, yPos, marginR + 300, yPos);
            int i = 1;
            foreach (Order1 ord in lOrd)
            {
                count++;
                yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
                line = i + ". " + ord.foods_name + " " + ord.qty;
                textSize = TextRenderer.MeasureText(line, ford, proposedSize, TextFormatFlags.RightToLeft);
                xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
                e.Graphics.DrawString(line, ford, Brushes.Black, leftMargin, yPos, flags);
                textSize = TextRenderer.MeasureText(ord.price, ford, proposedSize, TextFormatFlags.RightToLeft);
                e.Graphics.DrawString(ord.price, ford, Brushes.Black, marginR - textSize.Width - gap - 5, yPos, flags);
                if ((ord.special != null) && !ord.special.Equals(""))
                {
                    String[] txt = ord.special.Split('+');
                    foreach (String txt1 in txt)
                    {
                        count++;
                        line = "     " + txt1.Trim();
                        yPos = topMargin + (count * ford.GetHeight(e.Graphics) + gap);
                        textSize = TextRenderer.MeasureText(line, ford, proposedSize, TextFormatFlags.RightToLeft);
                        xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                        yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                        e.Graphics.DrawString(line, ford, Brushes.Black, leftMargin, yPos, flags);
                    }
                }
                if ((ord.topping != null) && !ord.topping.Equals(""))
                {
                    String[] txt = ord.topping.Split('+');
                    foreach (String txt1 in txt)
                    {
                        count++;
                        line = "     " + txt1.Trim();
                        yPos = topMargin + (count * ford.GetHeight(e.Graphics) + gap);
                        textSize = TextRenderer.MeasureText(line, ford, proposedSize, TextFormatFlags.RightToLeft);
                        xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                        yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                        e.Graphics.DrawString(line, ford, Brushes.Black, leftMargin, yPos, flags);
                    }
                }

                i++;
            }
            count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            e.Graphics.DrawLine(blackPen, leftMargin - 5, yPos, marginR + 300, yPos);

            count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_footer1;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_footer2;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);
        }
        private void printOrder()
        {
            List<String> lprn = new List<String>();
            iprn = 1;
            que = "";
            que = mposC.mposDB.copDB.genQueue1Doc();
            foreach (Order1 ord in lOrd)
            {
                //String printername = "";
                //printername = ord.printer_name;
                ord1 = ord;
                PrintDocument document = new PrintDocument();
                //MessageBox.Show("ord1.printer_name "+ ord1.printer_name, "");
                if (ord1.printer_name.Length > 0)
                {
                    try
                    {
                        ord1 = ord;
                        //PrintDocument document = new PrintDocument();
                        //MessageBox.Show("ord1.printer_name "+ ord1.printer_name, "");
                        if (ord1.printer_name.Length == 0)
                        {
                            //MessageBox.Show("ไม่ได้ตั้งชื่อ Printer Order", "");
                            continue;
                        }
                        document.PrinterSettings.PrinterName = ord1.printer_name;
                        document.PrintPage += new PrintPageEventHandler(printOrder_PrintPage);
                        //This is where you set the printer in your case you could use "EPSON USB"
                        //or whatever it is called on your machine, by Default it will choose the default printer
                        //document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
                        document.Print();
                        Application.DoEvents();
                        iprn++;
                    }
                    catch (Exception ex)
                    {
                        new LogFile("er "+ ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบ Prnt Name ", "");
                }
            }
        }
        private void printOrder_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //This part sets up the data to be printed
            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            //gets the text from the textbox
            String stringToPrint = "";
            string printText = "";

            String date = "";
            date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            String amt = "";
            Decimal amt1 = 0;
            try
            {
                //amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                amt = ord1.price;
                Decimal.TryParse(amt, out amt1);

                //lbAmt.Text = "จำนวนเงินต้องชำระ " + amt1.ToString("0.00");
            }
            catch (Exception ex)
            {

            }

            //que = mposC.mposDB.copDB.genQueue1Doc();
            stringToPrint = que + Environment.NewLine;
            stringToPrint += "เวลา " + date + Environment.NewLine;

            String name = "";
            name = ord1.foods_name;
            //ord1.special = ord1.special == null ? "" : ord1.special;
            //ord1.topping = ord1.topping == null ? "" : ord1.topping;
            int row = 0;
            int.TryParse(ord1.row1, out row);
            //int.TryParse(lOrd.Count, out cnt);
            //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            if (ord1.status_create.Equals("1"))
            {
                if (ord1.foods_name.IndexOf("เพิ่ม") >= 0)
                {
                    String temp1 = ord1.foods_name.Substring(0, ord1.foods_name.IndexOf("เพิ่ม")).Trim();
                    printText += (row) + "[" + lOrd.Count + "]  " + temp1 + Environment.NewLine;

                    String temp2 = (ord1.foods_name.Substring(ord1.foods_name.IndexOf("เพิ่ม")).Trim()).Replace("เพิ่ม","").Trim();
                    String[] temp22 = temp2.Split(' ');
                    if (temp2.Length > 0)
                    {
                        printText += "       เพิ่ม" + Environment.NewLine;
                        foreach (String temp222 in temp22)
                        {
                            printText += "       " + temp222.Trim() + Environment.NewLine;
                        }
                    }
                }
                
            }
            else
            {
                printText += (row) + "[" + lOrd.Count + "]  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            }

            foreach(OrderTopping ordt in lordt)
            {
                if (ordt.foods_id.Equals(ord1.foods_id) && ordt.status_ok.Equals("1"))
                {
                    decimal price = 0, qty = 0;
                    if(decimal.TryParse(ordt.price, out price))
                    {

                    }
                    if (decimal.TryParse(ordt.qty, out qty))
                    {

                    }
                    printText += "   " + ordt.name + " " + (price * qty).ToString() + " " + Environment.NewLine;
                }
            }
            foreach (OrderSpecial ords in lords)
            {
                if (ords.foods_id.Equals(ord1.foods_id) && ords.status_ok.Equals("1"))
                {
                    printText += "   " + ords.name + Environment.NewLine;
                }
            }
            //String[] txt = ord1.special.Split('+');
            //if (txt.Length > 1)
            //{
            //    String name1 = "";
            //    foreach (String txt1 in txt)
            //    {
            //        name1 += txt1.Trim() + Environment.NewLine;
            //    }
            //    name1 = name1.Trim();
            //    if (name1.IndexOf("+") == 0)
            //    {
            //        name1 = name1.Substring(1, name1.Length - 1);
            //    }
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //    //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += name1 + Environment.NewLine;
            //}
            //String[] txtT = ord1.topping.Split('+');
            //if (txtT.Length > 1)
            //{
            //    String name1 = "";
            //    foreach (String txt1 in txtT)
            //    {
            //        name1 += txt1.Trim() + Environment.NewLine;
            //    }
            //    name1 = name1.Trim();
            //    if (name1.IndexOf("+") == 0)
            //    {
            //        name1 = name1.Substring(1, name1.Length - 1);
            //    }
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //    //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += name1 + Environment.NewLine;

            //}
            //else
            //{
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //}
            printText += "          " + ord1.remark + Environment.NewLine;

            stringToPrint += printText;
            stringToPrint += Environment.NewLine;
            stringToPrint += "         จำนวนเงิน " + amt1.ToString("0.00") + Environment.NewLine;
            g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);

        }
        public void setBtnPay(String pay)
        {
            btnPay.Text = pay;
        }
        private void FrmTakeOut4_Load(object sender, EventArgs e)
        {
            flagShowTitle = false;
            setTitle(flagShowTitle);
            if (mposC.iniC.sCFoodsMainSplitterWidth.Equals("0"))
            {
                sCFoodsMain.SplitterWidth = 0;
                //scFoodsCat.Collapsed = false;
            }
            else
            {
                sCFoodsMain.SplitterWidth = 1;
                scFoodsCat.Collapsed = true;
            }
            if (mposC.iniC.sCOrderSplitterWidth.Equals("0"))
            {
                sCOrder.SplitterWidth = 0;
                //scFoods.Collapsed = false;
            }
            else
            {
                sCOrder.SplitterWidth = 1;
                //scFoodsCat.Collapsed = true;
            }

            if (mposC.iniC.takeouttilverticalsize.Equals("2"))
            {
                scFoodsCat.Height = 260;
            }
            else
            {
                scFoodsCat.Height = 260;
            }
            pnOrdOrder.Height = this.Height - pnOrdHead.Height -200;
            pnOrdOrder.Width = 420;
            scFoods.Width = this.Width - 440;
            scCheckLeft.Width = this.Width - 900;
            //scFoods.Width = int.Parse(mposC.iniC.scFoodsWidth);
            btnPay.Width = 420;
            btnPay.TextAlign = ContentAlignment.MiddleCenter;
            btnPay.Font = fgrd;
            //pnOrdOrder.Height = this.Height - pnOrdHead.Height - pnOrdBill.Height; 
        }
    }
}
