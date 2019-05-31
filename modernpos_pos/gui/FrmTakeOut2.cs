using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using C1.Win.C1Tile;
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
using System.Threading.Tasks;
using System.Windows.Forms;
namespace modernpos_pos.gui
{
    public partial class FrmTakeOut2 : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1,fgrd;

        Color bg, fc, tilecolor;
        Font ff, ffB;

        Boolean flagEdit = false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        public List<Foods> lfooT;
        public List<Foods> lfooR;
        Foods foo;
        //Theme theme1;

        PanelElement peOrd, peSpec, peSpecName, peTopping;
        ImageElement ieOrd, ieSpec, ieSpec8, ieTopping, ieTopping8;
        TextElement teOrd, teOrdFoodsName, teOrdFoodsPrice, teSpec, teSpecName, teTopping;

        Template tempFlickr, tempSpec, tempTopping, tempDrink;
        ImageElement imageElement8, imageElementDrink;
        PanelElement pnFoodsName, pnFoodsPrice, pnElementDrink, pnElementPrice;
        C1FlexGrid grfOrder, grfSpec, grfTopping, grfBill;
        C1DockingTab tC;

        VNEControl vneC;
        VNEresponsePayment vneRspPay;
        VNEPaymentPollingResponse vnePRep;
        VNEPaymentPollingResponsePaymentDetail vnePRepd;
        int colOrdNo = 1, colOrdFooName = 2, colOrdPrice = 3, colOrdQty = 5, colOrdqtyplus=6, colOrdqtyminus=4, colOrdRemark = 7, colOrdTopping = 8, colOrdArrowDown=9, colOrdThrumb=10, colOrdStatus = 11, colOrdFooId =12, colOrdPrinterName = 13, colOrdFooName1 = 14;
        int colSNo = 1, colSImg = 2, colSFoosName = 3, colSStatus = 4;
        int colTNo = 1, colTImg = 2, colTFoosName = 3, colTPrice = 4, colTStatus = 5;
        int colBNo = 1, colBFooName = 2, colBPrice = 3, colBQty = 4, colBRemark = 5, colBStatus = 6, colBFooId = 7, colBPrinterName = 8;

        List<Order1> lOrd;
        List<FoodsSpecial> lFoos;
        List<FoodsTopping> lFoot;
        Order1 ord;
        DataTable dtCat = new DataTable();
        DataTable dtRec = new DataTable();
        IntPtr intptr = new IntPtr();
        C1DockingTabPage[] tabPage;
        C1TileControl[] TileFoods;
        C1TileControl TileRec, TileSpec, TileTopping, TileDrink;
        Group[] gr1;
        Group grRec, grSpec, grDring;
        Boolean flagModi = false, flagShowTitle=false;
        Image imgR, imgC;
        String fooid = "", fooSpec = "", fooTopping = "";
        Form frmmain;

        Timer timer, timerOnLine;
        public enum VNECommand { Payment = 1, PollingStatusPayment = 2, DeletePendingPayment = 3, ListPendingPayment = 5 };
        String webapi = "/selfcashapi/", txtAmt = "จำนวนเงินต้องชำระ";
        Order1 ord1;
        int iprn = 1;
        Image imgMinus, imgPlus, imgArrowDown, imgAdd, imgThumb;
        private string _tip = "";

        public FrmTakeOut2(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {
            //MessageBox.Show("FrmTakeOut initConfig 1", "");
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 5, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);
            fEdit1 = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize +5, FontStyle.Regular + 2);
            fgrd = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize + 15, FontStyle.Regular);

            C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = C1ThemeController.ApplicationTheme;
            //theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                theme1.SetTheme(c, "Office2013Red");
            }
            try
            {
                tilecolor = ColorTranslator.FromHtml(mposC.iniC.TileFoodsBackColor);
            }
            catch (Exception ex)
            {

            }
            stt = new C1SuperTooltip();
            _tip = @"<table><tr>
              <td><parm><img src='minus_red.png'></parm></td>
              <td><b><parm>This is a SuperTooltip</parm></b></td></tr>
            </table>
            <parm><hr noshade size=1 style='margin:2' color=Darker></parm>
            <div style='margin:1 12'><parm>
              This tooltip is associated with cell (row,col).<br>
            You can show it as a balloon or as a regular<br>
            tooltip.
            </parm></div>
            <parm><hr noshade size=1 style='margin:2' color=Darker></parm>
            <table><tr>
              <td><parm></parm></td>
              <td><b><parm>enjoy your SuperTooltip today!</parm></b></td></tr>
            <tr><td><parm></parm></td><td><b><parm>enjoy your SuperTooltip today!</parm></b></td></tr>
            </table>";

            bg = txtTableCode.BackColor;
            fc = txtTableCode.ForeColor;
            ff = txtTableCode.Font;
            //MessageBox.Show("FrmTakeOut initConfig 2", "");
            lfooT = new List<Foods>();
            lfooR = new List<Foods>();
            lOrd = new List<Order1>();
            lFoos = new List<FoodsSpecial>();
            lFoot = new List<FoodsTopping>();
            foo = new Foods();
            ord = new Order1();
            lfooT = mposC.mposDB.fooDB.getlFoods1();
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();
            imgMinus = Resources.minus_red_100;
            imgPlus = Resources.plus_green_100;
            imgArrowDown = Resources.arrow_down_100;
            imgAdd = Resources.minus_cir_red_100;
            imgThumb = Resources.recycle_bin_50;
            int originalWidth = imgMinus.Width;
            int newWidth = 25;
            imgMinus = imgMinus.GetThumbnailImage(newWidth, (newWidth * imgMinus.Height) / originalWidth, null, IntPtr.Zero);
            originalWidth = imgPlus.Width;
            imgPlus = imgPlus.GetThumbnailImage(newWidth, (newWidth * imgPlus.Height) / originalWidth, null, IntPtr.Zero);
            originalWidth = imgArrowDown.Width;
            imgArrowDown = imgArrowDown.GetThumbnailImage(newWidth, (newWidth * imgArrowDown.Height) / originalWidth, null, IntPtr.Zero);
            //originalWidth = imgAdd.Width;
            //imgAdd = imgAdd.GetThumbnailImage(newWidth, (newWidth * imgAdd.Height) / originalWidth, null, IntPtr.Zero);

            btnVoid.Enabled = false;
            //MessageBox.Show("FrmTakeOut initConfig 3", "");
            if (mposC.iniC.pnOrderborderstyle.Equals("0"))
            {
                pnOrder1.BorderStyle = BorderStyle.None;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("1"))
            {
                pnOrder1.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (mposC.iniC.pnOrderborderstyle.Equals("2"))
            {
                pnOrder1.BorderStyle = BorderStyle.FixedSingle;
            }
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Enabled = false;

            btnPay.Click += BtnPay_Click;
            btnVoid.Click += BtnVoid_Click;
            btnSpec.Click += BtnSpec_Click;
            btnReturn.Click += BtnReturn_Click;
            //btnTopping.Click += BtnTopping_Click;
            btnVoidAll.Click += BtnVoidAll_Click;
            //spMain.SplitterMoved += SpMain_SplitterMoved;
            pnOrder.Resize += PnOrder_Resize;
            btnBillCheck.Click += BtnBillCheck_Click;
            btnVoidPay.Click += BtnVoidPay_Click;

            imgR = Resources.red_checkmark_png_16;
            //MessageBox.Show("FrmTakeOut initConfig", "");
            initGrfOrder();
            //initGrfSpec();
            initTC();
            initSpec();
            initTopping();
            initGrfBill();
            //initGrfTopping();

            flagModi = false;
            setBtnEnable(flagModi);
            this.FormBorderStyle = FormBorderStyle.None;
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
        private void BtnBillCheck_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String err = "", sql = "";
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
                listBox1.Items.Add("Host " + http.Host + "  VNEwebapi " + mposC.iniC.VNEwebapi);
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
                if (int.TryParse(chk, out dd))
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
                    mposC.statusVNEPaysuccess = "1";
                    printOrder();
                    printBill();
                    lbStatus.Text = "รับชำระเรียบร้อย ";
                    if (mposC.statusVNEPaysuccess.Equals("1"))
                    {
                        lOrd.Clear();
                        grfOrder.Dispose();
                        initGrfOrder();
                        if (mposC.iniC.statuspaytoclose.Equals("1"))
                        {
                            Close();
                        }
                    }
                    //Close();
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(err + " " + ex.Message);
            }
        }
        private void printOrder()
        {
            List<String> lprn = new List<String>();
            iprn = 1;
            foreach (Order1 ord in lOrd)
            {
                //String printername = "";
                //printername = ord.printer_name;
                ord1 = ord;
                PrintDocument document = new PrintDocument();
                //MessageBox.Show("ord1.printer_name "+ ord1.printer_name, "");
                document.PrinterSettings.PrinterName = ord1.printer_name;
                document.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                //This is where you set the printer in your case you could use "EPSON USB"
                //or whatever it is called on your machine, by Default it will choose the default printer
                //document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
                document.Print();
                Application.DoEvents();
                iprn++;
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
            String amt = "";
            Decimal amt1 = 0;
            try
            {
                //amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                amt = ord1.price;
                Decimal.TryParse(amt, out amt1);

                //lbAmt.Text = "จำนวนเงินต้องชำระ " + amt1.ToString("0.00");
            }
            catch (Exception ex)
            {

            }
            stringToPrint = mposC.mposDB.copDB.genQueue1Doc() + Environment.NewLine;
            stringToPrint += "เวลา " + date + Environment.NewLine;
            //stringToPrint += "" + textBox1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp1.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp2.Text + Environment.NewLine;
            //stringToPrint += "" + txtTopUp3.Text + Environment.NewLine;
            //stringToPrint += "โต๊ะ   " + txtDesk.Text + Environment.NewLine;
            //Makes the file to print and sets the look of it
            //int i = 1;
            //foreach (Order1 ord in lOrd)
            //{
            //    printText += i.ToString() + "  " + ord.foods_name + "  " + ord.qty + "  " + ord.price + Environment.NewLine;
            //    printText += "          " + ord.remark + Environment.NewLine;
            //    i++;
            //}
            String name = "";
            name = ord1.foods_name;
            ord1.special = ord1.special == null ? "" : ord1.special;
            ord1.topping = ord1.topping == null ? "" : ord1.topping;

            printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;

            String[] txt = ord1.special.Split('+');
            if (txt.Length > 1)
            {
                String name1 = "";
                foreach (String txt1 in txt)
                {
                    name1 += txt1.Trim() + Environment.NewLine;
                }
                name1 = name1.Trim();
                if (name1.IndexOf("+") == 0)
                {
                    name1 = name1.Substring(1, name1.Length - 1);
                }
                //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
                //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
                printText += name1 + Environment.NewLine;

            }
            String[] txtT = ord1.topping.Split('+');
            if (txtT.Length > 1)
            {
                String name1 = "";
                foreach (String txt1 in txtT)
                {
                    name1 += txt1.Trim() + Environment.NewLine;
                }
                name1 = name1.Trim();
                if (name1.IndexOf("+") == 0)
                {
                    name1 = name1.Substring(1, name1.Length - 1);
                }
                //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
                //printText += "         " + ord1.qty + "  " + ord1.price + Environment.NewLine;
                printText += name1 + Environment.NewLine;

            }
            //else
            //{
            //    //printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + "  " + ord1.price + Environment.NewLine;
            //    printText += iprn.ToString() + "  " + ord1.foods_name + "  " + ord1.qty + Environment.NewLine;
            //}
            printText += "          " + ord1.remark + Environment.NewLine;

            stringToPrint += printText;
            stringToPrint += Environment.NewLine;
            stringToPrint += "         จำนวนเงิน " + amt1.ToString("0.00") + Environment.NewLine;
            g.DrawString(stringToPrint, new Font("arial", 16), Brush, 10, 10);

        }
        private void printBill()
        {
            PrintDocument document = new PrintDocument();
            document.PrinterSettings.PrinterName = mposC.iniC.printerBill;
            document.PrintPage += new PrintPageEventHandler(printBill_PrintPage);
            //This is where you set the printer in your case you could use "EPSON USB"
            //or whatever it is called on your machine, by Default it will choose the default printer

            //document.PrinterSettings.PrinterName = ord1.printer_name;
            document.Print();
        }
        private void printBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float marginR = e.MarginBounds.Right;

            //topMargin = 5;
            //leftMargin = 5;
            //marginR = 80;
            float.TryParse(mposC.res.printer_bill_print_left, out leftMargin);
            float.TryParse(mposC.res.printer_bill_print_right, out marginR);
            float.TryParse(mposC.res.printer_bill_print_top, out topMargin);
            float avg = marginR / 2;

            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            String date = "";
            date = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            String amt = "";
            Decimal amt1 = 0;
            float yPos = 0, gap = 6;
            int count = 0;
            string line = null;
            try
            {
                //amt = grf[grf.Rows.Count - 1, colPrice].ToString();
                amt = ord1.price;
                Decimal.TryParse(amt, out amt1);

                //lbAmt.Text = "จำนวนเงินต้องชำระ " + amt1.ToString("0.00");
            }
            catch (Exception ex)
            {

            }
            Pen blackPen = new Pen(Color.Black, 1);
            Image resizedImage;
            int originalWidth = Resources.logo2.Width;
            int newWidth = 100;
            Size proposedSize = new Size(100, 100);
            StringFormat flags = new StringFormat(StringFormatFlags.LineLimit);  //wraps
            Size textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            Int32 xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            Int32 yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?

            resizedImage = Resources.logo2.GetThumbnailImage(newWidth, (newWidth * Resources.logo2.Height) / originalWidth, null, IntPtr.Zero);

            //e.Graphics.DrawImage(Resources.siph2, avg - (Resources.siph2.Width / 2), topMargin);
            e.Graphics.DrawImage(resizedImage, avg - (resizedImage.Width / 2), topMargin);

            count++; count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.res_name;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());leftMargin
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_header1;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_header2;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "Staff : Machine VNE1";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);

            count++; count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = "GOTO";
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            e.Graphics.DrawLine(blackPen, leftMargin - 5, yPos, marginR + 300, yPos);
            int i = 1;
            foreach (Order1 ord in lOrd)
            {
                count++;
                yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
                line = i + ". " + ord.foods_name + " " + ord.qty;
                textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
                xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
                e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
                textSize = TextRenderer.MeasureText(ord.price, fEdit, proposedSize, TextFormatFlags.RightToLeft);
                e.Graphics.DrawString(ord.price, fEdit, Brushes.Black, marginR - textSize.Width - gap - 5, yPos, flags);
                if ((ord.special != null) && !ord.special.Equals(""))
                {
                    String[] txt = ord.special.Split('+');
                    foreach (String txt1 in txt)
                    {
                        count++;
                        line = "     " + txt1.Trim();
                        yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
                        textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
                        xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                        yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                        e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
                    }
                }
                if ((ord.topping != null) && !ord.topping.Equals(""))
                {
                    String[] txt = ord.topping.Split('+');
                    foreach (String txt1 in txt)
                    {
                        count++;
                        line = "     " + txt1.Trim();
                        yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
                        textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
                        xOffset = int.Parse(marginR.ToString()) - textSize.Width;  //pad?
                        yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
                        e.Graphics.DrawString(line, fEdit, Brushes.Black, leftMargin, yPos, flags);
                    }
                }

                i++;
            }
            count++; count++; count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            e.Graphics.DrawLine(blackPen, leftMargin - 5, yPos, marginR + 300, yPos);

            count++; count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_footer1;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);

            count++; count++;
            yPos = topMargin + (count * fEdit.GetHeight(e.Graphics) + gap);
            line = mposC.res.receipt_footer2;
            textSize = TextRenderer.MeasureText(line, fEdit, proposedSize, TextFormatFlags.RightToLeft);
            xOffset = e.MarginBounds.Right - textSize.Width;  //pad?
            yOffset = e.MarginBounds.Bottom - textSize.Height;  //pad?
            //e.Graphics.DrawString(line, fEdit, Brushes.Black, xOffset, yPos, new StringFormat());
            e.Graphics.DrawString(line, fEdit, Brushes.Black, avg - (textSize.Width / 2), yPos, flags);
        }
        private void initTopping()
        {
            ieTopping8 = new C1.Win.C1Tile.ImageElement();
            ieTopping8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            tempTopping = new C1.Win.C1Tile.Template();
            TileTopping = new C1TileControl();
            TileTopping.Dock = DockStyle.Fill;
            //teOrd.Font = fEdit;
            TileTopping.Font = fEdit;
            //tempSpec.Elements.Add(pnFoodsPrice);
            tempTopping.Name = "tempSpec";

            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileTopping.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileTopping.Orientation = LayoutOrientation.Vertical;
            }
            grSpec = new Group();
            TileTopping.Groups.Add(grSpec);
            //peSpec = new C1.Win.C1Tile.PanelElement();
            ieTopping = new C1.Win.C1Tile.ImageElement();
            ieTopping.Alignment = ContentAlignment.TopLeft;

            TileTopping.Font = fEdit;
            //TileSpec.Templates.Add(this.tempFlickr);
            TileTopping.Name = "tilespec";
            TileTopping.Dock = DockStyle.Fill;
            TileTopping.ScrollOffset = 0;
            TileTopping.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileTopping.Padding = new System.Windows.Forms.Padding(0);
            TileTopping.GroupPadding = new System.Windows.Forms.Padding(20);
            TileTopping.Templates.Add(this.tempTopping);
            //TileSpec.Groups.Add(grSpec);

            peTopping = new C1.Win.C1Tile.PanelElement();
            peTopping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //peSpecName.Children.Add(teOrdFoodsName);
            peTopping.Dock = System.Windows.Forms.DockStyle.Top;
            peTopping.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            teSpecName = new C1.Win.C1Tile.TextElement();
            teSpecName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teSpecName.ForeColor = System.Drawing.Color.Black;
            teSpecName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teSpecName.SingleLine = true;
            tempTopping.Elements.Add(ieTopping8);
            tempTopping.Elements.Add(peTopping);
            tempTopping.Name = "tempSpec";

            peTopping.Children.Add(ieTopping);
            peTopping.Children.Add(teSpecName);
            pnToping.Controls.Add(TileTopping);
        }
        private void initGrfBill()
        {
            grfBill = new C1FlexGrid();
            grfBill.Font = fEdit;
            grfBill.Dock = System.Windows.Forms.DockStyle.Fill;
            grfBill.Location = new System.Drawing.Point(0, 0);
            grfBill.Rows[0].Visible = false;
            grfBill.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfBill.Rows.Count = 1;
            grfBill.Cols.Count = 8;
            grfBill.Cols[colBNo].Width = 40;
            grfBill.Cols[colBFooName].Width = 300;
            grfBill.Cols[colBPrice].Width = 80;
            //FilterRow fr = new FilterRow(grfExpn);
            grfBill.TabStop = false;
            grfBill.EditOptions = EditFlags.None;
            grfBill.Cols[colBNo].AllowEditing = false;
            grfBill.Cols[colBFooName].AllowEditing = false;
            grfBill.Cols[colBPrice].AllowEditing = false;
            //grf.ExtendLastCol = true;
            grfBill.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;

            grfBill.SubtotalPosition = SubtotalPositionEnum.BelowData;

            pnBill.Controls.Add(grfBill);
            grfBill.Cols[colBFooId].Visible = false;
            grfBill.Cols[colBStatus].Visible = false;
            grfBill.Cols[colBQty].Visible = false;

            pnBill.Width = mposC.panel1Width + 130;
            //theme.SetTheme(grf, "Office2010Blue");

        }
        private void setGrfBill()
        {
            //String re = "";
            if (lOrd.Count > 0)
            {
                foreach (Order1 ord in lOrd)
                {
                    Row row = grfBill.Rows.Add();
                    if (ord.topping.Equals(""))
                    {
                        if (!ord.special.Equals(""))
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.special;
                        }
                        else
                        {
                            row[colBFooName] = ord.foods_name;
                        }
                    }
                    else
                    {
                        if (!ord.special.Equals(""))
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.topping + " + " + ord.special;
                        }
                        else
                        {
                            row[colBFooName] = ord.foods_name + " + " + ord.topping;
                        }
                    }
                    row[colBPrice] = ord.sumPrice;
                    row[colBFooId] = ord.foods_id;
                    row[colBRemark] = ord.remark;
                    row[colBNo] = grfBill.Rows.Count - 1;
                }
                //String[] ext = name.Split('#');
                UpdateTotalsBill();
                lbAmt.Text = "";
                lbStatus.Text = "";
                String amt = "";
                try
                {
                    amt = grfBill[grfBill.Rows.Count - 1, colBPrice].ToString();
                    Decimal amt1 = 0;
                    Decimal.TryParse(amt, out amt1);

                    lbAmt.Text = txtAmt + " " + amt1.ToString("0.00");
                }
                catch (Exception ex)
                {

                }

            }
        }
        private void UpdateTotalsBill()
        {
            // clear existing totals
            grfBill.Subtotal(AggregateEnum.Clear);
            grfBill.Subtotal(AggregateEnum.Sum, 0, -1, colOrdPrice, "Grand Total");

        }
        private void initSpec()
        {
            ieSpec8 = new C1.Win.C1Tile.ImageElement();
            ieSpec8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            tempSpec = new C1.Win.C1Tile.Template();
            TileSpec = new C1TileControl();
            TileSpec.Dock = DockStyle.Fill;
            //teOrd.Font = fEdit;
            TileSpec.Font = fEdit;
            //tempSpec.Elements.Add(pnFoodsPrice);
            tempSpec.Name = "tempSpec";

            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileSpec.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileSpec.Orientation = LayoutOrientation.Vertical;
            }
            grSpec = new Group();
            TileSpec.Groups.Add(grSpec);
            //peSpec = new C1.Win.C1Tile.PanelElement();
            ieSpec = new C1.Win.C1Tile.ImageElement();
            
            ieSpec.Alignment = ContentAlignment.TopLeft;
            
            TileSpec.Font = fEdit;
            //TileSpec.Templates.Add(this.tempFlickr);
            TileSpec.Name = "tilespec";
            TileSpec.Dock = DockStyle.Fill;
            TileSpec.ScrollOffset = 0;
            TileSpec.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileSpec.Padding = new System.Windows.Forms.Padding(0);
            TileSpec.GroupPadding = new System.Windows.Forms.Padding(20);
            TileSpec.Templates.Add(this.tempSpec);
            //TileSpec.Groups.Add(grSpec);

            peSpecName = new C1.Win.C1Tile.PanelElement();
            peSpecName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            //peSpecName.Children.Add(teOrdFoodsName);
            peSpecName.Dock = System.Windows.Forms.DockStyle.Top;
            peSpecName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            teSpecName = new C1.Win.C1Tile.TextElement();
            teSpecName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teSpecName.ForeColor = System.Drawing.Color.Black;
            teSpecName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teSpecName.SingleLine = true;
            tempSpec.Elements.Add(ieSpec8);
            tempSpec.Elements.Add(peSpecName);
            tempSpec.Name = "tempSpec";

            peSpecName.Children.Add(ieSpec);
            peSpecName.Children.Add(teSpecName);
            pnSpecial.Controls.Add(TileSpec);
        }
        private void PnOrder_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            label2.Text = pnOrder.Width.ToString();
            if(pnOrder.Width>500)
                grfOrder.Cols[colOrdFooName].Width = pnOrder.Width - 300;
            else
                grfOrder.Cols[colOrdFooName].Width = 300;



        }

        private void SpMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //throw new NotImplementedException();
            //String aa = "";
            //aa = pnItem.Width.ToString();
            //label1.Text = pnOrder.Width.ToString();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Decimal price = 0, sum = 0, topping = 0;
            Decimal.TryParse(lbPrice.Text, out sum);
            Decimal.TryParse(foo.foods_price, out price);
            if (sum > 0)
                topping = sum - price;
            mposC.fooName = lbFooName.Text.Trim();
            mposC.fooSpec = fooSpec.Trim();
            mposC.fooTopping = fooTopping.Trim();
            mposC.toppingPrice = topping.ToString("0.00");
            mposC.foosumprice = lbPrice.Text;
            //mposC.fooToppingPrice = 
            mposC.fooName = fooTopping.Equals("") ? mposC.fooName.Replace("+", "").Trim() : mposC.fooName.Replace(fooTopping.Trim(), "").Replace("+", "").Trim();

            setGrfSpecialTopping();
            tabMain.SelectedTab = tabOrder;
        }

        private void BtnVoidAll_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();   
            grfOrder.Dispose();
            initGrfOrder();
        }
                
        private void setGrfSpecialTopping()
        {
            int row = 0;
            String topping = "", name = "";
            if (int.TryParse(txtRow.Text, out row))
            {
                //topping = grf[row, colTopping] == null ? "" : grf[row, colTopping].ToString();
                //name = grf[row, colFooName1] == null ? "" : grf[row, colFooName1].ToString();
                if (!mposC.fooName.Equals(""))
                {
                    Order1 ord = lOrd[row - 1];
                    //ord.special = mposC.fooSpec;
                    //ord.topping = mposC.fooTopping;
                    ord.sumPrice = mposC.foosumprice;
                    ord.toppingPrice = mposC.toppingPrice;
                    if (mposC.fooTopping.Equals(""))
                    {
                        //Order1 ord = lOrd[row - 1];
                        //ord.special = mposC.fooSpec;
                        if (!mposC.fooSpec.Equals(""))
                        {
                            grfOrder[row, colOrdFooName] = lbFooName.Text;
                        }
                        else
                        {
                            grfOrder[row, colOrdFooName] = lbFooName.Text;
                        }
                        grfOrder[row, colOrdPrice] = ord.sumPrice;
                    }
                    else
                    {
                        ord.topping = fooTopping;
                        if (mposC.fooSpec.Equals(""))
                        {
                            grfOrder[row, colOrdFooName] = lbFooName.Text;
                        }
                        else
                        {
                            grfOrder[row, colOrdFooName] = lbFooName.Text;
                        }
                        grfOrder[row, colOrdPrice] = ord.sumPrice;
                    }
                }
                if (!mposC.fooSpec.Equals(""))
                    grfOrder[row, colOrdRemark] = mposC.fooSpec;
            }
            UpdateTotals();
        }
        private void clearMPOSC()
        {
            mposC.fooName = "";
            mposC.fooSpec = "";
            mposC.fooTopping = "";
            mposC.toppingPrice = "";
            mposC.fooSpec = "";
            mposC.foosumprice = "";
            lFoos.Clear();
            lFoot.Clear();

        }
        private void BtnSpec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            clearMPOSC();
            //FrmTakeOutSpecial frm = new FrmTakeOutSpecial(mposC, txtFooId.Text);
            //frm.ShowDialog(this);
            foo = mposC.mposDB.fooDB.selectByPk1(txtFooId.Text);
            //setGrfSpec(foo.foods_id);
            setTileSpec(foo.foods_id);
            //setGrfTopping(foo.foods_id);
            setTiltTopping(foo.foods_id);
            tabMain.SelectedTab = tabSpecTopping;
            lbPrice.Text = foo.foods_price;
            fooTopping = "";
            fooSpec = "";
            setLbFooName();
            //setGrfSpecialTopping();

        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            int row = 0;
            if (int.TryParse(txtRow.Text, out row))
            {
                if (grfOrder.Rows.Count > row)
                    grfOrder.Rows.Remove(row);
            }
        }

        private void initTC()
        {
            dtCat = mposC.mposDB.foocDB.selectAll();
            dtRec = mposC.mposDB.foocDB.selectAll();
            tC = new C1DockingTab();
            tC.Dock = System.Windows.Forms.DockStyle.Fill;
            tC.Location = new System.Drawing.Point(0, 266);
            tC.Name = "c1DockingTab1";
            tC.Size = new System.Drawing.Size(669, 200);
            tC.TabIndex = 0;
            tC.TabsSpacing = 5;
            tC.Font = fEdit1;

            if (mposC.iniC.tabFoodsCustom.Equals("1"))
            {
                if (mposC.iniC.tabFoodsAlign.Equals("0"))
                {
                    tC.AlignTabs = StringAlignment.Near;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("1"))
                {
                    tC.AlignTabs = StringAlignment.Center;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("2"))
                {
                    tC.AlignTabs = StringAlignment.Far;
                }
                else
                {
                    tC.AlignTabs = StringAlignment.Near;
                }
                tC.TabAreaSpacing = int.Parse(mposC.iniC.tabFoodsAreaSpacing);
                tC.Indent = int.Parse(mposC.iniC.tabFoodsIndent);
                tC.TabsSpacing = int.Parse(mposC.iniC.tabFoodsSpacing);
                tC.TabAreaSpacing = int.Parse(mposC.iniC.tabFoodsAreaSpacing);
                if (mposC.iniC.tabFoodsAlign.Equals("0"))
                {
                    tC.TabLook = ButtonLookFlags.Default;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("16"))
                {
                    tC.TabLook = ButtonLookFlags.Control;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("2"))
                {
                    tC.TabLook = ButtonLookFlags.Image;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("1"))
                {
                    tC.TabLook = ButtonLookFlags.Text;
                }
                else if (mposC.iniC.tabFoodsAlign.Equals("3"))
                {
                    tC.TabLook = ButtonLookFlags.TextAndImage;
                }
                Size ss = new Size();
                ss.Height = int.Parse(mposC.iniC.tabFoodsPaddingHeight);
                ss.Width = int.Parse(mposC.iniC.tabFoodsPaddingWidth);
                Point pp = new Point(ss);
                tC.Padding = pp;
                tC.TabAreaSpacing = int.Parse(mposC.iniC.tabFoodsAreaSpacing);

                Color carea, cback, cfore;
                carea = ColorTranslator.FromHtml(mposC.iniC.tabFoodsAreaColor);
                cback = ColorTranslator.FromHtml(mposC.iniC.tabFoodsBackGroundColor);
                cfore = ColorTranslator.FromHtml(mposC.iniC.tabFoodsForeGroundColor);
                tC.TabAreaBackColor = carea;
                tC.BackColor = cback;
                tC.ForeColor = cfore;
            }

            pnFoods.Controls.Add(tC);
            tabPage = new C1DockingTabPage[dtCat.Rows.Count + 1];
            TileFoods = new C1TileControl[dtCat.Rows.Count + 1];
            gr1 = new Group[dtCat.Rows.Count + 1];
            tabPage[0] = new C1DockingTabPage();
            tabPage[0].Location = new System.Drawing.Point(1, 24);
            tabPage[0].Name = "c1DockingTabPage1";
            tabPage[0].Size = new System.Drawing.Size(667, 175);
            tabPage[0].TabIndex = 0;
            tabPage[0].Text = "Recommend";
            tabPage[0].Name = "Page0";
            tabPage[0].TabBackColor = tilecolor;
            tC.Controls.Add(tabPage[0]);


            TileRec = new C1TileControl();
            TileRec.Dock = DockStyle.Fill;
            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileRec.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileRec.Orientation = LayoutOrientation.Vertical;
            }
            grRec = new Group();
            TileRec.Groups.Add(this.grRec);
            //grRec = new Group();
            peOrd = new C1.Win.C1Tile.PanelElement();
            ieOrd = new C1.Win.C1Tile.ImageElement();
            tempFlickr = new C1.Win.C1Tile.Template();
            imageElement8 = new C1.Win.C1Tile.ImageElement();
            teOrd = new C1.Win.C1Tile.TextElement();
            pnFoodsName = new C1.Win.C1Tile.PanelElement();
            pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
            teOrdFoodsName = new C1.Win.C1Tile.TextElement();
            teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
            imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
            teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
            teOrdFoodsName.SingleLine = true;
            pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pnFoodsName.Children.Add(teOrdFoodsName);
            pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
            pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
            pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            //panelElement11.Children.Add(panelElement12);
            pnFoodsPrice.Children.Add(teOrdFoodsPrice);
            pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnFoodsPrice.FixedHeight = 32;
            teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
            teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
            teOrd.Font = fEdit;
            TileRec.Font = fEdit;

            peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            peOrd.Children.Add(ieOrd);
            peOrd.Children.Add(teOrd);
            peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            TileRec.DefaultTemplate.Elements.Add(peOrd);
            TileRec.Templates.Add(this.tempFlickr);
            //TileFoods = new C1TileControl();
            TileRec.Name = "tilerec";
            TileRec.Dock = DockStyle.Fill;
            //pnOrder.Controls.Add(TileFoods);                    

            this.tempFlickr.Elements.Add(imageElement8);
            this.tempFlickr.Elements.Add(pnFoodsName);
            this.tempFlickr.Elements.Add(pnFoodsPrice);
            this.tempFlickr.Name = "tempFlickrrec";
            TileRec.ScrollOffset = 0;
            TileRec.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileRec.Padding = new System.Windows.Forms.Padding(0);
            TileRec.GroupPadding = new System.Windows.Forms.Padding(20);
            TileRec.BackColor = tilecolor;
            tabPage[0].Controls.Add(TileRec);
            for (int i = 1; i < dtCat.Rows.Count + 1; i++)
            {
                //if (i == 0)
                //{

                //}
                //else
                //{
                //if (i == dtCat.Rows.Count) continue;
                tabPage[i] = new C1DockingTabPage();
                gr1[i] = new Group();
                tabPage[i].Location = new System.Drawing.Point(1, 24);
                //tabPage.Name = "c1DockingTabPage"+i;
                tabPage[i].Size = new System.Drawing.Size(667, 175);
                tabPage[i].TabIndex = 0;
                tabPage[i].Text = dtCat.Rows[i - 1]["foods_cat_name"].ToString();
                tabPage[i].Name = "Page" + i;
                tabPage[i].TabBackColor = tilecolor;
                //tabPage[i].st
                tC.Controls.Add(tabPage[i]);

                TileFoods[i] = new C1TileControl();
                if (i == 1)
                {
                    intptr = TileFoods[i].Handle;
                }
                if (mposC.iniC.TileFoodsOrientation.Equals("0"))
                {
                    TileFoods[i].Orientation = LayoutOrientation.Horizontal;
                }
                else
                {
                    TileFoods[i].Orientation = LayoutOrientation.Vertical;
                }
                TileFoods[i].Groups.Add(this.gr1[i]);
                peOrd = new C1.Win.C1Tile.PanelElement();
                ieOrd = new C1.Win.C1Tile.ImageElement();
                tempFlickr = new C1.Win.C1Tile.Template();
                imageElement8 = new C1.Win.C1Tile.ImageElement();
                teOrd = new C1.Win.C1Tile.TextElement();
                pnFoodsName = new C1.Win.C1Tile.PanelElement();
                pnFoodsPrice = new C1.Win.C1Tile.PanelElement();
                teOrdFoodsName = new C1.Win.C1Tile.TextElement();
                teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
                imageElement8.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
                teOrdFoodsName.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsName.ForeColor = System.Drawing.Color.Black;
                teOrdFoodsName.ForeColorSelector = C1.Win.C1Tile.ForeColorSelector.Unbound;
                teOrdFoodsName.SingleLine = true;
                pnFoodsName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                pnFoodsName.Children.Add(teOrdFoodsName);
                pnFoodsName.Dock = System.Windows.Forms.DockStyle.Top;
                pnFoodsName.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
                pnFoodsPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
                pnFoodsPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
                //panelElement11.Children.Add(panelElement12);
                pnFoodsPrice.Children.Add(teOrdFoodsPrice);
                pnFoodsPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnFoodsPrice.FixedHeight = 32;
                teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
                teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
                teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;
                teOrd.Font = fEdit;
                TileFoods[i].Font = fEdit;

                peOrd.Alignment = System.Drawing.ContentAlignment.BottomLeft;
                peOrd.Children.Add(ieOrd);
                peOrd.Children.Add(teOrd);
                peOrd.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
                TileFoods[i].DefaultTemplate.Elements.Add(peOrd);
                TileFoods[i].Templates.Add(this.tempFlickr);
                //TileFoods = new C1TileControl();
                TileFoods[i].Name = "tile" + i;
                TileFoods[i].Dock = DockStyle.Fill;
                TileFoods[i].BackColor = tilecolor;
                //pnOrder.Controls.Add(TileFoods);                    

                this.tempFlickr.Elements.Add(imageElement8);
                this.tempFlickr.Elements.Add(pnFoodsName);
                this.tempFlickr.Elements.Add(pnFoodsPrice);
                this.tempFlickr.Name = "tempFlickr";
                TileFoods[i].ScrollOffset = 0;
                TileFoods[i].SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
                TileFoods[i].Padding = new System.Windows.Forms.Padding(0);
                TileFoods[i].GroupPadding = new System.Windows.Forms.Padding(20);

                tabPage[i].Controls.Add(TileFoods[i]);
                //}

            }
            
            if (mposC.iniC.statusDrinkHide.Equals("0"))
            {
                int heigth = 0, spItemhei=0, tabMainHei=0;
                heigth = pnDrink.Height;
                spItemhei = spItem.Height;
                tabMainHei = tabMain.Height;
                pnDrink.Hide();
                pnFoods.Height = pnFoods.Height + heigth;
            }
            else
            {
                initTileDrink();
            }
        }
        private void initTileDrink()
        {
            TileDrink = new C1TileControl();
            TileDrink.Dock = DockStyle.Fill;
            if (mposC.iniC.TileFoodsOrientation.Equals("0"))
            {
                TileDrink.Orientation = LayoutOrientation.Horizontal;
            }
            else
            {
                TileDrink.Orientation = LayoutOrientation.Vertical;
            }
            grDring = new Group();
            TileDrink.Groups.Add(this.grDring);
            TileDrink.Font = fEdit;
            TileDrink.DefaultTemplate.Elements.Add(peOrd);
            
            TileDrink.Name = "tiledrink";
            TileDrink.Dock = DockStyle.Fill;
            TileDrink.ScrollOffset = 0;
            TileDrink.SurfaceContentAlignment = System.Drawing.ContentAlignment.TopLeft;
            TileDrink.Padding = new System.Windows.Forms.Padding(0);
            TileDrink.GroupPadding = new System.Windows.Forms.Padding(20);
            TileDrink.BackColor = tilecolor;

            tempDrink = new C1.Win.C1Tile.Template();
            
            this.tempDrink.Name = "tempDrink";
            imageElementDrink = new C1.Win.C1Tile.ImageElement();
            imageElementDrink.ImageLayout = C1.Win.C1Tile.ForeImageLayout.ScaleOuter;
            pnElementDrink = new C1.Win.C1Tile.PanelElement();
            pnElementDrink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            pnElementDrink.Children.Add(teOrdFoodsName);
            pnElementDrink.Dock = System.Windows.Forms.DockStyle.Top;
            pnElementDrink.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            pnElementPrice = new C1.Win.C1Tile.PanelElement();
            pnElementPrice.AlignmentOfContents = System.Drawing.ContentAlignment.MiddleRight;
            pnElementPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            pnElementPrice.Children.Add(teOrdFoodsPrice);
            pnElementPrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnElementPrice.FixedHeight = 32;
            teOrdFoodsPrice = new C1.Win.C1Tile.TextElement();
            teOrdFoodsPrice.BackColorSelector = C1.Win.C1Tile.BackColorSelector.Unbound;
            teOrdFoodsPrice.Margin = new System.Windows.Forms.Padding(0, 0, 37, 0);
            teOrdFoodsPrice.TextSelector = C1.Win.C1Tile.TextSelector.Text1;

            this.tempDrink.Elements.Add(imageElementDrink);
            this.tempDrink.Elements.Add(pnElementDrink);
            this.tempDrink.Elements.Add(pnElementPrice);
            //TileDrink.Templates.Add(this.tempDrink);
            TileDrink.Templates.Add(this.tempDrink);

            panel3.BackColor = tilecolor;
            pnDrink.Controls.Add(TileDrink);
        }
        private void genLotId()
        {
            String lotid = "";
            lotid = mposC.mposDB.seqDB.genLotId();
            foreach (Order1 ord in lOrd)
            {
                ord.lot_id = lotid;
            }
        }
        private void setFooNameRemark()
        {
            foreach (Row row in grfOrder.Rows)
            {
                try
                {
                    if (row[colOrdFooName] == null) continue;
                    int rowid1 = 0;
                    String fooname = "", rowid = "", spec = "";
                    fooname = row[colOrdFooName].ToString();
                    rowid = row[colOrdNo].ToString();
                    spec = row[colOrdRemark].ToString();
                    if (!spec.Equals(""))
                    {
                        if (int.TryParse(rowid, out rowid1))
                        {
                            Order1 ord = new Order1();
                            ord = lOrd[rowid1];
                            ord.foods_name = fooname;
                            ord.remark = spec;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
        private void BtnPay_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            mposC.statusVNEPaysuccess = "";
            genLotId();
            setFooNameRemark();
            tabMain.SelectedTab = tabCheck;
            tCBill.ShowTabs = false;
            setGrfBill();
            //FrmTakeOutCheck frm = new FrmTakeOutCheck(mposC, lOrd);
            //frm.ShowDialog(this);
            //MessageBox.Show("mposC.statusVNEPaysuccess " + mposC.statusVNEPaysuccess, "");
            //if (mposC.statusVNEPaysuccess.Equals("1"))
            //{
            //    lOrd.Clear();
            //    grfOrder.Dispose();
            //    initGrfOrder();
            //    if (mposC.iniC.statuspaytoclose.Equals("1"))
            //    {
            //        Close();
            //    }
            //}
        }

        private void initGrfOrder()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fgrd;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);
            grfOrder.Rows[0].Visible = false;
            grfOrder.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfOrder.Rows.Count = 1;
            grfOrder.Cols.Count = 15;
            grfOrder.Cols[colOrdNo].Width = 40;
            grfOrder.Cols[colOrdFooName].Width = 300;
            grfOrder.Cols[colOrdPrice].Width = 80;
            grfOrder.Cols[colOrdqtyplus].Width = 50;
            grfOrder.Cols[colOrdqtyminus].Width = 50;
            grfOrder.Cols[colOrdArrowDown].Width = 50;
            grfOrder.Cols[colOrdTopping].Width = 100;
            grfOrder.Cols[colOrdThrumb].Width = 50;
            grfOrder.Cols[colOrdQty].Width = 50;
            //FilterRow fr = new FilterRow(grfExpn);
            grfOrder.TabStop = false;
            grfOrder.EditOptions = EditFlags.None;
            grfOrder.Cols[colOrdNo].AllowEditing = false;
            grfOrder.Cols[colOrdFooName].AllowEditing = false;
            grfOrder.Cols[colOrdPrice].AllowEditing = false;
            grfOrder.Cols[colOrdQty].AllowEditing = false;
            grfOrder.Cols[colOrdArrowDown].AllowEditing = false;
            grfOrder.Cols[colOrdqtyminus].AllowEditing = false;
            grfOrder.Cols[colOrdqtyplus].AllowEditing = false;
            grfOrder.Cols[colOrdTopping].AllowEditing = false;
            grfOrder.Cols[colOrdThrumb].AllowEditing = false;
            Column colpic = grfOrder.Cols[colOrdqtyplus];
            colpic.DataType = typeof(Image);
            Column colpic1 = grfOrder.Cols[colOrdqtyminus];
            colpic1.DataType = typeof(Image);
            Column colpic2 = grfOrder.Cols[colOrdArrowDown];
            colpic2.DataType = typeof(Image);
            Column colpic3 = grfOrder.Cols[colOrdTopping];
            colpic3.DataType = typeof(Image);
            Column colpic4 = grfOrder.Cols[colOrdThrumb];
            colpic4.DataType = typeof(Image);

            //grf.ExtendLastCol = true;
            grfOrder.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grfOrder.AfterDataRefresh += Grf_AfterDataRefresh;
            //grf.SubtotalPosition = SubtotalPositionEnum.BelowData;
            grfOrder.SubtotalPosition = SubtotalPositionEnum.BelowData;

            grfOrder.AfterRowColChange += GrfOrder_AfterRowColChange;
            grfOrder.Click += GrfOrder_Click;
            //grfExpnC.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellButtonClick);
            //grfExpnC.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfDept_CellChanged);
            //ContextMenu menuGw = new ContextMenu();
            //menuGw.MenuItems.Add("&แก้ไข รายการเบิก", new EventHandler(ContextMenu_edit));
            //menuGw.MenuItems.Add("&แก้ไข", new EventHandler(ContextMenu_Gw_Edit));
            //menuGw.MenuItems.Add("&ยกเลิก", new EventHandler(ContextMenu_Gw_Cancel));
            //grf.ContextMenu = menuGw;
            //grf.EndUpdate();
            pnOrder.Controls.Add(grfOrder);
            grfOrder.Cols[colOrdFooId].Visible = false;
            grfOrder.Cols[colOrdStatus].Visible = false;
            grfOrder.Cols[colOrdPrinterName].Visible = false;
            //grfOrder.Cols[colOrdQty].Visible = false;
            grfOrder.Cols[colOrdRemark].Visible = false;
            //grfOrder.Cols[colOrdTopping].Visible = false;
            grfOrder.Cols[colOrdFooName1].Visible = false;
            pnOrder.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setBtnEnable(Boolean flag)
        {
            btnVoid.Enabled = flag;
            btnSpec.Enabled = flag;
            //btnTopping.Enabled = flag;
        }
        private void GrfOrder_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfOrder.Row < 0) return;
            if (grfOrder.Col < 0) return;
            if (grfOrder[grfOrder.Row, colOrdFooName] == null) return;
            flagModi = true;
            String name = "", id = "";
            if(grfOrder.Col == colOrdFooName)
            {
                name = grfOrder[grfOrder.Row, colOrdFooName].ToString();
                id = grfOrder[grfOrder.Row, colOrdFooId].ToString();
                lbFooName.Text = name;
                txtFooId.Value = id;
                txtRow.Value = grfOrder.Row;
                setBtnEnable(flagModi);
            }
            else if (grfOrder.Col == colOrdqtyplus)
            {
                String chk = "";
                int qty = 0;
                chk = grfOrder[grfOrder.Row, colOrdQty] != null ? grfOrder[grfOrder.Row, colOrdQty].ToString():"0";
                int.TryParse(chk, out qty);
                qty++;
                grfOrder[grfOrder.Row, colOrdQty] = qty;
            }
            else if (grfOrder.Col == colOrdqtyminus)
            {
                String chk = "";
                int qty = 0;
                chk = grfOrder[grfOrder.Row, colOrdQty] != null ? grfOrder[grfOrder.Row, colOrdQty].ToString() : "0";
                int.TryParse(chk, out qty);
                qty--;
                if (qty <= 0) return;
                grfOrder[grfOrder.Row, colOrdQty] = qty;
            }
            else if (grfOrder.Col == colOrdThrumb)
            {
                String chk = "";
                int row = 0;
                if (int.TryParse(grfOrder.Row.ToString(), out row))
                {
                    if (grfOrder.Rows.Count > grfOrder.Row)
                        grfOrder.Rows.Remove(grfOrder.Row);
                }
            }
            else if (grfOrder.Col == colOrdArrowDown)
            {
                //C1.Win.C1FlexGrid.C1FlexGrid flex = sender as C1.Win.C1FlexGrid.C1FlexGrid;
                string tip = _tip.Replace("(row,col)", string.Format("<b>({0},{1})</b>", grfOrder.Row, grfOrder.Col));
                stt.SetToolTip(grfOrder, tip);
            }
            else if (grfOrder.Col == colOrdTopping)
            {
                //C1.Win.C1FlexGrid.C1FlexGrid flex = sender as C1.Win.C1FlexGrid.C1FlexGrid;
                string tip = _tip.Replace("(row,col)", string.Format("<b>({0},{1})</b>", grfOrder.Row, grfOrder.Col));
                stt.SetToolTip(grfOrder, tip);
            }
        }

        private void GrfOrder_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }

        private void Grf_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //throw new NotImplementedException();
            UpdateTotals();
        }
        private void UpdateTotals()
        {
            // clear existing totals
            grfOrder.Subtotal(AggregateEnum.Clear);
            grfOrder.Subtotal(AggregateEnum.Sum, 0, -1, colOrdPrice, "Grand Total");

        }
        private void setGrfOrder(String id, String name, String price, String qty, String remark, String printer)
        {
            String re = "";
            if (!name.Equals(""))
            {
                //String[] ext = name.Split('#');
                Order1 ord1 = new Order1();
                Row row = grfOrder.Rows.Add();
                row[colOrdFooName] = name;
                row[colOrdPrice] = price;
                row[colOrdFooId] = id;
                row[colOrdRemark] = remark;
                row[colOrdNo] = grfOrder.Rows.Count - 2;
                row[colOrdPrinterName] = printer;
                row[colOrdFooName1] = name;
                row[colOrdQty] = "1";
                row[colOrdqtyplus] = imgPlus;
                row[colOrdqtyminus] = imgMinus;
                row[colOrdArrowDown] = imgArrowDown;
                row[colOrdTopping] = imgAdd;
                row[colOrdThrumb] = imgThumb;

                ord1.order_id = "";
                ord1.price = price;
                ord1.qty = "1";
                ord1.status_bill = "0";
                ord1.foods_id = id;
                ord1.foods_name = name;
                ord1.remark = remark;
                ord1.row1 = grfOrder.Rows.Count.ToString();
                ord1.printer_name = printer;
                ord1.sumPrice = price;
                ord1.toppingPrice = "";
                ord1.topping = "";
                ord1.special = "";
                lOrd.Add(ord1);
                UpdateTotals();
            }
        }
        private void initGrfSpec()
        {
            grfSpec = new C1FlexGrid();
            grfSpec.Font = fEdit;
            grfSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            grfSpec.Location = new System.Drawing.Point(0, 0);
            grfSpec.Rows[0].Visible = false;
            grfSpec.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfSpec.Rows.Count = 1;
            grfSpec.Cols.Count = 5;
            grfSpec.Cols[colSImg].Width = 50;
            grfSpec.Cols[colSFoosName].Width = 200;

            grfSpec.TabStop = false;
            grfSpec.EditOptions = EditFlags.None;
            grfSpec.Cols[colSImg].AllowEditing = false;
            grfSpec.Cols[colSFoosName].AllowEditing = false;

            //grf.ExtendLastCol = true;
            grfSpec.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
            grfSpec.Click += GrfSpec_Click;
            pnSpecial.Controls.Add(grfSpec);
            grfSpec.Cols[colSNo].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            //grf.Cols[colPrinterName].Visible = false;
            //grf.Cols[colQty].Visible = false;
            //pnBill.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setTileSpec(String fooId)
        {
            DataTable dt = new DataTable();
            lFoos = new List<FoodsSpecial>();
            //dt = mposC.mposDB.foosDB.selectByFoodsId1(fooId);
            lFoos = mposC.mposDB.foosDB.getlFooSpecByFooId(fooId);
            //lFoos = lfooC1;
            TileCollection tiles = TileSpec.Groups[0].Tiles;
            tiles.Clear(true);
            
            //foreach (DataRow drow in dt.Rows)
            foreach (FoodsSpecial foos in lFoos)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempSpec;
                tile.Text = foos.foods_spec_name;
                //tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foos;
                tile.Name = foos.foods_spec_id;
                tile.Click += TileSpec_Click;
                tile.Image = null;
                try
                {
                    //tile.Image = null;
                    tiles.Add(tile);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
                foos.statusUs = "";
            }
        }
        private void setTiltTopping(String fooId)
        {
            DataTable dt = new DataTable();
            lFoot = new List<FoodsTopping>();
            //dt = mposC.mposDB.foosDB.selectByFoodsId1(fooId);
            lFoot = mposC.mposDB.footpDB.getlFooSpecByFooId(fooId);
            //lFoos = lfooC1;
            TileCollection tiles = TileTopping.Groups[0].Tiles;
            tiles.Clear(true);

            //foreach (DataRow drow in dt.Rows)
            foreach (FoodsTopping foos in lFoot)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempSpec;
                tile.Text = foos.foods_topping_name;
                //tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foos;
                tile.Name = foos.foods_topping_id;
                tile.Click += TileTopping_Click;
                tile.Image = null;
                try
                {
                    //tile.Image = null;
                    tiles.Add(tile);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
                foos.statusUs = "";
            }
        }
        private void setGrfSpec(String fooId)
        {
            //grfDept.Rows.Count = 7;
            //pageLoad = true;
            grfSpec.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.foosDB.selectByFoodsId1(fooId);
            grfSpec.Cols.Count = 5;
            grfSpec.Rows.Count = dt.Rows.Count + 1;
            //if (dt.Rows.Count > 0)
                grfSpec.Rows[0].Visible = false;
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfSpec.Cols[1].Width = 60;

            grfSpec.Cols[colSImg].Width = 50;
            grfSpec.Cols[colSFoosName].Width = 200;

            grfSpec.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfSpec.Cols[colSImg].Caption = "รายการสั่งพิเศษ";
            
            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfSpec[i + 1, 0] = (i + 1);
                grfSpec[i + 1, colSFoosName] = dt.Rows[i]["foods_spec_name"].ToString();
                grfSpec[i + 1, colSStatus] = "";
                if (i % 2 == 0)
                    grfSpec.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfSpec.Cols[colSStatus].Visible = false;
            grfSpec.Cols[colSNo].Visible = false;
            grfSpec.Cols[colSFoosName].AllowEditing = false;
            grfSpec.Cols[colSImg].AllowEditing = false;
            //pageLoad = false;
        }

        private void GrfSpec_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfSpec.Row < 0) return;
            if (grfSpec.Col < 0) return;
            if (grfSpec[grfSpec.Row, colSFoosName] == null) return;
            String name = "", id = "";
            name = grfSpec[grfSpec.Row, colSFoosName].ToString();
            if (!name.Equals(""))
            {
                if (grfSpec[grfSpec.Row, colSStatus].Equals(""))
                {
                    grfSpec[grfSpec.Row, colSStatus] = "1";
                    grfSpec.SetCellImage(grfSpec.Row, colSImg, imgR);
                    //lbFooName.Text = lbFooName.Text + " + " + name;
                    setSpecName();
                }
                else
                {
                    grfSpec[grfSpec.Row, colSStatus] = "";
                    grfSpec.SetCellImage(grfSpec.Row, colSImg, null);
                    setSpecName();
                }
            }
            //grf.AutoSizeRows();
        }
        private void setTileSpecName()
        {
            String spec = "", topping="";
            Decimal price = 0, sum = 0;
            lbFooName.Text = foo.foods_name;
            Decimal.TryParse(foo.foods_price, out sum);
            foreach (FoodsSpecial row in lFoos)
            {
                if (row.foods_spec_name == null) continue;
                if (row.statusUs.Equals("1"))
                {
                    spec += row.foods_spec_name.ToString() + " + ";
                    
                }
            }
            spec = spec.Trim();
            try
            {
                if (spec.Substring(spec.Length - 1).Equals("+"))
                {
                    spec = spec.Substring(0, spec.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            fooSpec = spec;

            foreach (FoodsTopping row in lFoot)
            {
                if (row.foods_topping_name == null) continue;
                if (row.statusUs.Equals("1"))
                {
                    topping += row.foods_topping_name.ToString() + " + ";
                    Decimal.TryParse(row.price.ToString(), out price);
                    sum += price;
                }
            }
            topping = topping.Trim();
            try
            {
                if (topping.Substring(topping.Length - 1).Equals("+"))
                {
                    topping = topping.Substring(0, topping.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            fooTopping = topping;

            setLbFooName();
            lbPrice.Text = sum.ToString("0.00");
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void setSpecName()
        {
            String spec = "";
            lbFooName.Text = foo.foods_name;
            foreach (Row row in grfSpec.Rows)
            {
                if (row[colSStatus] == null) continue;
                if (row[colSStatus].Equals("1"))
                {
                    spec += row[colSFoosName].ToString() + " + ";
                }
            }
            spec = spec.Trim();
            try
            {
                if (spec.Substring(spec.Length - 1).Equals("+"))
                {
                    spec = spec.Substring(0, spec.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            
            fooSpec = spec;
            setLbFooName();
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void initGrfTopping()
        {
            grfTopping = new C1FlexGrid();
            grfTopping.Font = fEdit;
            grfTopping.Dock = System.Windows.Forms.DockStyle.Fill;
            grfTopping.Location = new System.Drawing.Point(0, 0);
            grfTopping.Rows[0].Visible = false;
            grfTopping.Cols[0].Visible = false;
            //grf.Cols[colStatus].Visible = false;
            grfTopping.Rows.Count = 1;
            grfTopping.Cols.Count = 6;
            grfTopping.Cols[colTImg].Width = 50;
            grfTopping.Cols[colTFoosName].Width = 200;

            grfTopping.TabStop = false;
            grfTopping.EditOptions = EditFlags.None;
            grfTopping.Cols[colTImg].AllowEditing = false;
            grfTopping.Cols[colTFoosName].AllowEditing = false;
            grfTopping.Click += GrfTopping_Click;
            //grf.ExtendLastCol = true;
            grfTopping.Styles.Normal.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;

            pnToping.Controls.Add(grfTopping);
            grfTopping.Cols[colTNo].Visible = false;
            grfTopping.Cols[colTStatus].Visible = false;
            grfTopping.Cols[colTPrice].AllowEditing = false;
            //grf.Cols[colQty].Visible = false;
            //pnBill.Width = mposC.panel1Width;
            //theme.SetTheme(grf, "Office2010Blue");
        }
        private void setGrfTopping(String fooId)
        {
            grfTopping.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.footpDB.selectByFoodsId1(fooId);
            grfTopping.Cols.Count = 6;
            grfTopping.Rows.Count = dt.Rows.Count + 1;
            //if(dt.Rows.Count>0)
                grfTopping.Rows[0].Visible = false;
            //CellStyle cs = grf.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grf.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfTopping.Cols[1].Width = 60;

            grfTopping.Cols[colTImg].Width = 50;
            grfTopping.Cols[colTFoosName].Width = 200;

            grfTopping.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfTopping.Cols[2].Caption = "รายการสั่งพิเศษ";
            
            //grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            //CellRange rg = grf.GetCellRange(2, colE);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grfTopping[i + 1, 0] = (i + 1);
                grfTopping[i + 1, colTFoosName] = dt.Rows[i]["foods_topping_name"].ToString();
                grfTopping[i + 1, colTPrice] = dt.Rows[i]["price"].ToString();
                grfTopping[i + 1, colTStatus] = "";
                if (i % 2 == 0)
                    grfTopping.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfTopping.Cols[colTStatus].Visible = false;
            grfTopping.Cols[colTNo].Visible = false;
            grfTopping.Cols[colTFoosName].AllowEditing = false;
            grfTopping.Cols[colTImg].AllowEditing = false;
            //pageLoad = false;
        }
        private void GrfTopping_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (grfTopping.Row < 0) return;
            if (grfTopping.Col < 0) return;
            if (grfTopping[grfTopping.Row, colTFoosName] == null) return;
            String name = "", id = "";
            name = grfTopping[grfTopping.Row, colTFoosName].ToString();
            if (!name.Equals(""))
            {
                if (grfTopping[grfTopping.Row, colTStatus].Equals(""))
                {
                    grfTopping[grfTopping.Row, colTStatus] = "1";
                    grfTopping.SetCellImage(grfTopping.Row, colTImg, imgR);
                    //lbFooName.Text = lbFooName.Text + " + " + name;
                    setToppingName();
                }
                else
                {
                    grfTopping[grfTopping.Row, colTStatus] = "";
                    grfTopping.SetCellImage(grfTopping.Row, colSImg, null);
                    setToppingName();
                }
            }
            //grf.AutoSizeRows();
        }
        private void setToppingName()
        {
            String topping = "";
            Decimal price = 0, sum = 0;
            lbFooName.Text = foo.foods_name;
            Decimal.TryParse(foo.foods_price, out sum);
            foreach (Row row in grfTopping.Rows)
            {
                if (row[colTStatus] == null) continue;

                if (row[colTStatus].Equals("1"))
                {
                    topping += row[colTFoosName].ToString() + "[" + row[colTPrice].ToString() + "]" + " + ";
                    Decimal.TryParse(row[colTPrice].ToString(), out price);
                    sum += price;
                }
            }
            topping = topping.Trim();
            try
            {
                if (topping.Substring(topping.Length - 1).Equals("+"))
                {
                    topping = topping.Substring(0, topping.Length - 1);
                }
            }
            catch (Exception ex)
            {

            }
            //lbFooName.Text = foo.foods_name + " + " + topping;
            //lbFooName.Text = lbFooName.Text.Trim();
            fooTopping = topping;
            setLbFooName();
            lbPrice.Text = sum.ToString("0.00");
            fooTopping = topping;
            try
            {
                if (lbFooName.Text.Substring(lbFooName.Text.Length - 1).Equals("+"))
                {
                    lbFooName.Text = lbFooName.Text.Substring(0, lbFooName.Text.Length - 1);
                    lbFooName.Text = lbFooName.Text.Trim();

                }
            }
            catch (Exception ex)
            {

            }
        }
        private void setLbFooName()
        {
            if (fooSpec.Length == 0)
            {
                if (fooTopping.Length == 0)
                {
                    lbFooName.Text = foo.foods_name;
                }
                else
                {
                    lbFooName.Text = foo.foods_name + " + " + fooTopping;
                }
            }
            else
            {
                if (fooTopping.Length == 0)
                {
                    lbFooName.Text = foo.foods_name + "+" + fooSpec;
                }
                else
                {
                    lbFooName.Text = foo.foods_name + "+" + fooSpec + " + " + fooTopping;
                }
            }
            lbFooName.Text = lbFooName.Text.Trim();
            lbSpecFooName.Text = lbFooName.Text;
            
            //return 
        }
        private void LoadFoods(bool keepExistent)
        {
            TileCollection tiles1 = TileRec.Groups[0].Tiles;
            tiles1.Clear(true);
            lfooR = mposC.mposDB.fooDB.getlFoodsRecommend();
            foreach (Foods foo1 in lfooR)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempFlickr;
                tile.Text = foo1.foods_name;
                tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foo1;
                tile.Name = foo1.foods_id;
                tile.Click += Tile_Click;
                tile.Image = null;
                try
                {
                    tile.Image = null;
                    tiles1.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (foo1.filename.Equals("")) continue;
                    //stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + foo1.filename);
                    string ext = Path.GetExtension(foo1.filename);
                    String file = "";
                    file = foo1.filename.Replace(ext, "");
                    file = file + "_210" + ext;
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + file);
                    //loadedImage = new Bitmap(stream);
                    //if (loadedImage != null)
                    //{
                    //    //SizeF size = tile.Width;
                    //    int originalWidth = loadedImage.Width;
                    //    int newWidth = 180;
                    //    resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                    //    tile.Image = resizedImage;
                    //}
                    tile.Image = new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));

            }

            for (int i = 0; i < dtCat.Rows.Count; i++)
            {
                LoadFoods(false, i, dtCat.Rows[i]["foods_cat_id"].ToString());
            }
        }
        private void LoadFoods(bool keepExistent, int index, String catid)
        {
            //Control.FromHandle(intptr);
            Control ctl = new Control();
            ctl = tabPage[1];
            //if (index == 0) return;
            if (TileFoods[index + 1] == null) return;
            TileCollection tiles = TileFoods[index + 1].Groups[0].Tiles;
            tiles.Clear(true);
            TileFoods[index + 1].BeginUpdate();
            lfooT = mposC.mposDB.fooDB.getlFoodsByCat(catid);
            foreach (Foods foo1 in lfooT)
            {
                var tile = new Tile();
                tile.HorizontalSize = mposC.takeouttilhorizontalsize;
                tile.VerticalSize = mposC.takeouttilverticalsize;
                tile.Template = tempFlickr;
                tile.Text = foo1.foods_name;
                tile.Text1 = "ราคา " + foo1.foods_price;
                tile.Tag = foo1;
                tile.Name = foo1.foods_id;
                tile.Click += Tile_Click;
                tile.Image = null;
                try
                {
                    String filename = "";
                    tile.Image = null;
                    tiles.Add(tile);
                    MemoryStream stream = new MemoryStream();
                    Image loadedImage = null, resizedImage;
                    if (foo1.filename.Equals("")) continue;
                    String ext = Path.GetExtension(foo1.filename);
                    filename = foo1.filename.Replace(ext, "");
                    stream = mposC.ftpC.download(mposC.iniC.ShareFile + "/foods/" + filename+"_210"+ext);
                    loadedImage = new Bitmap(stream);
                    if (loadedImage != null)
                    {
                        //SizeF size = tile.Width;
                        int originalWidth = loadedImage.Width;
                        int newWidth = 180;
                        //resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                        //tile.Image = resizedImage;
                        tile.Image = loadedImage;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("" + ex.Message, "showImg");
                }
                //if (!string.IsNullOrEmpty(photo.ThumbnailUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.ThumbnailUri, tile, false));
                //if (!string.IsNullOrEmpty(photo.AuthorBuddyIconUri))
                //    _downloadQueue.Enqueue(new DownloadItem(photo.AuthorBuddyIconUri, tile, true));



            }
            TileFoods[index + 1].EndUpdate();
        }
        private void TileTopping_Click(object sender, EventArgs e)
        {
            Tile tile = sender as Tile;
            if (tile != null)
            {
                FoodsTopping foos = new FoodsTopping();
                foos = (FoodsTopping)tile.Tag;
                if (tile.Image == null)
                {
                    tile.Image = imgR;
                    tile.Text1 = "เลือก";
                }
                else
                {
                    tile.Image = null;
                }
                foreach (FoodsTopping foos1 in lFoot)
                {
                    if (foos1.foods_topping_id.Equals(foos.foods_topping_id))
                    {
                        if (foos1.statusUs.Equals(""))
                        {
                            foos1.statusUs = "1";
                        }
                        else
                        {
                            foos1.statusUs = "";
                        }
                    }
                }
                //if (grfSpec[grfSpec.Row, colSStatus].Equals(""))
                setTileSpecName();
            }
        }
        private void TileSpec_Click(object sender, EventArgs e)
        {
            Tile tile = sender as Tile;
            if (tile != null)
            {
                FoodsSpecial foos = new FoodsSpecial();
                foos = (FoodsSpecial)tile.Tag;
                if (tile.Image == null)
                {
                    tile.Image = imgR;
                    tile.Text1 = "เลือก";
                }
                else
                {
                    tile.Image = null;
                }
                foreach(FoodsSpecial foos1 in lFoos)
                {
                    if (foos1.foods_spec_id.Equals(foos.foods_spec_id))
                    {
                        if (foos1.statusUs.Equals(""))
                        {
                            foos1.statusUs = "1";
                        }
                        else
                        {
                            foos1.statusUs = "";
                        }
                    }
                }
                //if (grfSpec[grfSpec.Row, colSStatus].Equals(""))
                setTileSpecName();
            }
        }
        private void Tile_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Tile tile = sender as Tile;
            if (tile != null)
            {
                Foods foo = new Foods();
                foo = (Foods)tile.Tag;
                setGrfOrder(tile.Name, tile.Text, tile.Text1.Replace("ราคา", "").Trim(), "1", "", foo.printer_name);
                //FlickrPhoto photo = (FlickrPhoto)tile.Tag;
                //string uri = photo.ContentUri;
                //if (!string.IsNullOrEmpty(uri))
                //{
                //    pictureBox.Image = pictureBox.InitialImage;
                //    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                //    imgPanel.Visible = true;
                //    imgPanel.BringToFront();
                //    titleLabel.Text = photo.Title;
                //    authorLabel.Text = photo.AuthorName;
                //    waitLabel.Visible = true;
                //    pictureBox.LoadAsync(uri);
                //    tagBox.Enabled = false;
                //    setTagButton.Enabled = false;
                //    refreshButton.Enabled = false;
                //    loadNewButton.Enabled = false;
                //    flickrTiles.Enabled = false;
                //    backButton.Enabled = true;
                //    this.Focus();
                //}
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ...
            if (keyData == (Keys.Escape))
            {
                //appExit();
                if (MessageBox.Show("ต้องการออกจากโปรแกรม1", "ออกจากโปรแกรม", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    frmmain.Show();
                    Close();
                    return true;
                }
            }
            else
            {
                switch (keyData)
                {
                    case Keys.K | Keys.Control:
                        if (flagShowTitle)
                            flagShowTitle = false;
                        else
                            flagShowTitle = true;
                        setTitle(flagShowTitle);
                        return true;
                    case Keys.X | Keys.Control:
                        frmmain.Show();
                        Close();
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void setTitle(Boolean flag)
        {
            tabMain.ShowTabs = flag;
            if (flag)
            {
                spMain.HeaderHeight = 21;
                spItem.HeaderHeight = 21;
                spSpecialTopping.HeaderHeight = 21;
                spCheck.HeaderHeight = 21;
            }
            else
            {
                spMain.HeaderHeight = 0;
                spItem.HeaderHeight = 0;
                spSpecialTopping.HeaderHeight = 0;
                spCheck.HeaderHeight = 0;
            }
            
            //spMain.HeaderHeight = 21;
            //pnItem.he
        }
        private void FrmTakeOut1_Load(object sender, EventArgs e)
        {
            flagShowTitle = false;
            setTitle(flagShowTitle);
            pnItem.Width = this.Width - 450;
            pnFoods.Height = this.Height - 250;
            lbFooName.Text = "";
            LoadFoods(false);
            this.Activate();
        }
    }
}
