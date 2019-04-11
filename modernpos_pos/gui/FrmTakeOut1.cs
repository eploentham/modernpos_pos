using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using C1.Win.C1Tile;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
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
    public partial class FrmTakeOut1 : Form
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

        C1.Win.C1Tile.PanelElement peOrd, peSpec, peSpecName;
        C1.Win.C1Tile.ImageElement ieOrd, ieSpec, ieSpec8;
        C1.Win.C1Tile.TextElement teOrd, teOrdFoodsName, teOrdFoodsPrice, teSpec, teSpecName;

        Template tempFlickr, tempSpec;
        C1.Win.C1Tile.ImageElement imageElement8;
        PanelElement pnFoodsName, pnFoodsPrice;
        C1FlexGrid grfOrder, grfSpec, grfTopping, grf;
        C1DockingTab tC;

        VNEControl vneC;
        int colNo = 1, colFooName = 2, colPrice = 3, colQty = 4, colRemark = 5, colTopping = 6, colStatus = 7, colFooId = 8, colPrinterName = 9, colFooName1 = 10;
        int colSNo = 1, colSImg = 2, colSFoosName = 3, colSStatus = 4;
        int colTNo = 1, colTImg = 2, colTFoosName = 3, colTPrice = 4, colTStatus = 5;

        List<Order1> lOrd;
        Order1 ord;
        DataTable dtCat = new DataTable();
        DataTable dtRec = new DataTable();
        IntPtr intptr = new IntPtr();
        C1DockingTabPage[] tabPage;
        C1TileControl[] TileFoods;
        C1TileControl TileRec, TileSpec;
        Group[] gr1;
        Group grRec, grSpec;
        Boolean flagModi = false, flagShowTitle=false;
        Image imgR, imgC;
        String fooid = "", fooSpec = "", fooTopping = "";

        public FrmTakeOut1(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            //MessageBox.Show("FrmTakeOut initConfig 1", "");
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);

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
            //MessageBox.Show("FrmTakeOut initConfig 2", "");
            lfooT = new List<Foods>();
            lfooR = new List<Foods>();
            lOrd = new List<Order1>();
            foo = new Foods();
            ord = new Order1();
            lfooT = mposC.mposDB.fooDB.getlFoods1();
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();

            btnVoid.Enabled = false;
            //MessageBox.Show("FrmTakeOut initConfig 3", "");
            if (mposC.iniC.pnOrderborderstyle.Equals("0"))
            {
                pnOrder1.BorderStyle = BorderStyle.None;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("1"))
            {
                pnOrder1.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("2"))
            {
                pnOrder1.BorderStyle = BorderStyle.FixedSingle;
            }

            btnPay.Click += BtnPay_Click;
            btnVoid.Click += BtnVoid_Click;
            btnSpec.Click += BtnSpec_Click;
            btnReturn.Click += BtnReturn_Click;
            //btnTopping.Click += BtnTopping_Click;
            btnVoidAll.Click += BtnVoidAll_Click;
            //spMain.SplitterMoved += SpMain_SplitterMoved;
            pnOrder.Resize += PnOrder_Resize;

            imgR = Resources.red_checkmark_png_16;
            //MessageBox.Show("FrmTakeOut initConfig", "");
            initGrfOrder();
            //initGrfSpec();
            initTC();
            initSpec();
            initGrfTopping();
            
            flagModi = false;
            setBtnEnable(flagModi);
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void initSpec()
        {
            ieSpec8 = new C1.Win.C1Tile.ImageElement();
            ieSpec8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            tempSpec = new C1.Win.C1Tile.Template();
            TileSpec = new C1TileControl();
            TileSpec.Dock = DockStyle.Fill;
            //teOrd.Font = fEdit;
            TileSpec.Font = fEdit;
            //tempSpec.Elements.Add(pnFoodsPrice);
            tempSpec.Name = "tempSpec";

            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileSpec.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileSpec.Orientation = LayoutOrientation.Vertical;
            }
            grSpec = new Group();
            TileSpec.Groups.Add(grSpec);
            peSpec = new C1.Win.C1Tile.PanelElement();
            ieSpec = new C1.Win.C1Tile.ImageElement();
            teSpec = new C1.Win.C1Tile.TextElement();
            teSpec.Font = fEdit;
            teSpec.Alignment = ContentAlignment.TopRight;
            ieSpec.Alignment = ContentAlignment.TopLeft;
            peSpec.Alignment = System.Drawing.ContentAlignment.TopLeft;
            peSpec.Children.Add(ieSpec);
            peSpec.Children.Add(teSpec);
            peSpec.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            //TileSpec.DefaultTemplate.Elements.Add(peSpec);
            TileSpec.Font = fEdit;
            //TileSpec.Templates.Add(this.tempFlickr);
            TileSpec.Name = "tilespec";
            TileSpec.Dock = DockStyle.Fill;
            TileSpec.ScrollOffset = 0;
            TileSpec.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileSpec.Padding = new System.Windows.Forms.Padding(0);
            TileSpec.GroupPadding = new System.Windows.Forms.Padding(20);
            TileSpec.Templates.Add(this.tempSpec);
            //TileSpec.Groups.Add(grSpec);

            peSpecName = new C1.Win.C1Tile.PanelElement();
            peSpecName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            peSpecName.Children.Add(teOrdFoodsName);
            peSpecName.Dock = System.Windows.Forms.DockStyle.Top;
            peSpecName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            teSpecName = new C1.Win.C1Tile.TextElement();
            teSpecName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teSpecName.ForeColor = System.Drawing.Color.Black;
            teSpecName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teSpecName.SingleLine = true;
            tempSpec.Elements.Add(ieSpec8);
            tempSpec.Elements.Add(peSpecName);
            tempSpec.Name = "tempSpec";
            
            peSpecName.Children.Add(teSpecName);
            pnSpecial.Controls.Add(TileSpec);
        }
        private void PnOrder_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            label2.Text = pnOrder.Width.ToString();
            if(pnOrder.Width>500)
                grfOrder.Cols[colFooName].Width = pnOrder.Width - 300;
            else
                grfOrder.Cols[colFooName].Width = 300;
        }

        private void SpMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //throw new NotImplementedException();
            //String aa = "";
            //aa = pnItem.Width.ToString();
            //label1.Text = pnOrder.Width.ToString();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Decimal price = 0, sum = 0, topping = 0;
            Decimal.TryParse(lbPrice.Text, out sum);
            Decimal.TryParse(foo.foods_price, out price);
            if (sum > 0)
                topping = sum - price;
            mposC.fooName = lbFooName.Text.Trim();
            mposC.fooSpec = fooSpec.Trim();
            mposC.fooTopping = fooTopping.Trim();
            mposC.toppingPrice = topping.ToString("0.00");
            mposC.foosumprice = lbPrice.Text;
            //mposC.fooToppingPrice = 
            mposC.fooName = fooTopping.Equals("") ? mposC.fooName.Replace("+", "").Trim() : mposC.fooName.Replace(fooTopping.Trim(), "").Replace("+", "").Trim();

            setGrfSpecialTopping();
            tabMain.SelectedTab = tabOrer;
        }

        private void BtnVoidAll_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();   
            grfOrder.Dispose();
            initGrfOrder();
        }
                
        private void setGrfSpecialTopping()
        {
            int row = 0;
            String topping = "", name = "";
            if (int.TryParse(txtRow.Text, out row))
            {
                //topping = grf[row, colTopping] == null ? "" : grf[row, colTopping].ToString();
                //name = grf[row, colFooName1] == null ? "" : grf[row, colFooName1].ToString();
                if (!mposC.fooName.Equals(""))
                {
                    Order1 ord = lOrd[row - 1];
                    //ord.special = mposC.fooSpec;
                    //ord.topping = mposC.fooTopping;
                    ord.sumPrice = mposC.foosumprice;
                    ord.toppingPrice = mposC.toppingPrice;
                    if (mposC.fooTopping.Equals(""))
                    {
                        //Order1 ord = lOrd[row - 1];
                        //ord.special = mposC.fooSpec;
                        if (!mposC.fooSpec.Equals(""))
                        {
                            grfOrder[row, colFooName] = lbFooName.Text;
                        }
                        else
                        {
                            grfOrder[row, colFooName] = lbFooName.Text;
                        }
                        grfOrder[row, colPrice] = ord.sumPrice;
                    }
                    else
                    {
                        ord.topping = fooTopping;
                        if (mposC.fooSpec.Equals(""))
                        {
                            grfOrder[row, colFooName] = lbFooName.Text;
                        }
                        else
                        {
                            grfOrder[row, colFooName] = lbFooName.Text;
                        }
                        grfOrder[row, colPrice] = ord.sumPrice;
                    }
                }
                if (!mposC.fooSpec.Equals(""))
                    grfOrder[row, colRemark] = mposC.fooSpec;
            }
            UpdateTotals();
        }
        private void clearMPOSC()
        {
            mposC.fooName = "";
            mposC.fooSpec = "";
            mposC.fooTopping = "";
            mposC.toppingPrice = "";
            mposC.fooSpec = "";
            mposC.foosumprice = "";
        }
        private void BtnSpec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            clearMPOSC();
            //FrmTakeOutSpecial frm = new FrmTakeOutSpecial(mposC, txtFooId.Text);
            //frm.ShowDialog(this);
            foo = mposC.mposDB.fooDB.selectByPk1(txtFooId.Text);
            //setGrfSpec(foo.foods_id);
            setTiltSpec(foo.foods_id);
            setGrfTopping(foo.foods_id);
            tabMain.SelectedTab = tabSpecTopping;
            lbPrice.Text = foo.foods_price;
            fooTopping = "";
            fooSpec = "";
            setLbFooName();
            //setGrfSpecialTopping();

        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = 0;
            if (int.TryParse(txtRow.Text, out row))
            {
                if (grfOrder.Rows.Count > row)
                    grfOrder.Rows.Remove(row);
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
            pnFoods.Controls.Add(tC);
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
            //grRec = new Group();
            peOrd = new C1.Win.C1Tile.PanelElement();
            ieOrd = new C1.Win.C1Tile.ImageElement();
            tempFlickr = new C1.Win.C1Tile.Template();
            imageElement8 = new C1.Win.C1Tile.ImageElement();
            teOrd = new C1.Win.C1Tile.TextElement();
            pnFoodsName = new C1.Win.C1Tile.PanelElement();
            pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
            teOrdFoodsName = new C1.Win.C1Tile.TextElement();
            teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
            imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
            teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teOrdFoodsName.SingleLine = true;
            pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pnFoodsName.Children.Add(teOrdFoodsName);
            pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
            pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
            pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //panelElement11.Children.Add(panelElement12);
            pnFoodsPrice.Children.Add(teOrdFoodsPrice);
            pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnFoodsPrice.FixedHeight = 32;
            teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
            teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
            teOrd.Font = fEdit;
            TileRec.Font = fEdit;

            peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            peOrd.Children.Add(ieOrd);
            peOrd.Children.Add(teOrd);
            peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            TileRec.DefaultTemplate.Elements.Add(peOrd);
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
            for (int i = 1; i < dtCat.Rows.Count + 1; i++)
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
                tabPage[i].Text = dtCat.Rows[i - 1]["foods_cat_name"].ToString();
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
                peOrd = new C1.Win.C1Tile.PanelElement();
                ieOrd = new C1.Win.C1Tile.ImageElement();
                tempFlickr = new C1.Win.C1Tile.Template();
                imageElement8 = new C1.Win.C1Tile.ImageElement();
                teOrd = new C1.Win.C1Tile.TextElement();
                pnFoodsName = new C1.Win.C1Tile.PanelElement();
                pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
                teOrdFoodsName = new C1.Win.C1Tile.TextElement();
                teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
                imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
                teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
                teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
                teOrdFoodsName.SingleLine = true;
                pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                pnFoodsName.Children.Add(teOrdFoodsName);
                pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
                pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
                pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
                pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                //panelElement11.Children.Add(panelElement12);
                pnFoodsPrice.Children.Add(teOrdFoodsPrice);
                pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnFoodsPrice.FixedHeight = 32;
                teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
                teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
                teOrd.Font = fEdit;
                TileFoods[i].Font = fEdit;

                peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
                peOrd.Children.Add(ieOrd);
                peOrd.Children.Add(teOrd);
                peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
                TileFoods[i].DefaultTemplate.Elements.Add(peOrd);
                TileFoods[i].Templates.Add(this.tempFlickr);
                //TileFoods = new C1TileControl();
                TileFoods[i].Name = "tile" + i;
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
            foreach (Order1 ord in lOrd)
            {
                ord.lot_id = lotid;
            }
        }
        private void setFooNameRemark()
        {
            foreach (Row row in grfOrder.Rows)
            {
                try
                {
                    if (row[colFooName] == null) continue;
                    int rowid1 = 0;
                    String fooname = "", rowid = "", spec = "";
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
            //FrmTakeOutCheck frm = new FrmTakeOutCheck(mposC, lOrd);
            //frm.ShowDialog(this);
            MessageBox.Show("mposC.statusVNEPaysuccess " + mposC.statusVNEPaysuccess, "");
            if (mposC.statusVNEPaysuccess.Equals("1"))
            {
                lOrd.Clear();
                grfOrder.Dispose();
                initGrfOrder();
            }
        }

        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);
            grfOrder.Rows[0].Visible = false;
            grfOrder.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfOrder.Rows.Count = 1;
            grfOrder.Cols.Count = 11;
            grfOrder.Cols[colNo].Width = 40;
            grfOrder.Cols[colFooName].Width = 300;
            grfOrder.Cols[colPrice].Width = 80;
            //FilterRow fr = new FilterRow(grfExpn);
            grfOrder.TabStop = false;
            grfOrder.EditOptions = EditFlags.None;
            grfOrder.Cols[colNo].AllowEditing = false;
            grfOrder.Cols[colFooName].AllowEditing = false;
            grfOrder.Cols[colPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grfOrder.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grfOrder.AfterDataRefresh += Grf_AfterDataRefresh;
            //grf.SubtotalPosition = SubtotalPositionEnum.BelowData;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;

            grfOrder.AfterRowColChange += GrfOrder_AfterRowColChange;
            grfOrder.Click += GrfOrder_Click;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grf.ContextMenu = menuGw;
            //grf.EndUpdate();
            pnOrder.Controls.Add(grfOrder);
            grfOrder.Cols[colFooId].Visible = false;
            grfOrder.Cols[colStatus].Visible = false;
            grfOrder.Cols[colPrinterName].Visible = false;
            grfOrder.Cols[colQty].Visible = false;
            grfOrder.Cols[colRemark].Visible = false;
            grfOrder.Cols[colTopping].Visible = false;
            grfOrder.Cols[colFooName1].Visible = false;
            pnOrder.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setBtnEnable(Boolean flag)
        {
            btnVoid.Enabled = flag;
            btnSpec.Enabled = flag;
            //btnTopping.Enabled = flag;
        }
        private void GrfOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfOrder.Row < 0) return;
            if (grfOrder.Col < 0) return;
            if (grfOrder[grfOrder.Row, colFooName] == null) return;
            flagModi = true;
            String name = "", id = "";
            name = grfOrder[grfOrder.Row, colFooName].ToString();
            id = grfOrder[grfOrder.Row, colFooId].ToString();
            lbFooName.Text = name;
            txtFooId.Value = id;
            txtRow.Value = grfOrder.Row;
            setBtnEnable(flagModi);
        }

        private void GrfOrder_AfterRowColChange(object sender, RangeEventArgs e)
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
            grfOrder.Subtotal(AggregateEnum.Clear);
            grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colPrice, "Grand Total");

        }
        private void setGrfOrder(String id, String name, String price, String qty, String remark, String printer)
        {
            String re = "";
            if (!name.Equals(""))
            {
                //String[] ext = name.Split('#');
                Order1 ord1 = new Order1();
                Row row = grfOrder.Rows.Add();
                row[colFooName] = name;
                row[colPrice] = price;
                row[colFooId] = id;
                row[colRemark] = remark;
                row[colNo] = grfOrder.Rows.Count - 2;
                row[colPrinterName] = printer;
                row[colFooName1] = name;
                ord1.order_id = "";
                ord1.price = price;
                ord1.qty = "1";
                ord1.status_bill = "0";
                ord1.foods_id = id;
                ord1.foods_name = name;
                ord1.remark = remark;
                ord1.row1 = grfOrder.Rows.Count.ToString();
                ord1.printer_name = printer;
                ord1.sumPrice = price;
                ord1.toppingPrice = "";
                ord1.topping = "";
                ord1.special = "";
                lOrd.Add(ord1);
                UpdateTotals();
            }
        }
        private void initGrfSpec()
        {
            grfSpec = new C1FlexGrid();
            grfSpec.Font = fEdit;
            grfSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpec.Location = new System.Drawing.Point(0, 0);
            grfSpec.Rows[0].Visible = false;
            grfSpec.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfSpec.Rows.Count = 1;
            grfSpec.Cols.Count = 5;
            grfSpec.Cols[colSImg].Width = 50;
            grfSpec.Cols[colSFoosName].Width = 200;

            grfSpec.TabStop = false;
            grfSpec.EditOptions = EditFlags.None;
            grfSpec.Cols[colSImg].AllowEditing = false;
            grfSpec.Cols[colSFoosName].AllowEditing = false;

            //grf.ExtendLastCol = true;
            grfSpec.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grfSpec.Click += GrfSpec_Click;
            pnSpecial.Controls.Add(grfSpec);
            grfSpec.Cols[colSNo].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grf.Cols[colPrinterName].Visible = false;
            //grf.Cols[colQty].Visible = false;
            //pnBill.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setTiltSpec(String fooId)
        {
            DataTable dt = new DataTable();
            List<FoodsSpecial> lfooC1 = new List<FoodsSpecial>();
            //dt = mposC.mposDB.foosDB.selectByFoodsId1(fooId);
            lfooC1 = mposC.mposDB.foosDB.getlFooSpecByFooId(fooId);
            TileCollection tiles = TileSpec.Groups[0].Tiles;
            tiles.Clear(true);
            
            //foreach (DataRow drow in dt.Rows)
            foreach (FoodsSpecial foos in lfooC1)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempSpec;
                tile.Text = foos.foods_spec_name;
                //tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foos;
                tile.Name = foos.foods_spec_id;
                tile.Click += TileSpec_Click;
                tile.Image = null;
                try
                {
                    //tile.Image = null;
                    tiles.Add(tile);
                    
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
            }
        }
        private void setGrfSpec(String fooId)
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            grfSpec.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.foosDB.selectByFoodsId1(fooId);
            grfSpec.Cols.Count = 5;
            grfSpec.Rows.Count = dt.Rows.Count + 1;
            //if (dt.Rows.Count > 0)
                grfSpec.Rows[0].Visible = false;
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfSpec.Cols[1].Width = 60;

            grfSpec.Cols[colSImg].Width = 50;
            grfSpec.Cols[colSFoosName].Width = 200;

            grfSpec.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSpec.Cols[colSImg].Caption = "รายการสั่งพิเศษ";
            
            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfSpec[i + 1, 0] = (i + 1);
                grfSpec[i + 1, colSFoosName] = dt.Rows[i]["foods_spec_name"].ToString();
                grfSpec[i + 1, colSStatus] = "";
                if (i % 2 == 0)
                    grfSpec.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfSpec.Cols[colSStatus].Visible = false;
            grfSpec.Cols[colSNo].Visible = false;
            grfSpec.Cols[colSFoosName].AllowEditing = false;
            grfSpec.Cols[colSImg].AllowEditing = false;
            //pageLoad = false;
        }

        private void GrfSpec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSpec.Row < 0) return;
            if (grfSpec.Col < 0) return;
            if (grfSpec[grfSpec.Row, colSFoosName] == null) return;
            String name = "", id = "";
            name = grfSpec[grfSpec.Row, colSFoosName].ToString();
            if (!name.Equals(""))
            {
                if (grfSpec[grfSpec.Row, colSStatus].Equals(""))
                {
                    grfSpec[grfSpec.Row, colSStatus] = "1";
                    grfSpec.SetCellImage(grfSpec.Row, colSImg, imgR);
                    //lbFooName.Text = lbFooName.Text + " + " + name;
                    setSpecName();
                }
                else
                {
                    grfSpec[grfSpec.Row, colSStatus] = "";
                    grfSpec.SetCellImage(grfSpec.Row, colSImg, null);
                    setSpecName();
                }
            }
            //grf.AutoSizeRows();
        }
        private void setSpecName()
        {
            String spec = "";
            lbFooName.Text = foo.foods_name;
            foreach (Row row in grfSpec.Rows)
            {
                if (row[colSStatus] == null) continue;
                if (row[colSStatus].Equals("1"))
                {
                    spec += row[colSFoosName].ToString() + " + ";
                }
            }
            spec = spec.Trim();
            try
            {
                if (spec.Substring(spec.Length - 1).Equals("+"))
                {
                    spec = spec.Substring(0, spec.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            
            fooSpec = spec;
            setLbFooName();
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void initGrfTopping()
        {
            grfTopping = new C1FlexGrid();
            grfTopping.Font = fEdit;
            grfTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTopping.Location = new System.Drawing.Point(0, 0);
            grfTopping.Rows[0].Visible = false;
            grfTopping.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfTopping.Rows.Count = 1;
            grfTopping.Cols.Count = 6;
            grfTopping.Cols[colTImg].Width = 50;
            grfTopping.Cols[colTFoosName].Width = 200;

            grfTopping.TabStop = false;
            grfTopping.EditOptions = EditFlags.None;
            grfTopping.Cols[colTImg].AllowEditing = false;
            grfTopping.Cols[colTFoosName].AllowEditing = false;
            grfTopping.Click += GrfTopping_Click;
            //grf.ExtendLastCol = true;
            grfTopping.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;

            pnToping.Controls.Add(grfTopping);
            grfTopping.Cols[colTNo].Visible = false;
            grfTopping.Cols[colTStatus].Visible = false;
            grfTopping.Cols[colTPrice].AllowEditing = false;
            //grf.Cols[colQty].Visible = false;
            //pnBill.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setGrfTopping(String fooId)
        {
            grfTopping.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.footpDB.selectByFoodsId1(fooId);
            grfTopping.Cols.Count = 6;
            grfTopping.Rows.Count = dt.Rows.Count + 1;
            //if(dt.Rows.Count>0)
                grfTopping.Rows[0].Visible = false;
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfTopping.Cols[1].Width = 60;

            grfTopping.Cols[colTImg].Width = 50;
            grfTopping.Cols[colTFoosName].Width = 200;

            grfTopping.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfTopping.Cols[2].Caption = "รายการสั่งพิเศษ";
            
            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfTopping[i + 1, 0] = (i + 1);
                grfTopping[i + 1, colTFoosName] = dt.Rows[i]["foods_topping_name"].ToString();
                grfTopping[i + 1, colTPrice] = dt.Rows[i]["price"].ToString();
                grfTopping[i + 1, colTStatus] = "";
                if (i % 2 == 0)
                    grfTopping.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfTopping.Cols[colTStatus].Visible = false;
            grfTopping.Cols[colTNo].Visible = false;
            grfTopping.Cols[colTFoosName].AllowEditing = false;
            grfTopping.Cols[colTImg].AllowEditing = false;
            //pageLoad = false;
        }
        private void GrfTopping_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfTopping.Row < 0) return;
            if (grfTopping.Col < 0) return;
            if (grfTopping[grfTopping.Row, colTFoosName] == null) return;
            String name = "", id = "";
            name = grfTopping[grfTopping.Row, colTFoosName].ToString();
            if (!name.Equals(""))
            {
                if (grfTopping[grfTopping.Row, colTStatus].Equals(""))
                {
                    grfTopping[grfTopping.Row, colTStatus] = "1";
                    grfTopping.SetCellImage(grfTopping.Row, colTImg, imgR);
                    //lbFooName.Text = lbFooName.Text + " + " + name;
                    setToppingName();
                }
                else
                {
                    grfTopping[grfTopping.Row, colTStatus] = "";
                    grfTopping.SetCellImage(grfTopping.Row, colSImg, null);
                    setToppingName();
                }
            }
            //grf.AutoSizeRows();
        }
        private void setToppingName()
        {
            String topping = "";
            Decimal price = 0, sum = 0;
            lbFooName.Text = foo.foods_name;
            Decimal.TryParse(foo.foods_price, out sum);
            foreach (Row row in grfTopping.Rows)
            {
                if (row[colTStatus] == null) continue;

                if (row[colTStatus].Equals("1"))
                {
                    topping += row[colTFoosName].ToString() + "[" + row[colTPrice].ToString() + "]" + " + ";
                    Decimal.TryParse(row[colTPrice].ToString(), out price);
                    sum += price;
                }
            }
            topping = topping.Trim();
            try
            {
                if (topping.Substring(topping.Length - 1).Equals("+"))
                {
                    topping = topping.Substring(0, topping.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            //lbFooName.Text = foo.foods_name + " + " + topping;
            //lbFooName.Text = lbFooName.Text.Trim();
            fooTopping = topping;
            setLbFooName();
            lbPrice.Text = sum.ToString("0.00");
            fooTopping = topping;
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void setLbFooName()
        {
            if (fooSpec.Length == 0)
            {
                if (fooTopping.Length == 0)
                {
                    lbFooName.Text = foo.foods_name;
                }
                else
                {
                    lbFooName.Text = foo.foods_name + " + " + fooTopping;
                }
            }
            else
            {
                if (fooTopping.Length == 0)
                {
                    lbFooName.Text = foo.foods_name + "+" + fooSpec;
                }
                else
                {
                    lbFooName.Text = foo.foods_name + "+" + fooSpec + " + " + fooTopping;
                }
            }
            lbFooName.Text = lbFooName.Text.Trim();
            lbSpecFooName.Text = lbFooName.Text;
            
            //return 
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
                    //stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + foo1.filename);
                    string ext = Path.GetExtension(foo1.filename);
                    String file = "";
                    file = foo1.filename.Replace(ext, "");
                    file = file + "_210" + ext;
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + file);
                    //loadedImage = new Bitmap(stream);
                    //if (loadedImage != null)
                    //{
                    //    //SizeF size = tile.Width;
                    //    int originalWidth = loadedImage.Width;
                    //    int newWidth = 180;
                    //    resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                    //    tile.Image = resizedImage;
                    //}
                    tile.Image = new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
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
            TileCollection tiles = TileFoods[index + 1].Groups[0].Tiles;
            tiles.Clear(true);
            TileFoods[index + 1].BeginUpdate();
            lfooT = mposC.mposDB.fooDB.getlFoodsByCat(catid);
            foreach (Foods foo1 in lfooT)
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
                    String filename = "";
                    tile.Image = null;
                    tiles.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (foo1.filename.Equals("")) continue;
                    String ext = Path.GetExtension(foo1.filename);
                    filename = foo1.filename.Replace(ext, "");
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + filename+"_210"+ext);
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
                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));



            }
            TileFoods[index + 1].EndUpdate();
        }
        private void TileSpec_Click(object sender, EventArgs e)
        {
            Tile tile = sender as Tile;
            if (tile != null)
            {
                FoodsSpecial foos = new FoodsSpecial();
                foos = (FoodsSpecial)tile.Tag;
                if (tile.Image == null)
                {
                    tile.Image = imgR;
                    tile.Text1 = "เลือก";
                }
                else
                {
                    tile.Image = null;
                }
                //setSpecName();
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
                setGrfOrder(tile.Name, tile.Text, tile.Text1.Replace("ราคา", "").Trim(), "1", "", foo.printer_name);
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
                switch (keyData)
                {
                    case Keys.K | Keys.Control:
                        if (flagShowTitle)
                            flagShowTitle = false;
                        else
                            flagShowTitle = true;
                        setTitle(flagShowTitle);
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void setTitle(Boolean flag)
        {
            tabMain.ShowTabs = flag;
            if (flag)
            {
                spMain.HeaderHeight = 21;
                spItem.HeaderHeight = 21;
                spSpecialTopping.HeaderHeight = 21;
                spCheck.HeaderHeight = 21;
            }
            else
            {
                spMain.HeaderHeight = 0;
                spItem.HeaderHeight = 0;
                spSpecialTopping.HeaderHeight = 0;
                spCheck.HeaderHeight = 0;
            }
            
            //spMain.HeaderHeight = 21;
            //pnItem.he
        }
        private void FrmTakeOut1_Load(object sender, EventArgs e)
        {
            flagShowTitle = false;
            setTitle(flagShowTitle);
            pnItem.Width = this.Width - 450;
            pnFoods.Height = this.Height - 250;
            lbFooName.Text = "";
            LoadFoods(false);
        }
    }
}
