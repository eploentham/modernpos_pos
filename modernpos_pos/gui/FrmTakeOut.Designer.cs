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
            this.txtFooId = new C1.Win.C1Input.C1TextBox();
            this.btnTopping = new System.Windows.Forms.Button();
            this.txtRow = new C1.Win.C1Input.C1TextBox();
            this.lbFooName = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnSpec = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTableCode = new C1.Win.C1Input.C1TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnOrder = new System.Windows.Forms.Panel();
            this.pnDrink = new System.Windows.Forms.Panel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.btnVoidAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).BeginInit();
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
            this.panel1.Location = new System.Drawing.Point(610, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 727);
            this.panel1.TabIndex = 0;
            // 
            // pnBill
            // 
            this.pnBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBill.Location = new System.Drawing.Point(0, 33);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(447, 541);
            this.pnBill.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnVoidAll);
            this.panel3.Controls.Add(this.txtFooId);
            this.panel3.Controls.Add(this.btnTopping);
            this.panel3.Controls.Add(this.txtRow);
            this.panel3.Controls.Add(this.lbFooName);
            this.panel3.Controls.Add(this.btnSpec);
            this.panel3.Controls.Add(this.btnVoid);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 574);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 153);
            this.panel3.TabIndex = 1;
            // 
            // txtFooId
            // 
            this.txtFooId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFooId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFooId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFooId.Location = new System.Drawing.Point(41, 51);
            this.txtFooId.Name = "txtFooId";
            this.txtFooId.Size = new System.Drawing.Size(22, 20);
            this.txtFooId.TabIndex = 240;
            this.txtFooId.Tag = null;
            this.theme1.SetTheme(this.txtFooId, "(default)");
            this.txtFooId.Visible = false;
            this.txtFooId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnTopping
            // 
            this.btnTopping.BackColor = System.Drawing.Color.Transparent;
            this.btnTopping.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnTopping.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.btnTopping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnTopping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnTopping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnTopping.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopping.Location = new System.Drawing.Point(336, 77);
            this.btnTopping.Name = "btnTopping";
            this.btnTopping.Size = new System.Drawing.Size(106, 64);
            this.btnTopping.TabIndex = 239;
            this.btnTopping.Text = "topping";
            this.btnTopping.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnTopping, "(default)");
            this.btnTopping.UseVisualStyleBackColor = true;
            // 
            // txtRow
            // 
            this.txtRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRow.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRow.Location = new System.Drawing.Point(13, 51);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(22, 20);
            this.txtRow.TabIndex = 238;
            this.txtRow.Tag = null;
            this.theme1.SetTheme(this.txtRow, "(default)");
            this.txtRow.Visible = false;
            this.txtRow.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // lbFooName
            // 
            this.lbFooName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbFooName.Location = new System.Drawing.Point(6, 6);
            this.lbFooName.Name = "lbFooName";
            this.lbFooName.Size = new System.Drawing.Size(424, 44);
            this.lbFooName.TabIndex = 19;
            this.lbFooName.Text = "modernpos POS Restaurant";
            this.theme1.SetTheme(this.lbFooName, "(default)");
            this.lbFooName.UseMnemonic = true;
            // 
            // btnSpec
            // 
            this.btnSpec.BackColor = System.Drawing.Color.Transparent;
            this.btnSpec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnSpec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnSpec.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpec.Location = new System.Drawing.Point(226, 77);
            this.btnSpec.Name = "btnSpec";
            this.btnSpec.Size = new System.Drawing.Size(106, 64);
            this.btnSpec.TabIndex = 15;
            this.btnSpec.Text = "special";
            this.btnSpec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSpec.UseVisualStyleBackColor = true;
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.Transparent;
            this.btnVoid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(116, 77);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(106, 64);
            this.btnVoid.TabIndex = 14;
            this.btnVoid.Text = "cancel";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVoid.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(6, 77);
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
            this.panel5.Size = new System.Drawing.Size(610, 727);
            this.panel5.TabIndex = 1;
            // 
            // pnOrder
            // 
            this.pnOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnOrder.Location = new System.Drawing.Point(0, 0);
            this.pnOrder.Name = "pnOrder";
            this.pnOrder.Size = new System.Drawing.Size(610, 574);
            this.pnOrder.TabIndex = 1;
            // 
            // pnDrink
            // 
            this.pnDrink.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDrink.Location = new System.Drawing.Point(0, 574);
            this.pnDrink.Name = "pnDrink";
            this.pnDrink.Size = new System.Drawing.Size(610, 153);
            this.pnDrink.TabIndex = 0;
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // btnVoidAll
            // 
            this.btnVoidAll.BackColor = System.Drawing.Color.Transparent;
            this.btnVoidAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnVoidAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnVoidAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoidAll.Location = new System.Drawing.Point(377, 30);
            this.btnVoidAll.Name = "btnVoidAll";
            this.btnVoidAll.Size = new System.Drawing.Size(65, 41);
            this.btnVoidAll.TabIndex = 241;
            this.btnVoidAll.Text = "cancel all";
            this.btnVoidAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoidAll, "(default)");
            this.btnVoidAll.UseVisualStyleBackColor = true;
            // 
            // FrmTakeOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 727);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTakeOut";
            this.Text = "FrmTakeOut";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakeOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).EndInit();
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
        private System.Windows.Forms.Button btnSpec;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel pnOrder;
        private System.Windows.Forms.Panel pnDrink;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Input.C1TextBox txtTableCode;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbFooName;
        private C1.Win.C1Input.C1TextBox txtRow;
        private System.Windows.Forms.Button btnTopping;
        private C1.Win.C1Input.C1TextBox txtFooId;
        private System.Windows.Forms.Button btnVoidAll;
    }
}