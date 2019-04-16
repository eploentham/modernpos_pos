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
        private TableLayoutPanel tlp;
        private Label lbA, lbB, lbC, lbD, lbE, lbF, lbG, lbH, lbI, lbJ,lbK,lbL, lbM, lbN, lbO, lbP, lbQ, lbR, lbS, lbT, lbU, lbV, lbW, lbX, lbY, lbZ;


        public FrmKeyBoard(Point pp)
        {
            initConfig(pp);
        }
        private void initConfig(Point pp)
        {
            initLabel();
            tlp = new System.Windows.Forms.TableLayoutPanel();
            this.Controls.Add(this.tlp);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Location = pp;
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;

            

            this.tlp.ColumnCount = 10;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            
            this.tlp.Location = new System.Drawing.Point(319, 210);
            this.tlp.Name = "tableLayoutPanel1";
            this.tlp.RowCount = 4;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp.Size = new System.Drawing.Size(200, 100);
            this.tlp.TabIndex = 0;
            this.tlp.Dock = DockStyle.Fill;
            this.tlp.Controls.Add(this.lbA, 0, 3);
            this.tlp.Controls.Add(this.lbB, 5, 4);
        }
        private void initLabel()
        {
            lbA = new Label();
            lbB = new Label();
            lbC = new Label();
            lbD = new Label();
            lbE = new Label();
            lbF = new Label();
            lbG = new Label();
            lbH = new Label();
            lbI = new Label();
            lbJ = new Label();
            lbK = new Label();
            lbL = new Label();
            lbM = new Label();
            lbN = new Label();
            lbO = new Label();
            lbP = new Label();
            lbQ = new Label();
            lbR = new Label();
            lbS = new Label();
            lbT = new Label();
            lbU = new Label();
            lbV = new Label();
            lbW = new Label();
            lbX = new Label();
            lbY = new Label();
            lbZ = new Label();

            lbA.AutoSize = true;
            lbA.BorderStyle = BorderStyle.Fixed3D;
            lbA.Dock = DockStyle.Fill;
            lbA.Location = new System.Drawing.Point(3, 0);
            lbA.Name = "labela";
            lbA.Size = new System.Drawing.Size(94, 50);
            lbA.TabIndex = 0;
            lbA.Text = "a";

            lbB.AutoSize = true;
            lbB.BorderStyle = BorderStyle.Fixed3D;
            lbB.Dock = DockStyle.Fill;
            lbB.Location = new System.Drawing.Point(3, 0);
            lbB.Name = "labelb";
            lbB.Size = new System.Drawing.Size(94, 50);
            lbB.TabIndex = 0;
            lbB.Text = "b";
        }
    }
}
