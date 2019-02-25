namespace modernpos_pos.gui
{
    partial class FrmConfig
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
            this.c1SuperLabel2 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.c1SuperLabel1 = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnArea = new C1.Win.C1Input.C1Button();
            this.btnTable = new C1.Win.C1Input.C1Button();
            this.btnRes = new C1.Win.C1Input.C1Button();
            this.btmStf = new C1.Win.C1Input.C1Button();
            this.btnDept = new C1.Win.C1Input.C1Button();
            this.btnPosi = new C1.Win.C1Input.C1Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmStf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDept)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPosi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c1SuperLabel2);
            this.panel1.Controls.Add(this.c1SuperLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 100);
            this.panel1.TabIndex = 2;
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
            // c1SuperLabel1
            // 
            this.c1SuperLabel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c1SuperLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.c1SuperLabel1.Location = new System.Drawing.Point(3, 8);
            this.c1SuperLabel1.Name = "c1SuperLabel1";
            this.c1SuperLabel1.Size = new System.Drawing.Size(475, 59);
            this.c1SuperLabel1.TabIndex = 0;
            this.c1SuperLabel1.Text = "modernpos POS Restaurant";
            this.c1SuperLabel1.UseMnemonic = true;
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(471, 257);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(116, 77);
            this.btnArea.TabIndex = 7;
            this.btnArea.Text = "พื้นที่";
            this.btnArea.UseVisualStyleBackColor = true;
            // 
            // btnTable
            // 
            this.btnTable.Location = new System.Drawing.Point(349, 257);
            this.btnTable.Name = "btnTable";
            this.btnTable.Size = new System.Drawing.Size(116, 77);
            this.btnTable.TabIndex = 6;
            this.btnTable.Text = "โต๊ะ";
            this.btnTable.UseVisualStyleBackColor = true;
            // 
            // btnRes
            // 
            this.btnRes.Location = new System.Drawing.Point(227, 257);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(116, 77);
            this.btnRes.TabIndex = 5;
            this.btnRes.Text = "ร้าน";
            this.btnRes.UseVisualStyleBackColor = true;
            // 
            // btmStf
            // 
            this.btmStf.Location = new System.Drawing.Point(227, 340);
            this.btmStf.Name = "btmStf";
            this.btmStf.Size = new System.Drawing.Size(116, 77);
            this.btmStf.TabIndex = 8;
            this.btmStf.Text = "พนักงาน";
            this.btmStf.UseVisualStyleBackColor = true;
            // 
            // btnDept
            // 
            this.btnDept.Location = new System.Drawing.Point(349, 340);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(116, 77);
            this.btnDept.TabIndex = 9;
            this.btnDept.Text = "แผนก";
            this.btnDept.UseVisualStyleBackColor = true;
            // 
            // btnPosi
            // 
            this.btnPosi.Location = new System.Drawing.Point(471, 340);
            this.btnPosi.Name = "btnPosi";
            this.btnPosi.Size = new System.Drawing.Size(116, 77);
            this.btnPosi.TabIndex = 10;
            this.btnPosi.Text = "ตำแหน่ง";
            this.btnPosi.UseVisualStyleBackColor = true;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 591);
            this.Controls.Add(this.btnPosi);
            this.Controls.Add(this.btnDept);
            this.Controls.Add(this.btmStf);
            this.Controls.Add(this.btnArea);
            this.Controls.Add(this.btnTable);
            this.Controls.Add(this.btnRes);
            this.Controls.Add(this.panel1);
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfig";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btmStf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDept)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPosi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel2;
        private C1.Win.C1SuperTooltip.C1SuperLabel c1SuperLabel1;
        private C1.Win.C1Input.C1Button btnArea;
        private C1.Win.C1Input.C1Button btnTable;
        private C1.Win.C1Input.C1Button btnRes;
        private C1.Win.C1Input.C1Button btmStf;
        private C1.Win.C1Input.C1Button btnDept;
        private C1.Win.C1Input.C1Button btnPosi;
    }
}