using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modernpos_pos.control;
using C1.Win.C1SuperTooltip;
using modernpos_pos.object1;
using C1.Win.C1Input;

namespace modernpos_pos.gui
{
    public partial class ucOrderTakeOut1 : UserControl
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1, fgrd, ford;

        Color bg, fc, tilecolor, tileFoodsPriceColor, tileFoodsNameColor, tileCatColor;
        Font ff, ffB;

        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        String qty="", price="" ,row="", fooid="";
        Boolean flagExplan = false;
        Size sizeNormal = new Size();
        int hei1 = 0, hei2 = 0, hei3 = 0, hei4=0, heiselect=0;
        Foods foo;
        FoodsSpecial foos;
        List<FoodsTopping> lfoot;
        List<FoodsSpecial> lfoos;
        TableLayoutPanel tpl;
        int cnt = 0;
        public ucOrderTakeOut1(mPOSControl x, String row, String fooid, String qty)
        {
            InitializeComponent();
            mposC = x;
            //fooName = foodsname;
            this.qty = qty;
            this.price = price;
            this.row = row;
            this.fooid = fooid;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);
            fgrd = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 15, FontStyle.Regular);
            ford = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);

            picPlus.Click += PicPlus_Click;
            picMinus.Click += PicMinus_Click;
            picDesc.Click += PicDesc_Click;
            picDel.Click += PicDel_Click;

            flagExplan = false;
            sizeNormal = this.Size;
            foo = new Foods();
            foos = new FoodsSpecial();
            tpl = new TableLayoutPanel();
            initTlp();

            setControl();
            //PicDesc_Click(null, null);
        }
        private void initTlp()
        {
            tpl = new TableLayoutPanel();
            tpl.ColumnCount = 1;
            //ColumnStyle cols = new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize);
            //SizeType padd = cols.SizeType;
            
            tpl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            //tplOrd.Location = new System.Drawing.Point(0, 0);
            tpl.Name = "tplOrder";
            tpl.RowCount = 1;
            //tplOrd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 50F));
            //tplOrd.RowStyles.Insert(2, new RowStyle(SizeType.Percent));
            tpl.TabIndex = 0;
            tpl.Dock = DockStyle.Fill;
            //tpl.AutoScroll = true;
            tpl.AutoScroll = false;
            
            panel1.Controls.Add(tpl);
        }
        private void PicDel_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Dispose();
        }

        private void PicDesc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagExplan)
            {
                Size size1 = new Size();
                size1 = sizeNormal;
                size1.Height = sizeNormal.Height + hei1 + hei2 + hei3 + hei4 + heiselect;
                sizeNormal = size1;
                this.Height = size1.Height;
                flagExplan = false;
            }
            else
            {
                Size size1 = new Size();
                size1 = sizeNormal;
                size1.Height = sizeNormal.Height - hei1 - hei2 - hei3 - hei4 - heiselect;
                sizeNormal = size1;
                this.Height = size1.Height;
                flagExplan = true;
            }
        }

        private void PicMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int chk = 0;
            if (int.TryParse(qty, out chk))
            {
                chk--;
                lbQty.Value = chk.ToString();
                qty = chk.ToString();
            }
        }

        private void PicPlus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int chk = 0;
            if (int.TryParse(qty, out chk))
            {
                chk++;
                lbQty.Value = chk.ToString();
                qty = chk.ToString();
            }
        }

        private void setControl()
        {
            lfoot = new List<FoodsTopping>();
            foo = mposC.mposDB.fooDB.getList(fooid);
            lfoot = mposC.mposDB.footpDB.getlFooSpecByFooId(foo.foods_id);
            foreach(FoodsTopping foot in lfoot)
            {
                //lbFoot1.Value = foot.foods_topping_name+" "+foot.price;
                initTopping(foot.foods_topping_name + " " + foot.price);
                cnt++;
            }
            lfoos = mposC.mposDB.foosDB.getlFooSpecByFooId(foo.foods_id);

            lbName.Value = foo.foods_name;
            lbQty.Value = qty;
            lbPrice.Value = foo.foods_price;
            lbRow.Value = row;

            int hei = 0;
            for(int i = 0; i < cnt; i++)
            {
                String ctl = "";
                ctl = "pnCri"+i;
                Control ctn = tpl.Controls[ctl];
                hei += ctn.Height;
            }
            //Padding padding = this.Padding;
            this.Height = phHead.Height + hei;
        }
        private void initTopping(String name)
        {
            Panel pnCri1 = new Panel();
            C1PictureBox picTrah = new C1PictureBox();
            C1PictureBox picMinus = new C1PictureBox();
            C1Label lbQty = new C1Label();
            C1PictureBox picPlus = new C1PictureBox();
            C1Label lbFoot1 = new C1Label();
            //pnCri1.BackColor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsBackColor);
            pnCri1.BackColor = Color.FromArgb(255, 209, 81);
            pnCri1.Dock = System.Windows.Forms.DockStyle.Top;
            //pnCri1.Location = new System.Drawing.Point(0, 85);
            pnCri1.Size = new System.Drawing.Size(390, 47);
            pnCri1.Name = "pnCri"+cnt;
            pnCri1.BorderStyle = BorderStyle.FixedSingle;


            picTrah.Image = global::modernpos_pos.Properties.Resources.Trashcan;
            picTrah.Location = new System.Drawing.Point(360, 8);
            picTrah.Name = "picTrah";
            picTrah.Size = new System.Drawing.Size(32, 32);
            picTrah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picTrah.TabStop = false;
            picMinus.Image = global::modernpos_pos.Properties.Resources.minus_red;
            picMinus.Location = new System.Drawing.Point(241, 8);
            picMinus.Name = "picMinus";
            picMinus.Size = new System.Drawing.Size(32, 32);
            picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picMinus.TabIndex = 10;
            picMinus.TabStop = false;
            lbQty.BackColor = System.Drawing.SystemColors.MenuHighlight;
            lbQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbQty.Location = new System.Drawing.Point(276, 8);
            lbQty.Name = "c1Label2";
            lbQty.Size = new System.Drawing.Size(49, 32);
            lbQty.TabIndex = 12;
            lbQty.Tag = null;
            lbQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            picPlus.Image = global::modernpos_pos.Properties.Resources.plus_green_100;
            picPlus.Location = new System.Drawing.Point(327, 8);
            picPlus.Name = "c1PictureBox2";
            picPlus.Size = new System.Drawing.Size(32, 32);
            picPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picPlus.TabIndex = 11;
            picPlus.TabStop = false;
            lbFoot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(81)))));
            lbFoot1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbFoot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbFoot1.Location = new System.Drawing.Point(4, 8);
            lbFoot1.Name = "lbFoot1";
            lbFoot1.Size = new System.Drawing.Size(232, 31);
            lbFoot1.TabIndex = 6;
            lbFoot1.Tag = null;
            lbFoot1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lbFoot1.Value = name;

            pnCri1.Controls.Add(picTrah);
            pnCri1.Controls.Add(picMinus);
            pnCri1.Controls.Add(lbQty);
            pnCri1.Controls.Add(picPlus);

            //Padding padding = pnCri1.Padding;
            tpl.Controls.Add(pnCri1, 0, tpl.RowCount++);
        }
    }
}
