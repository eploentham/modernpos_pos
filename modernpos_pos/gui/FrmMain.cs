using modernpos_pos.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmMain : Form
    {
        mPOSControl mposC;
        FrmSplash splash;
        public FrmMain(mPOSControl mposC, FrmSplash splash)
        {
            InitializeComponent();
            this.mposC = mposC;
            this.splash = splash;
            
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                mposC.mposDB = new objdb.mPosDB(mposC.conn);
                mposC.getInit();
            }).Start();

            //if (login.LogonSuccessful.Equals("1"))
            //{
            initConfig();
            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    /* run your code here */

            //}).Start();
            //}
            //else
            //{
            //    Application.Exit();
            //}

            //initConfig();
            
        }
        private void initConfig()
        {
            btnDineIn.Click += BtnDineIn_Click;
            btnTakeOut.Click += BtnTakeOut_Click;
            btnConfig.Click += BtnConfig_Click;
            //btnTakeOut.Click += BtnTakeOut_Click;
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmConfig frm = new FrmConfig(mposC);
            frm.ShowDialog(this);
        }

        private void BtnTakeOut_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmTakeOut frm = new FrmTakeOut(mposC);
            frm.Show(this);
        }

        private void BtnDineIn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

            FrmPassword frm = new FrmPassword();
            frm.ShowDialog(this);
        }
        private Boolean appExit()
        {
            if (MessageBox.Show("ต้องการออกจากโปรแกรม2", "ออกจากโปรแกรม menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Close();
                return false;
            }
            else
            {
                return false;
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
        private void FrmMain_Load(object sender, EventArgs e)
        {
            splash.Dispose();
            String date = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            this.Text = " Update 2019-02-25 format date " + date;
        }
    }
}
