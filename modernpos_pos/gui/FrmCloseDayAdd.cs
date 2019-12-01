using modernpos_pos.control;
using modernpos_pos.object1;
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
    public partial class FrmCloseDayAdd : Form
    {
        mPOSControl mposC;
        Form frmmain;
        String cldid = "";
        public FrmCloseDayAdd(mPOSControl x, Form frmmain, String cldid)
        {
            InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            this.cldid = cldid;
            initConfig();
        }
        private void initConfig()
        {
            txtCldDate.Value = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            setControl();
        }
        private void setControl()
        {
            CloseDay cld = new CloseDay();
            cld = mposC.mposDB.cldDB.selectByPk1(cldid);
            if (cld.closeday_id.Length > 0)
            {

            }
            else
            {
                DataTable dt = new DataTable();
                dt = mposC.mposDB.bildDB.selectCloseDayCurr();
                if (dt.Rows.Count > 0)
                {
                    txtCntOrder.Value = dt.Rows[0]["cnt_order"].ToString();
                    txtAmt.Value = dt.Rows[0]["sum_price"].ToString();
                }
            }
        }
        private void FrmCloseDayAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
