namespace modernpos_pos.gui
{
    partial class FrmMatrDrawAdd
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
            this.sB = new System.Windows.Forms.StatusStrip();
            this.sB1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDoc = new C1.Win.C1Input.C1Button();
            this.btnVoid = new C1.Win.C1Input.C1Button();
            this.txtPasswordVoid = new C1.Win.C1Input.C1TextBox();
            this.chkVoid = new C1.Win.C1Input.C1CheckBox();
            this.btnSave = new C1.Win.C1Input.C1Button();
            this.txtMatrId = new C1.Win.C1Input.C1TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new C1.Win.C1Input.C1TextBox();
            this.label109 = new System.Windows.Forms.Label();
            this.txtMatrDate = new C1.Win.C1Input.C1DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMatrCode = new C1.Win.C1Input.C1TextBox();
            this.sB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // sB
            // 
            this.sB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sB1});
            this.sB.Location = new System.Drawing.Point(0, 699);
            this.sB.Name = "sB";
            this.sB.Size = new System.Drawing.Size(1130, 22);
            this.sB.TabIndex = 5;
            this.sB.Text = "statusStrip1";
            // 
            // sB1
            // 
            this.sB1.Name = "sB1";
            this.sB1.Size = new System.Drawing.Size(118, 17);
            this.sB1.Text = "toolStripStatusLabel1";
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1130, 628);
            this.panel2.TabIndex = 8;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.btnDoc);
            this.panel1.Controls.Add(this.btnVoid);
            this.panel1.Controls.Add(this.txtPasswordVoid);
            this.panel1.Controls.Add(this.chkVoid);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txtMatrId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label109);
            this.panel1.Controls.Add(this.txtMatrDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtMatrCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 71);
            this.panel1.TabIndex = 7;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // btnDoc
            // 
            this.btnDoc.Image = global::modernpos_pos.Properties.Resources.Email_icon_24;
            this.btnDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoc.Location = new System.Drawing.Point(1005, 3);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(91, 39);
            this.btnDoc.TabIndex = 821;
            this.btnDoc.Text = "นำเข้าStock";
            this.btnDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnDoc, "(default)");
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnVoid
            // 
            this.btnVoid.Image = global::modernpos_pos.Properties.Resources.trash24;
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(916, 29);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(83, 39);
            this.btnVoid.TabIndex = 820;
            this.btnVoid.Text = "ยกเลิกช้อมูล";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtPasswordVoid
            // 
            this.txtPasswordVoid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordVoid.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtPasswordVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPasswordVoid.Location = new System.Drawing.Point(804, 45);
            this.txtPasswordVoid.Name = "txtPasswordVoid";
            this.txtPasswordVoid.PasswordChar = '*';
            this.txtPasswordVoid.Size = new System.Drawing.Size(78, 20);
            this.txtPasswordVoid.TabIndex = 819;
            this.txtPasswordVoid.Tag = null;
            this.theme1.SetTheme(this.txtPasswordVoid, "(default)");
            this.txtPasswordVoid.Visible = false;
            this.txtPasswordVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // chkVoid
            // 
            this.chkVoid.BackColor = System.Drawing.Color.Transparent;
            this.chkVoid.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.chkVoid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkVoid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.chkVoid.Location = new System.Drawing.Point(643, 44);
            this.chkVoid.Name = "chkVoid";
            this.chkVoid.Padding = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.chkVoid.Size = new System.Drawing.Size(155, 24);
            this.chkVoid.TabIndex = 818;
            this.chkVoid.Text = "ต้องการยกเลิกรายการ";
            this.theme1.SetTheme(this.chkVoid, "(default)");
            this.chkVoid.UseVisualStyleBackColor = true;
            this.chkVoid.Value = null;
            this.chkVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::modernpos_pos.Properties.Resources.accept_database24;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(781, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 39);
            this.btnSave.TabIndex = 817;
            this.btnSave.Text = "บันทึกช้อมูล";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSave, "(default)");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtMatrId
            // 
            this.txtMatrId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatrId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtMatrId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMatrId.Location = new System.Drawing.Point(314, 12);
            this.txtMatrId.Name = "txtMatrId";
            this.txtMatrId.Size = new System.Drawing.Size(34, 20);
            this.txtMatrId.TabIndex = 816;
            this.txtMatrId.Tag = null;
            this.theme1.SetTheme(this.txtMatrId, "(default)");
            this.txtMatrId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 815;
            this.label1.Text = "หมายเหตุ  :";
            this.theme1.SetTheme(this.label1, "(default)");
            // 
            // txtRemark
            // 
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRemark.Location = new System.Drawing.Point(101, 38);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(430, 20);
            this.txtRemark.TabIndex = 814;
            this.txtRemark.Tag = null;
            this.theme1.SetTheme(this.txtRemark, "(default)");
            this.txtRemark.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label109.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label109.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label109.Location = new System.Drawing.Point(559, 14);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(35, 16);
            this.label109.TabIndex = 813;
            this.label109.Text = "วันที่ :";
            this.theme1.SetTheme(this.label109, "(default)");
            // 
            // txtMatrDate
            // 
            this.txtMatrDate.AllowSpinLoop = false;
            this.txtMatrDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.txtMatrDate.Calendar.ArrowColor = System.Drawing.Color.Black;
            this.txtMatrDate.Calendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMatrDate.Calendar.DayNamesFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtMatrDate.Calendar.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtMatrDate.Calendar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtMatrDate.Calendar.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.txtMatrDate.Calendar.SelectionForeColor = System.Drawing.Color.White;
            this.txtMatrDate.Calendar.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtMatrDate.Calendar.TitleFont = new System.Drawing.Font("Tahoma", 8F);
            this.txtMatrDate.Calendar.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.txtMatrDate.Calendar.TodayBorderColor = System.Drawing.Color.White;
            this.txtMatrDate.Calendar.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtMatrDate.Calendar.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.txtMatrDate.Culture = 1054;
            this.txtMatrDate.CurrentTimeZone = false;
            this.txtMatrDate.DateTimeInput = false;
            this.txtMatrDate.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtMatrDate.DisplayFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtMatrDate.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtMatrDate.DisplayFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtMatrDate.EditFormat.CalendarType = C1.Win.C1Input.CalendarType.GregorianCalendar;
            this.txtMatrDate.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate;
            this.txtMatrDate.EditFormat.Inherit = ((C1.Win.C1Input.FormatInfoInheritFlags)(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat | C1.Win.C1Input.FormatInfoInheritFlags.NullText) 
            | C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) 
            | C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd)));
            this.txtMatrDate.EmptyAsNull = true;
            this.txtMatrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMatrDate.GMTOffset = System.TimeSpan.Parse("00:00:00");
            this.txtMatrDate.ImagePadding = new System.Windows.Forms.Padding(0);
            this.txtMatrDate.Location = new System.Drawing.Point(600, 12);
            this.txtMatrDate.Name = "txtMatrDate";
            this.txtMatrDate.Size = new System.Drawing.Size(165, 20);
            this.txtMatrDate.TabIndex = 812;
            this.txtMatrDate.Tag = null;
            this.theme1.SetTheme(this.txtMatrDate, "(default)");
            this.txtMatrDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.label4.Location = new System.Drawing.Point(15, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 538;
            this.label4.Text = "เลขที่  :";
            this.theme1.SetTheme(this.label4, "(default)");
            // 
            // txtMatrCode
            // 
            this.txtMatrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMatrCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtMatrCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMatrCode.Location = new System.Drawing.Point(101, 12);
            this.txtMatrCode.Name = "txtMatrCode";
            this.txtMatrCode.Size = new System.Drawing.Size(207, 20);
            this.txtMatrCode.TabIndex = 537;
            this.txtMatrCode.Tag = null;
            this.theme1.SetTheme(this.txtMatrCode, "(default)");
            this.txtMatrCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmMatrDrawAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 721);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.sB);
            this.Name = "FrmMatrDrawAdd";
            this.Text = "FrmMatrDrawAdd";
            this.Load += new System.EventHandler(this.FrmMatrDrawAdd_Load);
            this.sB.ResumeLayout(false);
            this.sB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVoid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatrCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sB;
        private System.Windows.Forms.ToolStripStatusLabel sB1;
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private C1.Win.C1Input.C1Button btnDoc;
        private C1.Win.C1Input.C1Button btnVoid;
        private C1.Win.C1Input.C1TextBox txtPasswordVoid;
        private C1.Win.C1Input.C1CheckBox chkVoid;
        private C1.Win.C1Input.C1Button btnSave;
        private C1.Win.C1Input.C1TextBox txtMatrId;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1Input.C1TextBox txtRemark;
        private System.Windows.Forms.Label label109;
        private C1.Win.C1Input.C1DateEdit txtMatrDate;
        private System.Windows.Forms.Label label4;
        private C1.Win.C1Input.C1TextBox txtMatrCode;
    }
}