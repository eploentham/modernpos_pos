﻿using C1.Win.C1Input;
using modernpos_pos.objdb;
using modernpos_pos.object1;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.control
{
    public class mPOSControl
    {
        public mPosDB mposDB;
        public ConnectDB conn;

        public InitConfig iniC;
        private IniFile iniF;
        
        public int grdViewFontSize = 0, panel1Width=0, takeouttilhorizontalsize=0, takeouttilverticalsize=0;
        public List<Department> lDept;
        public Company cop;

        public String userId = "";
        public String copID = "", jobID = "", cusID = "", addrID = "", contID = "", cusrID = "", custID = "", stfID = "", deptID = "", posiID = "", drawID = "";
        public String rContactName = "", rContacTel = "", rContID = "", userIderc = "", statusVNEPaysuccess="", pnOrderborderstyle="";

        public String txtHeader = "";

        public Staff sStf, cStf;

        public LogFile lf;
        public Staff user;

        public Color cTxtFocus;

        public FtpClient ftpC;
        Regex regEmail;
        String soapTaxId = "";
        public String theme = "", StartupPath = "", passOK="", tableidToGo="";
        public String FixJobCode = "IMP", FixEccCode = "CC", fooName="", fooSpec="", toppingPrice="", fooTopping="", foosumprice="", fooToppingPrice = "";
        

        //public VideoCaptureDevice video;

        public String _IPAddress = "",MACAddress="";
        public Boolean ftpUsePassive = false;

        public Restaurant res;
        public mPOSControl()
        {
            initConfig();
        }
        private void initConfig()
        {
            String appName = "";
            appName = System.AppDomain.CurrentDomain.FriendlyName;
            appName = appName.ToLower().Replace(".exe", "");
            if (System.IO.File.Exists(Environment.CurrentDirectory + "\\" + appName + ".ini"))
            {
                appName = Environment.CurrentDirectory + "\\" + appName + ".ini";
            }
            else
            {
                appName = Environment.CurrentDirectory + "\\" + Application.ProductName + ".ini";
            }
            StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            iniF = new IniFile(appName);
            iniC = new InitConfig();
            user = new Staff();
            cStf = new Staff();
            sStf = new Staff();
            cop = new Company();
            res = new Restaurant();

            GetConfig();
            conn = new ConnectDB(iniC);
            //MessageBox.Show("mPOSControl before ftpC", "");
            ftpC = new FtpClient(iniC.hostFTP, iniC.userFTP, iniC.passFTP, ftpUsePassive);
            //MessageBox.Show("mPOSControl after ftpC", "");
            //ivfDB = new IvfDB(conn);

            cTxtFocus = ColorTranslator.FromHtml(iniC.txtFocus);
            if (iniC.statusAppToGo.Equals("1"))
            {
                theme = iniC.themeDonor;
            }
            else
            {
                theme = iniC.themeApplication;
            }
            using (StreamReader s = new StreamReader("header.html"))
            {
                txtHeader = s.ReadToEnd();
            }
    }
        public static string GetCurrentExecutingDirectory(System.Reflection.Assembly assembly)
        {
            string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }
        public void getInit()
        {
            //MessageBox.Show("mPOSControl getInit", "");
            mposDB.sexDB.getlSex();
            //MessageBox.Show("mPOSControl getInit 1", "");
            cop = mposDB.copDB.selectByCode1("001");
            //MessageBox.Show("mPOSControl getInit 2", "");
            res = mposDB.resDB.selectByDefault();
            //MessageBox.Show("mPOSControl getInit 3", "");
            tableidToGo = mposDB.tblDB.selectIdByToGo();
            //MessageBox.Show("mPOSControl getInit middle", "");
            _IPAddress = GetLocalIPAddress();
            MACAddress = GetMACAddress();
            conn._IPAddress = _IPAddress;
            //MessageBox.Show("mPOSControl getInit end", "");
        }
        public void GetConfig()
        {
            iniC.hostDB = iniF.getIni("connection", "hostDB");
            iniC.nameDB = iniF.getIni("connection", "nameDB");
            iniC.userDB = iniF.getIni("connection", "userDB");
            iniC.passDB = iniF.getIni("connection", "passDB");
            iniC.portDB = iniF.getIni("connection", "portDB");

            iniC.hostDBEx = iniF.getIni("connection", "hostDBEx");
            iniC.nameDBEx = iniF.getIni("connection", "nameDBEx");
            iniC.userDBEx = iniF.getIni("connection", "userDBEx");
            iniC.passDBEx = iniF.getIni("connection", "passDBEx");
            iniC.portDBEx = iniF.getIni("connection", "portDBEx");

            iniC.hostFTP = iniF.getIni("ftp", "hostFTP");
            iniC.userFTP = iniF.getIni("ftp", "userFTP");
            iniC.passFTP = iniF.getIni("ftp", "passFTP");
            iniC.portFTP = iniF.getIni("ftp", "portFTP");
            iniC.folderFTP = iniF.getIni("ftp", "folderFTP");
            iniC.usePassiveFTP = iniF.getIni("ftp", "usePassiveFTP");

            iniC.grdViewFontSize = iniF.getIni("app", "grdViewFontSize");
            iniC.grdViewFontName = iniF.getIni("app", "grdViewFontName");

            iniC.txtFocus = iniF.getIni("app", "txtFocus");
            iniC.grfRowColor = iniF.getIni("app", "grfRowColor");
            iniC.statusAppToGo = iniF.getIni("app", "statusAppToGo");
            iniC.themeApplication = iniF.getIni("app", "themeApplication");
            iniC.themeDonor = iniF.getIni("app", "themeDonor");
            iniC.themeDonor1 = iniF.getIni("app", "themeDonor1");
            iniC.printerBill = iniF.getIni("app", "printerBill");
            iniC.timerlabreqaccept = iniF.getIni("app", "timerlabreqaccept");
            iniC.takeouttilhorizontalsize = iniF.getIni("app", "takeouttilhorizontalsize");
            iniC.takeouttilverticalsize = iniF.getIni("app", "takeouttilverticalsize");
            iniC.pnOrderborderstyle = iniF.getIni("app", "pnOrderborderstyle");

            iniC.sticker_donor_takeout_panel1 = iniF.getIni("sticker_donor", "takeout_panel1");
            iniC.sticker_donor_height = iniF.getIni("sticker_donor", "height");
            iniC.sticker_donor_start_y = iniF.getIni("sticker_donor", "start_y");
            iniC.sticker_donor_barcode_height = iniF.getIni("sticker_donor", "barcode_height");
            iniC.sticker_donor_barcode_gap_x = iniF.getIni("sticker_donor", "barcode_gap_x");
            iniC.sticker_donor_barcode_gap_y = iniF.getIni("sticker_donor", "barcode_gap_y");
            iniC.sticker_donor_gap = iniF.getIni("sticker_donor", "gap");
            iniC.sticker_donor_start_x = iniF.getIni("sticker_donor", "start_x");
            iniC.status_show_border = iniF.getIni("sticker_donor", "status_show_border");
            iniC.barcode_width_minus = iniF.getIni("sticker_donor", "barcode_width_minus");
            iniC.grfRowRed = iniF.getIni("app", "grfRowRed");
            iniC.grfRowGreen = iniF.getIni("app", "grfRowGreen");
            iniC.grfRowYellow = iniF.getIni("app", "grfRowYellow");
            iniC.timerImgScanNew = iniF.getIni("app", "timerImgScanNew");
            iniC.pathImageScan = iniF.getIni("app", "pathImageScan");
            iniC.patientaddpanel1weight = iniF.getIni("app", "patientaddpanel1weight");
            iniC.ShareFile = iniF.getIni("app", "ShareFile");
            iniC.ShareFileSMBFolder = iniF.getIni("app", "ShareFileSMBFolder");
            iniC.TileFoodsOrientation = iniF.getIni("app", "TileFoodsOrientation");
            iniC.TileFoodsBackColor = iniF.getIni("app", "TileFoodsBackColor");

            iniC.VNEip = iniF.getIni("VNE", "VNEip");
            iniC.VNEwebapi = iniF.getIni("VNE", "VNEwebapi");
            iniC.statusShowListBox1 = iniF.getIni("app", "statusShowListBox1");
            iniC.statuspaytoclose = iniF.getIni("app", "statuspaytoclose");
            iniC.statushidenavigator = iniF.getIni("app", "statushidenavigator");
            iniC.statusHide = iniF.getIni("app", "statusHide");

            iniC.grdViewFontName = iniC.grdViewFontName.Equals("") ? "Microsoft Sans Serif" : iniC.grdViewFontName;

            iniC.sticker_donor_takeout_panel1 = iniC.sticker_donor_takeout_panel1.Equals("") ? "120" : iniC.sticker_donor_takeout_panel1;
            iniC.sticker_donor_height = iniC.sticker_donor_height.Equals("") ? "90" : iniC.sticker_donor_height;
            iniC.sticker_donor_start_y = iniC.sticker_donor_start_y.Equals("") ? "60" : iniC.sticker_donor_start_y;
            iniC.sticker_donor_barcode_height = iniC.sticker_donor_barcode_height.Equals("") ? "40" : iniC.sticker_donor_barcode_height;
            iniC.sticker_donor_barcode_gap_x = iniC.sticker_donor_barcode_gap_x.Equals("") ? "5" : iniC.sticker_donor_barcode_gap_x;
            iniC.sticker_donor_barcode_gap_y = iniC.sticker_donor_barcode_gap_y.Equals("") ? "30" : iniC.sticker_donor_barcode_gap_y;
            iniC.sticker_donor_gap = iniC.sticker_donor_gap.Equals("") ? "20" : iniC.sticker_donor_gap;
            iniC.sticker_donor_start_x = iniC.sticker_donor_start_x.Equals("") ? "52" : iniC.sticker_donor_start_x;
            iniC.patientaddpanel1weight = iniC.patientaddpanel1weight == null ? "320" : iniC.patientaddpanel1weight.Equals("") ? "320" : iniC.patientaddpanel1weight;
            iniC.printerBill = iniC.printerBill.Equals("") ? "default" : iniC.printerBill;
            iniC.status_show_border = iniC.status_show_border.Equals("") ? "0" : iniC.status_show_border;
            iniC.barcode_width_minus = iniC.barcode_width_minus.Equals("") ? "0" : iniC.barcode_width_minus;
            iniC.timerlabreqaccept = iniC.timerlabreqaccept.Equals("") ? "120" : iniC.timerlabreqaccept;
            iniC.takeouttilhorizontalsize = iniC.takeouttilhorizontalsize.Equals("") ? "0" : iniC.takeouttilhorizontalsize;
            iniC.takeouttilverticalsize = iniC.takeouttilverticalsize.Equals("") ? "0" : iniC.takeouttilverticalsize;
            iniC.pnOrderborderstyle = iniC.pnOrderborderstyle.Equals("") ? "0" : iniC.pnOrderborderstyle;
            iniC.TileFoodsOrientation = iniC.TileFoodsOrientation==null  ? "0" : iniC.TileFoodsOrientation;
            iniC.statuspaytoclose = iniC.statuspaytoclose == null ? "0" : iniC.statuspaytoclose;

            iniC.hostFTP = iniC.hostFTP == null ? "" : iniC.hostFTP;
            iniC.userFTP = iniC.userFTP == null ? "" : iniC.userFTP;
            iniC.passFTP = iniC.passFTP == null ? "" : iniC.passFTP;
            iniC.portFTP = iniC.portFTP == null ? "" : iniC.portFTP;

            iniC.themeApplication = iniC.themeApplication == null ? "Office2007Blue" : iniC.themeApplication.Equals("") ? "Office2007Blue" : iniC.themeApplication;
            iniC.themeDonor = iniC.themeDonor == null ? "Office2007Blue" : iniC.themeDonor.Equals("") ? "Office2007Blue" : iniC.themeDonor;
            iniC.themeDonor1 = iniC.themeDonor1 == null ? "MacBlue" : iniC.themeDonor1.Equals("") ? "MacBlue" : iniC.themeDonor1;
            iniC.grfRowRed = iniC.grfRowRed == null ? "#FF0266" : iniC.grfRowRed.Equals("") ? "#FF0266" : iniC.grfRowRed;
            iniC.grfRowGreen = iniC.grfRowGreen == null ? "#7CB342" : iniC.grfRowGreen.Equals("") ? "#7CB342" : iniC.grfRowGreen;
            iniC.grfRowYellow = iniC.grfRowYellow == null ? "#FFDE03" : iniC.grfRowYellow.Equals("") ? "#FFDE03" : iniC.grfRowYellow;

            iniC.statusAppToGo = iniC.statusAppToGo == null ? "1" : iniC.statusAppToGo.Equals("") ? "1" : iniC.statusAppToGo;
            iniC.timerImgScanNew = iniC.timerImgScanNew == null ? "2" : iniC.timerImgScanNew.Equals("") ? "0" : iniC.timerImgScanNew;
            iniC.pathImageScan = iniC.pathImageScan == null ? "d:\\images" : iniC.pathImageScan.Equals("") ? "d:\\images" : iniC.pathImageScan;
            iniC.folderFTP = iniC.folderFTP == null ? "images_medical_record" : iniC.folderFTP.Equals("") ? "images_medical_record" : iniC.folderFTP;
            iniC.ShareFile = iniC.folderFTP == null ? "FTP" : iniC.folderFTP.Equals("") ? "FTP" : iniC.folderFTP;
            iniC.ShareFileSMBFolder = iniC.ShareFileSMBFolder == null ? "d:\\images" : iniC.ShareFileSMBFolder.Equals("") ? "d:\\images" : iniC.folderFTP;
            int.TryParse(iniC.grdViewFontSize, out grdViewFontSize);
            int.TryParse(iniC.patientaddpanel1weight, out panel1Width);
            iniC.statusShowListBox1 = iniC.statusShowListBox1 != null ? iniC.statusShowListBox1 : "1";
            iniC.statushidenavigator = iniC.statushidenavigator != null ? iniC.statushidenavigator : "0";
            iniC.statusHide = iniC.statusHide != null ? iniC.statusHide : "0";

            iniC.usePassiveFTP = iniC.usePassiveFTP == null ? "false" : iniC.usePassiveFTP.Equals("") ? "false" : iniC.usePassiveFTP;
            Boolean.TryParse(iniC.usePassiveFTP, out ftpUsePassive);
            int.TryParse(iniC.takeouttilhorizontalsize, out takeouttilhorizontalsize);
            int.TryParse(iniC.takeouttilverticalsize, out takeouttilverticalsize);
        }
        public String datetoDB(String dt)
        {
            DateTime dt1 = new DateTime();
            String re = "";
            if (dt != null)
            {
                if (!dt.Equals(""))
                {
                    // Thread แบบนี้ ทำให้ โปรแกรม ที่ไปลงที Xtrim ไม่เอา date ผิด
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us")
                    {
                        DateTimeFormat =
                        {
                            DateSeparator = "-"
                        }
                    };
                    if (DateTime.TryParse(dt, out dt1))
                    {
                        re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH")
                        {
                            DateTimeFormat =
                            {
                                DateSeparator = "-"
                            }
                        };
                        if (DateTime.TryParse(dt, out dt1))
                        {
                            re = dt1.ToString("yyyy-MM-dd");
                        }
                    }
                    //dt1 = DateTime.Parse(dt.ToString());

                }
            }
            return re;
        }
        public String dateTimetoDB1(Object dt)
        {
            DateTime dt1 = new DateTime();
            String re = "", tim = "";
            if (dt != null)
            {
                if (!dt.Equals(""))
                {
                    // Thread แบบนี้ ทำให้ โปรแกรม ที่ไปลงที Xtrim ไม่เอา date ผิด
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us")
                    {
                        DateTimeFormat =
                        {
                            DateSeparator = "-"
                        }
                    };
                    if (DateTime.TryParse(dt.ToString(), out dt1))
                    {
                        re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH")
                        {
                            DateTimeFormat =
                            {
                                DateSeparator = "-"
                            }
                        };
                        if (DateTime.TryParse(dt.ToString(), out dt1))
                        {
                            re = dt1.ToString("yyyy-MM-dd");
                        }
                    }
                    //dt1 = DateTime.Parse(dt.ToString());

                }
                tim = dt1.ToString("HH:mm:ss");
            }
            return re + " " + tim;
        }
        public String dateTimetoDB(String dt)
        {
            DateTime dt1 = new DateTime();
            String re = "", tim = "";
            if (dt != null)
            {
                if (!dt.Equals(""))
                {
                    // Thread แบบนี้ ทำให้ โปรแกรม ที่ไปลงที Xtrim ไม่เอา date ผิด
                    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-us")
                    {
                        DateTimeFormat =
                        {
                            DateSeparator = "-"
                        }
                    };
                    if (DateTime.TryParse(dt, out dt1))
                    {
                        re = dt1.Year.ToString() + "-" + dt1.ToString("MM-dd");
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH")
                        {
                            DateTimeFormat =
                            {
                                DateSeparator = "-"
                            }
                        };
                        if (DateTime.TryParse(dt, out dt1))
                        {
                            re = dt1.ToString("yyyy-MM-dd");
                        }
                    }
                    //dt1 = DateTime.Parse(dt.ToString());

                }
                tim = dt1.ToString("HH:mm:ss");
            }
            return re + " " + tim;
        }
        public String timetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    re = dt1.ToString("hh:mm:ss");
                }


            }
            return re;
        }
        public String datetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    if (dt1.Year < 1900) return "";
                    re = dt1.ToString("dd-MM-yyyy");
                }
            }
            return re;
        }
        public String datetimetoShow(Object dt)
        {
            DateTime dt1 = new DateTime();
            MySqlDateTime dtm = new MySqlDateTime();
            String re = "";
            if (dt != null)
            {
                if (DateTime.TryParse(dt.ToString(), out dt1))
                {
                    re = dt1.ToString("dd-MM-yyyy HH:mm:ss");
                }
            }
            return re;
        }
        public void setCboDay(C1ComboBox c, String selected)
        {
            ComboBoxItem item = new ComboBoxItem();
            //DataTable dt = selectWard();

            item = new ComboBoxItem();
            item.Value = "";
            item.Text = "";
            c.Items.Add(item);
            for (int i = 1; i <= 6; i++)
            {
                item = new ComboBoxItem();
                item.Value = i.ToString();
                item.Text = i.ToString();
                c.Items.Add(item);
                if (item.Value.Equals(selected))
                {
                    //c.SelectedItem = item.Value;
                    c.SelectedText = item.Text;
                    c.SelectedIndex = i + 1;
                }
            }
        }
        public void setC1ComboPrinter(C1ComboBox c, String data)
        {
            String chk = "", printerDefault = "";
            try
            {
                c.Items.Clear();
                PrinterSettings settings = new PrinterSettings();
                int i = 0;
                ComboBoxItem item1 = new ComboBoxItem();
                item1.Text = "";
                item1.Value = "";
                c.Items.Add(item1);
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    settings.PrinterName = printer;
                    ComboBoxItem item = new ComboBoxItem();
                    item.Text = printer;
                    item.Value = printer;
                    c.Items.Add(item);
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
        public void setC1Combo(C1ComboBox c, String data)
        {
            if (c.Items.Count == 0) return;
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            c.SelectedIndex = 0;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Value.Equals(data))
                {
                    c.SelectedItem = item;
                    break;
                }
            }
        }
        public void setC1ComboByName(C1ComboBox c, String data)
        {
            if (c.Items.Count == 0) return;
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            c.SelectedIndex = 0;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    c.SelectedItem = item;
                    break;
                }
            }
        }
        public String getC1Combo(C1ComboBox c, String data)
        {
            String re = "";
            if (c.Items.Count == 0) return "";
            c.SelectedIndex = c.SelectedItem == null ? 0 : c.SelectedIndex;
            foreach (ComboBoxItem item in c.Items)
            {
                if (item.Text.Equals(data))
                {
                    //c.SelectedItem = item;
                    re = item.Value;
                    break;
                }
            }
            return re;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            //bmp.Dispose();
            return bmp;
        }
        public bool compareImage(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }
        public void savePicFoodstoServer(String fooId, String pathLocalFile)
        {
            string ext = Path.GetExtension(pathLocalFile);
            //if (iniC.ShareFile.Equals("FTP"))
            //{
            
            FileInfo fi1 = new FileInfo(pathLocalFile);
            if (fi1.Exists)
            {
                ftpC.createDirectory(iniC.ShareFile + "/foods");
                ftpC.delete(iniC.ShareFile + "/foods/" + fooId + ext);
                ftpC.upload(iniC.ShareFile + "/foods/" + fooId + ext, pathLocalFile);

                Image loadedImage, resizedImage;
                loadedImage = Image.FromFile(pathLocalFile);
                int originalWidth = 0;
                originalWidth = loadedImage.Width;
                int newWidth = 210;
                resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                //byte[] buf = imgToByteArray(resizedImage);
                var data = new MemoryStream();
                resizedImage.Save(data, ImageFormat.Jpeg);

                //ImageConverter imgCon = new ImageConverter();
                //imgCon.ConvertTo(resizedImage, buf);


                //data.Read(buf, 0, buf.Length);

                ftpC.delete(iniC.ShareFile + "/foods/" + fooId+"_210" + ext);
                ftpC.upload(iniC.ShareFile + "/foods/" + fooId + "_210" + ext, data);
            }
            else
            {
                MessageBox.Show("ไม่พบ File", "");
            }
                //}
                //else
                //{

                //}
                //if (File.Exists(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg))
                //{
                //    File.Delete(@"temppic" + System.Drawing.Imaging.ImageFormat.Jpeg);
                //}
                //pathFile.Save(@"temppic." + System.Drawing.Imaging.ImageFormat.Jpeg, System.Drawing.Imaging.ImageFormat.Jpeg);

                //ftpC.createDirectory("images/foods");

                //ftpC.delete("images/foods/" + fooId + ext);

                //ftpC.upload("images/foods/" + fooId + ext, pathLocalFile);
                mposDB.fooDB.updateFileName(fooId, fooId + ext);
        }
        //convert image to bytearray
        public byte[] imgToByteArray(Image img)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat); 
                return mStream.ToArray();
            }
        }
        public String paymentVNE(String amt, ListBox listBox1)
        {
            String err = "", sql = "";
            VNEresponsePayment vneRspPay = new VNEresponsePayment();
            MySqlConnection conn;
            conn = new MySqlConnection();
            conn.ConnectionString = "Server=" + iniC.hostDB + ";Database=" + iniC.nameDB + ";Uid=" + iniC.userDB + ";Pwd=" + iniC.passDB +
                ";port = " + iniC.portDB + "; Connection Timeout = 300;default command timeout=0; CharSet=utf8;SslMode=none;";
            try
            {
                err = "00";
                var baseAddress = "http://" + iniC.VNEip +iniC.VNEwebapi;
                VNErequestPayment vne = new VNErequestPayment();
                vne.tipo = "1";
                vne.importo = amt;
                vne.opname = "admin";
                vne.operatore = "";
                String txtjson = JsonConvert.SerializeObject(vne, Formatting.Indented);
                //listBox1.Items.Add(txtjson);
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
                    "id='" + vneRspPay.id + "'" +
                    ",importo='" + vneRspPay.importo + "'" +
                    ",tipo='" + vneRspPay.tipo + "'" +
                    ",req_status='" + vneRspPay.importo + "'" +
                    ",active='1'" +
                    ",date_create=now()" +
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
                err = vneRspPay.id;
                //timer.Enabled = true;
                //timer.Start();
                //label9.Text = "Start waiting payment";
                listBox1.Items.Add("insert payment OK");
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            conn.Dispose();
            return err;
        }
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public String ListCardReader()
        {
            string fileName = StartupPath + "\\RDNIDLib.DLX";
            if (System.IO.File.Exists(fileName) == false)
            {
                MessageBox.Show("RDNIDLib.DLX not found");
            }

            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            //this.Text = String.Format("R&D NID Card VC# {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);


            byte[] _lic = String2Byte(fileName);

            int nres = 0;
            nres = RDNID.openNIDLibRD(_lic);
            if (nres != 0)
            {
                String m;
                m = String.Format(" error no {0} ", nres);
                MessageBox.Show(m);
            }

            byte[] Licinfo = new byte[1024];

            RDNID.getLicenseInfoRD(Licinfo);

            //m_lblDLXInfo.Text = aByteToString(Licinfo);

            byte[] Softinfo = new byte[1024];
            RDNID.getSoftwareInfoRD(Softinfo);
            //m_lblSoftwareInfo.Text = aByteToString(Softinfo);

            String re = "";
            byte[] szReaders = new byte[1024 * 2];
            int size = szReaders.Length;
            int numreader = RDNID.getReaderListRD(szReaders, size);
            if (numreader <= 0)
                return "";
            String s = aByteToString(szReaders);
            String[] readlist = s.Split(';');
            if (readlist != null)
            {
                re = readlist[0];
                //for (int i = 0; i < readlist.Length; i++)
                //    m_ListReaderCard.Items.Add(readlist[i]);
                //m_ListReaderCard.SelectedIndex = 0;
            }
            return re;
        }
        public string aByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;

            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }
        public IntPtr selectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = String2Byte(reader);
            IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
                mCard = (IntPtr)res;
            return mCard;
        }
        static byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }
        public String _yyyymmdd_(String d)
        {
            string s = "";
            string _yyyy = d.Substring(0, 4);
            string _mm = d.Substring(4, 2);
            string _dd = d.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
            string _tm = "-";
            if (_mm == "00")
            {
                _tm = "-";
            }
            else
            {
                _tm = mm[int.Parse(_mm)];
            }
            if (_yyyy == "0000")
                _yyyy = "-";

            if (_dd == "00")
                _dd = "-";

            s = _dd + " " + _tm + " " + _yyyy;
            return s;
        }
        public String ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน", "ล้าน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            bahtTH = "";

            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                //intVal = "11";
                if (intVal.Length > 7)
                {
                    string intVal1 = intVal.Substring(0, (intVal.Length - 6));
                    intVal = intVal.Substring(intVal.Length - 6);
                    for (int i = 0; i < intVal1.Length; i++)
                    {
                        n = intVal1.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == (intVal1.Length - 1)) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (intVal1.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (intVal1.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];

                            bahtTH += rank[(intVal1.Length - i) - 1];
                        }
                    }
                    bahtTH += "ล้าน";
                }
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];

                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }

            return bahtTH;
        }
    }
}
