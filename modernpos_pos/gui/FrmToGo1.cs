using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
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
    public partial class FrmToGo1 : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        Image imgLogo, imgOK;
        Form frmmain;

        public FrmToGo1(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            vlcControl1.Click += VlcControl1_Click;
        }

        private void VlcControl1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmToGo1_Load(object sender, EventArgs e)
        {
            vlcControl1.Play(new FileInfo(@"C:\Users\ekapop-pc\Downloads\SSNI-547.mp4"));
        }
    }
}
