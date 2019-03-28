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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTakeOutCheck));
            this.pnBill = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnVoidPay = new System.Windows.Forms.Panel();
            this.cboRsp = new C1.Win.C1List.C1Combo();
            this.chkPaypaying = new System.Windows.Forms.RadioButton();
            this.chkPayBefore = new System.Windows.Forms.RadioButton();
            this.btnVoidPay = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtTableCode = new C1.Win.C1Input.C1TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbStatus = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.lbAmt = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnPay = new System.Windows.Forms.Button();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.tC = new C1.Win.C1Command.C1DockingTab();
            this.tab1 = new C1.Win.C1Command.C1DockingTabPage();
            this.tab2 = new C1.Win.C1Command.C1DockingTabPage();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.panel2.SuspendLayout();
            this.pnVoidPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).BeginInit();
            this.tC.SuspendLayout();
            this.tab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBill
            // 
            this.pnBill.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnBill.Location = new System.Drawing.Point(602, 0);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(293, 570);
            this.pnBill.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.c1Button1);
            this.panel2.Controls.Add(this.pnVoidPay);
            this.panel2.Controls.Add(this.btnVoidPay);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.txtTableCode);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lbStatus);
            this.panel2.Controls.Add(this.lbAmt);
            this.panel2.Controls.Add(this.btnPay);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 545);
            this.panel2.TabIndex = 1;
            // 
            // pnVoidPay
            // 
            this.pnVoidPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnVoidPay.Controls.Add(this.cboRsp);
            this.pnVoidPay.Controls.Add(this.chkPaypaying);
            this.pnVoidPay.Controls.Add(this.chkPayBefore);
            this.pnVoidPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnVoidPay.Location = new System.Drawing.Point(359, 431);
            this.pnVoidPay.Name = "pnVoidPay";
            this.pnVoidPay.Size = new System.Drawing.Size(236, 57);
            this.pnVoidPay.TabIndex = 240;
            this.theme1.SetTheme(this.pnVoidPay, "(default)");
            // 
            // cboRsp
            // 
            this.cboRsp.AddItemSeparator = ';';
            this.cboRsp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboRsp.Caption = "";
            this.cboRsp.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cboRsp.DeadAreaBackColor = System.Drawing.Color.White;
            this.cboRsp.EditorBackColor = System.Drawing.Color.White;
            this.cboRsp.EditorFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cboRsp.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.cboRsp.FlatStyle = C1.Win.C1List.FlatModeEnum.Flat;
            this.cboRsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRsp.Images.Add(((System.Drawing.Image)(resources.GetObject("cboRsp.Images"))));
            this.cboRsp.Location = new System.Drawing.Point(6, 32);
            this.cboRsp.MatchEntryTimeout = ((long)(2000));
            this.cboRsp.MaxDropDownItems = ((short)(5));
            this.cboRsp.MaxLength = 32767;
            this.cboRsp.MouseCursor = System.Windows.Forms.Cursors.Default;
            this.cboRsp.Name = "cboRsp";
            this.cboRsp.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None;
            this.cboRsp.RowSubDividerColor = System.Drawing.Color.DarkGray;
            this.cboRsp.Size = new System.Drawing.Size(221, 19);
            this.cboRsp.TabIndex = 240;
            this.cboRsp.Text = "c1Combo1";
            this.theme1.SetTheme(this.cboRsp, "(default)");
            this.cboRsp.PropBag = resources.GetString("cboRsp.PropBag");
            // 
            // chkPaypaying
            // 
            this.chkPaypaying.AutoSize = true;
            this.chkPaypaying.BackColor = System.Drawing.Color.Transparent;
            this.chkPaypaying.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkPaypaying.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkPaypaying.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkPaypaying.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkPaypaying.Location = new System.Drawing.Point(149, 9);
            this.chkPaypaying.Name = "chkPaypaying";
            this.chkPaypaying.Size = new System.Drawing.Size(84, 17);
            this.chkPaypaying.TabIndex = 28;
            this.chkPaypaying.Text = "กำลังรับชำระ";
            this.theme1.SetTheme(this.chkPaypaying, "(default)");
            this.chkPaypaying.UseVisualStyleBackColor = false;
            // 
            // chkPayBefore
            // 
            this.chkPayBefore.AutoSize = true;
            this.chkPayBefore.BackColor = System.Drawing.Color.Transparent;
            this.chkPayBefore.Checked = true;
            this.chkPayBefore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkPayBefore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkPayBefore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.chkPayBefore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkPayBefore.Location = new System.Drawing.Point(6, 9);
            this.chkPayBefore.Name = "chkPayBefore";
            this.chkPayBefore.Size = new System.Drawing.Size(94, 17);
            this.chkPayBefore.TabIndex = 26;
            this.chkPayBefore.TabStop = true;
            this.chkPayBefore.Text = "ยังไม่ได้รับเงิน";
            this.theme1.SetTheme(this.chkPayBefore, "(default)");
            this.chkPayBefore.UseVisualStyleBackColor = false;
            // 
            // btnVoidPay
            // 
            this.btnVoidPay.BackColor = System.Drawing.Color.Transparent;
            this.btnVoidPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnVoidPay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.btnVoidPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnVoidPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnVoidPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnVoidPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoidPay.Location = new System.Drawing.Point(429, 494);
            this.btnVoidPay.Name = "btnVoidPay";
            this.btnVoidPay.Size = new System.Drawing.Size(106, 45);
            this.btnVoidPay.TabIndex = 239;
            this.btnVoidPay.Text = "ยกเลิก รับชำระเงิน";
            this.btnVoidPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoidPay, "(default)");
            this.btnVoidPay.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.White;
            this.listBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 252);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(587, 173);
            this.listBox1.TabIndex = 238;
            this.theme1.SetTheme(this.listBox1, "(default)");
            // 
            // txtTableCode
            // 
            this.txtTableCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTableCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableCode.Location = new System.Drawing.Point(12, 12);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(22, 20);
            this.txtTableCode.TabIndex = 237;
            this.txtTableCode.Tag = null;
            this.theme1.SetTheme(this.txtTableCode, "(default)");
            this.txtTableCode.Visible = false;
            this.txtTableCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
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
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbStatus.Location = new System.Drawing.Point(12, 158);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(464, 81);
            this.lbStatus.TabIndex = 18;
            this.lbStatus.Text = "modernpos POS Restaurant";
            this.lbStatus.UseMnemonic = true;
            // 
            // lbAmt
            // 
            this.lbAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAmt.Location = new System.Drawing.Point(12, 38);
            this.lbAmt.Name = "lbAmt";
            this.lbAmt.Size = new System.Drawing.Size(464, 81);
            this.lbAmt.TabIndex = 17;
            this.lbAmt.Text = "modernpos POS Restaurant";
            this.lbAmt.UseMnemonic = true;
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
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // tC
            // 
            this.tC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tC.Controls.Add(this.tab1);
            this.tC.Controls.Add(this.tab2);
            this.tC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tC.HotTrack = true;
            this.tC.Location = new System.Drawing.Point(0, 0);
            this.tC.Name = "tC";
            this.tC.SelectedIndex = 1;
            this.tC.Size = new System.Drawing.Size(602, 570);
            this.tC.TabIndex = 239;
            this.tC.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tC.TabsShowFocusCues = false;
            this.tC.TabsSpacing = 2;
            this.tC.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tC, "(default)");
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.panel2);
            this.tab1.Location = new System.Drawing.Point(1, 24);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(600, 545);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "Page1";
            // 
            // tab2
            // 
            this.tab2.Location = new System.Drawing.Point(1, 24);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(600, 545);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "Page2";
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(26, 459);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(43, 23);
            this.c1Button1.TabIndex = 241;
            this.c1Button1.Text = "c1Button1";
            this.theme1.SetTheme(this.c1Button1, "(default)");
            this.c1Button1.UseVisualStyleBackColor = true;
            this.c1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmTakeOutCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 570);
            this.Controls.Add(this.tC);
            this.Controls.Add(this.pnBill);
            this.Name = "FrmTakeOutCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTakeOutCheck";
            this.Load += new System.EventHandler(this.FrmTakeOutCheck_Load);
            this.panel2.ResumeLayout(false);
            this.pnVoidPay.ResumeLayout(false);
            this.pnVoidPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tC)).EndInit();
            this.tC.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBill;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button button1;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbStatus;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbAmt;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Input.C1TextBox txtTableCode;
        private System.Windows.Forms.ListBox listBox1;
        private C1.Win.C1Command.C1DockingTab tC;
        private C1.Win.C1Command.C1DockingTabPage tab1;
        private C1.Win.C1Command.C1DockingTabPage tab2;
        private System.Windows.Forms.Button btnVoidPay;
        private System.Windows.Forms.Panel pnVoidPay;
        private System.Windows.Forms.RadioButton chkPaypaying;
        private System.Windows.Forms.RadioButton chkPayBefore;
        private C1.Win.C1List.C1Combo cboRsp;
        private C1.Win.C1Input.C1Button c1Button1;
    }
}