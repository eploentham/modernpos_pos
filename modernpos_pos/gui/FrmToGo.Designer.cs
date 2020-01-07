namespace modernpos_pos.gui
{
    partial class FrmToGo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbBanner = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.picLogo = new C1.Win.C1Input.C1PictureBox();
            this.picAds = new C1.Win.C1Input.C1PictureBox();
            this.picOK = new C1.Win.C1Input.C1PictureBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOK)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1244, 621);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.picLogo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picAds, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picOK, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbBanner, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1244, 621);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lbBanner
            // 
            this.lbBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBanner.Location = new System.Drawing.Point(3, 499);
            this.lbBanner.Name = "lbBanner";
            this.lbBanner.Size = new System.Drawing.Size(864, 119);
            this.lbBanner.TabIndex = 4;
            this.lbBanner.Text = "c1SuperLabel1";
            this.lbBanner.UseMnemonic = true;
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::modernpos_pos.Properties.Resources.logo1;
            this.picLogo.Location = new System.Drawing.Point(873, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(368, 490);
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // picAds
            // 
            this.picAds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picAds.Image = global::modernpos_pos.Properties.Resources.button_1;
            this.picAds.Location = new System.Drawing.Point(3, 3);
            this.picAds.Name = "picAds";
            this.picAds.Size = new System.Drawing.Size(864, 490);
            this.picAds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAds.TabIndex = 2;
            this.picAds.TabStop = false;
            // 
            // picOK
            // 
            this.picOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOK.Image = global::modernpos_pos.Properties.Resources.button_1;
            this.picOK.Location = new System.Drawing.Point(873, 499);
            this.picOK.Name = "picOK";
            this.picOK.Size = new System.Drawing.Size(368, 119);
            this.picOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOK.TabIndex = 3;
            this.picOK.TabStop = false;
            // 
            // FrmToGo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 621);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmToGo";
            this.Text = "FrmToGo";
            this.Load += new System.EventHandler(this.FrmToGo_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1PictureBox picLogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private C1.Win.C1Input.C1PictureBox picAds;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbBanner;
        private C1.Win.C1Input.C1PictureBox picOK;
    }
}