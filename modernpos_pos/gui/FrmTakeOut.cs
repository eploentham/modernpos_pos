using C1.Framework;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace modernpos_pos.gui
{
    public partial class FrmTakeOut : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public List<Foods> lfooT;
        Foods foo;
        //Theme theme1;
        C1TileControl TileFoods;
        C1.Win.C1Tile.PanelElement panelElement1;
        C1.Win.C1Tile.ImageElement imageElement1;
        C1.Win.C1Tile.TextElement textElement1, txtFoodsName, txtFoodsPrice;
        
        Group gr1 = new C1.Win.C1Tile.Group();
        Template tempFlickr;
        C1.Win.C1Tile.ImageElement imageElement8;
        PanelElement pnFoodsName, pnFoodsPrice;
        C1FlexGrid grf;

        VNEControl vneC;
        int colNo = 1, colName = 2, colPrice = 3, colStatus = 4;
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
            foo = new Foods();
            lfooT = mposC.mposDB.fooDB.getlFoods1();

            TileFoods = new C1.Win.C1Tile.C1TileControl();
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
            TileFoods.Font = fEdit;
            
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            TileFoods.DefaultTemplate.Elements.Add(panelElement1);
            TileFoods.Templates.Add(this.tempFlickr);
            TileFoods = new C1TileControl();
            TileFoods.Name = "tile1";
            TileFoods.Dock = DockStyle.Fill;
            pnOrder.Controls.Add(TileFoods);
            TileFoods.Groups.Add(this.gr1);

            this.tempFlickr.Elements.Add(imageElement8);
            this.tempFlickr.Elements.Add(pnFoodsName);
            this.tempFlickr.Elements.Add(pnFoodsPrice);
            this.tempFlickr.Name = "tempFlickr";

            initGrf();
            //gr1.Name = "gr1";
            //gr1.Text = "Group 1";


            //Tile til1;
            //til1 = new C1.Win.C1Tile.Tile();
            //til1.Name = "til1";
            //til1.Text = "aaaaa";
            //til1.VerticalSize = 2;
            //til1.HorizontalSize = 2;
            //til1.BackColor = Color.LightCoral;
            ////til1.Group = gr1;

            //gr1.Tiles.Add(til1);
            //this.SuspendLayout();
            //til1 = new Tile();
            //til1.Name = "til2";
            //til1.Text = "bbbbb";
            //til1.VerticalSize = 2;
            //til1.HorizontalSize = 2;
            //gr1.Tiles.Add(til1);

            //til1 = new Tile();
            //til1.Name = "til3";
            //til1.Text = "cccccc";
            //til1.VerticalSize = 2;
            //til1.HorizontalSize = 2;
            //gr1.Tiles.Add(til1);

            //til1 = new Tile();
            //til1.Name = "til31";
            //til1.Text = "cccccc";
            //til1.VerticalSize = 2;
            //til1.HorizontalSize = 2;
            //gr1.Tiles.Add(til1);

            //til1 = new Tile();
            //til1.Name = "til32";
            //til1.Text = "cccccc";
            //til1.VerticalSize = 2;
            //til1.HorizontalSize = 2;
            //gr1.Tiles.Add(til1);
        }
        private void initGrf()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            grf.Cols[colStatus].Visible = false;
            grf.Rows.Count = 1;
            grf.Cols.Count = 5;
            grf.Cols[colNo].Width = 40;
            grf.Cols[colName].Width = 300;
            grf.Cols[colPrice].Width = 80;
            //FilterRow fr = new FilterRow(grfExpn);
            grf.TabStop = false;
            grf.EditOptions = EditFlags.None;
            grf.Cols[colNo].AllowEditing = false;
            grf.Cols[colName].AllowEditing = false;
            grf.Cols[colPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grf.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grf.AfterDataRefresh += Grf_AfterDataRefresh;
            //grf.SubtotalPosition = SubtotalPositionEnum.BelowData;
            grf.SubtotalPosition = SubtotalPositionEnum.BelowData;

            grf.AfterRowColChange += Grf_AfterRowColChange;
            //grf.DoubleClick += GrfPtt_DoubleClick;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            grf.ContextMenu = menuGw;
            //grf.EndUpdate();
            pnBill.Controls.Add(grf);

            //theme.SetTheme(grf, "Office2010Blue");

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
        private void setGrf(String name)
        {
            String re = "";
            if (!name.Equals(""))
            {
                String[] ext = name.Split('#');
                Row row = grf.Rows.Add();
                row[colName] = ext[0];
                row[colPrice] = ext[1];
                row[colNo] = grf.Rows.Count - 2;
                UpdateTotals();
            }
        }
        private void LoadFoods(bool keepExistent)
        {
            TileCollection tiles = TileFoods.Groups[0].Tiles;
            tiles.Clear(true);
            foreach (Foods foo1 in lfooT)
            {
                var tile = new Tile();
                tile.HorizontalSize = 2;
                tile.VerticalSize = 2;
                tile.Template = tempFlickr;
                tile.Text = foo1.foods_name;
                tile.Text1 = "ราคา "+foo1.foods_price;
                tile.Tag = foo1;
                tile.Name = foo1.foods_code;
                tile.Click += Tile_Click;

                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));


                tiles.Add(tile);
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Tile tile = sender as Tile;
            if (tile != null)
            {
                setGrf(tile.Text + "#" + tile.Text1.Replace("ราคา", "").Trim());
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

        private void FrmTakeOut_Load(object sender, EventArgs e)
        {
            TileFoods.Groups[0].Tiles.Clear(true);
            LoadFoods(false);
        }
    }
}
