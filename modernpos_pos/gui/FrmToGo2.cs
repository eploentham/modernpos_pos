using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using System;
using System.Collections.Generic;
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
    public class FrmToGo2:Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        PictureBox imgLeft, imgRight;
        Form frmmain;
        VlcControl vlcControl1;
        TransparentPanel pnVlc;
        Panel pnMain = null;
        public event System.Windows.Forms.MouseEventHandler MouseClick;
        public FrmToGo2(mPOSControl x, Form frmmain)
        {
            //InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += FrmToGo2_Load;



            //this.MouseClick += FrmToGo2_MouseClick;
            //this.Click += FrmToGo2_Click;

            //vlcControl1 = new VlcControl();
            //var currentAssembly = Assembly.GetEntryAssembly();
            //var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            //// Default installation path of VideoLAN.LibVLC.Windows
            //var libDirectory = new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            //vlcControl1.BeginInit();
            //vlcControl1.VlcLibDirectory = libDirectory;
            //vlcControl1.Dock = DockStyle.Fill;
            //vlcControl1.EndInit();
            ////control.Dock = DockStyle.Fill;
            //vlcControl1.Click += VlcControl1_Click;
            //vlcControl1.MouseClick += Control1_MouseClick;
            //vlcControl1.MouseDown += VlcControl1_MouseDown;
            //this.vlcControl1.MouseUp += VlcControl1_MouseUp;

            //pnVlc = new TransparentPanel();
            //pnVlc.Dock = DockStyle.Fill;

            //pnVlc.Click += PnVlc_Click;
            //pnVlc.MouseClick += PnVlc_MouseClick;
            ////pnVlc.Controls.Add(vlcControl1);
            //this.Controls.Add(pnVlc);
            //this.Controls.Add(vlcControl1);
            //pnVlc.BringToFront();
            //this.FormClosing += FrmToGo1_FormClosing;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            pnMain = new Panel();
            pnMain.Dock = DockStyle.Fill;
            this.Controls.Add(pnMain);
            imgLeft = new PictureBox();
            imgLeft.Location = new System.Drawing.Point(0, 0);
            imgLeft.Name = "imgLeft";
            imgLeft.Size = new System.Drawing.Size(screenWidth / 2, screenHeight);
            imgLeft.Image = Resources.screen_first_l;
            imgLeft.SizeMode = PictureBoxSizeMode.StretchImage;
            imgLeft.Click += ImgLeft_Click;

            imgRight = new PictureBox();
            imgRight.Location = new System.Drawing.Point(screenWidth / 2, 0);
            imgRight.Name = "imgLeft";
            imgRight.Size = new System.Drawing.Size(screenWidth / 2, screenHeight);
            imgRight.Image = Resources.screen_first_r;
            imgRight.SizeMode = PictureBoxSizeMode.StretchImage;
            imgRight.Click += ImgRight_Click;

            pnMain.Controls.Add(imgLeft);
            pnMain.Controls.Add(imgRight);
        }

        private void ImgLeft_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void ImgRight_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void Control1_MouseClick(Object sender, MouseEventArgs e)
        {

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event");
        }
        private void VlcControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PnVlc_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PnVlc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void VlcControl1_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            String aaa = "";
        }

        private async Task AddPlayerAsync()
        {
            await Task.Run(async () =>
            {
                //var player = new VlcControl
                //{
                //    VlcLibDirectory = new DirectoryInfo(this.vlcLibraryPath), Size = new Size(200, 200)
                //};

                //var uiUpdatedTask = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
                //panel.BeginInvoke((MethodInvoker)delegate
                //{
                //    panel.Controls.Add(player);
                //    player.EndInit();
                //    uiUpdatedTask.SetResult(true);
                //});

                //await uiUpdatedTask.Task.ConfigureAwait(false);

                //lock (listOfControls)
                //{
                //    // Add to a list
                //    listOfControls.Add(player);
                //}

                HookEvents(vlcControl1);

                // If any of the following 2 elements is true, then the vlc player itself will capture input from the user.
                // and then, the mouse click event won't fire.
                //player.Video.IsMouseInputEnabled = false;
                //player.Video.IsKeyInputEnabled = false;
                //player.Audio.IsMute = true;

                // Tell the player to play
                //player.SetMedia(textBox1.Text, StreamParams);
                //player.Play();
            });
        }
        private void HookEvents(VlcControl player)
        {
            // hook to whatever you need, but remember to unhook it too.
            //player.EndReached += PlayerOnEndReached;
            //player.EncounteredError += Player_EncounteredError;
            //player.Buffering += PlayerOnBuffering;
            //player.Playing += PlayerOnPlaying;
            //player.TimeChanged += PlayerOnTimeChanged;
            //player.Opening += PlayerOnOpening;
            player.MouseClick += PlayerOnMouseClick;
        }
        private void PlayerOnMouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(@"Click = ");

        }
        private void FrmToGo2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String aaa = "";
        }

        private void FrmToGo2_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            String aaa = "";
        }

        private void VlcControl1_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmToGo2
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "FrmToGo2";
            this.ResumeLayout(false);

        }
        private void VlcControl1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            opennew();
        }
        private void opennew()
        {

            //vlcControl1.Stop();
            FrmWaiting frmW = new FrmWaiting();
            frmW.Show();

            //FrmTakeOut2 frm = new FrmTakeOut2(mposC, this);
            //FrmTakeOut3 frm = new FrmTakeOut3(mposC, this);
            FrmTakeOut4 frm = new FrmTakeOut4(mposC, this);
            frmW.Dispose();
            frm.ShowDialog(this);
            //vlcControl1.Play();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                frmmain.Show();
                Close();
                return true;
                //}
            }
            else
            {
                //keyData
                switch (keyData)
                {
                    case Keys.X | Keys.Control:
                        frmmain.Show();
                        Close();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private async void setPlay()
        {
            await AddPlayerAsync();
        }
        private void FrmToGo2_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //string path = Directory.GetCurrentDirectory();
            //vlcControl1.Play(new FileInfo(path+"\\"+mposC.iniC.screenFirstFilename));
            //setPlay();
            //vlcControl1.Play(new FileInfo(@"C:\output\capture-20181210-022923.png"));
        }
    }
}
