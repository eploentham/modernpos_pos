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
            initConfig();
        }
        private void initConfig()
        {
            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            btn5.Click += Btn5_Click;
            btn6.Click += Btn6_Click;
            btn7.Click += Btn7_Click;
            btn8.Click += Btn8_Click;
            btn9.Click += Btn9_Click;
            btn0.Click += Btn0_Click;
            btnDel.Click += BtnDel_Click;
            btnMinus.Click += BtnMinus_Click;
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtPassword.Text.Length <= 0) return;
            txtPassword.Text = txtPassword.Text.Substring(0, txtPassword.Text.Length - 1);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = "";
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "0";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "9";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "8";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "7";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "6";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "5";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "4";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "3";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value + "2";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtPassword.Text = txtPassword.Value+"1";
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

        private void FrmPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
