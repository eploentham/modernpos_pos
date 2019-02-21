using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Form4 : Form
    {
        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;

        Timer timer, timerOnLine;
        public enum VNECommand {Payment=1, PollingStatusPayment=2,DeletePendingPayment=3, ListPendingPayment=5 };
        String webapi = "/selfcashapi/";
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
            btnConnect.Invoke(new EventHandler(delegate
            {
                btnConnect.Enabled = msg;
            }));
        }
        public Form4()
        {
            InitializeComponent();
            initConfig();
        }
        private void initConfig()
        {
            int timerOnline = 5;
            int.TryParse(txtTimerOnLine.Text, out timerOnline);
            vneC = new VNEControl();

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Enabled = false;

            timerOnLine = new Timer();
            timerOnLine.Interval = timerOnline*1000;
            timerOnLine.Tick += TimerOnLine_Tick;
            timerOnLine.Enabled = false;

            vneRspPay = new VNEresponsePayment();
            vnePRep = new VNEPaymentPollingResponse();
            vnePRepd = new VNEPaymentPollingResponsePaymentDetail();

            ComboBoxItem item = new ComboBoxItem();
            item.Value = "1";
            item.Text = "Payment";
            cboCommand.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "2";
            item.Text = "Pooling to Check the status of the Payment";
            cboCommand.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "3";
            item.Text = "Delete pending payment";
            cboCommand.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "5";
            item.Text = "List of pending payments";
            cboCommand.Items.Add(item);
            item = new ComboBoxItem();
            item.Value = "10";
            item.Text = "Operator withdrawal request";
            cboCommand.Items.Add(item);
            label9.Text = "";
            label10.Text = "";

            txtCloseDay.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            txtPaymentStartDate.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");
            txtPaymentEndDate.Text = DateTime.Now.Year + "-" + DateTime.Now.ToString("MM-dd");

            btnConnect.Click += BtnConnect_Click;
            btnListPayment.Click += BtnListPayment_Click;
            btnDelPay.Click += BtnDelPay_Click;
            btnCloseDay.Click += BtnCloseDay_Click;
            txtTimerOnLine.TextChanged += TxtTimerOnLine_TextChanged;
            txtTimerOnLine.KeyPress += TxtTimerOnLine_KeyPress;
            btnStacker.Click += BtnStacker_Click;
            btnDoorOpen.Click += BtnDoorOpen_Click;
            txtWaitTime.KeyPress += TxtWaitTime_KeyPress;
            btnPayment.Click += BtnPayment_Click;
            btnRestart.Click += BtnRestart_Click;
            btnShutdown.Click += BtnShutdown_Click;
            //cboPpl.SelectedValueChanged += CboPpl_SelectedValueChanged;

            //cboCommand.Items.Insert(0, "");
            //cboCommand.Items.Insert(1, "Payment");
            //cboCommand.Items.Insert(2, "Pooling to Check the status of the Payment");
            //cboCommand.Items.Insert(3, "Delete pending payment");
            //cboCommand.Items.Insert(5, "List of pending payments");
            //cboCommand.Items.Insert(10, "Operator withdrawal request");
            //cboCommand.Items.Insert(11, "Polling ot check the status of the operator withdrawal");
            //cboCommand.Items.Insert(12, "End of operatoe withdrawal");
            //cboCommand.Items.Insert(20, "");
            //cboCommand.Items.Insert(30, "");
            //cboCommand.Items.Insert(31, "");
            //cboCommand.Items.Insert(40, "");
            int i = 0;
            timerOnLine.Start();
        }

        private void BtnShutdown_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNERestartRequest vneR = new VNERestartRequest();
            VNERestartResponse vneRep = new VNERestartResponse();
            try
            {
                vneR.restart = "0";
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneR, Formatting.Indented);
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
                vneRep = new VNERestartResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneRep.req_status = obj.req_status;
                if (vneRep.req_status.Equals("1"))
                {
                    label24.Text = "Restart OK";
                }
                else
                {
                    label24.Text = "error";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnRestart_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNERestartRequest vneR = new VNERestartRequest();
            VNERestartResponse vneRep = new VNERestartResponse();
            try
            {
                vneR.restart = "1";
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneR, Formatting.Indented);
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
                vneRep = new VNERestartResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneRep.req_status = obj.req_status;
                if (vneRep.req_status.Equals("1"))
                {
                    label24.Text = "Restart OK";
                }
                else
                {
                    label24.Text = "error";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnPayment_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNEPaymentListRequest vneplr = new VNEPaymentListRequest();
            VNEPaymentListResponse vneplres = new VNEPaymentListResponse();
            try
            {
                long datestartU = ((DateTimeOffset) txtPaymentStartDate.Value).ToUnixTimeSeconds();
                long dateendU = ((DateTimeOffset)txtPaymentEndDate.Value).ToUnixTimeSeconds();
                vneplr.start_date = datestartU.ToString();
                vneplr.end_date = dateendU.ToString();
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneplr, Formatting.Indented);
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
                vneplres = new VNEPaymentListResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneplres.tipo = obj.tipo;
                vneplres.req_status = obj.req_status;
                JArray aa = new JArray();
                aa = obj.payments;
                //String aaaa = obj.payments;
                //vneplres.payments = obj.payments;
                if (aa.Count>0)
                {
                    VNEPaymentListResponseDetail vneplresd = new VNEPaymentListResponseDetail();
                    String aaa = String.Concat(obj.payments);
                    dynamic obj1 = JsonConvert.DeserializeObject(String.Concat(obj.aaa));
                    foreach (var item11 in aaa)
                    {

                    }
                }
            }
            catch(Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }

        private void TxtWaitTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void BtnDoorOpen_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNEDoorOpenRequest vneDor = new VNEDoorOpenRequest();
            VNEDoorOpenResponse vneDorep = new VNEDoorOpenResponse();
            try
            {
                vneDor.wait_timeout = txtWaitTime.Text;
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneDor, Formatting.Indented);
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
                vneDorep = new VNEDoorOpenResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneDorep.req_status = obj.req_status;
                if (vneDorep.req_status.Equals("1"))
                {
                    label24.Text = "Door Open OK";
                }
                else
                {
                    label24.Text = "error";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnStacker_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNEStackerCancelRequest vneScr = new VNEStackerCancelRequest();
            VNEStackerCancelResponse vneScrep = new VNEStackerCancelResponse();
            try
            {
                vneScr.peripheral = chkStackerBank.Checked ? "1" : chkStackerCoin.Checked ? "0" : chkStarkerAll.Checked ? "2" : "";
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneScr, Formatting.Indented);
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
                vneScrep = new VNEStackerCancelResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneScrep.req_status = obj.req_status;
                if (vneScrep.req_status.Equals("1"))
                {
                    label23.Text = "Reset OK";
                }
                else
                {
                    label23.Text = "error";
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void TxtTimerOnLine_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
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

        private void BtnCloseDay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err = "";
            VNECashClosingRequest vneccr = new VNECashClosingRequest();
            VNECashClosingResponse vneccres = new VNECashClosingResponse();
            MySqlConnection conn;
            conn = new MySqlConnection();
            conn.ConnectionString = "Server=" + txthostDB.Text + ";Database=" + txtnameDB.Text + ";Uid=" + txtuserDB.Text + ";Pwd=" + txtpassDB.Text +
                ";port = " + txtportDB.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";
            try
            {
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vneccr, Formatting.Indented);
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
                vneccres = new VNECashClosingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);

                vneccres.tipo = obj.tipo;
                vneccres.req_status = obj.req_status;
                vneccres.total_in = obj.total_in;
                vneccres.total_out = obj.total_out;
                vneccres.total_payments = obj.total_payments;
                vneccres.total_operator_in = obj.total_operator_in;
                vneccres.total_operator_out = obj.total_operator_out;
                vneccres.total_content = obj.total_content;
                vneccres.date = obj.date;
                vneccres.date_start = obj.date_start;
                Double chk = 0;
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                Double.TryParse(vneccres.date, out chk);
                dtDateTime = dtDateTime.AddSeconds(chk).ToLocalTime();
                DateTime dtStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                Double.TryParse(vneccres.date_start, out chk);
                dtStartDateTime = dtDateTime.AddSeconds(chk).ToLocalTime();
                String date1 = "", datestart = "";
                date1 = dtDateTime.Year.ToString() + "-" + dtDateTime.ToString("MM-dd");
                datestart = dtStartDateTime.Year.ToString() + "-" + dtStartDateTime.ToString("MM-dd");
                sql = "Insert Into vne_close_day Set " +
                    "req_status='" + vneccres.req_status + "'" +
                    ",total_in='" + vneccres.total_in + "'" +
                    ",total_out='" + vneccres.total_out + "'" +
                    ",total_payments='" + vneccres.total_payments + "'" +
                    ",total_operator_in='" + vneccres.total_operator_in + "'" +
                    ",total_operator_out='" + vneccres.total_operator_out + "'" +
                    ",total_content='" + vneccres.total_content + "'" +
                    ",date1='" + vneccres.date + "'" +
                    ",date_start='" + vneccres.date_start + "'" +
                    ",date11='" + date1 + "'" +
                    ",date_start1='" + datestart + "'" +
                    ",active='1'" +
                    ",date_Create=now()" +
                    ",user_create='" + vneccr.opName + "'"
                    ;
                MySqlCommand com = new MySqlCommand();
                com.CommandText = sql;
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                conn.Open();
                int chk1 = com.ExecuteNonQuery();
                conn.Close();
                com.Dispose();
                txtDate.Text = date1;
                txtDateStart.Text = datestart;
                txtTotalIn.Text = vneccres.total_in;
                txtTotalOut.Text = vneccres.total_out;
                txtPayment.Text = vneccres.total_payments;
                txtTotalOperIn.Text = vneccres.total_operator_in;
                txtTotalOperOut.Text = vneccres.total_operator_out;
                txtTotalContent.Text = vneccres.total_content;
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
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

                    var baseAddress = "http://" + txtVNEip.Text + webapi;
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
                    listBox1.Items.Add(err + " " + ex.Message);
                }
                btnC(true);
            }).Start();
        }

        private void setControlEnable(Boolean flag)
        {
            btnListPayment.Enabled = flag;
            cboPpl.Enabled = flag;
            panel1.Enabled = flag;
            btnDelPay.Enabled = flag;
            //btnListPayment.Enabled = false;
        }
        private void BtnDelPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlEnable(false);
            String err = "";
            if (MessageBox.Show("ต้องการ ลบ Payment ID "+cboPpl.Text,"",MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    String statuspay = "";
                    statuspay = chkPayBefore.Checked ? "1" : "2";
                    statuspay = chkPaypaying.Checked ? "1" : "2";
                    VNEPaymentPendingDeleteRequest vnepdreq = new VNEPaymentPendingDeleteRequest();
                    vnepdreq.id = cboPpl.Text;
                    vnepdreq.opName = "admin";
                    vnepdreq.tipo = "3";
                    //vnepdreq.tipo_annullamento = statuspay+"/2";
                    vnepdreq.tipo_annullamento = statuspay;
                    var baseAddress = "http://" + txtVNEip.Text + webapi;
                    String txtjson = JsonConvert.SerializeObject(vnepdreq, Formatting.Indented);
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
                    listBox1.Items.Add(txtjson);
                    var response = http.GetResponse();

                    var stream = response.GetResponseStream();
                    var sr = new StreamReader(stream);
                    var content = sr.ReadToEnd();

                    listBox1.Items.Add(content);
                    dynamic obj = JsonConvert.DeserializeObject(content);
                    cboPpl.Text = "";
                    BtnListPayment_Click(null, null);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(err + " " + ex.Message);
                }
            }
            setControlEnable(true);
        }

        private void BtnListPayment_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            setControlEnable(false);
            String err = "";
            VNEPaymentPendingListRequest vnePplReq = new VNEPaymentPendingListRequest();
            VNEPaymentPendingListResponse vnePplRes = new VNEPaymentPendingListResponse();
            vnePplReq.tipo = "5";
            vnePplReq.opName = "admin";
            try
            {
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                String txtjson = JsonConvert.SerializeObject(vnePplReq, Formatting.Indented);
                WebClient webClient = new WebClient();
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";
                ASCIIEncoding encoding = new ASCIIEncoding();
                listBox1.Items.Add(txtjson);
                Byte[] bytes = encoding.GetBytes(txtjson);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();

                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                listBox1.Items.Add(content);
                vnePRep = new VNEPaymentPollingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);

                vnePplRes.tipo = obj.tipo;
                vnePplRes.list_length = obj.list_length;
                //vnePplRes.pending_list = obj.pending_list;
                if (vnePplRes.tipo.Equals("5"))
                {
                    VNEPaymentPendingListResponseDetail vnePplResd = new VNEPaymentPendingListResponseDetail();
                    dynamic obj1 = JsonConvert.DeserializeObject(String.Concat(obj.pending_list));
                    vnePplResd.id = obj1.id;
                    //vnePplResd.pending_list = obj1.pending_list;
                    String aaa = String.Concat(obj.pending_list);
                    cboPpl.Items.Clear();
                    vneC.setCboPaymentPendingList(cboPpl, vnePplRes.list_length, aaa);

                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
            setControlEnable(true);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            String err = "";
            //throw new NotImplementedException();
            VNEPaymentPollingRequest vnePpReq = new VNEPaymentPollingRequest();
            vnePpReq.tipo = "2";
            vnePpReq.id = vneRspPay.id;
            vnePpReq.opName = "admin";
            try
            {
                var baseAddress = "http://" + txtVNEip.Text + webapi;
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

                vnePRepd.amount = obj1.amount;
                vnePRepd.inserted = obj1.inserted;
                vnePRepd.rest = obj1.rest;
                vnePRepd.status = obj1.status;

                label10.Text = "ID "+ vnePRep.id+" amount "+ vnePRepd.amount+" status "+ vnePRepd.status;
                listBox1.Items.Add(content);
                if (vnePRepd.status.Equals("complete"))
                {
                    timer.Stop();
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }
        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String sql = "", err="";
            MySqlConnection conn;
            conn = new MySqlConnection();
            conn = new MySqlConnection();
            conn = new MySqlConnection();
            conn = new MySqlConnection();

            conn.ConnectionString = "Server=" + txthostDB.Text + ";Database=" + txtnameDB.Text + ";Uid=" + txtuserDB.Text + ";Pwd=" + txtpassDB.Text +
                ";port = " + txtportDB.Text + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";
            try
            {
                err = "00";
                var baseAddress = "http://" + txtVNEip.Text + webapi;
                VNErequestPayment vne = new VNErequestPayment();
                vne.tipo = "1";
                vne.importo = txtAmount.Text;
                vne.opname = "admin";
                vne.operatore = "";
                String txtjson = JsonConvert.SerializeObject(vne, Formatting.Indented);
                listBox1.Items.Add(txtjson);
                err = "01";
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
                err = "02";
                var response = http.GetResponse();
                err = "03";
                var stream = response.GetResponseStream();
                err = "04";
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                err = "05";
                listBox1.Items.Add(content);
                vneRspPay = new VNEresponsePayment();
                dynamic obj = JsonConvert.DeserializeObject(content);
                vneRspPay.id = obj.id;
                vneRspPay.importo = obj.importo;
                vneRspPay.tipo = obj.tipo;
                vneRspPay.req_status = obj.req_status;
                //vneRspPay = (VNEresponsePayment)JsonConvert.DeserializeObject(content);
                err = "06";
                sql = "Insert Into vne_response_payment Set " +
                    "id='"+ vneRspPay.id+"'"+
                    ",importo='" + vneRspPay.importo + "'"+
                    ",tipo='" + vneRspPay.tipo + "'"+
                    ",req_status='" + vneRspPay.importo + "'"+
                    ",active='1'"+
                    ",date_Create=now()"+
                    ",user_create='" + vne.opname + "'" 
                    ;
                MySqlCommand com = new MySqlCommand();
                com.CommandText = sql;
                com.CommandType = CommandType.Text;
                com.Connection = conn;
                conn.Open();
                int chk = com.ExecuteNonQuery();
                conn.Close();
                com.Dispose();
                timer.Enabled = true;
                timer.Start();
                label9.Text = "Start waiting payment";
                listBox1.Items.Add("insert payment OK");
            }
            catch(Exception ex)
            {
                listBox1.Items.Add(err+" "+ex.Message);
            }
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
