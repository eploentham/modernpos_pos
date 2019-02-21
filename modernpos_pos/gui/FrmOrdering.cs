using C1.Win.C1Tile;
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
    public partial class FrmOrdering : Form
    {
        public FrmOrdering()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            Tile til1;
            til1 = new Tile();
            til1.Name = "til1";
            til1.Text = "aaaaa";
            til1.VerticalSize = 2;
            til1.HorizontalSize = 2;
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

            gr1.Text = "";
            tile1.Text = "";
            
        }
        private void FrmOrdering_Load(object sender, EventArgs e)
        {

        }
    }
}
