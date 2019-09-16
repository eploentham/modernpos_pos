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

namespace modernpos_pos.gui
{
    public partial class ucOrderTakeOut : UserControl
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
        public ucOrderTakeOut(mPOSControl x, String row, String fooid, String qty)
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

            hei1 = pnCri1.Height;
            hei2 = pnCri2.Height;
            hei3 = pnCri3.Height;
            hei4 = pnCri4.Height;
            heiselect = pnSelect.Height;

            setControl();
            PicDesc_Click(null, null);
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
                pnCri1.Show();
                pnCri2.Show();
                pnCri3.Show();
                pnCri4.Show();
                pnSelect.Show();

                Size size1 = new Size();
                size1 = sizeNormal;
                size1.Height = sizeNormal.Height + hei1 + hei2 + hei3 + hei4 + heiselect;
                sizeNormal = size1;
                this.Height = size1.Height;
                flagExplan = false;
            }
            else
            {
                pnCri1.Hide();
                pnCri2.Hide();
                pnCri3.Hide();
                pnCri4.Hide();
                pnSelect.Hide();
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
                lbFoot1.Value = foot.foods_topping_name+" "+foot.price;
            }
            lfoos = mposC.mposDB.foosDB.getlFooSpecByFooId(foo.foods_id);

            lbName.Value = foo.foods_name;
            lbQty.Value = qty;
            lbPrice.Value = foo.foods_price;
            lbRow.Value = row;
        }
    }
}
