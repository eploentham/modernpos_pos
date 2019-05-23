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
    public partial class FrmMessage : Form
    {
        String message = "";
        public FrmMessage(String message)
        {
            InitializeComponent();
            this.message = message;
            initConfig();
        }
        private void initConfig()
        {
            lbMessage.Text = message;
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Close();
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {

        }
    }
}
