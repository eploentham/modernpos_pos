using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmToGo1 : Form
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
        VlcControl vlcControl1;

        public FrmToGo1(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            this.vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            vlcControl1.Dock = DockStyle.Fill;
            this.Controls.Add(vlcControl1);
            vlcControl1.VlcLibDirectory = new DirectoryInfo(@"C:\Users\ekapop-pc\Downloads");
            //vlcControl1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.OnVlcControlNeedLibDirectory);
            vlcControl1.Click += VlcControl1_Click;
            this.FormClosing += FrmToGo1_FormClosing;
        }

        private void FrmToGo1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //throw new NotImplementedException();
            if (vlcControl1.IsPlaying)
            {
                vlcControl1.Stop();
                vlcControl1.Dispose();
            }
            vlcControl1.Dispose();
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            //throw new NotImplementedException();
            var currentAssembly = Assembly.GetEntryAssembly();           var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }

        private void VlcControl1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void FrmToGo1_Load(object sender, EventArgs e)
        {
            vlcControl1.Play(new FileInfo(@"C:\Users\ekapop-pc\Downloads\SSNI-547.mp4"));
        }
    }
}
