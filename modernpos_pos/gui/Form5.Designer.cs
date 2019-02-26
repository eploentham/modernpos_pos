namespace modernpos_pos.gui
{
    partial class Form5
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
            C1.Win.C1Tile.PanelElement panelElement1 = new C1.Win.C1Tile.PanelElement();
            C1.Win.C1Tile.ImageElement imageElement1 = new C1.Win.C1Tile.ImageElement();
            C1.Win.C1Tile.TextElement textElement1 = new C1.Win.C1Tile.TextElement();
            this.c1TileControl1 = new C1.Win.C1Tile.C1TileControl();
            this.group1 = new C1.Win.C1Tile.Group();
            this.tile1 = new C1.Win.C1Tile.Tile();
            this.tile2 = new C1.Win.C1Tile.Tile();
            this.tile3 = new C1.Win.C1Tile.Tile();
            this.SuspendLayout();
            // 
            // c1TileControl1
            // 
            this.c1TileControl1.AllowChecking = true;
            // 
            // 
            // 
            panelElement1.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            panelElement1.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.c1TileControl1.DefaultTemplate.Elements.Add(panelElement1);
            this.c1TileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1TileControl1.Groups.Add(this.group1);
            this.c1TileControl1.Location = new System.Drawing.Point(0, 0);
            this.c1TileControl1.Name = "c1TileControl1";
            this.c1TileControl1.Size = new System.Drawing.Size(1129, 705);
            this.c1TileControl1.TabIndex = 0;
            this.c1TileControl1.Text = "c1TileControl1";
            // 
            // group1
            // 
            this.group1.Name = "group1";
            this.group1.Text = "Group 1";
            this.group1.Tiles.Add(this.tile1);
            this.group1.Tiles.Add(this.tile2);
            this.group1.Tiles.Add(this.tile3);
            // 
            // tile1
            // 
            this.tile1.BackColor = System.Drawing.Color.LightCoral;
            this.tile1.Name = "tile1";
            this.tile1.Text = "Tile 1111";
            // 
            // tile2
            // 
            this.tile2.BackColor = System.Drawing.Color.Teal;
            this.tile2.Name = "tile2";
            this.tile2.Text = "Tile 2";
            // 
            // tile3
            // 
            this.tile3.BackColor = System.Drawing.Color.SteelBlue;
            this.tile3.Name = "tile3";
            this.tile3.Text = "Tile 3";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 705);
            this.Controls.Add(this.c1TileControl1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Tile.C1TileControl c1TileControl1;
        private C1.Win.C1Tile.Group group1;
        private C1.Win.C1Tile.Tile tile1;
        private C1.Win.C1Tile.Tile tile2;
        private C1.Win.C1Tile.Tile tile3;
    }
}