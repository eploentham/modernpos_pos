using C1.Win.C1Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public class FrmKeyBoard : Form
    {
        private Panel pn;
        private Label[] lbA;
        private Form frm;
        private C1TextBox txt;
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmKeyBoard
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmKeyBoard";
            this.Load += new System.EventHandler(this.FrmKeyBoard_Load);
            this.ResumeLayout(false);

        }

        public FrmKeyBoard(Point pp, C1TextBox frm)
        {
            this.txt = frm;
            initConfig(pp);
        }
        private void initConfig(Point pp)
        {
            initLabel();
            pn = new System.Windows.Forms.Panel();
            this.Controls.Add(this.pn);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Location = pp;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
                        
            this.pn.Location = new System.Drawing.Point(319, 210);
            this.pn.Name = "pn";            
            this.pn.Size = new System.Drawing.Size(200, 100);
            this.pn.TabIndex = 0;
            this.pn.Dock = DockStyle.Fill;
            //this.pn.Controls.Add(this.lbA, 0, 3);
            //this.pn.Controls.Add(this.lbB, 5, 4);
        }
        private void initLabel()
        {
            //lbA = new Label();
            //lbB = new Label();
            //lbC = new Label();
            //lbD = new Label();
            //lbE = new Label();
            //lbF = new Label();
            //lbG = new Label();
            //lbH = new Label();
            //lbI = new Label();
            //lbJ = new Label();
            //lbK = new Label();
            //lbL = new Label();
            //lbM = new Label();
            //lbN = new Label();
            //lbO = new Label();
            //lbP = new Label();
            //lbQ = new Label();
            //lbR = new Label();
            //lbS = new Label();
            //lbT = new Label();
            //lbU = new Label();
            //lbV = new Label();
            //lbW = new Label();
            //lbX = new Label();
            //lbY = new Label();
            //lbZ = new Label();

            //lbA.AutoSize = true;
            //lbA.BorderStyle = BorderStyle.Fixed3D;
            //lbA.Dock = DockStyle.Fill;
            //lbA.Location = new System.Drawing.Point(3, 0);
            //lbA.Name = "labela";
            //lbA.Size = new System.Drawing.Size(94, 50);
            //lbA.TabIndex = 0;
            //lbA.Text = "a";
            //lbA.Click += LbA_Click;

            //lbB.AutoSize = true;
            //lbB.BorderStyle = BorderStyle.Fixed3D;
            //lbB.Dock = DockStyle.Fill;
            //lbB.Location = new System.Drawing.Point(3, 0);
            //lbB.Name = "labelb";
            //lbB.Size = new System.Drawing.Size(94, 50);
            //lbB.TabIndex = 0;
            //lbB.Text = "b";
        }

        private void LbA_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txt.Focus();
            SendKeys.Send("a");
        }
        private void FrmKeyBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
