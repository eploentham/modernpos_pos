using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public class FrmToGo1:Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        Image imgLogo, imgOK;
        Form frmmain;

        public FrmToGo1(mPOSControl x, Form frmmain)
        {
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {

        }
    }
}
