using C1.Win.C1Input;

using modernpos_pos.control;
using modernpos_pos.gui;
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
        Timer timer, timerOnLine, timerReader;
        //System.Timers.Timer timerOnLine;
        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;

        String webapi = "/selfcashapi/", paymentId="";
        Boolean MobileFocus = false, AmountFocus = false;
        RDNID mRDNIDWRAPPER = new RDNID();
        Font ff, ffB;
        Font fEdit, fEditB, fEdit1, fEditBB, fEdit2;
        String donatename = "";
        Boolean statuaRead = false, statusEdit=false;
        enum NID_FIELD
        {
            NID_Number,   //1234567890123#

            TITLE_T,    //Thai title#
            NAME_T,     //Thai name#
            MIDNAME_T,  //Thai mid name#
            SURNAME_T,  //Thai surname#

            TITLE_E,    //Eng title#
            NAME_E,     //Eng name#
            MIDNAME_E,  //Eng mid name#
            SURNAME_E,  //Eng surname#

            HOME_NO,    //12/34#
            MOO,        //10#
            TROK,       //ตรอกxxx#
            SOI,        //ซอยxxx#
            ROAD,       //ถนนxxx#
            TUMBON,     //ตำบลxxx#
            AMPHOE,     //อำเภอxxx#
            PROVINCE,   //จังหวัดxxx#

            GENDER,     //1#			//1=male,2=female

            BIRTH_DATE, //25200131#	    //YYYYMMDD 
            ISSUE_PLACE,//xxxxxxx#      //
            ISSUE_DATE, //25580131#     //YYYYMMDD 
            EXPIRY_DATE,//25680130      //YYYYMMDD 
            ISSUE_NUM,  //12345678901234 //14-Char
            END
        };
        String _CardReaderTFK2700 = "";

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
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 2, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 3, FontStyle.Bold);
            fEditBB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 4, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize , FontStyle.Regular);
            fEdit2 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize - 2, FontStyle.Regular);
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
            
            btnDonate1.Click += BtnDonate1_Click;
            btnDonate2.Click += BtnDonate2_Click;
            pic3Back.Click += Pic3Back_Click;
            pic3Next.Click += Pic3Next_Click;
            pic1Back.Click += Pic1Back_Click;
            pic1Next.Click += Pic1Next_Click;
            pic4Back.Click += Pic4Back_Click;
            pic4Next.Click += Pic4Next_Click;
            pic2Back.Click += Pic2Back_Click1;
            pic2Next.Click += Pic2Next_Click1;
            pic3Donate.Click += Pic3Donate_Click;

            btnReadCard.Click += BtnReadCard_Click;
            btnPrint.Click += BtnPrint_Click;
            btnDonate11.Click += BtnDonate11_Click;
            btnDonate12.Click += BtnDonate12_Click;
            btnEdit.Click += BtnEdit_Click;

            txtPttName.Enter += TxtPttName_Enter;
            txtPttLName.Enter += TxtPttLName_Enter;
            txtPttNameE.Enter += TxtPttNameE_Enter;
            txtPttLNameE.Enter += TxtPttLNameE_Enter;
            txtRoad.Enter += TxtRoad_Enter;
            txtPid.Enter += TxtPid_Enter;

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

            timerReader = new Timer();
            timerReader.Interval = 2000;
            timerReader.Tick += TimerReader_Tick;
            timerReader.Enabled = true;

            timerOnLine = new Timer();
            timerOnLine.Interval = timerOnline * 1000;
            timerOnLine.Tick += TimerOnLine_Tick;
            timerOnLine.Enabled = false;
            lbMessage.Hide();
            //pnPID.Hide();

            timerOnLine.Start();
        }
        private void setPnPIDEnable(Boolean flag)
        {
            txtPid.ReadOnly = flag;
            txtPttName.ReadOnly = flag;
            txtPttLName.ReadOnly = flag;
            txtPttNameE.ReadOnly = flag;
            txtPttLNameE.ReadOnly = flag;
            txtRoad.ReadOnly = flag;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            statusEdit = true;
            timerClose();
            setPnPIDEnable(true);
        }

        private void Pic3Donate_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab4;
        }

        private void TimerReader_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MessageBox.Show("0000000", "");
            statuaRead = false;
            setPnPIDEnable(true);
            ReadCard();
            statuaRead = false;
        }

        private void TxtPid_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtPid.Location;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtPid);
                frm.Show(this);
            }
        }

        private void TxtRoad_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtRoad.Location;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtRoad);
                frm.Show(this);
            }
        }

        private void TxtPttLNameE_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtPttLNameE.Location;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtPttLNameE);
                frm.Show(this);
            }
        }

        private void TxtPttNameE_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtPttNameE.Location;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtPttNameE);
                frm.Show(this);
            }
        }

        private void TxtPttLName_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtPttLName.Location;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtPttLName);
                frm.Show(this);
            }
        }

        private void TxtPttName_Enter(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (!statusEdit) return;
            Point pp = txtPttName.Location;
            //pp.Y = pp.Y + 120 + 20;
            //pp.X = pp.X - 20 + panel4.Left;
            Boolean chk = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Focus();
                    chk = true;
                }
            }
            if (!chk)
            {
                FrmKeyBoard2 frm = new FrmKeyBoard2(mposC, pp, txtPttName);
                frm.Show(this);
            }
        }

        private void Pic2Next_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab3;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            //pic32.Size = new Size(100, 100);
        }

        private void Pic2Back_Click1(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab1;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            //pic11.Size = new Size(100, 100);
        }

        private void Pic4Next_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        private void Pic4Back_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab3;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            pic32.Size = new Size(100, 100);
        }

        private void BtnDonate12_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab3;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            //pic32.Size = new Size(100, 100);
            //pic3Donate.Image = Resources.siph_11;
            donatename = " ช่วยเหลือผู้ป่วยยากไร้ โรงพยาบาลศิริราช";
        }

        private void BtnDonate11_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab3;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            pic32.Size = new Size(100, 100);
            //pic3Donate.Image = Resources.siph_10;
            donatename = " เพื่อสร้างอาคารนวมินทรบพิตร 84 พรรษา";
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            timerClose();
            statusEdit = false;
            PrintDocument document = new PrintDocument();
            //document.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A5", 148, 210);
            //document.DefaultPageSettings.Landscape = true;

            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            
            //This is where you set the printer in your case you could use "EPSON USB"

            //or whatever it is called on your machine, by Default it will choose the default printer

            document.PrinterSettings.PrinterName = cboPrinter.Text;

            document.Print();

            FrmMessage frm = new FrmMessage("ขอบคุณที่บริจาก");
            frm.ShowDialog(this);
            txtPid.Value = "";
            txtPttName.Value = "";
            txtPttLName.Value = "";
            txtPttNameE.Value = "";
            txtPttLNameE.Value = "";
            txtRoad.Value = "";
            m_lblDLXInfo.Text = "";
            picPID.Image = null;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm1 in fc)
            {
                if (frm1.Name.Equals("FrmKeyBoard2"))
                {
                    frm1.Close();
                }
            }
            tC.SelectedTab = tab1;
            timerStart();
        }

        private void BtnReadCard_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            lbMessage.Show();
            pnPID.Show();
            ReadCard();

            lbMessage.Hide();
        }

        private void Pic3Next_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab4;
            //pic43.Size = new Size(100, 100);
        }

        private void Pic1Back_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }
        private void Pic1Next_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab3;
        }
        private void Pic3Back_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab2;
            //pic22.Size = new Size(100, 100);
            //pic21.Size = new Size(77, 77);
        }

        private void BtnDonate2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab2;
            //lbDonate2.Text = "บริจากเงินให้กับ 111111";
            //pic21.Size = new Size(100, 100);
        }

        private void BtnDonate1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            tC.SelectedTab = tab2;
            //lbDonate2.Text = "บริจากเงินให้กับ 2222222";
            //pic21.Size = new Size(100, 100);
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
        private void BtnPayment_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            long chk = 0;
            String re = "", pay = "";
            pay = txtAmount.Text.Replace(".", "");
            pay = pay + "00";
            re = mposC.paymentVNE(pay, listBox1);
            if (long.TryParse(re, out chk))
            {
                paymentId = re;
                timer.Enabled = true;
                timer.Start();
                label9.Text = "Start waiting payment";
            }
            else
            {
                label9.Text = "Error payment " + re;
            }
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
            //MessageBox.Show("01", "");
            listBox1.Items.Add("paymentId " + paymentId);
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
                listBox1.Items.Add("รอรับชำระ " + txtjson);
                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                vnePRep = new VNEPaymentPollingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                listBox1.Items.Add("รอรับชำระ content " + content);
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
                listBox1.Items.Add("content vnePRepd " + aaa);
                //label10.Text = "ID " + vnePRep.id + " amount " + vnePRepd.amount + " status " + vnePRepd.status;
                //listBox1.Items.Add(content);
                if (vnePRepd.status.Equals("completed"))
                {
                    label10.Text = vnePRepd.status;
                    timer.Stop();
                    mposC.statusVNEPaysuccess = "1";
                    tC.SelectedTab = tab4;
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
            //SolidBrush Brush = new SolidBrush(Color.Black);
            ////gets the text from the textbox
            //String stringToPrint = "";
            //string printText = "";
            ////String RECEIPT = Environment.CurrentDirectory + "\\comprovante.txt";
            ////if (File.Exists(RECEIPT))
            ////{
            ////    FileStream fs = new FileStream(RECEIPT, FileMode.Open);
            ////    StreamReader sr = new StreamReader(fs);
            ////    stringToPrint = sr.ReadToEnd();

            ////    sr.Close();
            ////    fs.Close();
            ////}
            //String date = "";
            //date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            //stringToPrint = "เวลา " + date + Environment.NewLine;
            //stringToPrint += "รับเงิน จำนวน "+txtAmount.Text + Environment.NewLine;
            //stringToPrint += "ขอบคุณที่ใช้บริการ " + Environment.NewLine;
            ////stringToPrint += "" + txtTopUp2.Text + Environment.NewLine;
            ////stringToPrint += "" + txtTopUp3.Text + Environment.NewLine;
            ////stringToPrint += "โต๊ะ   " + txtDesk.Text + Environment.NewLine;
            ////Makes the file to print and sets the look of it

            //g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);

            float linesPerPage = 0;
            float yPos = 0, gap=6, amt=0;
            int count = 0, rect=17;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float marginR = e.MarginBounds.Right;
            float avg = marginR / 2;
            string line = null;
            // Calculate the number of lines per page.
            linesPerPage = e.MarginBounds.Height / fEdit.GetHeight(e.Graphics);
            topMargin = topMargin / 2;
            topMargin = topMargin / 2;
            leftMargin = leftMargin / 2;
            //// Print each line of the file.
            //while (count < linesPerPage &&
            //   ((line = streamToPrint.ReadLine()) != null))
            //{
            //    yPos = topMargin + (count * fEdit.GetHeight(e.Graphics));
            //    e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, new StringFormat());
            //    count++;
            //}
            line = "ศิริราชมูลนิธิ";
            Size proposedSize = new Size(100, 100);  //maximum size you would ever want to allow
            StringFormat flags = new StringFormat(StringFormatFlags.LineLimit);  //wraps
            Size textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            Int32 xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            Int32 yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?

            Image resizedImage;
            int originalWidth = Resources.save.Width;
            int newWidth = 100;
            resizedImage = Resources.save.GetThumbnailImage(newWidth, (newWidth * Resources.save.Height) / originalWidth, null, IntPtr.Zero);

            //e.Graphics.DrawImage(Resources.siph2, avg - (Resources.siph2.Width / 2), topMargin);
            e.Graphics.DrawImage(resizedImage, avg - (resizedImage.Width / 2), topMargin);

            count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics)+gap);
            line = "เลขที่  ....................";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, flags);

            count++;            count++;
            yPos = topMargin + (count * fEditBB.GetHeight(e.Graphics) + gap);
            line = "ศิริราชมูลนิธิ";
            textSize = TextRenderer.MeasureText(line, fEditBB, proposedSize, TextFormatFlags.VerticalCenter);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEditBB, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            //line = "ศิริราชมูลนิธิ";
            //textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.Left);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "คณะแพทย์ศาสตร์ศิริราชพยาบาล  มาหวิทยาลัยมหิดล";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "ตึกมหิดลบำเพ็ญ ชั้น1 โรงพยาบาลศิริราข ถนนวังหลัง แขวงศิริราช เขตบางกอกน้อย กรุงเทพฯ  10700";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "โทร. 0-2419-7658-60 โทรสาร. 0-2419-7687, 0-2419-7658 กด 9";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEditB.GetHeight(e.Graphics) + gap);
            line = "ใบเสร็จรับเงิน";
            textSize = TextRenderer.MeasureText(line, fEditB, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEditB, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics));

            count++;
            String date = "";
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) );
            date = mposC._yyyymmdd_(System.DateTime.Now.Year + 543 + DateTime.Now.ToString("MMdd"));
            line = "วันที่ "+ date;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "นามผู้บริจาก " + txtPttName.Text +" "+ txtPttLName.Text;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "ที่อยู่ " + txtRoad.Text ;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);

            float.TryParse(txtAmount.Text, out amt);
            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "ได้รับเงินบริจากจำนวน   " + amt.ToString("0.00") + "     บาท เป็น เงินสด ";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            line = mposC.ThaiBaht(txtAmount.Text);
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, yOffset, yPos, flags);

            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            //line = "เป็น เงินสด             ";
            //textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(blackPen, leftMargin, yPos, rect, rect);

            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            //line = "     โอนผ่านธนาคาร                 สาขา                 เลขที่บัญชี่                  วันที่             ";
            //textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            ////Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(blackPen, leftMargin, yPos, rect, rect);

            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            //line = "     ธนาณัติ      เลขที่                          ";
            //textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            ////Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(blackPen, leftMargin, yPos, rect, rect);

            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            //line = "     บัตรเครดิต      เลขที่                  ธนาคาร        ";
            //textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            ////Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(blackPen, leftMargin, yPos, rect, rect);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = donatename;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            //Pen blackPen = new Pen(Color.Black, 1);
            //e.Graphics.DrawRectangle(blackPen, leftMargin + 35, yPos, rect, rect);
            //e.Graphics.DrawRectangle(blackPen, leftMargin + 125, yPos, rect, rect);


            count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            e.Graphics.DrawLine(blackPen, leftMargin, yPos, leftMargin + 200, yPos);
            e.Graphics.DrawLine(blackPen, leftMargin+250, yPos, leftMargin + 250 + 200, yPos);
            e.Graphics.DrawLine(blackPen, leftMargin + 500, yPos, leftMargin + 500 + 200, yPos);
            count++; count++; count++; count++; count++; 
            yPos = topMargin + (count * fEdit1.GetHeight(e.Graphics) + gap);
            line = "ผู้ช่วยศาสตราจารย์นายแพทย์ชัยวัฒน์  โมกขะเวศ";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin, yPos, flags);
            line = "นางสาวณตวัน  วิรกานต์กุล";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin + 250, yPos, flags);
            line = "ศาสตราจารย์นายแพทย์อรุณ  เผ่าสวัสดิ์";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin + 500, yPos, flags);
            count++;
            yPos = topMargin + (count * fEdit1.GetHeight(e.Graphics) + gap);
            line = "กรรมการเหรัญญิก";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin, yPos, flags);
            line = "ผู้รับเงิน";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin+250, yPos, flags);
            line = "รองประธานลงนามแทนองค์ประธาน";
            textSize = TextRenderer.MeasureText(line, fEdit1, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit1, Brushes.Black, leftMargin+500, yPos, flags);

            count++; count++; count++; count++; count++; count++; count++; count++; count++; count++; count++; 
            yPos = topMargin + (count * fEdit2.GetHeight(e.Graphics) + gap);
            line = "ใบเสร็จรับเงินบริจากนี้  นำไปลดหย่อนภาษีเงินได้ ลำดับที่ 85";
            textSize = TextRenderer.MeasureText(line, fEdit2, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit2, Brushes.Black, leftMargin, yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit2.GetHeight(e.Graphics) + gap);
            line = "ใบเสร็จรับเงินบริจากนี้  ไม่สามารถนำไปเบิกเงินเพิ่อการรักษาพยาบาลได้  ใบเสร็จรับเงินบริจากนี้  จะสมบรูณ์เมื่อเช็คได้ผ่านธนาคารแล้ว";
            textSize = TextRenderer.MeasureText(line, fEdit2, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit2, Brushes.Black, leftMargin, yPos, flags);

            //count++;
            //yPos = topMargin + (count * fEdit2.GetHeight(e.Graphics) + gap);
            //line = "ใบเสร็จรับเงินบริจากนี้  จะสมบรูณ์เมื่อเช็คได้ผ่านธนาคารแล้ว";
            //textSize = TextRenderer.MeasureText(line, fEdit2, proposedSize, TextFormatFlags.RightToLeft);
            //xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            //yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit2, Brushes.Black, leftMargin, yPos, flags);
            //count++;
            //yPos = topMargin + (count * fEdit.GetHeight(e.Graphics));
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, flags);
            //count++;
            // If more lines exist, print another page.
            line = null;
            if (line != null)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;

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
        private void timerStart()
        {
            //timer.Start();
            //timerOnLine.Start();
            timerReader.Start();
        }
        private void timerClose()
        {
            //timer.Stop();
            //timerOnLine.Stop();
            timerReader.Stop();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                timerClose();
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
        static string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        protected int ReadCard()
        {
            //MessageBox.Show("111111", "");
            if (statuaRead) return 0;
            try
            {
                statuaRead = true;
                //MessageBox.Show("22222", "");
                byte[] Licinfo = new byte[1024];
                RDNID.getLicenseInfoRD(Licinfo);
                m_lblDLXInfo.Text = aByteToString(Licinfo);
                //String strTerminal = m_ListReaderCard.GetItemText(m_ListReaderCard.SelectedItem);
                _CardReaderTFK2700 = mposC.ListCardReader();
                String strTerminal = _CardReaderTFK2700;
                IntPtr obj = mposC.selectReader(strTerminal);

                Int32 nInsertCard = 0;
                nInsertCard = RDNID.connectCardRD(obj);
                if (nInsertCard != 0)
                {
                    String m;
                    m = String.Format(" error no {0} ", nInsertCard);
                    //MessageBox.Show(m);

                    RDNID.disconnectCardRD(obj);
                    RDNID.deselectReaderRD(obj);
                    return nInsertCard;
                }

                byte[] id = new byte[30];
                int res = RDNID.getNIDNumberRD(obj, id);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;
                String NIDNum = aByteToString(id);

                byte[] data = new byte[1024];
                res = RDNID.getNIDTextRD(obj, data, data.Length);
                if (res != DefineConstants.NID_SUCCESS)
                    return res;

                String NIDData = aByteToString(data);
                if (NIDData == "")
                {
                    //MessageBox.Show("Read Text error");
                }
                else
                {
                    string[] fields = NIDData.Split('#');
                    String fullname = fields[(int)NID_FIELD.TITLE_T] + " " + fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " " + fields[(int)NID_FIELD.SURNAME_T];
                    String dob = fields[(int)NID_FIELD.BIRTH_DATE];

                    txtPid.Value = NIDNum;
                    txtPttName.Value = fields[(int)NID_FIELD.TITLE_T] +" " + fields[(int)NID_FIELD.NAME_T] + " " + fields[(int)NID_FIELD.MIDNAME_T] + " ";
                    txtPttLName.Value = fields[(int)NID_FIELD.SURNAME_T];
                    txtPttNameE.Value = fields[(int)NID_FIELD.TITLE_E] + " " + fields[(int)NID_FIELD.NAME_E] + " " + fields[(int)NID_FIELD.MIDNAME_E] + " ";
                    txtPttLNameE.Value = fields[(int)NID_FIELD.SURNAME_E];
                    //txtAddrNo.Value = fields[(int)NID_FIELD.HOME_NO];
                    //txtMoo.Value = fields[(int)NID_FIELD.MOO];
                    txtRoad.Value = fields[(int)NID_FIELD.HOME_NO]+" "+ fields[(int)NID_FIELD.MOO] + " "+fields[(int)NID_FIELD.TROK] + " " + fields[(int)NID_FIELD.SOI] + " " + fields[(int)NID_FIELD.ROAD] + " " + fields[(int)NID_FIELD.TUMBON] + " " + fields[(int)NID_FIELD.AMPHOE] + " " + fields[(int)NID_FIELD.PROVINCE];
                    if (dob.Length >= 8)
                    {
                        dob = dob.Substring(0, 4) + "-" + dob.Substring(4, 2) + "-" + dob.Substring(dob.Length - 2);
                        //txtDob.Value = dob;
                    }
                    //cboSex.SelectedIndex = 1;
                    //cboPrefix.Text = "Mr.";
                    byte[] NIDPicture = new byte[1024 * 5];
                    int imgsize = NIDPicture.Length;
                    res = RDNID.getNIDPhotoRD(obj, NIDPicture, out imgsize);
                    if (res != DefineConstants.NID_SUCCESS)
                        return res;

                    byte[] byteImage = NIDPicture;
                    if (byteImage == null)
                    {
                        MessageBox.Show("Read Photo error");
                    }
                    else
                    {
                        //m_picPhoto
                        Image img = Image.FromStream(new MemoryStream(byteImage));
                        //Bitmap MyImage = new Bitmap(img, m_picPhoto.Width - 2, m_picPhoto.Height - 2);
                        Bitmap MyImage = new Bitmap(img, picPID.Width - 2, picPID.Height - 2);
                        //m_picPhoto.Image = (Image)MyImage;
                        picPID.Image = (Image)MyImage;
                        //setControlDonor("", txtPid.Text);
                        //if (txtID.Text.Equals(""))
                        //{
                        //img.Save(picIDCard, ImageFormat.Jpeg);
                        //flagReadCard = true;
                        //}
                    }
                }

                RDNID.disconnectCardRD(obj);
                RDNID.deselectReaderRD(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReadCard " + ex.Message, "");
            }

            return 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtMobile.Focus();
            label1.Text = "Last Update 2018-12-17";
            String chk = "", printerDefault = "";
            try
            {
                PrinterSettings settings = new PrinterSettings();
                int i = 0, chk1=0;
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    settings.PrinterName = printer;
                    cboPrinter.Items.Insert(i, printer);
                    if (settings.IsDefaultPrinter)
                    {
                        printerDefault = printer;
                        chk1 = i;
                    }
                        
                    i++;
                }
                PrinterSettings settings1 = new PrinterSettings();
                cboPrinter.SelectedIndex = chk1;
                //settings1.PrinterName = ;

            }
            catch (Exception ex)
            {
                chk = ex.Message.ToString();
            }
            tC.SelectedTab = tab1;
            tC.ShowTabs = false; 
            pic1Back.Hide();
            pic1Next.Hide();
            pic2Back.Hide();
            pic2Next.Hide();
            pic3Back.Hide();
            pic3Next.Hide();
            pic4Back.Hide();
            pic4Next.Hide();
            if (mposC.iniC.statusHide.Equals("1"))
            {
                btnReadCard.Hide();
            }
            //
        }
    }
}
