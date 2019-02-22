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
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
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
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                Close();
                //    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
