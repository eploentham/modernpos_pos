namespace modernpos_pos.gui
{
    partial class FrmTakeOutCheck
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
            this.pnBill = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPay = new System.Windows.Forms.Button();
            this.c1SuperLabel1 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.c1SuperLabel2 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBill
            // 
            this.pnBill.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBill.Location = new System.Drawing.Point(537, 0);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(293, 570);
            this.pnBill.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.c1SuperLabel2);
            this.panel2.Controls.Add(this.c1SuperLabel1);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(537, 570);
            this.panel2.TabIndex = 1;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(75, 442);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(106, 64);
            this.btnPay.TabIndex = 16;
            this.btnPay.Text = "ชำระเงิน";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // c1SuperLabel1
            // 
            this.c1SuperLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1SuperLabel1.Location = new System.Drawing.Point(12, 71);
            this.c1SuperLabel1.Name = "c1SuperLabel1";
            this.c1SuperLabel1.Size = new System.Drawing.Size(464, 81);
            this.c1SuperLabel1.TabIndex = 17;
            this.c1SuperLabel1.Text = "modernpos POS Restaurant";
            this.c1SuperLabel1.UseMnemonic = true;
            // 
            // c1SuperLabel2
            // 
            this.c1SuperLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1SuperLabel2.Location = new System.Drawing.Point(12, 196);
            this.c1SuperLabel2.Name = "c1SuperLabel2";
            this.c1SuperLabel2.Size = new System.Drawing.Size(464, 81);
            this.c1SuperLabel2.TabIndex = 18;
            this.c1SuperLabel2.Text = "modernpos POS Restaurant";
            this.c1SuperLabel2.UseMnemonic = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(247, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 64);
            this.button1.TabIndex = 19;
            this.button1.Text = "พิมพ์ใบกำกับภาษี";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FrmTakeOutCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnBill);
            this.Name = "FrmTakeOutCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTakeOutCheck";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button button1;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel2;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel1;
    }
}