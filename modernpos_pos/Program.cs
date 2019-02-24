using modernpos_pos.control;
using modernpos_pos.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form4());
            mposControl mposC = new mposControl();
            FrmSplash spl = new FrmSplash();
            spl.Show();
            Application.Run(new FrmMain(mposC, spl));
        }
    }
}
