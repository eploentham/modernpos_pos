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
        List<OrderTopping> lordt;
        List<OrderSpecial> lords;
        TableLayoutPanel tpl;
        int cnt = 0;
        Order1 ord;
        FrmTakeOut4 frmtakeout4;
        public ucOrderTakeOut1(mPOSControl x, String row, String fooid, String qty,ref Order1 ord, ref List<OrderSpecial> lords, ref List<OrderTopping> lordt, FrmTakeOut4 frmtakeout4)
        {
            InitializeComponent();
            mposC = x;
            //fooName = foodsname;
            this.qty = qty;
            //this.price = price;
            this.row = row;
            this.fooid = fooid;
            this.ord = ord;
            this.frmtakeout4 = frmtakeout4;
            this.lordt = lordt;
            this.lords = lords;
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
            sizeNormal = this.Size;
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
            setBill();
        }

        private void PicDesc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (flagExplan)
            {
                //int heisum = 0;
                //for (int i = 0; i < tpl.RowCount - 1; i++)
                //{
                //    Panel pn = new Panel();
                //    pn = (Panel)tpl.Controls["pnCri" + i];
                //    heisum += pn.Height;
                //}

                //Size size1 = new Size();
                //size1 = sizeNormal;
                //size1.Height = sizeNormal.Height + heisum + (tpl.RowCount * 5);
                ////sizeNormal = size1;
                this.Height = sizeNormal.Height;
                flagExplan = false;
            }
            else
            {
                int heisum = 0;
                Size size1 = new Size();
                size1 = sizeNormal;
                for(int i = 0; i < tpl.RowCount-1; i++)
                {
                    Panel pn = new Panel();
                    pn = (Panel)tpl.Controls["pnCri" + i];
                    heisum += pn.Height;
                }

                size1.Height = sizeNormal.Height - heisum - (tpl.RowCount * 5);
                //sizeNormal = size1;
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
            setPrice();
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
            setPrice();
        }
        private void setControl()
        {
            lfoot = new List<FoodsTopping>();
            foo = mposC.mposDB.fooDB.getList(fooid);
            lfoot = mposC.mposDB.footpDB.getlFooSpecByFooId(foo.foods_id);
            int i2 = 0;
            foreach(FoodsTopping foot in lfoot)
            {
                //lbFoot1.Value = foot.foods_topping_name+" "+foot.price;
                initTopping(foot.foods_topping_name + " " + foot.price, foot.price, mposC.lcolorTopping[cnt], foot.foods_topping_id);
                OrderTopping ordt = new OrderTopping();
                ordt.order_topping_id = "";
                ordt.order_id = "";
                ordt.foods_topping_id = foot.foods_topping_id;
                ordt.active = "1";
                ordt.remark = "";
                ordt.row1 = i2.ToString();
                ordt.date_cancel = "";
                ordt.date_create = "";
                ordt.date_modi = "";
                ordt.user_cancel = "";
                ordt.user_create = "";
                ordt.user_modi = "";
                ordt.host_id = "";
                ordt.branch_id = "";
                ordt.device_id = "";
                ordt.qty = "";
                ordt.price = foot.price;
                ordt.name = foot.foods_topping_name;
                ordt.foods_id = foot.foods_id;
                ordt.status_ok = "";
                lordt.Add(ordt);
                cnt++;
                i2++;
            }
            lfoos = new List<FoodsSpecial>();
            lfoos = mposC.mposDB.foosDB.getlFooSpecByFooId(foo.foods_id);
            int i1 = 0;
            foreach (FoodsSpecial foot in lfoos)
            {
                //lbFoot1.Value = foot.foods_topping_name+" "+foot.price;
                initSpecial(foot.foods_spec_name, mposC.lcolorSpec[i1], foot.foods_spec_id);
                OrderSpecial ords = new OrderSpecial();
                ords.order_special_id = "";
                ords.order_id = "";
                ords.foods_spec_id = foot.foods_spec_id;
                ords.active = "1";
                ords.remark = "";
                ords.row1 = i1.ToString();
                ords.date_cancel = "";
                ords.date_create = "";
                ords.date_modi = "";
                ords.user_cancel = "";
                ords.user_create = "";
                ords.user_modi = "";
                ords.host_id = "";
                ords.branch_id = "";
                ords.device_id = "";
                ords.name = foot.foods_spec_name;
                ords.foods_id = foot.foods_id;
                ords.status_ok = "";
                lords.Add(ords);
                i1++;
                cnt++;
            }

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
            this.Height = phHead.Height + hei + (cnt*5)+3;
            sizeNormal = this.Size;
        }
        private void setPrice()
        {
            decimal sum = 0, fooprice=0, fooqty=0, foosum=0;
            if(decimal.TryParse(foo.foods_price, out fooprice))
            {
                if (decimal.TryParse(lbQty.Text, out fooqty))
                {
            //        foosum = fooprice * fooqty;
                }
            }
            for (int i = 0; i < lfoot.Count; i++)
            {
                decimal price = 0;
                int qty = 0;
                String name = "", cnt = "";
                Panel pn = (Panel)tpl.Controls["pnCri" + i];
                C1Label lbQtyTopping = new C1Label();
                C1Label lbPriceTopping = new C1Label();
                cnt = pn.Name.Replace("pnCri", "");
                lbQtyTopping = (C1Label)pn.Controls["lbQtyTopping" + cnt];
                lbPriceTopping = (C1Label)pn.Controls["lbPriceTopping" + cnt];
                if (int.TryParse(lbQtyTopping.Text, out qty))
                {
                    if(decimal.TryParse(lbPriceTopping.Text, out price))
                    {
                        sum += (price * qty);
                    }
                }
                
            }
            foosum = (fooprice + sum) * fooqty;
            //sum = foosum + sum;
            lbPrice.Value = foosum.ToString("#,###.00");
            ord.sumPrice = lbPrice.Text;
            //ord.toppingPrice = 
            setBill();
        }
        private void setBill()
        {
            frmtakeout4.calBill();
        }
        private void initSpecial(String name, Color cor, String ordspecialid)
        {
            Panel pnCri1 = new Panel();
            C1PictureBox picSelect = new C1PictureBox();
            C1Label lbFoot1 = new C1Label();
            C1Label lbFoot2 = new C1Label();
            C1Label lbID = new C1Label();

            pnCri1.BackColor = Color.FromArgb(255, 209, 81);
            pnCri1.Dock = System.Windows.Forms.DockStyle.Top;
            //pnCri1.Location = new System.Drawing.Point(0, 85);
            pnCri1.Size = new System.Drawing.Size(390, 47);
            pnCri1.Name = "pnCri" + cnt;
            pnCri1.BorderStyle = BorderStyle.FixedSingle;
            pnCri1.BackColor = cor;
            pnCri1.Click += PicSpecSelect_Click;
            picSelect.Image = global::modernpos_pos.Properties.Resources.circle_png_circle_icon_1600;
            picSelect.Location = new System.Drawing.Point(4, 8);
            picSelect.Name = "picSelect" + cnt;
            picSelect.Size = new System.Drawing.Size(32, 32);
            picSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picSelect.TabStop = false;
            picSelect.Click += PicSpecSelect_Click;
            lbFoot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(81)))));
            lbFoot1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbFoot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbFoot1.Location = new System.Drawing.Point(40, 8);
            lbFoot1.Name = "lbFoot1" + cnt;
            lbFoot1.Size = new System.Drawing.Size(232, 31);
            lbFoot1.TabIndex = 6;
            lbFoot1.Tag = null;
            lbFoot1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lbFoot1.Value = name;
            lbFoot1.BackColor = cor;
            lbFoot1.Click += PicSpecSelect_Click;
            lbFoot2.Name = "lbFoot12" + cnt;
            lbFoot2.Visible = false;
            lbID.Visible = false;
            lbID.Value = ordspecialid;
            lbID.Name = "lbOrdSpecID" + cnt;

            pnCri1.Controls.Add(picSelect);
            pnCri1.Controls.Add(lbFoot1);
            pnCri1.Controls.Add(lbFoot2);
            pnCri1.Controls.Add(lbID);
            tpl.Controls.Add(pnCri1, 0, tpl.RowCount++);
        }

        private void PicSpecSelect_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String name = "", cnt="";
            C1Label lbFoot1 = new C1Label();
            C1Label lbFoot12 = new C1Label();
            C1Label lbID = new C1Label();
            C1PictureBox picSelect = new C1PictureBox();
            if (sender is C1Label)
            {
                lbFoot1 = (C1Label)sender;
                cnt = lbFoot1.Name.Replace("lbFoot1", "");
                Panel pn = new Panel();
                pn = (Panel)tpl.Controls["pnCri" + cnt];
                picSelect = (C1PictureBox)pn.Controls["picSelect" + cnt];
                lbFoot12 = (C1Label)pn.Controls["lbFoot12" + cnt];
                lbID = (C1Label)pn.Controls["lbOrdSpecID" + cnt];
            }
            else if (sender is C1PictureBox)
            {
                picSelect = (C1PictureBox)sender;
                cnt = picSelect.Name.Replace("picSelect", "");
                lbFoot1 = new C1Label();
                Panel pn = new Panel();
                pn = (Panel)tpl.Controls["pnCri" + cnt];
                lbFoot12 = (C1Label)pn.Controls["lbFoot12" + cnt];
                lbID = (C1Label)pn.Controls["lbOrdSpecID" + cnt];
            }
            else if(sender is Panel)
            {
                Panel pn = (Panel)sender;
                cnt = pn.Name.Replace("pnCri", "");
                lbFoot1 = new C1Label();
                lbFoot1 = (C1Label)pn.Controls["lbFoot1" + cnt];
                lbFoot12 = (C1Label)pn.Controls["lbFoot12" + cnt];
                picSelect = (C1PictureBox)pn.Controls["picSelect" + cnt];
                lbID = (C1Label)pn.Controls["lbOrdSpecID" + cnt];
            }
            if (lbFoot12.Text.Equals("NO"))
            {
                picSelect.Image = global::modernpos_pos.Properties.Resources.images;
                //ord.foods_name = ord.foods_name + " 11111111";
                lbFoot12.Value = "YES";
                foreach(OrderSpecial ords in lords)
                {
                    if (ords.foods_spec_id.Equals(lbID.Text))
                    {
                        ords.status_ok = "1";
                        break;
                    }
                }
            }
            else if (lbFoot12.Text.Equals("YES"))
            {
                picSelect.Image = global::modernpos_pos.Properties.Resources.circle_png_circle_icon_1600;
                //ord.foods_name = "";
                lbFoot12.Value = "NO";
                foreach (OrderSpecial ords in lords)
                {
                    if (ords.foods_spec_id.Equals(lbID.Text))
                    {
                        ords.status_ok = "0";
                        break;
                    }
                }
            }
            else
            {
                picSelect.Image = global::modernpos_pos.Properties.Resources.images;
                lbFoot12.Value = "YES";
                foreach (OrderSpecial ords in lords)
                {
                    if (ords.foods_spec_id.Equals(lbID.Text))
                    {
                        ords.status_ok = "1";
                        break;
                    }
                }
            }
        }

        private void initTopping(String name, String price, Color cor,String footoppingid)
        {
            Panel pnCri1 = new Panel();
            C1PictureBox picTrah = new C1PictureBox();
            C1PictureBox picMinus = new C1PictureBox();
            C1Label lbQty = new C1Label();
            C1PictureBox picPlus = new C1PictureBox();
            C1Label lbFoot1 = new C1Label();
            C1Label lbPrice = new C1Label();
            C1Label lbID = new C1Label();
            //pnCri1.BackColor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsBackColor);
            pnCri1.BackColor = Color.FromArgb(255, 209, 81);
            pnCri1.Dock = System.Windows.Forms.DockStyle.Top;
            //pnCri1.Location = new System.Drawing.Point(0, 85);
            pnCri1.Size = new System.Drawing.Size(390, 47);
            pnCri1.Name = "pnCri"+cnt;
            pnCri1.BorderStyle = BorderStyle.FixedSingle;
            pnCri1.BackColor = cor;

            picTrah.Image = global::modernpos_pos.Properties.Resources.Trashcan;
            picTrah.Location = new System.Drawing.Point(360, 8);
            picTrah.Name = "picTrahTopping" + cnt;
            picTrah.Size = new System.Drawing.Size(32, 32);
            picTrah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picTrah.TabStop = false;
            picMinus.Image = global::modernpos_pos.Properties.Resources.minus_red;
            picMinus.Location = new System.Drawing.Point(241, 8);
            picMinus.Name = "picMinusTopping" + cnt;
            picMinus.Size = new System.Drawing.Size(32, 32);
            picMinus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picMinus.TabIndex = 10;
            picMinus.TabStop = false;
            lbQty.BackColor = System.Drawing.SystemColors.MenuHighlight;
            lbQty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbQty.Location = new System.Drawing.Point(276, 8);
            lbQty.Name = "lbQtyTopping" + cnt;
            lbQty.Size = new System.Drawing.Size(49, 32);
            lbQty.TabIndex = 12;
            lbQty.Tag = null;
            lbQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            picPlus.Image = global::modernpos_pos.Properties.Resources.plus_green_100;
            picPlus.Location = new System.Drawing.Point(327, 8);
            picPlus.Name = "picPlusTopping" + cnt;
            picPlus.Size = new System.Drawing.Size(32, 32);
            picPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picPlus.TabIndex = 11;
            picPlus.TabStop = false;
            lbFoot1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(209)))), ((int)(((byte)(81)))));
            lbFoot1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lbFoot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbFoot1.Location = new System.Drawing.Point(4, 8);
            lbFoot1.Name = "lbFootTopping" + cnt;
            lbFoot1.Size = new System.Drawing.Size(232, 31);
            lbFoot1.TabIndex = 6;
            lbFoot1.Tag = null;
            lbFoot1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lbFoot1.Value = name;
            lbFoot1.BackColor = cor;
            picMinus.Click += PicMinusTopping_Click1;
            picPlus.Click += PicPlusTopping_Click1;
            picTrah.Click += PicTrahTopping_Click;
            lbPrice.Name = "lbPriceTopping" + cnt;
            lbPrice.Visible = false;
            lbPrice.Value = price;
            lbID.Value = footoppingid;
            lbID.Visible = false;
            lbID.Name = "lbOrdTopping" + cnt;

            pnCri1.Controls.Add(picTrah);
            pnCri1.Controls.Add(picMinus);
            pnCri1.Controls.Add(lbQty);
            pnCri1.Controls.Add(picPlus);
            pnCri1.Controls.Add(lbFoot1);
            pnCri1.Controls.Add(lbPrice);
            pnCri1.Controls.Add(lbID);
            //Padding padding = pnCri1.Padding;
            tpl.Controls.Add(pnCri1, 0, tpl.RowCount++);
        }

        private void PicTrahTopping_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String name = "", cnt = "";
            Panel pn = new Panel();
            C1PictureBox pic = (C1PictureBox)sender;
            cnt = pic.Name.Replace("picTrahTopping", "");
            pn = (Panel)tpl.Controls["pnCri" + cnt];

            pn.Dispose();
            setPrice();
        }

        private void PicPlusTopping_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String name = "", cnt = "";
            Panel pn = new Panel();
            C1Label lbQtyTopping = new C1Label();
            C1Label lbID = new C1Label();
            C1PictureBox pic = (C1PictureBox)sender;
            cnt = pic.Name.Replace("picPlusTopping", "");
            pn = (Panel)tpl.Controls["pnCri" + cnt];
            lbQtyTopping = (C1Label)pn.Controls["lbQtyTopping" + cnt];
            lbID = (C1Label)pn.Controls["lbOrdTopping" + cnt];
            if (lbQtyTopping.Text.Equals("")) lbQtyTopping.Value = "0";
            int chk = 0;
            if (int.TryParse(lbQtyTopping.Text, out chk))
            {
                chk++;
                lbQtyTopping.Value = chk.ToString();
                //qty = chk.ToString();
            }
            foreach (OrderTopping ordt in lordt)
            {
                if (ordt.foods_topping_id.Equals(lbID.Text))
                {
                    ordt.status_ok = "1";
                    ordt.qty = lbQtyTopping.Text;
                    //ordt.price = "";
                    break;
                }
            }
            setPrice();
        }

        private void PicMinusTopping_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String name = "", cnt = "";
            Panel pn = new Panel();
            C1Label lbQtyTopping = new C1Label();
            C1Label lbID = new C1Label();
            C1PictureBox pic = (C1PictureBox)sender;
            cnt = pic.Name.Replace("picMinusTopping", "");
            pn = (Panel)tpl.Controls["pnCri" + cnt];
            lbQtyTopping = (C1Label)pn.Controls["lbQtyTopping" + cnt];
            lbID = (C1Label)pn.Controls["lbOrdTopping" + cnt];
            if (lbQtyTopping.Text.Equals("")) return;
            int chk = 0;
            if (int.TryParse(lbQtyTopping.Text, out chk))
            {
                chk--;
                lbQtyTopping.Value = chk.ToString();
                //qty = chk.ToString();
            }
            foreach (OrderTopping ordt in lordt)
            {
                if (ordt.foods_topping_id.Equals(lbID.Text))
                {
                    ordt.status_ok = "1";
                    ordt.qty = lbQtyTopping.Text;
                    //ordt.price = "";
                    break;
                }
            }
            setPrice();
        }
    }
}
