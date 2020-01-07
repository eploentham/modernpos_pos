using modernpos_pos.control;
using modernpos_pos.object1;
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
            //MessageBox.Show("FrmMain before Thread", "");
            //new LogFile("w FrmMain  ");
            new Thread(() =>
            {
                //MessageBox.Show("Thread start ", "");
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                mposC.mposDB = new objdb.mPosDB(mposC.conn);
                //MessageBox.Show("Thread after mposC.mposDB ", "");
                mposC.getInit();
                //MessageBox.Show("Thread end", "");
            }).Start();

            //if (login.LogonSuccessful.Equals("1"))
            //{
            initConfig();

        }
        private void initConfig()
        {
            btnDineIn.Click += BtnDineIn_Click;
            btnTakeOut.Click += BtnTakeOut_Click;
            btnConfig.Click += BtnConfig_Click;
            btnClose.Click += BtnClose_Click;
            btnCloseDay.Click += BtnCloseDay_Click;
        }
        private void BtnCloseDay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCloseDayAdd frm = new FrmCloseDayAdd(mposC, this,"");
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Close();
            //return true;
        }

        private void BtnConfig_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmConfig frm = new FrmConfig(mposC, this);
            this.Hide();
            frm.ShowDialog(this);
            
        }

        private void BtnTakeOut_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmTakeOut4 frm = new FrmTakeOut4(mposC,this);
            this.Hide();
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
                switch (keyData)
                {
                    case Keys.X | Keys.Control:
                        Close();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            splash.Dispose();
            String date = "";
            date = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            this.Text = "Start 2019-04-17 Last Update 2020-01-06 format date " + date;
            txtHeader.Text = mposC.txtHeader;
            if (mposC.iniC.statusAppToGo.Equals("1"))
            {
                FrmToGo2 frm = new FrmToGo2(mposC, this);
                frm.WindowState = FormWindowState.Maximized;
                frm.Show(this);
                this.Hide();
            }
        }
    }
}
