using modernpos_pos.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmConfig : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        public FrmConfig(mPOSControl mposC)
        {
            InitializeComponent();
            this.mposC = mposC;
            initConfig();
        }
        private void initConfig()
        {
            btmStf.Click += BtmStf_Click;
            btnDept.Click += BtnDept_Click;
            btnPosi.Click += BtnPosi_Click;
            btnRes.Click += BtnRes_Click;
            btnTable.Click += BtnTable_Click;
            btnArea.Click += BtnArea_Click;
            btnRes.Click += BtnRes_Click1;
            btnFoodsType.Click += BtnFoodsType_Click;
            btnFoodsCategory.Click += BtnFoodsCategory_Click;
            btnFoods.Click += BtnFoods_Click;
            btnFoodsCatSub.Click += BtnFoodsCatSub_Click;
        }

        private void BtnFoodsCatSub_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsCatSub frm = new FrmCFoodsCatSub(mposC);
            frm.Show(this);
        }

        private void BtnFoods_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoods frm = new FrmCFoods(mposC);
            frm.Show(this);
        }

        private void BtnFoodsCategory_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsCat frm = new FrmCFoodsCat(mposC);
            frm.Show(this);
        }

        private void BtnFoodsType_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsType frm = new FrmCFoodsType(mposC);
            frm.Show(this);
        }

        private void BtnRes_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCRestaurant frm = new FrmCRestaurant(mposC);
            frm.Show(this);
        }

        private void BtnArea_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCArea frm = new FrmCArea(mposC);
            frm.Show(this);
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsCatSub frm = new FrmCFoodsCatSub(mposC);
            frm.Show(this);
        }

        private void BtnRes_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnPosi_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPosition frm = new FrmPosition(mposC);
            frm.Show(this);
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDepartment1 frm = new FrmDepartment1(mposC);
            frm.Show(this);
        }

        private void BtmStf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStaff frm = new FrmStaff(mposC);
            frm.Show(this);
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
