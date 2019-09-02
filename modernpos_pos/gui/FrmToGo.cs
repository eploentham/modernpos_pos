using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
using modernpos_pos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmToGo : Form
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

        public FrmToGo(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {
            picOK.Click += PicOK_Click;
            picAds.Click += PicAds_Click;
            picLogo.Click += PicLogo_Click;
        }

        private void PicLogo_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void PicAds_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void PicOK_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }
        private void opennew()
        {
            FrmTakeOut3 frm = new FrmTakeOut3(mposC, this);
            frm.Show(this);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                frmmain.Show();
                Close();
                    return true;
                //}
            }
            else
            {
                //keyData
                switch (keyData)
                {
                    case Keys.X | Keys.Control:
                        frmmain.Show();
                        Close();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void FrmToGo_Load(object sender, EventArgs e)
        {
            Image loadedImage = null, resizedImage;
            loadedImage = Resources.logo1;
            int originalWidth = loadedImage.Width;
            int newWidth = picLogo.Width;
            resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
            imgLogo = resizedImage;

            picLogo.Image = imgLogo;
            if (File.Exists("togo_banner.html"))
            {
                string res = string.Format("SuperLabels.Resources.{0}.html", "togo_banner");
                Assembly a = Assembly.GetExecutingAssembly();
                using (StreamReader s = new StreamReader("togo_banner.html"))
                {
                    //this.richTextBox1.Text = s.ReadToEnd();
                    lbBanner.Text = s.ReadToEnd();
                }
            }
            this.FormBorderStyle = FormBorderStyle.None;
            //this.Activate();
        }
    }
}
