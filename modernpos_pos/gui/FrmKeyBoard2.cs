using C1.Win.C1Input;
using modernpos_pos.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmKeyBoard2 : Form
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        mPOSControl mposC;
        C1TextBox txt;
        Font fEdit, fEditB, fEdit1;
        String shift = "", lang="";
        public FrmKeyBoard2(mPOSControl x, Point p, C1TextBox frm)
        {
            InitializeComponent();
            mposC = x;
            txt = frm;
            initConfig(p);
        }
        private void initConfig(Point pp)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = pp;
            setTextEng();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 12, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular + 2);
            foreach(Control ctl in panel1.Controls)
            {
                if( ctl is Label)
                {
                    ctl.Font = fEdit;
                }
            }
            lb11.Click += Lb21_Click; lb12.Click += Lb21_Click; lb13.Click += Lb21_Click; lb14.Click += Lb21_Click; lb15.Click += Lb21_Click; lb16.Click += Lb21_Click; lb17.Click += Lb21_Click; lb18.Click += Lb21_Click; lb19.Click += Lb21_Click; lb110.Click += Lb21_Click; lb111.Click += Lb21_Click; lb112.Click += Lb21_Click;
            lb21.Click += Lb21_Click; lb22.Click += Lb21_Click; lb23.Click += Lb21_Click; lb24.Click += Lb21_Click; lb25.Click += Lb21_Click; lb26.Click += Lb21_Click; lb27.Click += Lb21_Click; lb28.Click += Lb21_Click; lb29.Click += Lb21_Click; lb210.Click += Lb21_Click; lb211.Click += Lb21_Click; lb212.Click += Lb21_Click;
            lb31.Click += Lb21_Click; lb32.Click += Lb21_Click; lb33.Click += Lb21_Click; lb34.Click += Lb21_Click; lb35.Click += Lb21_Click; lb36.Click += Lb21_Click; lb37.Click += Lb21_Click; lb38.Click += Lb21_Click; lb39.Click += Lb21_Click; lb310.Click += Lb21_Click; lb311.Click += Lb21_Click;
            lb41.Click += Lb21_Click; lb42.Click += Lb21_Click; lb43.Click += Lb21_Click; lb44.Click += Lb21_Click; lb45.Click += Lb21_Click; lb46.Click += Lb21_Click; lb47.Click += Lb21_Click; lb48.Click += Lb21_Click; lb49.Click += Lb21_Click; lb410.Click += Lb21_Click;
            lb51.Click += Lb51_Click;
            lb510.Click += Lb510_Click;
            lb53.Click += Lb53_Click;
            lb411.Click += Lb411_Click;
        }

        private void Lb411_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txt.Focus();
            //Label lb = (Label)sender;
            SendKeys.Send("{BKSP}");
        }

        private void Lb53_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (lang.Equals(""))
                lang = "thai";
            else
                lang = "";
            if (lang.Equals(""))
                setTextEng();
            else
                setTextThai();
        }

        private void Lb510_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Close();
        }

        private void Lb51_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (shift.Equals(""))
                shift = "shift";
            else
                shift = "";
            if (lang.Equals(""))
            {
                if (shift.Equals(""))
                    setTextEng();
                else
                    setTextEngShift();
            }
            else
            {
                if (shift.Equals(""))
                    setTextThai();
                else
                    setTextThaiShift();
            }
        }
        private void setTextThai()
        {
            int a = 97;
            char aaa;
            aaa = (char)97;
            int aa = 0;
            aa = (int)aaa;
            aaa = Convert.ToChar((int)'a' - 32);
            lb11.Text = "า"; lb12.Text = "/"; lb13.Text = "_"; lb14.Text = "ภ"; lb15.Text = "ถ"; lb16.Text = "ุ"; lb17.Text = "ึ"; lb18.Text = "ค"; lb19.Text = "ต"; lb110.Text = "จ"; lb111.Text = "ข"; lb112.Text = "ช";
            lb21.Text = "ๆ"; lb22.Text = "ไ"; lb23.Text = "ำ"; lb24.Text = "พ"; lb25.Text = "ะ"; lb26.Text = "ั"; lb27.Text = "ี"; lb28.Text = "ร"; lb29.Text = "น"; lb210.Text = "ย"; lb211.Text = "บ"; ; lb212.Text = "ล";
            lb31.Text = "ฟ"; lb32.Text = "ห"; lb33.Text = "ก"; lb34.Text = "ด"; lb35.Text = "เ"; lb36.Text = "้"; lb37.Text = "่"; lb38.Text = "า"; lb39.Text = "ส"; lb310.Text = "ว"; lb311.Text = "ง";
            lb41.Text = "ผ"; lb42.Text = "ป"; lb43.Text = "แ"; lb44.Text = "อ"; lb45.Text = "ิ"; lb46.Text = "ื"; lb47.Text = "ท"; lb48.Text = "ม"; lb49.Text = "ใ"; lb410.Text = "ฝ"; lb411.Text = "del";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "abc"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "return";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb58.Hide();
            lb511.Hide();
            lb412.Hide();
            lb51.Width = 72 + ((lb52.Left + lb52.Width) - (lb51.Left + 72));
            lb54.Width = 72 + ((lb55.Left + lb55.Width) - (lb51.Left + 72));
            lb510.Width = 72 + ((lb511.Left + lb511.Width) - (lb510.Left + 72));
            lb411.Width = 72 + ((lb412.Left + lb412.Width) - (lb411.Left + 72));
            lb510.Text = "return";
            lb510.ForeColor = Color.Green;
        }
        private void setTextThaiShift()
        {
            lb11.Text = "+"; lb12.Text = "๑"; lb13.Text = "๒"; lb14.Text = "๓"; lb15.Text = "๔"; lb16.Text = "ู"; lb17.Text = "฿"; lb18.Text = "๕"; lb19.Text = "๖"; lb110.Text = "๗"; lb111.Text = "๘"; lb112.Text = "๙";
            lb21.Text = "๐"; lb22.Text = @""; lb23.Text = "ฎ"; lb24.Text = "ฑ"; lb25.Text = "ธ"; lb26.Text = "ํ"; lb27.Text = "๊"; lb28.Text = "ณ"; lb29.Text = "ฯ"; lb210.Text = "ญ"; lb211.Text = "ฐ"; ; lb212.Text = ",";
            lb31.Text = "ฤ"; lb32.Text = "ฆ"; lb33.Text = "ฏ"; lb34.Text = "โ"; lb35.Text = "ฌ"; lb36.Text = "็"; lb37.Text = "๋"; lb38.Text = "ษ"; lb39.Text = "ศ"; lb310.Text = "ซ"; lb311.Text = ".";
            lb41.Text = "("; lb42.Text = ")"; lb43.Text = "ฉ"; lb44.Text = "ฮ"; lb45.Text = "ฺ"; lb46.Text = "์"; lb47.Text = "?"; lb48.Text = "ฒ"; lb49.Text = "ฬ"; lb410.Text = "ฦ"; lb411.Text = "del";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "abc"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "return";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb58.Hide();
            lb511.Hide();
            lb412.Hide();
            lb51.Width = 72 + ((lb52.Left + lb52.Width) - (lb51.Left + 72));
            lb54.Width = 72 + ((lb55.Left + lb55.Width) - (lb51.Left + 72));
            lb510.Width = 72 + ((lb511.Left + lb511.Width) - (lb510.Left + 72));
            lb411.Width = 72 + ((lb412.Left + lb412.Width) - (lb411.Left + 72));
            lb510.Text = "return";
            lb510.ForeColor = Color.Green;
        }
        private void setTextEng()
        {
            int a = 97;
            char aaa;
            aaa = (char)97;
            int aa = 0;
            aa = (int) aaa;
            aaa = Convert.ToChar((int)'a' - 32);
            lb11.Text = "1"; lb12.Text = "2"; lb13.Text = "3"; lb14.Text = "4"; lb15.Text = "5"; lb16.Text = "6"; lb17.Text = "7"; lb18.Text = "8"; lb19.Text = "9"; lb110.Text = "0"; lb111.Text = ""; lb112.Text = "";
            lb21.Text = "q"; lb22.Text = "w"; lb23.Text = "e"; lb24.Text = "r"; lb25.Text = "t"; lb26.Text = "y"; lb27.Text = "u"; lb28.Text = "i"; lb29.Text = "o"; lb210.Text = "p"; lb211.Text = "["; ; lb212.Text = "]";
            lb31.Text = "a"; lb32.Text = "s"; lb33.Text = "d"; lb34.Text = "f"; lb35.Text = "g"; lb36.Text = "h"; lb37.Text = "j"; lb38.Text = "k"; lb39.Text = "l"; lb310.Text = ";"; lb311.Text = "'";
            lb41.Text = "z"; lb42.Text = "x"; lb43.Text = "c"; lb44.Text = "v"; lb45.Text = "b"; lb46.Text = "n"; lb47.Text = "m"; lb48.Text = ","; lb49.Text = "."; lb410.Text = "/"; lb411.Text = "del";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "กขค"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "return";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb58.Hide();
            lb511.Hide();
            lb412.Hide();
            lb312.Hide();
            lb512.Hide();
            lb51.Width = 72 + ((lb52.Left + lb52.Width) - (lb51.Left + 72));
            lb54.Width = 72 + ((lb55.Left + lb55.Width) - (lb51.Left + 72));
            lb510.Width = 72 + ((lb511.Left + lb511.Width) - (lb510.Left + 72));
            lb411.Width = 72 + ((lb412.Left + lb412.Width) - (lb411.Left + 72));
            lb510.Text = "return";
            lb510.ForeColor = Color.Green;
        }
        private void setTextEngShift()
        {
            lb11.Text = "1"; lb12.Text = "2"; lb13.Text = "3"; lb14.Text = "4"; lb15.Text = "5"; lb16.Text = "6"; lb17.Text = "7"; lb18.Text = "8"; lb19.Text = "9"; lb110.Text = "0"; lb111.Text = ""; lb112.Text = "";
            lb21.Text = "Q"; lb22.Text = "W"; lb23.Text = "E"; lb24.Text = "R"; lb25.Text = "T"; lb26.Text = "Y"; lb27.Text = "U"; lb28.Text = "I"; lb29.Text = "O"; lb210.Text = "P"; lb211.Text = "["; ; lb212.Text = "]";
            lb31.Text = Convert.ToString(Convert.ToChar((int) 'a'-32)); lb32.Text = "S"; lb33.Text = "D"; lb34.Text = "F"; lb35.Text = "G"; lb36.Text = "H"; lb37.Text = "J"; lb38.Text = "K"; lb39.Text = "L"; lb310.Text = ";"; ; lb311.Text = "'";
            lb41.Text = "Z"; lb42.Text = "X"; lb43.Text = "C"; lb44.Text = "V"; lb45.Text = "B"; lb46.Text = "N"; lb47.Text = "M"; lb48.Text = ","; lb49.Text = "."; lb410.Text = "/"; lb411.Text = "del";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "กขค"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "return";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb58.Hide();
            lb511.Hide();
            lb412.Hide();
            lb312.Hide();
            lb512.Hide();
            lb51.Width = 72 + ((lb52.Left + lb52.Width) - (lb51.Left + 72));
            lb54.Width = 72 + ((lb55.Left + lb55.Width) - (lb51.Left + 72));
            lb510.Width = 72 + ((lb511.Left + lb511.Width) - (lb510.Left + 72));
            lb411.Width = 72 + ((lb412.Left + lb412.Width) - (lb411.Left + 72));
            lb510.Text = "return";
            lb510.ForeColor = Color.Green;
        }

        private void Lb21_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txt.Focus();
            Label lb = (Label)sender;
            SendKeys.Send(lb.Text);
        }

        private void FrmKeyBoard2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}
