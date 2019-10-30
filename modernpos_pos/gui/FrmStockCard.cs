using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
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
    public partial class FrmStockCard : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid grfMatd;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public FrmStockCard(mPOSControl x)
        {
            InitializeComponent();
        }

        private void FrmStockCard_Load(object sender, EventArgs e)
        {

        }
    }
}
