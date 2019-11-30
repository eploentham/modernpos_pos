namespace modernpos_pos.gui
{ 
    partial class FrmTakeOut4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTakeOut4));
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.pnMain = new System.Windows.Forms.Panel();
            this.tCMain = new C1.Win.C1Command.C1DockingTab();
            this.tabOrder = new C1.Win.C1Command.C1DockingTabPage();
            this.pnOrderMain = new System.Windows.Forms.Panel();
            this.sCOrder = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.scFoods = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.sCFoodsMain = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.scFoodsCat = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.scFoodsItem = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.scOrd = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnOrdBill = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbTakeOutFooName = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnPay = new System.Windows.Forms.Button();
            this.pnOrdOrder = new System.Windows.Forms.Panel();
            this.pnOrdHead = new System.Windows.Forms.Panel();
            this.txtFooId = new C1.Win.C1Input.C1TextBox();
            this.txtRow = new C1.Win.C1Input.C1TextBox();
            this.txtTableCode = new C1.Win.C1Input.C1TextBox();
            this.tabCheck = new C1.Win.C1Command.C1DockingTabPage();
            this.pnCheckMain = new System.Windows.Forms.Panel();
            this.sCCheck = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.scCheckLeft = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnCheckBill = new System.Windows.Forms.Panel();
            this.btnBack = new C1.Win.C1Input.C1Button();
            this.pnVoidPay = new System.Windows.Forms.Panel();
            this.cboRsp = new C1.Win.C1List.C1Combo();
            this.chkPaypaying = new System.Windows.Forms.RadioButton();
            this.chkPayBefore = new System.Windows.Forms.RadioButton();
            this.btnVoidPay = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbStatus = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.lbAmt = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnBillCheck = new System.Windows.Forms.Button();
            this.scCheckRight = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnCheckOrder = new System.Windows.Forms.Panel();
            this.tabCommand = new C1.Win.C1Command.C1DockingTabPage();
            this.pnCommand = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCMain)).BeginInit();
            this.tCMain.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.pnOrderMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCOrder)).BeginInit();
            this.sCOrder.SuspendLayout();
            this.scFoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCFoodsMain)).BeginInit();
            this.sCFoodsMain.SuspendLayout();
            this.scOrd.SuspendLayout();
            this.pnOrdBill.SuspendLayout();
            this.pnOrdHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).BeginInit();
            this.tabCheck.SuspendLayout();
            this.pnCheckMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sCCheck)).BeginInit();
            this.sCCheck.SuspendLayout();
            this.scCheckLeft.SuspendLayout();
            this.pnCheckBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            this.pnVoidPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsp)).BeginInit();
            this.scCheckRight.SuspendLayout();
            this.tabCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnMain.Controls.Add(this.tCMain);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1408, 773);
            this.pnMain.TabIndex = 1;
            this.theme1.SetTheme(this.pnMain, "(default)");
            // 
            // tCMain
            // 
            this.tCMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tCMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tCMain.Controls.Add(this.tabOrder);
            this.tCMain.Controls.Add(this.tabCheck);
            this.tCMain.Controls.Add(this.tabCommand);
            this.tCMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tCMain.HotTrack = true;
            this.tCMain.Location = new System.Drawing.Point(0, 0);
            this.tCMain.Name = "tCMain";
            this.tCMain.Size = new System.Drawing.Size(1408, 773);
            this.tCMain.TabIndex = 2;
            this.tCMain.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tCMain.TabsShowFocusCues = false;
            this.tCMain.TabsSpacing = 2;
            this.tCMain.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tCMain, "(default)");
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.pnOrderMain);
            this.tabOrder.Location = new System.Drawing.Point(1, 24);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Size = new System.Drawing.Size(1406, 748);
            this.tabOrder.TabIndex = 0;
            this.tabOrder.Text = "Order";
            // 
            // pnOrderMain
            // 
            this.pnOrderMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnOrderMain.Controls.Add(this.sCOrder);
            this.pnOrderMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnOrderMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnOrderMain.Location = new System.Drawing.Point(0, 0);
            this.pnOrderMain.Name = "pnOrderMain";
            this.pnOrderMain.Size = new System.Drawing.Size(1406, 748);
            this.pnOrderMain.TabIndex = 2;
            this.theme1.SetTheme(this.pnOrderMain, "(default)");
            // 
            // sCOrder
            // 
            this.sCOrder.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.sCOrder.BackColor = System.Drawing.Color.White;
            this.sCOrder.CollapsingAreaColor = System.Drawing.Color.White;
            this.sCOrder.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sCOrder.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCOrder.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCOrder.HeaderLineWidth = 1;
            this.sCOrder.Location = new System.Drawing.Point(0, 0);
            this.sCOrder.Name = "sCOrder";
            this.sCOrder.Panels.Add(this.scFoods);
            this.sCOrder.Panels.Add(this.scOrd);
            this.sCOrder.Size = new System.Drawing.Size(1406, 748);
            this.sCOrder.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCOrder.SplitterMovingColor = System.Drawing.Color.Black;
            this.sCOrder.TabIndex = 0;
            this.theme1.SetTheme(this.sCOrder, "(default)");
            this.sCOrder.UseParentVisualStyle = false;
            // 
            // scFoods
            // 
            this.scFoods.Collapsible = true;
            this.scFoods.Controls.Add(this.sCFoodsMain);
            this.scFoods.Cursor = System.Windows.Forms.Cursors.Default;
            this.scFoods.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.scFoods.Location = new System.Drawing.Point(0, 21);
            this.scFoods.Name = "scFoods";
            this.scFoods.Size = new System.Drawing.Size(793, 727);
            this.scFoods.SizeRatio = 57.061D;
            this.scFoods.TabIndex = 0;
            this.scFoods.Text = "Foods";
            this.scFoods.Width = 793;
            // 
            // sCFoodsMain
            // 
            this.sCFoodsMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.sCFoodsMain.BackColor = System.Drawing.Color.White;
            this.sCFoodsMain.CollapsingAreaColor = System.Drawing.Color.White;
            this.sCFoodsMain.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCFoodsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sCFoodsMain.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCFoodsMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCFoodsMain.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCFoodsMain.HeaderLineWidth = 1;
            this.sCFoodsMain.Location = new System.Drawing.Point(0, 0);
            this.sCFoodsMain.Name = "sCFoodsMain";
            this.sCFoodsMain.Panels.Add(this.scFoodsCat);
            this.sCFoodsMain.Panels.Add(this.scFoodsItem);
            this.sCFoodsMain.Size = new System.Drawing.Size(793, 727);
            this.sCFoodsMain.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCFoodsMain.SplitterMovingColor = System.Drawing.Color.Black;
            this.sCFoodsMain.TabIndex = 0;
            this.theme1.SetTheme(this.sCFoodsMain, "(default)");
            this.sCFoodsMain.UseParentVisualStyle = false;
            // 
            // scFoodsCat
            // 
            this.scFoodsCat.Height = 158;
            this.scFoodsCat.Location = new System.Drawing.Point(0, 21);
            this.scFoodsCat.Name = "scFoodsCat";
            this.scFoodsCat.Size = new System.Drawing.Size(793, 137);
            this.scFoodsCat.SizeRatio = 21.911D;
            this.scFoodsCat.TabIndex = 0;
            this.scFoodsCat.Text = "Category";
            // 
            // scFoodsItem
            // 
            this.scFoodsItem.Height = 565;
            this.scFoodsItem.Location = new System.Drawing.Point(0, 183);
            this.scFoodsItem.Name = "scFoodsItem";
            this.scFoodsItem.Size = new System.Drawing.Size(793, 544);
            this.scFoodsItem.TabIndex = 1;
            this.scFoodsItem.Text = "Item";
            // 
            // scOrd
            // 
            this.scOrd.Controls.Add(this.pnOrdBill);
            this.scOrd.Controls.Add(this.pnOrdOrder);
            this.scOrd.Controls.Add(this.pnOrdHead);
            this.scOrd.Height = 748;
            this.scOrd.Location = new System.Drawing.Point(804, 21);
            this.scOrd.Name = "scOrd";
            this.scOrd.Size = new System.Drawing.Size(602, 727);
            this.scOrd.TabIndex = 1;
            this.scOrd.Text = "Order";
            // 
            // pnOrdBill
            // 
            this.pnOrdBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnOrdBill.Controls.Add(this.button3);
            this.pnOrdBill.Controls.Add(this.button2);
            this.pnOrdBill.Controls.Add(this.lbTakeOutFooName);
            this.pnOrdBill.Controls.Add(this.btnPay);
            this.pnOrdBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnOrdBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnOrdBill.Location = new System.Drawing.Point(0, 533);
            this.pnOrdBill.Name = "pnOrdBill";
            this.pnOrdBill.Size = new System.Drawing.Size(602, 194);
            this.pnOrdBill.TabIndex = 2;
            this.theme1.SetTheme(this.pnOrdBill, "(default)");
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(158, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 64);
            this.button3.TabIndex = 255;
            this.button3.Text = "QR Code kbank";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.button3, "(default)");
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(3, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 64);
            this.button2.TabIndex = 254;
            this.button2.Text = "ชำระเงินสด";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.button2, "(default)");
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lbTakeOutFooName
            // 
            this.lbTakeOutFooName.AutoSize = true;
            this.lbTakeOutFooName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbTakeOutFooName.Location = new System.Drawing.Point(3, 6);
            this.lbTakeOutFooName.Name = "lbTakeOutFooName";
            this.lbTakeOutFooName.Size = new System.Drawing.Size(301, 29);
            this.lbTakeOutFooName.TabIndex = 253;
            this.lbTakeOutFooName.Text = "modernpos POS Restaurant";
            this.theme1.SetTheme(this.lbTakeOutFooName, "(default)");
            this.lbTakeOutFooName.UseMnemonic = true;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnPay.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.btnPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(3, 119);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(361, 64);
            this.btnPay.TabIndex = 250;
            this.btnPay.Text = "bill";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnPay, "(default)");
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // pnOrdOrder
            // 
            this.pnOrdOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnOrdOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnOrdOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnOrdOrder.Location = new System.Drawing.Point(0, 31);
            this.pnOrdOrder.Name = "pnOrdOrder";
            this.pnOrdOrder.Size = new System.Drawing.Size(602, 502);
            this.pnOrdOrder.TabIndex = 1;
            this.theme1.SetTheme(this.pnOrdOrder, "(default)");
            // 
            // pnOrdHead
            // 
            this.pnOrdHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnOrdHead.Controls.Add(this.txtFooId);
            this.pnOrdHead.Controls.Add(this.txtRow);
            this.pnOrdHead.Controls.Add(this.txtTableCode);
            this.pnOrdHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnOrdHead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnOrdHead.Location = new System.Drawing.Point(0, 0);
            this.pnOrdHead.Name = "pnOrdHead";
            this.pnOrdHead.Size = new System.Drawing.Size(602, 31);
            this.pnOrdHead.TabIndex = 0;
            this.theme1.SetTheme(this.pnOrdHead, "(default)");
            // 
            // txtFooId
            // 
            this.txtFooId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFooId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFooId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFooId.Location = new System.Drawing.Point(59, 5);
            this.txtFooId.Name = "txtFooId";
            this.txtFooId.Size = new System.Drawing.Size(22, 20);
            this.txtFooId.TabIndex = 245;
            this.txtFooId.Tag = null;
            this.theme1.SetTheme(this.txtFooId, "(default)");
            this.txtFooId.Visible = false;
            this.txtFooId.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtRow
            // 
            this.txtRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRow.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtRow.Location = new System.Drawing.Point(31, 5);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(22, 20);
            this.txtRow.TabIndex = 244;
            this.txtRow.Tag = null;
            this.theme1.SetTheme(this.txtRow, "(default)");
            this.txtRow.Visible = false;
            this.txtRow.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtTableCode
            // 
            this.txtTableCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTableCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableCode.Location = new System.Drawing.Point(3, 5);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(22, 20);
            this.txtTableCode.TabIndex = 243;
            this.txtTableCode.Tag = null;
            this.theme1.SetTheme(this.txtTableCode, "(default)");
            this.txtTableCode.Visible = false;
            this.txtTableCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // tabCheck
            // 
            this.tabCheck.Controls.Add(this.pnCheckMain);
            this.tabCheck.Location = new System.Drawing.Point(1, 24);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Size = new System.Drawing.Size(1406, 748);
            this.tabCheck.TabIndex = 1;
            this.tabCheck.Text = "Check";
            // 
            // pnCheckMain
            // 
            this.pnCheckMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCheckMain.Controls.Add(this.sCCheck);
            this.pnCheckMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCheckMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCheckMain.Location = new System.Drawing.Point(0, 0);
            this.pnCheckMain.Name = "pnCheckMain";
            this.pnCheckMain.Size = new System.Drawing.Size(1406, 748);
            this.pnCheckMain.TabIndex = 2;
            this.theme1.SetTheme(this.pnCheckMain, "(default)");
            // 
            // sCCheck
            // 
            this.sCCheck.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.sCCheck.BackColor = System.Drawing.Color.White;
            this.sCCheck.CollapsingAreaColor = System.Drawing.Color.White;
            this.sCCheck.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sCCheck.FixedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCCheck.HeaderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.sCCheck.HeaderLineWidth = 1;
            this.sCCheck.Location = new System.Drawing.Point(0, 0);
            this.sCCheck.Name = "sCCheck";
            this.sCCheck.Panels.Add(this.scCheckLeft);
            this.sCCheck.Panels.Add(this.scCheckRight);
            this.sCCheck.Size = new System.Drawing.Size(1406, 748);
            this.sCCheck.SplitterColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.sCCheck.SplitterMovingColor = System.Drawing.Color.Black;
            this.sCCheck.TabIndex = 0;
            this.theme1.SetTheme(this.sCCheck, "(default)");
            this.sCCheck.UseParentVisualStyle = false;
            // 
            // scCheckLeft
            // 
            this.scCheckLeft.Collapsible = true;
            this.scCheckLeft.Controls.Add(this.pnCheckBill);
            this.scCheckLeft.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.scCheckLeft.Location = new System.Drawing.Point(0, 21);
            this.scCheckLeft.Name = "scCheckLeft";
            this.scCheckLeft.Size = new System.Drawing.Size(694, 727);
            this.scCheckLeft.TabIndex = 0;
            this.scCheckLeft.Text = "Panel 1";
            this.scCheckLeft.Width = 701;
            // 
            // pnCheckBill
            // 
            this.pnCheckBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCheckBill.Controls.Add(this.btnBack);
            this.pnCheckBill.Controls.Add(this.pnVoidPay);
            this.pnCheckBill.Controls.Add(this.listBox1);
            this.pnCheckBill.Controls.Add(this.button1);
            this.pnCheckBill.Controls.Add(this.lbStatus);
            this.pnCheckBill.Controls.Add(this.lbAmt);
            this.pnCheckBill.Controls.Add(this.btnBillCheck);
            this.pnCheckBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCheckBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCheckBill.Location = new System.Drawing.Point(0, 0);
            this.pnCheckBill.Name = "pnCheckBill";
            this.pnCheckBill.Size = new System.Drawing.Size(694, 727);
            this.pnCheckBill.TabIndex = 0;
            this.theme1.SetTheme(this.pnCheckBill, "(default)");
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBack.Location = new System.Drawing.Point(74, 506);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(106, 64);
            this.btnBack.TabIndex = 249;
            this.btnBack.Text = "กลับสั่งต่อ";
            this.theme1.SetTheme(this.btnBack, "(default)");
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // pnVoidPay
            // 
            this.pnVoidPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnVoidPay.Controls.Add(this.cboRsp);
            this.pnVoidPay.Controls.Add(this.chkPaypaying);
            this.pnVoidPay.Controls.Add(this.btnVoidPay);
            this.pnVoidPay.Controls.Add(this.chkPayBefore);
            this.pnVoidPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnVoidPay.Location = new System.Drawing.Point(358, 425);
            this.pnVoidPay.Name = "pnVoidPay";
            this.pnVoidPay.Size = new System.Drawing.Size(236, 143);
            this.pnVoidPay.TabIndex = 248;
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
            this.cboRsp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
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
            this.btnVoidPay.Location = new System.Drawing.Point(121, 94);
            this.btnVoidPay.Name = "btnVoidPay";
            this.btnVoidPay.Size = new System.Drawing.Size(106, 45);
            this.btnVoidPay.TabIndex = 247;
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
            this.listBox1.Location = new System.Drawing.Point(11, 246);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(587, 173);
            this.listBox1.TabIndex = 246;
            this.theme1.SetTheme(this.listBox1, "(default)");
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(209, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 64);
            this.button1.TabIndex = 245;
            this.button1.Text = "พิมพ์ใบกำกับภาษี";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.button1, "(default)");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbStatus.Location = new System.Drawing.Point(11, 152);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(464, 81);
            this.lbStatus.TabIndex = 244;
            this.lbStatus.Text = "modernpos POS Restaurant";
            this.theme1.SetTheme(this.lbStatus, "(default)");
            this.lbStatus.UseMnemonic = true;
            // 
            // lbAmt
            // 
            this.lbAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbAmt.Location = new System.Drawing.Point(11, 32);
            this.lbAmt.Name = "lbAmt";
            this.lbAmt.Size = new System.Drawing.Size(464, 81);
            this.lbAmt.TabIndex = 243;
            this.lbAmt.Text = "modernpos POS Restaurant";
            this.theme1.SetTheme(this.lbAmt, "(default)");
            this.lbAmt.UseMnemonic = true;
            // 
            // btnBillCheck
            // 
            this.btnBillCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnBillCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnBillCheck.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.btnBillCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnBillCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnBillCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBillCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnBillCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBillCheck.Location = new System.Drawing.Point(74, 436);
            this.btnBillCheck.Name = "btnBillCheck";
            this.btnBillCheck.Size = new System.Drawing.Size(106, 64);
            this.btnBillCheck.TabIndex = 242;
            this.btnBillCheck.Text = "ชำระเงิน";
            this.theme1.SetTheme(this.btnBillCheck, "(default)");
            this.btnBillCheck.UseVisualStyleBackColor = true;
            // 
            // scCheckRight
            // 
            this.scCheckRight.Collapsible = true;
            this.scCheckRight.Controls.Add(this.pnCheckOrder);
            this.scCheckRight.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.scCheckRight.Height = 748;
            this.scCheckRight.Location = new System.Drawing.Point(705, 21);
            this.scCheckRight.Name = "scCheckRight";
            this.scCheckRight.Size = new System.Drawing.Size(701, 727);
            this.scCheckRight.TabIndex = 1;
            this.scCheckRight.Text = "Panel 2";
            this.scCheckRight.Width = 701;
            // 
            // pnCheckOrder
            // 
            this.pnCheckOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCheckOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCheckOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCheckOrder.Location = new System.Drawing.Point(0, 0);
            this.pnCheckOrder.Name = "pnCheckOrder";
            this.pnCheckOrder.Size = new System.Drawing.Size(701, 727);
            this.pnCheckOrder.TabIndex = 0;
            this.theme1.SetTheme(this.pnCheckOrder, "(default)");
            // 
            // tabCommand
            // 
            this.tabCommand.Controls.Add(this.pnCommand);
            this.tabCommand.Location = new System.Drawing.Point(1, 24);
            this.tabCommand.Name = "tabCommand";
            this.tabCommand.Size = new System.Drawing.Size(1406, 748);
            this.tabCommand.TabIndex = 2;
            this.tabCommand.Text = "Command";
            // 
            // pnCommand
            // 
            this.pnCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnCommand.Location = new System.Drawing.Point(0, 0);
            this.pnCommand.Name = "pnCommand";
            this.pnCommand.Size = new System.Drawing.Size(1406, 748);
            this.pnCommand.TabIndex = 0;
            this.theme1.SetTheme(this.pnCommand, "(default)");
            // 
            // FrmTakeOut4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 773);
            this.Controls.Add(this.pnMain);
            this.Name = "FrmTakeOut4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTakeOut4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakeOut4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tCMain)).EndInit();
            this.tCMain.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.pnOrderMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sCOrder)).EndInit();
            this.sCOrder.ResumeLayout(false);
            this.scFoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sCFoodsMain)).EndInit();
            this.sCFoodsMain.ResumeLayout(false);
            this.scOrd.ResumeLayout(false);
            this.pnOrdBill.ResumeLayout(false);
            this.pnOrdBill.PerformLayout();
            this.pnOrdHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).EndInit();
            this.tabCheck.ResumeLayout(false);
            this.pnCheckMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sCCheck)).EndInit();
            this.sCCheck.ResumeLayout(false);
            this.scCheckLeft.ResumeLayout(false);
            this.pnCheckBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            this.pnVoidPay.ResumeLayout(false);
            this.pnVoidPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboRsp)).EndInit();
            this.scCheckRight.ResumeLayout(false);
            this.tabCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1Themes.C1ThemeController theme1;
        private System.Windows.Forms.Panel pnMain;
        private C1.Win.C1Command.C1DockingTab tCMain;
        private C1.Win.C1Command.C1DockingTabPage tabOrder;
        private System.Windows.Forms.Panel pnOrderMain;
        private C1.Win.C1SplitContainer.C1SplitContainer sCOrder;
        private C1.Win.C1SplitContainer.C1SplitterPanel scFoods;
        private C1.Win.C1SplitContainer.C1SplitContainer sCFoodsMain;
        private C1.Win.C1SplitContainer.C1SplitterPanel scFoodsCat;
        private C1.Win.C1SplitContainer.C1SplitterPanel scFoodsItem;
        private C1.Win.C1SplitContainer.C1SplitterPanel scOrd;
        private System.Windows.Forms.Panel pnOrdBill;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbTakeOutFooName;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Panel pnOrdOrder;
        private System.Windows.Forms.Panel pnOrdHead;
        private C1.Win.C1Input.C1TextBox txtFooId;
        private C1.Win.C1Input.C1TextBox txtRow;
        private C1.Win.C1Input.C1TextBox txtTableCode;
        private C1.Win.C1Command.C1DockingTabPage tabCheck;
        private System.Windows.Forms.Panel pnCheckMain;
        private C1.Win.C1SplitContainer.C1SplitContainer sCCheck;
        private C1.Win.C1SplitContainer.C1SplitterPanel scCheckLeft;
        private System.Windows.Forms.Panel pnCheckBill;
        private C1.Win.C1Input.C1Button btnBack;
        private System.Windows.Forms.Panel pnVoidPay;
        private C1.Win.C1List.C1Combo cboRsp;
        private System.Windows.Forms.RadioButton chkPaypaying;
        private System.Windows.Forms.RadioButton chkPayBefore;
        private System.Windows.Forms.Button btnVoidPay;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbStatus;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbAmt;
        private System.Windows.Forms.Button btnBillCheck;
        private C1.Win.C1SplitContainer.C1SplitterPanel scCheckRight;
        private System.Windows.Forms.Panel pnCheckOrder;
        private C1.Win.C1Command.C1DockingTabPage tabCommand;
        private System.Windows.Forms.Panel pnCommand;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}