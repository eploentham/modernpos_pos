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
        FrmMain frm;

        public FrmConfig(mPOSControl mposC, FrmMain frm)
        {
            InitializeComponent();
            this.mposC = mposC;
            this.frm = frm;
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
            btnReCom.Click += BtnReCom_Click;
            btnFooMaterial.Click += BtnFooMaterial_Click;
            btnMaterialType.Click += BtnMaterialType_Click;
            btnUnit.Click += BtnUnit_Click;
            btnMatrRec.Click += BtnRecMatr_Click;
            btnMatrDraw.Click += BtnMatrDraw_Click;
            btnStockCard.Click += BtnStockCard_Click;
            this.FormClosed += FrmConfig_FormClosed;
        }

        private void BtnStockCard_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMatrDrawView frm = new FrmMatrDrawView(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnMatrDraw_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMatrDrawView frm = new FrmMatrDrawView(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnRecMatr_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMatrRecView frm = new FrmMatrRecView(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void FrmConfig_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            frm.Show();
        }

        private void BtnUnit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmUnit frm = new FrmUnit(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnMaterialType_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMaterialType frm = new FrmMaterialType(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnFooMaterial_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmMaterial frm = new FrmMaterial(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnReCom_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnFoodsCatSub_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsCatSub frm = new FrmCFoodsCatSub(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnFoods_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoods frm = new FrmCFoods(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnFoodsCategory_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsCat frm = new FrmCFoodsCat(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnFoodsType_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCFoodsType frm = new FrmCFoodsType(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnRes_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCRestaurant frm = new FrmCRestaurant(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnArea_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCArea frm = new FrmCArea(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmCTable frm = new FrmCTable(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnRes_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void BtnPosi_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmPosition frm = new FrmPosition(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtnDept_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmDepartment1 frm = new FrmDepartment1(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.ShowDialog(this);
            this.Show();
        }

        private void BtmStf_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FrmStaff frm = new FrmStaff(mposC);
            frm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            frm.Show(this);
            this.Show();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {

        }
    }
}
