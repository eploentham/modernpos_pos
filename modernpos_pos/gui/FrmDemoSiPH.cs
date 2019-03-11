using C1.Win.C1Input;

using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace modernpos_pos
{
    public partial class FrmDemoSiPH : Form
    {
        mPOSControl mposC;
        Timer timer, timerOnLine;
        //System.Timers.Timer timerOnLine;
        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;

        String webapi = "/selfcashapi/", paymentId="";
        Boolean MobileFocus = false, AmountFocus = false;
        [STAThread]
        private void txtStatus(String msg)
        {
            lbVersion.Invoke(new EventHandler(delegate
            {
                lbVersion.Text = msg;
            }));
        }
        [STAThread]
        private void btnC(Boolean msg)
        {
            btnPayment.Invoke(new EventHandler(delegate
            {
                btnPayment.Enabled = msg;
            }));
        }

        public FrmDemoSiPH(mPOSControl x)
        {
            mposC = x;
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            int timerOnline = 5;
            int.TryParse(txtTimerOnLine.Text, out timerOnline);
            vneC = new VNEControl();
            txtTimerOnLine.KeyPress += TxtTimerOnLine_KeyPress;
            txtTimerOnLine.TextChanged += TxtTimerOnLine_TextChanged;
            btnPayment.Click += BtnPayment_Click;
            btn7.Click += Btn7_Click;
            btn8.Click += Btn7_Click;
            btn9.Click += Btn7_Click;
            btn4.Click += Btn7_Click;
            btn5.Click += Btn7_Click;
            btn6.Click += Btn7_Click;
            btn1.Click += Btn7_Click;
            btn2.Click += Btn7_Click;
            btn3.Click += Btn7_Click;
            btn0.Click += Btn7_Click;
            btnMinus.Click += BtnMinus_Click;
            txtMobile.Enter += TxtMobile_Enter;
            txtMobile.Leave += TxtMobile_Leave;
            txtAmount.Enter += TxtAmount_Enter;
            txtAmount.Leave += TxtAmount_Leave;
            txtAmount.KeyPress += TxtAmount_KeyPress;
            lbVersion.Text = mposC.iniC.statusShowListBox1;
            if (mposC.iniC.statusShowListBox1.Equals("1"))
            {
                listBox1.Show();
            }
            else
            {
                listBox1.Hide();
            }

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Enabled = false;

            timerOnLine = new Timer();
            timerOnLine.Interval = timerOnline * 1000;
            timerOnLine.Tick += TimerOnLine_Tick;
            timerOnLine.Enabled = false;

            timerOnLine.Start();
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as C1TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            //if (txtAmount.Text.Equals("00"))
            //{
            //    txtAmount.Value = "0";
            //}
                
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MobileFocus)
            {
                if (txtMobile.TextLength>0)
                    txtMobile.Value = txtMobile.Text.Substring(0,txtMobile.Text.Length - 1);
            }
            else
            {
                if (txtAmount.TextLength > 0)
                    txtAmount.Value = txtAmount.Text.Substring(0,txtAmount.Text.Length - 1);
            }
        }

        private void TxtAmount_Leave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //AmountFocus = false;
        }

        private void TxtAmount_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            AmountFocus = true;
            MobileFocus = false;
        }

        private void TxtMobile_Leave(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MobileFocus = false;
        }

        private void TxtMobile_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MobileFocus = true;
            AmountFocus = false;
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //C1Button aa = new C1Button();
            //aa = (C1Button)sender;
            if (MobileFocus)
            {
                txtMobile.Value = txtMobile.Value + (sender as C1Button).Name.Replace("btn","");
            }
            else
            {
                txtAmount.Value = txtAmount.Value + (sender as C1Button).Name.Replace("btn", "");
                if (txtAmount.Text.Equals("00"))
                {
                    txtAmount.Value = "0";
                }
            }
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            long chk = 0;
            String re = "", pay="";
            pay = txtAmount.Text.Replace(".", "");
            pay = pay + "00";
            re = mposC.paymentVNE(pay, listBox1);
            if(long.TryParse(re, out chk))
            {
                paymentId = re;
                timer.Enabled = true;
                timer.Start();
                label9.Text = "Start waiting payment";
            }
            else
            {
                label9.Text = "Error payment "+ re;
            }
        }

        private void TxtTimerOnLine_TextChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int timerOnline = 5;
            int.TryParse(txtTimerOnLine.Text, out timerOnline);
            timerOnLine.Stop();
            timerOnLine.Enabled = false;
            timerOnLine.Interval = timerOnline * 1000;

            timerOnLine.Enabled = true;
            timerOnLine.Start();
        }

        private void TxtTimerOnLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void TimerOnLine_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            new Thread(() =>
            {
                btnC(false);
                String err = "";
                Thread.CurrentThread.IsBackground = true;
                Image loadedImage = null;
                try
                {
                    VNEVesionRequest vneVerR = new VNEVesionRequest();

                    var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                    String txtjson = JsonConvert.SerializeObject(vneVerR, Formatting.Indented);
                    WebClient webClient = new WebClient();
                    var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                    http.Accept = "application/json";
                    http.ContentType = "application/json";
                    http.Method = "POST";
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    Byte[] bytes = encoding.GetBytes(txtjson);
                    Stream newStream = http.GetRequestStream();
                    newStream.Write(bytes, 0, bytes.Length);
                    newStream.Close();
                    //listBox1.Items.Add(txtjson);
                    var response = http.GetResponse();

                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    var content = sr.ReadToEnd();
                    String status = "";
                    dynamic obj1 = JsonConvert.DeserializeObject(content);
                    VNEVesionResponse vneVerRes = new VNEVesionResponse();
                    vneVerRes.req_status = obj1.req_status;
                    vneVerRes.version = obj1.version;
                    //vneloginres = (VNELoginResponse)obj1;

                    if (vneVerRes.req_status.Equals("1"))
                    {
                        pic1.Image = Resources.green;
                        //lbVersion.Text = obj1.version;
                        txtStatus(vneVerRes.version);

                    }
                    else
                    {
                        pic1.Image = Resources.red_big;
                    }
                }
                catch (Exception ex)
                {
                    //listBox1.Items.Add(err + " " + ex.Message);
                }
                btnC(true);
            }).Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "";
            //throw new NotImplementedException();
            VNEPaymentPollingRequest vnePpReq = new VNEPaymentPollingRequest();
            vnePpReq.tipo = "2";
            vnePpReq.id = paymentId;
            vnePpReq.opName = "admin";
            try
            {
                var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                String txtjson = JsonConvert.SerializeObject(vnePpReq, Formatting.Indented);
                WebClient webClient = new WebClient();
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                ASCIIEncoding encoding = new ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(txtjson);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                vnePRep = new VNEPaymentPollingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);

                vnePRep.id = obj.id;
                vnePRep.req_status = obj.req_status;
                vnePRep.tipo = obj.tipo;
                vnePRep.payment_status = obj.payment_status;
                //vnePRep.payment_detail = obj.payment_details.toString();
                String aaa = String.Concat(obj.payment_details);
                dynamic obj1 = JsonConvert.DeserializeObject(aaa);

                vnePRepd = new VNEPaymentPollingResponsePaymentDetail();
                vnePRepd.amount = obj1.amount;
                vnePRepd.inserted = obj1.inserted;
                vnePRepd.rest = obj1.rest;
                vnePRepd.status = obj1.status;

                //label10.Text = "ID " + vnePRep.id + " amount " + vnePRepd.amount + " status " + vnePRepd.status;
                //listBox1.Items.Add(content);
                if (vnePRepd.status.Equals("complete"))
                {
                    label10.Text = vnePRepd.status;
                    timer.Stop();
                    //PrintDocument document = new PrintDocument();
                    //document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                    //document.PrinterSettings.PrinterName = cboPrinter.Text;
                    //document.Print();
                }
                else
                {
                    label10.Text = vnePRepd.status;
                }
            }
            catch (Exception ex)
            {
                //listBox1.Items.Add(err + " " + ex.Message);
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //This part sets up the data to be printed
            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            //gets the text from the textbox
            String stringToPrint = "";
            string printText = "";
            //String RECEIPT = Environment.CurrentDirectory + "\\comprovante.txt";
            //if (File.Exists(RECEIPT))
            //{
            //    FileStream fs = new FileStream(RECEIPT, FileMode.Open);
            //    StreamReader sr = new StreamReader(fs);
            //    stringToPrint = sr.ReadToEnd();

            //    sr.Close();
            //    fs.Close();
            //}
            String date = "";
            date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            stringToPrint = "เวลา " + date + Environment.NewLine;
            stringToPrint += "รับเงิน จำนวน "+txtAmount.Text + Environment.NewLine;
            stringToPrint += "ขอบคุณที่ใช้บริการ " + Environment.NewLine;
            //stringToPrint += "" + txtTopUp2.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp3.Text + Environment.NewLine;
            //stringToPrint += "โต๊ะ   " + txtDesk.Text + Environment.NewLine;
            //Makes the file to print and sets the look of it

            g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);

        }
        private Boolean appExit()
        {
            //flagExit = true;
            if (MessageBox.Show("ต้องการออกจากโปรแกรม2", "ออกจากโปรแกรม menu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                appExit();
                //if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //{
                //    Close();
                //    return true;
                //}
            }
            else
            {
                //keyData
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtMobile.Focus();
            label1.Text = "Last Update 2018-12-17";
            String chk = "", printerDefault = "";
            try
            {
                PrinterSettings settings = new PrinterSettings();
                int i = 0;
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    settings.PrinterName = printer;
                    cboPrinter.Items.Insert(i, printer);
                    if (settings.IsDefaultPrinter)
                        printerDefault = printer;
                    i++;
                }
                PrinterSettings settings1 = new PrinterSettings();
                //settings1.PrinterName = ;

            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
        }
    }
}
