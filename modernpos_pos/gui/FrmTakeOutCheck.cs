using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using modernpos_pos.control;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;

namespace modernpos_pos.gui
{
    public partial class FrmTakeOutCheck : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1FlexGrid grf;

        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;

        List<Order1> lOrd;

        int colNo = 1, colFooName = 2, colPrice = 3, colQty = 4, colRemark = 5, colStatus = 6, colFooId = 7, colPrinterName = 8;
        Timer timer, timerOnLine;
        public enum VNECommand { Payment = 1, PollingStatusPayment = 2, DeletePendingPayment = 3, ListPendingPayment = 5 };
        String webapi = "/selfcashapi/", txtAmt= "จำนวนเงินต้องชำระ";

        int cntClick = 0;

        public FrmTakeOutCheck(mPOSControl x, List<Order1> lOrd)
        {
            InitializeComponent();
            mposC = x;
            this.lOrd = lOrd;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;

            vneRspPay = new VNEresponsePayment();
            vnePRepd = new VNEPaymentPollingResponsePaymentDetail();

            lbAmt.Text = "";
            lbStatus.Text = "";
            //theme1.SetTheme(sB, "BeigeOne");
            //foreach (Control c in panel3.Controls)
            //{
            //    theme1.SetTheme(c, "Office2013Red");
            //}
            btnPay.Click += BtnPay_Click;
            btnVoidPay.Click += BtnVoidPay_Click;
            lbAmt.Click += LbAmt_Click;

            bg = txtTableCode.BackColor;
            fc = txtTableCode.ForeColor;
            ff = txtTableCode.Font;

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Enabled = false;
            btnVoidPay.Enabled = false;
            pnVoidPay.Hide();
            btnVoidPay.Hide();

            initGrf();
            setGrf();
        }

        private void LbAmt_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            cntClick++;
            if (cntClick == 5)
            {
                cntClick = 0;
                tC.ShowTabs = true;
            }
        }

        private void BtnVoidPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "";
            if (MessageBox.Show("ต้องการ ลบ Payment ID " + vneRspPay.id, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    String statuspay = "";
                    statuspay = chkPayBefore.Checked ? "1" : "2";
                    statuspay = chkPaypaying.Checked ? "1" : "2";
                    VNEPaymentPendingDeleteRequest vnepdreq = new VNEPaymentPendingDeleteRequest();
                    vnepdreq.id = vneRspPay.id;
                    vnepdreq.opName = "admin";
                    vnepdreq.tipo = "3";
                    //vnepdreq.tipo_annullamento = statuspay+"/2";
                    vnepdreq.tipo_annullamento = statuspay;
                    var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
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
                    String status = obj.payment_status;
                    if (status.Equals("1"))
                    {
                        //MessageBox.Show("ทำการยกเลิก รับชำระเงิน เรียบร้อย", "");
                        lbStatus.Text = "ยกเลิก รับชำระเงิน เรียบร้อย";
                        timer.Stop();
                        pnVoidPay.Hide();
                    }
                    
                    //cboPpl.Text = "";
                    //BtnListPayment_Click(null, null);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(err + " " + ex.Message);
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            
            String err = "00";
            //throw new NotImplementedException();
            btnVoidPay.Enabled = true;
            pnVoidPay.Show();
            btnVoidPay.Show();
            listBox1.Items.Add("vneRspPay.id " + vneRspPay.id);
            VNEPaymentPollingRequest vnePpReq = new VNEPaymentPollingRequest();
            vnePRepd = new VNEPaymentPollingResponsePaymentDetail();
            vnePpReq.tipo = "2";
            vnePpReq.id = vneRspPay.id;
            vnePpReq.opName = "admin";
            try
            {
                lbStatus.Text = "สถานะ รอการชำระเงิน";
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
                err = "01";
                var response = http.GetResponse();
                err = "02";
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                vnePRep = new VNEPaymentPollingResponse();
                dynamic obj = JsonConvert.DeserializeObject(content);
                err = "03";
                listBox1.Items.Add("รอรับชำระ content " + content);
                vnePRep.id = obj.id;
                vnePRep.req_status = obj.req_status;
                vnePRep.tipo = obj.tipo;
                vnePRep.payment_status = obj.payment_status;
                //vnePRep.payment_detail = obj.payment_details.toString();
                err = "04";
                String aaa = String.Concat(obj.payment_details);
                err = "05";
                dynamic obj1 = JsonConvert.DeserializeObject(aaa);
                err = "06";
                vnePRepd.amount = obj1.amount;
                vnePRepd.inserted = obj1.inserted;
                vnePRepd.rest = obj1.rest;
                vnePRepd.status = obj1.status;
                listBox1.Items.Add("content vnePRepd " + aaa);
                err = "07";
                //listBox1.Items.Add("รอรับชำระ " + vnePpReq.id);
                //label10.Text = "ID " + vnePRep.id + " amount " + vnePRepd.amount + " status " + vnePRepd.status;
                //listBox1.Items.Add(content);
                if (vnePRepd.status.Equals("completed"))
                {
                    timer.Stop();
                    printBill();
                    lbStatus.Text = "รับชำระเรียบร้อย ";
                    Close();
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //MySqlConnection conn;
            //VNEresponsePayment vneRspPay;
            
            //lbStatus.Text = "สถานะ รอการชำระเงิน";
            String err = "", sql="";
            try
            {
                err = "00";
                var baseAddress = "http://" + mposC.iniC.VNEip + mposC.iniC.VNEwebapi;
                VNErequestPayment vne = new VNErequestPayment();
                vne.tipo = "1";
                vne.importo = lbAmt.Text.Replace(txtAmt, "").Replace(".", "").Trim();
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
                listBox1.Items.Add("Host "+ http.Host+ "  VNEwebapi "+ mposC.iniC.VNEwebapi);
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
                listBox1.Items.Add("VNE response " + vneRspPay.id);
                cboRsp.Text = vneRspPay.id;
                //vneRspPay = (VNEresponsePayment)JsonConvert.DeserializeObject(content);
                err = "06";
                sql = "Insert Into vne_response_payment Set " +
                    "id='" + vneRspPay.id + "'" +
                    ",importo='" + vneRspPay.importo + "'" +
                    ",tipo='" + vneRspPay.tipo + "'" +
                    ",req_status='" + vneRspPay.importo + "'" +
                    ",active='1'" +
                    ",date_Create=now()" +
                    ",user_create='" + vne.opname + "'"
                    ;
                //MySqlCommand com = new MySqlCommand();
                //com.CommandText = sql;
                //com.CommandType = CommandType.Text;
                //com.Connection = mposC.conn.conn;
                
                //conn.Open();
                String chk = "";
                try
                {
                    //chk = com.ExecuteNonQuery();
                    chk = mposC.conn.ExecuteNonQuery(mposC.conn.conn, sql);
                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(err + " " + ex.Message);
                }
                
                //conn.Close();
                //com.Dispose();
                timer.Enabled = true;
                timer.Start();
                //label9.Text = "Start waiting payment";
                int dd = 0;
                if(int.TryParse(chk,out dd))
                {
                    listBox1.Items.Add("insert payment OK");
                    Order1 ord = new Order1();
                    String lot = ord.getGenID();
                    foreach (Order1 row in lOrd)
                    {
                        ord = new Order1();
                        ord.order_id = row.order_id;
                        ord.lot_id = row.lot_id;
                        ord.res_id = "";
                        ord.host_id = "";
                        ord.device_id = mposC.MACAddress;
                        ord.branch_id = "";
                        ord.foods_id = row.foods_id;
                        ord.foods_name = row.foods_name;
                        ord.price = row.price;
                        ord.qty = row.qty;
                        ord.remark = row.remark;
                        ord.row1 = row.row1;
                        ord.printer_name = row.printer_name;
                        ord.status_bill = row.status_bill;
                        ord.table_id = mposC.tableidToGo;
                        mposC.mposDB.ordDB.insertOrder(ord, "");
                    }
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }

        private void initGrf()
        {
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grf.Rows.Count = 1;
            grf.Cols.Count = 8;
            grf.Cols[colNo].Width = 40;
            grf.Cols[colFooName].Width = 300;
            grf.Cols[colPrice].Width = 80;
            //FilterRow fr = new FilterRow(grfExpn);
            grf.TabStop = false;
            grf.EditOptions = EditFlags.None;
            grf.Cols[colNo].AllowEditing = false;
            grf.Cols[colFooName].AllowEditing = false;
            grf.Cols[colPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grf.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            
            grf.SubtotalPosition = SubtotalPositionEnum.BelowData;            
            
            pnBill.Controls.Add(grf);
            grf.Cols[colFooId].Visible = false;
            grf.Cols[colStatus].Visible = false;
            grf.Cols[colQty].Visible = false;
            
            pnBill.Width = mposC.panel1Width+130;
            //theme.SetTheme(grf, "Office2010Blue");

        }
        private void setGrf()
        {
            //String re = "";
            if (lOrd.Count>0)
            {
                foreach(Order1 ord in lOrd)
                {
                    Row row = grf.Rows.Add();
                    row[colFooName] = ord.foods_name;
                    row[colPrice] = ord.price;
                    row[colFooId] = ord.foods_id;
                    row[colRemark] = ord.remark;
                    row[colNo] = grf.Rows.Count - 2;
                    
                }
                //String[] ext = name.Split('#');
                UpdateTotals();
                lbAmt.Text = "";
                lbStatus.Text = "";
                String amt = "";
                try
                {
                    amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                    Decimal amt1 = 0;
                    Decimal.TryParse(amt, out amt1);

                    lbAmt.Text = txtAmt+" " +amt1.ToString("0.00");
                }
                catch (Exception ex)
                {

                }
                
            }
        }
        private void UpdateTotals()
        {
            // clear existing totals
            grf.Subtotal(AggregateEnum.Clear);
            grf.Subtotal(AggregateEnum.Sum, 0, -1, colPrice, "Grand Total");

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //This part sets up the data to be printed
            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            //gets the text from the textbox
            String stringToPrint = "";
            string printText = "";
            String RECEIPT = Environment.CurrentDirectory + "\\comprovante.txt";
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
            String amt = "";
            Decimal amt1 = 0;
            try
            {
                amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                
                Decimal.TryParse(amt, out amt1);

                //lbAmt.Text = "จำนวนเงินต้องชำระ " + amt1.ToString("0.00");
            }
            catch (Exception ex)
            {

            }
            stringToPrint = "เวลา " + date + Environment.NewLine;
            //stringToPrint += "" + textBox1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp2.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp3.Text + Environment.NewLine;
            //stringToPrint += "โต๊ะ   " + txtDesk.Text + Environment.NewLine;
            //Makes the file to print and sets the look of it
            int i = 1;
            foreach (Order1 ord in lOrd)
            {
                printText += i.ToString() + "  " + ord.foods_name + "  " + ord.qty + "  " + ord.price + Environment.NewLine;
                printText += "          " + ord.remark + Environment.NewLine;
                i++;
            }
            stringToPrint += printText;
            stringToPrint += Environment.NewLine;
            stringToPrint += "         จำนวนเงิน "+ amt1.ToString("0.00") +  Environment.NewLine;
            g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);


        }
        private void printBill()
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer
            document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
            document.Print();
        }
        private void FrmTakeOutCheck_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tab1;
            tC.ShowTabs = false;
        }
    }
}
