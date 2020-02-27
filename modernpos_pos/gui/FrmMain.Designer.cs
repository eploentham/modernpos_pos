namespace modernpos_pos.gui
{
    partial class FrmMain
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
            this.txtHeader = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c1SuperLabel2 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new C1.Win.C1Input.C1Button();
            this.btnCloseDay = new C1.Win.C1Input.C1Button();
            this.btnKitchen = new C1.Win.C1Input.C1Button();
            this.btnBackOffice = new C1.Win.C1Input.C1Button();
            this.btnOrder = new C1.Win.C1Input.C1Button();
            this.btnHome = new C1.Win.C1Input.C1Button();
            this.btnRetail = new C1.Win.C1Input.C1Button();
            this.btnTakeOut = new C1.Win.C1Input.C1Button();
            this.btnDineIn = new C1.Win.C1Input.C1Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKitchen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackOffice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDineIn)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtHeader.Location = new System.Drawing.Point(3, 8);
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(475, 86);
            this.txtHeader.TabIndex = 0;
            this.txtHeader.Text = "modernpos POS Restaurant";
            this.txtHeader.UseMnemonic = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1SuperLabel2);
            this.panel1.Controls.Add(this.txtHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 100);
            this.panel1.TabIndex = 1;
            // 
            // c1SuperLabel2
            // 
            this.c1SuperLabel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1SuperLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1SuperLabel2.Location = new System.Drawing.Point(493, 8);
            this.c1SuperLabel2.Name = "c1SuperLabel2";
            this.c1SuperLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.c1SuperLabel2.Size = new System.Drawing.Size(452, 59);
            this.c1SuperLabel2.TabIndex = 1;
            this.c1SuperLabel2.Text = "message";
            this.c1SuperLabel2.UseMnemonic = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnCloseDay);
            this.panel2.Controls.Add(this.btnKitchen);
            this.panel2.Controls.Add(this.btnBackOffice);
            this.panel2.Controls.Add(this.btnOrder);
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.btnRetail);
            this.panel2.Controls.Add(this.btnTakeOut);
            this.panel2.Controls.Add(this.btnDineIn);
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 626);
            this.panel2.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::modernpos_pos.Properties.Resources.close_program;
            this.btnClose.Location = new System.Drawing.Point(722, 306);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(344, 141);
            this.btnClose.TabIndex = 11;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCloseDay
            // 
            this.btnCloseDay.Image = global::modernpos_pos.Properties.Resources.close_res;
            this.btnCloseDay.Location = new System.Drawing.Point(22, 306);
            this.btnCloseDay.Name = "btnCloseDay";
            this.btnCloseDay.Size = new System.Drawing.Size(338, 141);
            this.btnCloseDay.TabIndex = 9;
            this.btnCloseDay.UseVisualStyleBackColor = true;
            // 
            // btnKitchen
            // 
            this.btnKitchen.Image = global::modernpos_pos.Properties.Resources.Kitchen;
            this.btnKitchen.Location = new System.Drawing.Point(734, 159);
            this.btnKitchen.Name = "btnKitchen";
            this.btnKitchen.Size = new System.Drawing.Size(323, 141);
            this.btnKitchen.TabIndex = 8;
            this.btnKitchen.UseVisualStyleBackColor = true;
            // 
            // btnBackOffice
            // 
            this.btnBackOffice.Image = global::modernpos_pos.Properties.Resources.backoffice;
            this.btnBackOffice.Location = new System.Drawing.Point(384, 306);
            this.btnBackOffice.Name = "btnBackOffice";
            this.btnBackOffice.Size = new System.Drawing.Size(323, 141);
            this.btnBackOffice.TabIndex = 7;
            this.btnBackOffice.UseVisualStyleBackColor = true;
            // 
            // btnOrder
            // 
            this.btnOrder.Image = global::modernpos_pos.Properties.Resources.item_Oder;
            this.btnOrder.Location = new System.Drawing.Point(384, 159);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(323, 141);
            this.btnOrder.TabIndex = 6;
            this.btnOrder.UseVisualStyleBackColor = true;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::modernpos_pos.Properties.Resources.HomeDelivery;
            this.btnHome.Location = new System.Drawing.Point(31, 159);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(323, 141);
            this.btnHome.TabIndex = 5;
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnRetail
            // 
            this.btnRetail.Image = global::modernpos_pos.Properties.Resources.ขายปลีก;
            this.btnRetail.Location = new System.Drawing.Point(734, 12);
            this.btnRetail.Name = "btnRetail";
            this.btnRetail.Size = new System.Drawing.Size(323, 141);
            this.btnRetail.TabIndex = 4;
            this.btnRetail.UseVisualStyleBackColor = true;
            // 
            // btnTakeOut
            // 
            this.btnTakeOut.Image = global::modernpos_pos.Properties.Resources.take_out;
            this.btnTakeOut.Location = new System.Drawing.Point(384, 12);
            this.btnTakeOut.Name = "btnTakeOut";
            this.btnTakeOut.Size = new System.Drawing.Size(323, 141);
            this.btnTakeOut.TabIndex = 3;
            this.btnTakeOut.UseVisualStyleBackColor = true;
            // 
            // btnDineIn
            // 
            this.btnDineIn.Image = global::modernpos_pos.Properties.Resources.Dinein;
            this.btnDineIn.Location = new System.Drawing.Point(31, 12);
            this.btnDineIn.Name = "btnDineIn";
            this.btnDineIn.Size = new System.Drawing.Size(323, 141);
            this.btnDineIn.TabIndex = 2;
            this.btnDineIn.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 726);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKitchen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackOffice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDineIn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1SuperTooltip.C1SuperLabel txtHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private C1.Win.C1Input.C1Button btnClose;
        private C1.Win.C1Input.C1Button btnCloseDay;
        private C1.Win.C1Input.C1Button btnKitchen;
        private C1.Win.C1Input.C1Button btnBackOffice;
        private C1.Win.C1Input.C1Button btnOrder;
        private C1.Win.C1Input.C1Button btnHome;
        private C1.Win.C1Input.C1Button btnRetail;
        private C1.Win.C1Input.C1Button btnTakeOut;
        private C1.Win.C1Input.C1Button btnDineIn;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel2;
    }
}