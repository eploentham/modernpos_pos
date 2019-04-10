namespace modernpos_pos.gui
{
    partial class FrmTakeOut1
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
            this.theme1 = new C1.Win.C1Themes.C1ThemeController();
            this.tabMain = new C1.Win.C1Command.C1DockingTab();
            this.tabOrer = new C1.Win.C1Command.C1DockingTabPage();
            this.tabSpecTopping = new C1.Win.C1Command.C1DockingTabPage();
            this.tabCheck = new C1.Win.C1Command.C1DockingTabPage();
            this.spMain = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.pnItem = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnOrder = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.spItem = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.pnFoods = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnDrink = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnSpecItem = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spSpecialTopping = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.pnSpecial = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.pnToping = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.spCheck = new C1.Win.C1SplitContainer.C1SplitContainer();
            this.c1SplitterPanel1 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1SplitterPanel2 = new C1.Win.C1SplitContainer.C1SplitterPanel();
            this.c1DockingTab2 = new C1.Win.C1Command.C1DockingTab();
            this.tabBill = new C1.Win.C1Command.C1DockingTabPage();
            this.tabCommand = new C1.Win.C1Command.C1DockingTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnBill = new System.Windows.Forms.Panel();
            this.btnVoidAll = new System.Windows.Forms.Button();
            this.btnTopping = new System.Windows.Forms.Button();
            this.lbFooName = new C1.Win.C1SuperTooltip.C1SuperLabel();
            this.btnSpec = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.txtTableCode = new C1.Win.C1Input.C1TextBox();
            this.txtFooId = new C1.Win.C1Input.C1TextBox();
            this.txtRow = new C1.Win.C1Input.C1TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabOrer.SuspendLayout();
            this.tabSpecTopping.SuspendLayout();
            this.tabCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).BeginInit();
            this.spMain.SuspendLayout();
            this.pnItem.SuspendLayout();
            this.pnOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spItem)).BeginInit();
            this.spItem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spSpecialTopping)).BeginInit();
            this.spSpecialTopping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCheck)).BeginInit();
            this.spCheck.SuspendLayout();
            this.c1SplitterPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab2)).BeginInit();
            this.c1DockingTab2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).BeginInit();
            this.SuspendLayout();
            // 
            // theme1
            // 
            this.theme1.Theme = "Office2013Red";
            // 
            // tabMain
            // 
            this.tabMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tabMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabMain.Controls.Add(this.tabOrer);
            this.tabMain.Controls.Add(this.tabSpecTopping);
            this.tabMain.Controls.Add(this.tabCheck);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.HotTrack = true;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(988, 721);
            this.tabMain.TabIndex = 0;
            this.tabMain.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.tabMain.TabsShowFocusCues = false;
            this.tabMain.TabsSpacing = 2;
            this.tabMain.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.tabMain, "(default)");
            // 
            // tabOrer
            // 
            this.tabOrer.Controls.Add(this.spMain);
            this.tabOrer.Location = new System.Drawing.Point(1, 24);
            this.tabOrer.Name = "tabOrer";
            this.tabOrer.Size = new System.Drawing.Size(986, 696);
            this.tabOrer.TabIndex = 0;
            this.tabOrer.Text = "Order";
            // 
            // tabSpecTopping
            // 
            this.tabSpecTopping.Controls.Add(this.panel2);
            this.tabSpecTopping.Controls.Add(this.pnSpecItem);
            this.tabSpecTopping.Location = new System.Drawing.Point(1, 24);
            this.tabSpecTopping.Name = "tabSpecTopping";
            this.tabSpecTopping.Size = new System.Drawing.Size(986, 696);
            this.tabSpecTopping.TabIndex = 1;
            this.tabSpecTopping.Text = "Special Topping";
            // 
            // tabCheck
            // 
            this.tabCheck.Controls.Add(this.spCheck);
            this.tabCheck.Location = new System.Drawing.Point(1, 24);
            this.tabCheck.Name = "tabCheck";
            this.tabCheck.Size = new System.Drawing.Size(986, 696);
            this.tabCheck.TabIndex = 2;
            this.tabCheck.Text = "Check";
            // 
            // spMain
            // 
            this.spMain.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.spMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.spMain.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.spMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spMain.HeaderLineWidth = 1;
            this.spMain.Location = new System.Drawing.Point(0, 0);
            this.spMain.Name = "spMain";
            this.spMain.Panels.Add(this.pnItem);
            this.spMain.Panels.Add(this.pnOrder);
            this.spMain.Size = new System.Drawing.Size(986, 696);
            this.spMain.SplitterMovingColor = System.Drawing.Color.Black;
            this.spMain.TabIndex = 1;
            this.theme1.SetTheme(this.spMain, "(default)");
            // 
            // pnItem
            // 
            this.pnItem.Collapsible = true;
            this.pnItem.Controls.Add(this.spItem);
            this.pnItem.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.pnItem.Location = new System.Drawing.Point(0, 21);
            this.pnItem.Name = "pnItem";
            this.pnItem.Size = new System.Drawing.Size(484, 675);
            this.pnItem.TabIndex = 0;
            this.pnItem.Text = "Item";
            this.pnItem.Width = 491;
            // 
            // pnOrder
            // 
            this.pnOrder.Controls.Add(this.pnBill);
            this.pnOrder.Controls.Add(this.panel3);
            this.pnOrder.Controls.Add(this.panel1);
            this.pnOrder.Height = 696;
            this.pnOrder.Location = new System.Drawing.Point(495, 21);
            this.pnOrder.Name = "pnOrder";
            this.pnOrder.Size = new System.Drawing.Size(491, 675);
            this.pnOrder.TabIndex = 1;
            this.pnOrder.Text = "Order";
            // 
            // spItem
            // 
            this.spItem.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.spItem.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.spItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spItem.HeaderLineWidth = 1;
            this.spItem.Location = new System.Drawing.Point(0, 0);
            this.spItem.Name = "spItem";
            this.spItem.Panels.Add(this.pnFoods);
            this.spItem.Panels.Add(this.pnDrink);
            this.spItem.Size = new System.Drawing.Size(484, 675);
            this.spItem.SplitterMovingColor = System.Drawing.Color.Black;
            this.spItem.TabIndex = 0;
            this.theme1.SetTheme(this.spItem, "(default)");
            // 
            // pnFoods
            // 
            this.pnFoods.Collapsible = true;
            this.pnFoods.Height = 336;
            this.pnFoods.Location = new System.Drawing.Point(0, 21);
            this.pnFoods.Name = "pnFoods";
            this.pnFoods.Size = new System.Drawing.Size(484, 308);
            this.pnFoods.SizeRatio = 50.075D;
            this.pnFoods.TabIndex = 0;
            this.pnFoods.Text = "Foods";
            // 
            // pnDrink
            // 
            this.pnDrink.Height = 335;
            this.pnDrink.Location = new System.Drawing.Point(0, 361);
            this.pnDrink.Name = "pnDrink";
            this.pnDrink.Size = new System.Drawing.Size(484, 314);
            this.pnDrink.TabIndex = 1;
            this.pnDrink.Text = "Drink";
            // 
            // pnSpecItem
            // 
            this.pnSpecItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnSpecItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnSpecItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnSpecItem.Location = new System.Drawing.Point(0, 0);
            this.pnSpecItem.Name = "pnSpecItem";
            this.pnSpecItem.Size = new System.Drawing.Size(986, 93);
            this.pnSpecItem.TabIndex = 1;
            this.theme1.SetTheme(this.pnSpecItem, "(default)");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.spSpecialTopping);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel2.Location = new System.Drawing.Point(0, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(986, 603);
            this.panel2.TabIndex = 2;
            this.theme1.SetTheme(this.panel2, "(default)");
            // 
            // spSpecialTopping
            // 
            this.spSpecialTopping.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.spSpecialTopping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.spSpecialTopping.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.spSpecialTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spSpecialTopping.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spSpecialTopping.HeaderLineWidth = 1;
            this.spSpecialTopping.Location = new System.Drawing.Point(0, 0);
            this.spSpecialTopping.Name = "spSpecialTopping";
            this.spSpecialTopping.Panels.Add(this.pnSpecial);
            this.spSpecialTopping.Panels.Add(this.pnToping);
            this.spSpecialTopping.Size = new System.Drawing.Size(986, 603);
            this.spSpecialTopping.SplitterMovingColor = System.Drawing.Color.Black;
            this.spSpecialTopping.TabIndex = 0;
            this.theme1.SetTheme(this.spSpecialTopping, "(default)");
            // 
            // pnSpecial
            // 
            this.pnSpecial.Height = 300;
            this.pnSpecial.Location = new System.Drawing.Point(0, 21);
            this.pnSpecial.Name = "pnSpecial";
            this.pnSpecial.Size = new System.Drawing.Size(986, 279);
            this.pnSpecial.SizeRatio = 50.083D;
            this.pnSpecial.TabIndex = 0;
            this.pnSpecial.Text = "Special Item";
            // 
            // pnToping
            // 
            this.pnToping.Height = 299;
            this.pnToping.Location = new System.Drawing.Point(0, 325);
            this.pnToping.Name = "pnToping";
            this.pnToping.Size = new System.Drawing.Size(986, 278);
            this.pnToping.TabIndex = 1;
            this.pnToping.Text = "Topping Item";
            // 
            // spCheck
            // 
            this.spCheck.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.spCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.spCheck.CollapsingCueColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.spCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.spCheck.HeaderLineWidth = 1;
            this.spCheck.Location = new System.Drawing.Point(0, 0);
            this.spCheck.Name = "spCheck";
            this.spCheck.Panels.Add(this.c1SplitterPanel1);
            this.spCheck.Panels.Add(this.c1SplitterPanel2);
            this.spCheck.Size = new System.Drawing.Size(986, 696);
            this.spCheck.SplitterMovingColor = System.Drawing.Color.Black;
            this.spCheck.TabIndex = 1;
            this.theme1.SetTheme(this.spCheck, "(default)");
            // 
            // c1SplitterPanel1
            // 
            this.c1SplitterPanel1.Collapsible = true;
            this.c1SplitterPanel1.Controls.Add(this.c1DockingTab2);
            this.c1SplitterPanel1.Dock = C1.Win.C1SplitContainer.PanelDockStyle.Left;
            this.c1SplitterPanel1.Location = new System.Drawing.Point(0, 21);
            this.c1SplitterPanel1.Name = "c1SplitterPanel1";
            this.c1SplitterPanel1.Size = new System.Drawing.Size(484, 675);
            this.c1SplitterPanel1.TabIndex = 0;
            this.c1SplitterPanel1.Text = "Panel 1";
            this.c1SplitterPanel1.Width = 484;
            // 
            // c1SplitterPanel2
            // 
            this.c1SplitterPanel2.Height = 696;
            this.c1SplitterPanel2.Location = new System.Drawing.Point(495, 21);
            this.c1SplitterPanel2.Name = "c1SplitterPanel2";
            this.c1SplitterPanel2.Size = new System.Drawing.Size(491, 675);
            this.c1SplitterPanel2.TabIndex = 1;
            this.c1SplitterPanel2.Text = "Panel 2";
            // 
            // c1DockingTab2
            // 
            this.c1DockingTab2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.c1DockingTab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c1DockingTab2.Controls.Add(this.tabBill);
            this.c1DockingTab2.Controls.Add(this.tabCommand);
            this.c1DockingTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1DockingTab2.HotTrack = true;
            this.c1DockingTab2.Location = new System.Drawing.Point(0, 0);
            this.c1DockingTab2.Name = "c1DockingTab2";
            this.c1DockingTab2.Size = new System.Drawing.Size(484, 675);
            this.c1DockingTab2.TabIndex = 0;
            this.c1DockingTab2.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit;
            this.c1DockingTab2.TabsShowFocusCues = false;
            this.c1DockingTab2.TabsSpacing = 2;
            this.c1DockingTab2.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007;
            this.theme1.SetTheme(this.c1DockingTab2, "(default)");
            // 
            // tabBill
            // 
            this.tabBill.Location = new System.Drawing.Point(1, 24);
            this.tabBill.Name = "tabBill";
            this.tabBill.Size = new System.Drawing.Size(482, 650);
            this.tabBill.TabIndex = 0;
            this.tabBill.Text = "Bill";
            // 
            // tabCommand
            // 
            this.tabCommand.Location = new System.Drawing.Point(1, 24);
            this.tabCommand.Name = "tabCommand";
            this.tabCommand.Size = new System.Drawing.Size(482, 650);
            this.tabCommand.TabIndex = 1;
            this.tabCommand.Text = "Command";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtFooId);
            this.panel1.Controls.Add(this.txtRow);
            this.panel1.Controls.Add(this.txtTableCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 40);
            this.panel1.TabIndex = 0;
            this.theme1.SetTheme(this.panel1, "(default)");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.btnVoidAll);
            this.panel3.Controls.Add(this.btnTopping);
            this.panel3.Controls.Add(this.lbFooName);
            this.panel3.Controls.Add(this.btnSpec);
            this.panel3.Controls.Add(this.btnVoid);
            this.panel3.Controls.Add(this.btnPay);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel3.Location = new System.Drawing.Point(0, 527);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 148);
            this.panel3.TabIndex = 1;
            this.theme1.SetTheme(this.panel3, "(default)");
            // 
            // pnBill
            // 
            this.pnBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.pnBill.Location = new System.Drawing.Point(0, 40);
            this.pnBill.Name = "pnBill";
            this.pnBill.Size = new System.Drawing.Size(491, 487);
            this.pnBill.TabIndex = 2;
            this.theme1.SetTheme(this.pnBill, "(default)");
            // 
            // btnVoidAll
            // 
            this.btnVoidAll.BackColor = System.Drawing.Color.Transparent;
            this.btnVoidAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.btnVoidAll.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(71)))), ((int)(((byte)(47)))));
            this.btnVoidAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnVoidAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(189)))), ((int)(((byte)(182)))));
            this.btnVoidAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btnVoidAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoidAll.Location = new System.Drawing.Point(372, 31);
            this.btnVoidAll.Name = "btnVoidAll";
            this.btnVoidAll.Size = new System.Drawing.Size(65, 41);
            this.btnVoidAll.TabIndex = 247;
            this.btnVoidAll.Text = "cancel all";
            this.btnVoidAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoidAll, "(default)");
            this.btnVoidAll.UseVisualStyleBackColor = true;
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
            this.btnTopping.Location = new System.Drawing.Point(337, 78);
            this.btnTopping.Name = "btnTopping";
            this.btnTopping.Size = new System.Drawing.Size(100, 64);
            this.btnTopping.TabIndex = 246;
            this.btnTopping.Text = "topping";
            this.btnTopping.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnTopping, "(default)");
            this.btnTopping.UseVisualStyleBackColor = true;
            // 
            // lbFooName
            // 
            this.lbFooName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbFooName.Location = new System.Drawing.Point(7, 7);
            this.lbFooName.Name = "lbFooName";
            this.lbFooName.Size = new System.Drawing.Size(481, 65);
            this.lbFooName.TabIndex = 245;
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
            this.btnSpec.Location = new System.Drawing.Point(227, 78);
            this.btnSpec.Name = "btnSpec";
            this.btnSpec.Size = new System.Drawing.Size(100, 64);
            this.btnSpec.TabIndex = 244;
            this.btnSpec.Text = "special";
            this.btnSpec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnSpec, "(default)");
            this.btnSpec.UseVisualStyleBackColor = true;
            // 
            // btnVoid
            // 
            this.btnVoid.BackColor = System.Drawing.Color.Transparent;
            this.btnVoid.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnVoid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnVoid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoid.Location = new System.Drawing.Point(117, 78);
            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Size = new System.Drawing.Size(100, 64);
            this.btnVoid.TabIndex = 243;
            this.btnVoid.Text = "cancel";
            this.btnVoid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnVoid, "(default)");
            this.btnVoid.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.Transparent;
            this.btnPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(241)))), ((int)(((byte)(171)))));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(7, 78);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(100, 64);
            this.btnPay.TabIndex = 242;
            this.btnPay.Text = "bill";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.theme1.SetTheme(this.btnPay, "(default)");
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // txtTableCode
            // 
            this.txtTableCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableCode.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtTableCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTableCode.Location = new System.Drawing.Point(7, 3);
            this.txtTableCode.Name = "txtTableCode";
            this.txtTableCode.Size = new System.Drawing.Size(22, 20);
            this.txtTableCode.TabIndex = 237;
            this.txtTableCode.Tag = null;
            this.theme1.SetTheme(this.txtTableCode, "(default)");
            this.txtTableCode.Visible = false;
            this.txtTableCode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // txtFooId
            // 
            this.txtFooId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFooId.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(152)))), ((int)(((byte)(152)))));
            this.txtFooId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFooId.Location = new System.Drawing.Point(63, 3);
            this.txtFooId.Name = "txtFooId";
            this.txtFooId.Size = new System.Drawing.Size(22, 20);
            this.txtFooId.TabIndex = 242;
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
            this.txtRow.Location = new System.Drawing.Point(35, 3);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(22, 20);
            this.txtRow.TabIndex = 241;
            this.txtRow.Tag = null;
            this.theme1.SetTheme(this.txtRow, "(default)");
            this.txtRow.Visible = false;
            this.txtRow.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // FrmTakeOut1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 721);
            this.Controls.Add(this.tabMain);
            this.Name = "FrmTakeOut1";
            this.Text = "FrmTakeOut1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTakeOut1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.theme1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabOrer.ResumeLayout(false);
            this.tabSpecTopping.ResumeLayout(false);
            this.tabCheck.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spMain)).EndInit();
            this.spMain.ResumeLayout(false);
            this.pnItem.ResumeLayout(false);
            this.pnOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spItem)).EndInit();
            this.spItem.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spSpecialTopping)).EndInit();
            this.spSpecialTopping.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spCheck)).EndInit();
            this.spCheck.ResumeLayout(false);
            this.c1SplitterPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1DockingTab2)).EndInit();
            this.c1DockingTab2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTableCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFooId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1Themes.C1ThemeController theme1;
        private C1.Win.C1Command.C1DockingTab tabMain;
        private C1.Win.C1Command.C1DockingTabPage tabOrer;
        private C1.Win.C1Command.C1DockingTabPage tabSpecTopping;
        private C1.Win.C1Command.C1DockingTabPage tabCheck;
        private C1.Win.C1SplitContainer.C1SplitContainer spMain;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnItem;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnOrder;
        private C1.Win.C1SplitContainer.C1SplitContainer spItem;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnFoods;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnDrink;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnSpecItem;
        private C1.Win.C1SplitContainer.C1SplitContainer spSpecialTopping;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnSpecial;
        private C1.Win.C1SplitContainer.C1SplitterPanel pnToping;
        private C1.Win.C1SplitContainer.C1SplitContainer spCheck;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel1;
        private C1.Win.C1SplitContainer.C1SplitterPanel c1SplitterPanel2;
        private C1.Win.C1Command.C1DockingTab c1DockingTab2;
        private C1.Win.C1Command.C1DockingTabPage tabBill;
        private C1.Win.C1Command.C1DockingTabPage tabCommand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnBill;
        private System.Windows.Forms.Button btnVoidAll;
        private System.Windows.Forms.Button btnTopping;
        private C1.Win.C1SuperTooltip.C1SuperLabel lbFooName;
        private System.Windows.Forms.Button btnSpec;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnPay;
        private C1.Win.C1Input.C1TextBox txtTableCode;
        private C1.Win.C1Input.C1TextBox txtFooId;
        private C1.Win.C1Input.C1TextBox txtRow;
    }
}