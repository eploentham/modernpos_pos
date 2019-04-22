using C1.Win.C1Input;
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
    public partial class FrmKeyBoard2 : Form
    {
        C1TextBox txt;
        public FrmKeyBoard2(Point p, C1TextBox frm)
        {
            InitializeComponent();
            txt = frm;
            initConfig(p);
        }
        private void initConfig(Point pp)
        {
            this.Location = pp;
            setTextEng();

            lb21.Click += Lb21_Click; lb22.Click += Lb21_Click; lb23.Click += Lb21_Click; lb24.Click += Lb21_Click; lb25.Click += Lb21_Click; lb26.Click += Lb21_Click; lb27.Click += Lb21_Click; lb28.Click += Lb21_Click; lb29.Click += Lb21_Click; lb210.Click += Lb21_Click; lb211.Click += Lb21_Click; lb212.Click += Lb21_Click;
            lb31.Click += Lb21_Click; lb32.Click += Lb21_Click; lb33.Click += Lb21_Click; lb34.Click += Lb21_Click; lb35.Click += Lb21_Click; lb36.Click += Lb21_Click; lb37.Click += Lb21_Click; lb38.Click += Lb21_Click; lb39.Click += Lb21_Click; lb310.Click += Lb21_Click; lb311.Click += Lb21_Click;
            lb41.Click += Lb21_Click; lb42.Click += Lb21_Click; lb43.Click += Lb21_Click; lb44.Click += Lb21_Click; lb45.Click += Lb21_Click; lb46.Click += Lb21_Click; lb47.Click += Lb21_Click; lb48.Click += Lb21_Click; lb49.Click += Lb21_Click; lb410.Click += Lb21_Click;

        }
        private void setTextEng()
        {
            lb11.Text = "1"; lb12.Text = "2"; lb13.Text = "3"; lb14.Text = "4"; lb15.Text = "5"; lb16.Text = "6"; lb17.Text = "7"; lb18.Text = "8"; lb19.Text = "9"; lb110.Text = "0";
            lb21.Text = "q"; lb22.Text = "w"; lb23.Text = "e"; lb24.Text = "r"; lb25.Text = "t"; lb26.Text = "y"; lb27.Text = "u"; lb28.Text = "i"; lb29.Text = "o"; lb210.Text = "p"; lb211.Text = "["; ; lb212.Text = "]";
            lb31.Text = "a"; lb32.Text = "s"; lb33.Text = "d"; lb34.Text = "f"; lb35.Text = "g"; lb36.Text = "h"; lb37.Text = "j"; lb38.Text = "k"; lb39.Text = "l"; lb310.Text = ";"; ; lb311.Text = "'";
            lb41.Text = "z"; lb42.Text = "x"; lb43.Text = "c"; lb44.Text = "v"; lb45.Text = "b"; lb46.Text = "n"; lb47.Text = "m"; lb48.Text = ","; lb49.Text = "."; lb410.Text = "/";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "กขค"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb51.Width = lb51.Width + ((lb52.Left + lb52.Width) - (lb51.Left + lb51.Width));
            lb54.Width = lb54.Width + ((lb55.Left + lb55.Width) - (lb51.Left + lb51.Width));
        }
        private void setTextEngShift()
        {
            lb11.Text = "1"; lb12.Text = "2"; lb13.Text = "3"; lb14.Text = "4"; lb15.Text = "5"; lb16.Text = "6"; lb17.Text = "7"; lb18.Text = "8"; lb19.Text = "9"; lb110.Text = "0";
            lb21.Text = "q"; lb22.Text = "w"; lb23.Text = "e"; lb24.Text = "r"; lb25.Text = "t"; lb26.Text = "y"; lb27.Text = "u"; lb28.Text = "i"; lb29.Text = "o"; lb210.Text = "p"; lb211.Text = "["; ; lb212.Text = "]";
            lb31.Text = "a"; lb32.Text = "s"; lb33.Text = "d"; lb34.Text = "f"; lb35.Text = "g"; lb36.Text = "h"; lb37.Text = "j"; lb38.Text = "k"; lb39.Text = "l"; lb310.Text = ";"; ; lb311.Text = "'";
            lb41.Text = "z"; lb42.Text = "x"; lb43.Text = "c"; lb44.Text = "v"; lb45.Text = "b"; lb46.Text = "n"; lb47.Text = "m"; lb48.Text = ","; lb49.Text = "."; lb410.Text = "/";
            lb51.Text = "shift"; lb52.Text = ""; lb53.Text = "กขค"; lb54.Text = ""; lb55.Text = ""; lb56.Text = ""; lb57.Text = ""; lb58.Text = ""; lb59.Text = ""; lb510.Text = "";
            lb52.Hide();
            lb54.Text = "space";
            lb55.Hide();
            lb56.Hide();
            lb57.Hide();
            lb51.Width = lb51.Width + ((lb52.Left + lb52.Width) - (lb51.Left + lb51.Width));
            lb54.Width = lb54.Width + ((lb55.Left + lb55.Width) - (lb51.Left + lb51.Width));
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

        }
    }
}
