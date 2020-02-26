namespace modernpos_pos.gui
{
    partial class ucOrderTakeOut1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPrice = new C1.Win.C1Input.C1Label();
            this.lbName = new C1.Win.C1Input.C1Label();
            this.lbQty = new C1.Win.C1Input.C1Label();
            this.pnHead = new System.Windows.Forms.Panel();
            this.picTogo = new C1.Win.C1Input.C1PictureBox();
            this.lbRow = new C1.Win.C1Input.C1Label();
            this.picDesc = new C1.Win.C1Input.C1PictureBox();
            this.picDel = new C1.Win.C1Input.C1PictureBox();
            this.picMinus = new C1.Win.C1Input.C1PictureBox();
            this.picPlus = new C1.Win.C1Input.C1PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.lbPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbQty)).BeginInit();
            this.pnHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlus)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPrice
            // 
            this.lbPrice.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrice.Location = new System.Drawing.Point(284, 4);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(113, 31);
            this.lbPrice.TabIndex = 6;
            this.lbPrice.Tag = null;
            this.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbPrice.Value = "9,999.00";
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(208)))));
            this.lbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(42, 4);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(237, 42);
            this.lbName.TabIndex = 5;
            this.lbName.Tag = null;
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbQty
            // 
            this.lbQty.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQty.Location = new System.Drawing.Point(86, 49);
            this.lbQty.Name = "lbQty";
            this.lbQty.Size = new System.Drawing.Size(49, 32);
            this.lbQty.TabIndex = 9;
            this.lbQty.Tag = null;
            this.lbQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnHead
            // 
            this.pnHead.BackColor = System.Drawing.Color.White;
            this.pnHead.Controls.Add(this.picTogo);
            this.pnHead.Controls.Add(this.lbRow);
            this.pnHead.Controls.Add(this.lbName);
            this.pnHead.Controls.Add(this.picDesc);
            this.pnHead.Controls.Add(this.lbPrice);
            this.pnHead.Controls.Add(this.picDel);
            this.pnHead.Controls.Add(this.picMinus);
            this.pnHead.Controls.Add(this.lbQty);
            this.pnHead.Controls.Add(this.picPlus);
            this.pnHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHead.Location = new System.Drawing.Point(0, 0);
            this.pnHead.Name = "pnHead";
            this.pnHead.Size = new System.Drawing.Size(400, 85);
            this.pnHead.TabIndex = 12;
            // 
            // picTogo
            // 
            this.picTogo.BackColor = System.Drawing.Color.White;
            this.picTogo.Image = global::modernpos_pos.Properties.Resources.circle_write;
            this.picTogo.Location = new System.Drawing.Point(269, 49);
            this.picTogo.Name = "picTogo";
            this.picTogo.Size = new System.Drawing.Size(78, 32);
            this.picTogo.TabIndex = 13;
            this.picTogo.TabStop = false;
            // 
            // lbRow
            // 
            this.lbRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(208)))));
            this.lbRow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRow.Location = new System.Drawing.Point(2, 4);
            this.lbRow.Name = "lbRow";
            this.lbRow.Size = new System.Drawing.Size(36, 31);
            this.lbRow.TabIndex = 12;
            this.lbRow.Tag = null;
            this.lbRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picDesc
            // 
            this.picDesc.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picDesc.Location = new System.Drawing.Point(185, 49);
            this.picDesc.Name = "picDesc";
            this.picDesc.Size = new System.Drawing.Size(78, 32);
            this.picDesc.TabIndex = 11;
            this.picDesc.TabStop = false;
            // 
            // picDel
            // 
            this.picDel.Image = global::modernpos_pos.Properties.Resources.exit;
            this.picDel.Location = new System.Drawing.Point(355, 37);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(42, 42);
            this.picDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDel.TabIndex = 10;
            this.picDel.TabStop = false;
            // 
            // picMinus
            // 
            this.picMinus.Image = global::modernpos_pos.Properties.Resources.minus;
            this.picMinus.Location = new System.Drawing.Point(43, 49);
            this.picMinus.Name = "picMinus";
            this.picMinus.Size = new System.Drawing.Size(32, 32);
            this.picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinus.TabIndex = 7;
            this.picMinus.TabStop = false;
            // 
            // picPlus
            // 
            this.picPlus.Image = global::modernpos_pos.Properties.Resources.plus;
            this.picPlus.Location = new System.Drawing.Point(137, 49);
            this.picPlus.Name = "picPlus";
            this.picPlus.Size = new System.Drawing.Size(32, 32);
            this.picPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlus.TabIndex = 8;
            this.picPlus.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 362);
            this.panel1.TabIndex = 13;
            // 
            // ucOrderTakeOut1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnHead);
            this.Name = "ucOrderTakeOut1";
            this.Size = new System.Drawing.Size(400, 447);
            ((System.ComponentModel.ISupportInitialize)(this.lbPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbQty)).EndInit();
            this.pnHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1Label lbPrice;
        private C1.Win.C1Input.C1Label lbName;
        private C1.Win.C1Input.C1PictureBox picDesc;
        private C1.Win.C1Input.C1PictureBox picDel;
        private C1.Win.C1Input.C1Label lbQty;
        private C1.Win.C1Input.C1PictureBox picPlus;
        private C1.Win.C1Input.C1PictureBox picMinus;
        private System.Windows.Forms.Panel pnHead;
        private C1.Win.C1Input.C1Label lbRow;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1PictureBox picTogo;
    }
}
