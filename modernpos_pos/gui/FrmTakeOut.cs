using C1.Framework;
using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using C1.Win.C1Tile;
using modernpos_pos.control;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace modernpos_pos.gui
{
    public partial class FrmTakeOut : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public List<Foods> lfooT;
        public List<Foods> lfooR;
        Foods foo;
        //Theme theme1;
        
        C1.Win.C1Tile.PanelElement panelElement1;
        C1.Win.C1Tile.ImageElement imageElement1;
        C1.Win.C1Tile.TextElement textElement1, txtFoodsName, txtFoodsPrice;
        
        
        Template tempFlickr;
        C1.Win.C1Tile.ImageElement imageElement8;
        PanelElement pnFoodsName, pnFoodsPrice;
        C1FlexGrid grf;
        C1DockingTab tC;

        VNEControl vneC;
        int colNo = 1, colFooName = 2, colPrice = 3, colQty=4, colRemark=5, colTopping=6, colStatus = 7, colFooId=8, colPrinterName=9, colFooName1=10;

        List<Order1> lOrd;
        Order1 ord;
        DataTable dtCat = new DataTable();
        DataTable dtRec= new DataTable();
        IntPtr intptr = new IntPtr();
        C1DockingTabPage[] tabPage;
        C1TileControl[] TileFoods;
        C1TileControl TileRec;
        Group[] gr1;
        Group grRec;
        Boolean flagModi = false;
        public FrmTakeOut(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize+5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular+2);

            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            //theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }

            bg = txtTableCode.BackColor;
            fc = txtTableCode.ForeColor;
            ff = txtTableCode.Font;

            lfooT = new List<Foods>();
            lfooR = new List<Foods>();
            lOrd = new List<Order1>();
            foo = new Foods();
            ord = new Order1();
            lfooT = mposC.mposDB.fooDB.getlFoods1();
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();

            btnVoid.Enabled = false;

            if (mposC.iniC.pnOrderborderstyle.Equals("0"))
            {
                pnOrder.BorderStyle = BorderStyle.None;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("1"))
            {
                pnOrder.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("2"))
            {
                pnOrder.BorderStyle = BorderStyle.FixedSingle;
            }
            
            btnPay.Click += BtnPay_Click;
            btnVoid.Click += BtnVoid_Click;
            btnSpec.Click += BtnSpec_Click;
            btnTopping.Click += BtnTopping_Click;

            initGrf();
            initTC();
            flagModi = false;
            setBtnEnable(flagModi);
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void BtnTopping_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            mposC.fooName = "";
            mposC.fooTopping = "";
            mposC.toppingPrice = "";
            mposC.foosumprice = "";
            FrmTakeOutTopping frm = new FrmTakeOutTopping(mposC, txtFooId.Text);
            frm.ShowDialog(this);
            int row = 0;
            String spec = "", name="";
            if (int.TryParse(txtRow.Text, out row))
            {
                spec = grf[row, colRemark] == null ? "" : grf[row, colRemark].ToString();
                name = grf[row, colFooName1] == null ? "" : grf[row, colFooName1].ToString();
                if (!mposC.fooName.Equals(""))
                {
                    if (spec.Equals(""))
                    {
                        grf[row, colFooName] = mposC.fooName + " + " + mposC.fooTopping;
                    }
                    else
                    {
                        grf[row, colFooName] = mposC.fooName + " + " + spec + " + " + mposC.fooTopping;
                    }
                }
                    
                if (!mposC.fooTopping.Equals(""))
                    grf[row, colTopping] = mposC.fooTopping;
                if (!mposC.toppingPrice.Equals(""))
                    grf[row, colPrice] = mposC.foosumprice;
            }
            UpdateTotals();
        }

        private void BtnSpec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            mposC.fooName = "";
            mposC.fooSpec = "";
            FrmTakeOutSpecial frm = new FrmTakeOutSpecial(mposC, txtFooId.Text);
            frm.ShowDialog(this);
            int row = 0;
            String topping = "", name = "";
            if (int.TryParse(txtRow.Text, out row))
            {
                topping = grf[row, colTopping] == null ? "" : grf[row, colTopping].ToString();
                name = grf[row, colFooName1] == null ? "" : grf[row, colFooName1].ToString();
                if (!mposC.fooName.Equals(""))
                {
                    if (topping.Equals(""))
                    {
                        grf[row, colFooName] = mposC.fooName + " + " + mposC.fooSpec;
                    }
                    else
                    {
                        grf[row, colFooName] = mposC.fooName + " + " + mposC.fooSpec + " + " + topping;
                    }
                }                
                if (!mposC.fooSpec.Equals(""))
                    grf[row, colRemark] = mposC.fooSpec;
            }
            UpdateTotals();
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = 0;
            if(int.TryParse(txtRow.Text, out row))
            {
                grf.Rows.Remove(row);
            }
        }

        private void initTC()
        {
            dtCat = mposC.mposDB.foocDB.selectAll();
            dtRec = mposC.mposDB.foocDB.selectAll();
            tC = new C1DockingTab();
            tC.Dock = System.Windows.Forms.DockStyle.Fill;
            tC.Location = new System.Drawing.Point(0, 266);
            tC.Name = "c1DockingTab1";
            tC.Size = new System.Drawing.Size(669, 200);
            tC.TabIndex = 0;
            tC.TabsSpacing = 5;
            tC.Font = fEdit1;
            pnOrder.Controls.Add(tC);
            tabPage = new C1DockingTabPage[dtCat.Rows.Count + 1];
            TileFoods = new C1TileControl[dtCat.Rows.Count + 1];
            gr1 = new Group[dtCat.Rows.Count + 1];
            tabPage[0] = new C1DockingTabPage();
            tabPage[0].Location = new System.Drawing.Point(1, 24);
            tabPage[0].Name = "c1DockingTabPage1";
            tabPage[0].Size = new System.Drawing.Size(667, 175);
            tabPage[0].TabIndex = 0;
            tabPage[0].Text = "Recommend";
            tabPage[0].Name = "Page0";
            tC.Controls.Add(tabPage[0]);

            TileRec = new C1TileControl();
            TileRec.Dock = DockStyle.Fill;
            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileRec.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileRec.Orientation = LayoutOrientation.Vertical;
            }
            grRec = new Group();
            TileRec.Groups.Add(this.grRec);
            grRec = new Group();
            panelElement1 = new C1.Win.C1Tile.PanelElement();
            imageElement1 = new C1.Win.C1Tile.ImageElement();
            tempFlickr = new C1.Win.C1Tile.Template();
            imageElement8 = new C1.Win.C1Tile.ImageElement();
            textElement1 = new C1.Win.C1Tile.TextElement();
            pnFoodsName = new C1.Win.C1Tile.PanelElement();
            pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
            txtFoodsName = new C1.Win.C1Tile.TextElement();
            txtFoodsPrice = new C1.Win.C1Tile.TextElement();
            imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            txtFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            txtFoodsName.ForeColor = System.Drawing.Color.Black;
            txtFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            txtFoodsName.SingleLine = true;
            pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pnFoodsName.Children.Add(txtFoodsName);
            pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
            pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
            pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //panelElement11.Children.Add(panelElement12);
            pnFoodsPrice.Children.Add(txtFoodsPrice);
            pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnFoodsPrice.FixedHeight = 32;
            txtFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            txtFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
            txtFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
            textElement1.Font = fEdit;
            TileRec.Font = fEdit;

            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            TileRec.DefaultTemplate.Elements.Add(panelElement1);
            TileRec.Templates.Add(this.tempFlickr);
            //TileFoods = new C1TileControl();
            TileRec.Name = "tilerec";
            TileRec.Dock = DockStyle.Fill;
            //pnOrder.Controls.Add(TileFoods);                    

            this.tempFlickr.Elements.Add(imageElement8);
            this.tempFlickr.Elements.Add(pnFoodsName);
            this.tempFlickr.Elements.Add(pnFoodsPrice);
            this.tempFlickr.Name = "tempFlickrrec";
            TileRec.ScrollOffset = 0;
            TileRec.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileRec.Padding = new System.Windows.Forms.Padding(0);
            TileRec.GroupPadding = new System.Windows.Forms.Padding(20);
            tabPage[0].Controls.Add(TileRec);
            for (int i = 1; i < dtCat.Rows.Count+1; i++)
            {
                //if (i == 0)
                //{

                //}
                //else
                //{
                //if (i == dtCat.Rows.Count) continue;
                tabPage[i] = new C1DockingTabPage();
                gr1[i] = new Group();
                tabPage[i].Location = new System.Drawing.Point(1, 24);
                //tabPage.Name = "c1DockingTabPage"+i;
                tabPage[i].Size = new System.Drawing.Size(667, 175);
                tabPage[i].TabIndex = 0;
                tabPage[i].Text = dtCat.Rows[i-1]["foods_cat_name"].ToString();
                tabPage[i].Name = "Page" + i;
                
                //tabPage[i].Font = fEditB;
                tC.Controls.Add(tabPage[i]);

                TileFoods[i] = new C1TileControl();
                if (i == 1)
                {
                    intptr = TileFoods[i].Handle;
                }
                if (mposC.iniC.TileFoodsOrientation.Equals("0"))
                {
                    TileFoods[i].Orientation = LayoutOrientation.Horizontal;
                }
                else
                {
                    TileFoods[i].Orientation = LayoutOrientation.Vertical;
                }
                TileFoods[i].Groups.Add(this.gr1[i]);
                panelElement1 = new C1.Win.C1Tile.PanelElement();
                imageElement1 = new C1.Win.C1Tile.ImageElement();
                tempFlickr = new C1.Win.C1Tile.Template();
                imageElement8 = new C1.Win.C1Tile.ImageElement();
                textElement1 = new C1.Win.C1Tile.TextElement();
                pnFoodsName = new C1.Win.C1Tile.PanelElement();
                pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
                txtFoodsName = new C1.Win.C1Tile.TextElement();
                txtFoodsPrice = new C1.Win.C1Tile.TextElement();
                imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
                txtFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                txtFoodsName.ForeColor = System.Drawing.Color.Black;
                txtFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
                txtFoodsName.SingleLine = true;
                pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                pnFoodsName.Children.Add(txtFoodsName);
                pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
                pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
                pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
                pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                //panelElement11.Children.Add(panelElement12);
                pnFoodsPrice.Children.Add(txtFoodsPrice);
                pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnFoodsPrice.FixedHeight = 32;
                txtFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                txtFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
                txtFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
                textElement1.Font = fEdit;
                TileFoods[i].Font = fEdit;

                panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
                panelElement1.Children.Add(imageElement1);
                panelElement1.Children.Add(textElement1);
                panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
                TileFoods[i].DefaultTemplate.Elements.Add(panelElement1);
                TileFoods[i].Templates.Add(this.tempFlickr);
                //TileFoods = new C1TileControl();
                TileFoods[i].Name = "tile"+i;
                TileFoods[i].Dock = DockStyle.Fill;
                //pnOrder.Controls.Add(TileFoods);                    

                this.tempFlickr.Elements.Add(imageElement8);
                this.tempFlickr.Elements.Add(pnFoodsName);
                this.tempFlickr.Elements.Add(pnFoodsPrice);
                this.tempFlickr.Name = "tempFlickr";
                TileFoods[i].ScrollOffset = 0;
                TileFoods[i].SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
                TileFoods[i].Padding = new System.Windows.Forms.Padding(0);
                TileFoods[i].GroupPadding = new System.Windows.Forms.Padding(20);

                tabPage[i].Controls.Add(TileFoods[i]);
                //}
                
            }
        }
        private void genLotId()
        {
            String lotid = "";
            lotid = mposC.mposDB.seqDB.genLotId();
            foreach(Order1 ord in lOrd)
            {
                ord.lot_id = lotid;
            }
        }
        private void setFooNameRemark()
        {
            foreach(Row row in grf.Rows)
            {
                try
                {
                    if (row[colFooName] == null) continue;
                    int rowid1 = 0;
                    String fooname = "", rowid="", spec="";
                    fooname = row[colFooName].ToString();
                    rowid = row[colNo].ToString();
                    spec = row[colRemark].ToString();
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
            mposC.statusVNEPaysuccess = "";
            genLotId();
            setFooNameRemark();
            FrmTakeOutCheck frm = new FrmTakeOutCheck(mposC, lOrd);
            frm.ShowDialog(this);

            if (mposC.statusVNEPaysuccess.Equals("1"))
            {
                lOrd.Clear();
            }
        }

        private void initGrf()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grf.Rows.Count = 1;
            grf.Cols.Count = 11;
            grf.Cols[colNo].Width = 40;
            grf.Cols[colFooName].Width = 300;
            grf.Cols[colPrice].Width = 80;
            //FilterRow fr = new FilterRow(grfExpn);
            grf.TabStop = false;
            grf.EditOptions = EditFlags.None;
            grf.Cols[colNo].AllowEditing = false;
            grf.Cols[colFooName].AllowEditing = false;
            grf.Cols[colPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grf.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grf.AfterDataRefresh += Grf_AfterDataRefresh;
            //grf.SubtotalPosition = SubtotalPositionEnum.BelowData;
            grf.SubtotalPosition = SubtotalPositionEnum.BelowData;

            grf.AfterRowColChange += Grf_AfterRowColChange;
            grf.Click += Grf_Click;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grf.ContextMenu = menuGw;
            //grf.EndUpdate();
            pnBill.Controls.Add(grf);
            grf.Cols[colFooId].Visible = false;
            grf.Cols[colStatus].Visible = false;
            grf.Cols[colPrinterName].Visible = false;
            grf.Cols[colQty].Visible = false;
            grf.Cols[colRemark].Visible = false;
            grf.Cols[colTopping].Visible = false;
            grf.Cols[colFooName1].Visible = false;
            pnBill.Width =  mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setBtnEnable(Boolean flag)
        {
            btnVoid.Enabled = flag;
            btnSpec.Enabled = flag;
            btnTopping.Enabled = flag;
        }
        private void Grf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grf.Row < 0) return;
            if (grf.Col < 0) return;
            if (grf[grf.Row, colFooName] == null) return;
            flagModi = true;
            String name = "", id="";
            name = grf[grf.Row, colFooName].ToString();
            id = grf[grf.Row, colFooId].ToString();
            lbFooName.Text = name;
            txtFooId.Value = id;
            txtRow.Value = grf.Row;
            setBtnEnable(flagModi);
        }

        private void Grf_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }

        private void Grf_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void UpdateTotals()
        {
            // clear existing totals
            grf.Subtotal(AggregateEnum.Clear);
            grf.Subtotal(AggregateEnum.Sum, 0, -1, colPrice, "Grand Total");
            
        }
        private void setGrf(String id, String name, String price, String qty, String remark, String printer)
        {
            String re = "";
            if (!name.Equals(""))
            {
                //String[] ext = name.Split('#');
                Order1 ord1 = new Order1();
                Row row = grf.Rows.Add();
                row[colFooName] = name;
                row[colPrice] = price;
                row[colFooId] = id;
                row[colRemark] = remark;
                row[colNo] = grf.Rows.Count - 2;
                row[colPrinterName] = printer;
                row[colFooName1] = name;
                ord1.order_id = "";
                ord1.price = price;
                ord1.qty = "1";
                ord1.status_bill = "0";
                ord1.foods_id = id;
                ord1.foods_name = name;
                ord1.remark = remark;
                ord1.row1 = grf.Rows.Count.ToString();
                lOrd.Add(ord1);
                UpdateTotals();
            }
        }
        private void LoadFoods(bool keepExistent)
        {
            TileCollection tiles1 = TileRec.Groups[0].Tiles;
            tiles1.Clear(true);
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();
            foreach (Foods foo1 in lfooR)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempFlickr;
                tile.Text = foo1.foods_name;
                tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foo1;
                tile.Name = foo1.foods_id;
                tile.Click += Tile_Click;
                tile.Image = null;
                try
                {
                    tile.Image = null;
                    tiles1.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (foo1.filename.Equals("")) continue;
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + foo1.filename);
                    loadedImage = new Bitmap(stream);
                    if (loadedImage != null)
                    {
                        //SizeF size = tile.Width;
                        int originalWidth = loadedImage.Width;
                        int newWidth = 180;
                        resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        tile.Image = resizedImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "showImg");
                }
                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));


                
            }

            for (int i = 0; i < dtCat.Rows.Count; i++)
            {
                LoadFoods(false, i, dtCat.Rows[i]["foods_cat_id"].ToString());
            }
        }
        private void LoadFoods(bool keepExistent, int index, String catid)
        {
            //Control.FromHandle(intptr);
            Control ctl = new Control();
            ctl = tabPage[1];
            //if (index == 0) return;
            if (TileFoods[index + 1] == null) return;
            TileCollection tiles = TileFoods[index+1].Groups[0].Tiles;
            tiles.Clear(true);
            lfooT = mposC.mposDB.fooDB.getlFoodsByCat(catid);
            foreach (Foods foo1 in lfooT)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempFlickr;
                tile.Text = foo1.foods_name;
                tile.Text1 = "ราคา "+foo1.foods_price;
                tile.Tag = foo1;
                tile.Name = foo1.foods_id;
                tile.Click += Tile_Click;
                tile.Image = null;
                try
                {
                    tile.Image = null;
                    tiles.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (foo1.filename.Equals("")) continue;
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + foo1.filename);
                    loadedImage = new Bitmap(stream);
                    if (loadedImage != null)
                    {
                        //SizeF size = tile.Width;
                        int originalWidth = loadedImage.Width;
                        int newWidth = 180;
                        resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        tile.Image = resizedImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "showImg");
                }
                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));


                
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Tile tile = sender as Tile;
            if (tile != null)
            {
                Foods foo = new Foods();
                foo = (Foods)tile.Tag;
                setGrf(tile.Name, tile.Text, tile.Text1.Replace("ราคา", "").Trim(),"1","", foo.printer_name);
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
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    Close();
                    return true;
                }
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmTakeOut_Load(object sender, EventArgs e)
        {
            //TileFoods.Groups[0].Tiles.Clear(true);
            lbFooName.Text = "";
            LoadFoods(false);
        }
    }
}
