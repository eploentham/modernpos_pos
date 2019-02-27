namespace modernpos_pos.gui
{
    partial class FrmTakeOut
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
            this.pnBill = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTableCode = new C1.Win.C1Input.C1TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnOrder = new System.Windows.Forms.Panel();
            this.pnDrink = new System.Windows.Forms.Panel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnBill);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(550, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 727);
            this.panel1.TabIndex = 0;
            // 
            // pnBill
            // 
            this.pnBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBill.Location = new System.Drawing.Point(0, 33);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(447, 594);
            this.pnBill.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 627);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 100);
            this.panel3.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirm.Location = new System.Drawing.Point(271, 18);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(106, 64);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "confirm";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(159, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 64);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(47, 18);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(106, 64);
            this.btnPay.TabIndex = 13;
            this.btnPay.Text = "bill";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTableCode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 33);
            this.panel2.TabIndex = 0;
            // 
            // txtTableCode
            // 
            this.txtTableCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTableCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableCode.Location = new System.Drawing.Point(109, 6);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(22, 20);
            this.txtTableCode.TabIndex = 236;
            this.txtTableCode.Tag = null;
            this.theme1.SetTheme(this.txtTableCode, "(default)");
            this.txtTableCode.Visible = false;
            this.txtTableCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pnOrder);
            this.panel5.Controls.Add(this.pnDrink);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(550, 727);
            this.panel5.TabIndex = 1;
            // 
            // pnOrder
            // 
            this.pnOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnOrder.Location = new System.Drawing.Point(0, 0);
            this.pnOrder.Name = "pnOrder";
            this.pnOrder.Size = new System.Drawing.Size(550, 574);
            this.pnOrder.TabIndex = 1;
            // 
            // pnDrink
            // 
            this.pnDrink.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDrink.Location = new System.Drawing.Point(0, 574);
            this.pnDrink.Name = "pnDrink";
            this.pnDrink.Size = new System.Drawing.Size(550, 153);
            this.pnDrink.TabIndex = 0;
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // FrmTakeOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 727);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTakeOut";
            this.Text = "FrmTakeOut";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakeOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnBill;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnOrder;
        private System.Windows.Forms.Panel pnDrink;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Input.C1TextBox txtTableCode;
    }
}