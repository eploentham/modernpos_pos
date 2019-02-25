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
    public partial class FrmConfig : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmConfig(mPOSControl mposC)
        {
            InitializeComponent();
            this.mposC = mposC;
            initConfig();
        }
        private void initConfig()
        {
            btmStf.Click += BtmStf_Click;
            btnDept.Click += BtnDept_Click;
            btnPosi.Click += BtnPosi_Click;
        }

        private void BtnPosi_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPosition frm = new FrmPosition(mposC);
            frm.Show(this);
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDepartment1 frm = new FrmDepartment1(mposC);
            frm.Show(this);
        }

        private void BtmStf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStaff frm = new FrmStaff(mposC);
            frm.Show(this);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
