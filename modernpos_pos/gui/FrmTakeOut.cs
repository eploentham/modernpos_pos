using C1.Framework;
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
        C1TileControl tilOrder;
        C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
        C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
        C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
        Group gr1 = new C1.Win.C1Tile.Group();
        public FrmTakeOut(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
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

            tilOrder = new C1.Win.C1Tile.C1TileControl();
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            tilOrder.DefaultTemplate.Elements.Add(panelElement1);
            tilOrder = new C1TileControl();
            tilOrder.Name = "tile1";
            tilOrder.Dock = DockStyle.Fill;
            pnOrder.Controls.Add(tilOrder);
            tilOrder.Groups.Add(this.gr1);
            gr1.Name = "gr1";
            //gr1.Text = "Group 1";

            Tile til1;
            til1 = new Tile();
            til1.Name = "til1";
            til1.Text = "aaaaa";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
            til1.BackColor = Color.LightCoral;
            til1.Group = gr1;

            gr1.Tiles.Add(til1);

            til1 = new Tile();
            til1.Name = "til2";
            til1.Text = "bbbbb";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
            gr1.Tiles.Add(til1);

            til1 = new Tile();
            til1.Name = "til3";
            til1.Text = "cccccc";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
            gr1.Tiles.Add(til1);

            til1 = new Tile();
            til1.Name = "til31";
            til1.Text = "cccccc";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
            gr1.Tiles.Add(til1);

            til1 = new Tile();
            til1.Name = "til32";
            til1.Text = "cccccc";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
            gr1.Tiles.Add(til1);
        }
        private void FrmTakeOut_Load(object sender, EventArgs e)
        {

        }
    }
}
