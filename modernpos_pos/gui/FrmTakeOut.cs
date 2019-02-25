using C1.Framework;
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
    public partial class FrmTakeOut : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        //Theme theme1;
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
        }
        private void FrmTakeOut_Load(object sender, EventArgs e)
        {

        }
    }
}
