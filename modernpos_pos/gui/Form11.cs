using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos
{
    public partial class Form11 : Form
    {
        private PrintDocument printDocument = new PrintDocument();
        private static String RECEIPT = Environment.CurrentDirectory + @"comprovante.txt";
        private String stringToPrint = "";
        public Form11()
        {
            InitializeComponent();
            generateReceipt();
        }
        private void generateReceipt()
        {
            FileStream fs = new FileStream(RECEIPT, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine("==========================================");
            writer.WriteLine("          NOME DA EMPRESA AQUI            ");
            writer.WriteLine("==========================================");
            writer.Close();
            fs.Close();
        }
        private void printReceipt()
        {
            if (File.Exists(RECEIPT))
            {
                FileStream fs = new FileStream(RECEIPT, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                stringToPrint = sr.ReadToEnd();
                printDocument.PrinterSettings.PrinterName = cboPrinter.Text;
                printDocument.PrintPage += new PrintPageEventHandler(printPage);
                printDocument.Print();
                sr.Close();
                fs.Close();
            }
            
        }
        private void printPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            Graphics graphics = e.Graphics;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            graphics.MeasureString(stringToPrint, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page
            graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(cboPrinter.Text, GetDocument());
            //printReceipt();
        }
        private byte[] GetDocument()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                // Reset the printer bws (NV images are not cleared)
                bw.Write(AsciiControlChars.Escape);
                bw.Write('@');

                // Render the logo
                //RenderLogo(bw);
                PrintReceipt(bw);
                //printReceipt();
                // Feed 3 vertical motion units and cut the paper with a 1 point cut
                bw.Write(AsciiControlChars.GroupSeparator);
                bw.Write('V');
                bw.Write((byte)66);
                bw.Write((byte)3);

                bw.Flush();

                return ms.ToArray();
            }
        }
        private void PrintReceipt(BinaryWriter bw)
        {
            var utf8bytes = Encoding.UTF8.GetBytes("     กกกกกกก");
            byte[] win1252Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-874"), utf8bytes);
            bw.LargeText(win1252Bytes);
            bw.LargeText("  Enterprises");
            bw.NormalFont("  M:071-2628126 T:045-2271300");
            bw.FeedLines(1);
            bw.NormalFont("Invoice #: 123456");
            bw.NormalFont("Date: 01-12-2561" );
            bw.NormalFont("Customer: aaaaaa" );
            bw.FeedLines(1);

            bw.NormalFont("Itm     Qty     Price    Tot");
            bw.NormalFont("-----------------------------");
            //foreach (var item in _mappedInvoice.InvoiceItems)
            //{
            //    // var idx = InvoiceItems.IndexOf(item) + 1;
            //    bw.NormalFont(ReadOnlyItem.GetById(item.ItemID).Name);
            //    bw.NormalFont("       {0}   {1}  {2}".FormatWith(item.Qty, item.UnitPrice, item.Qty * item.UnitPrice), false);

            //}
            bw.FeedLines(2);
            bw.NormalFont(" Discount:  " );
            bw.NormalFont("Sub Total:  " );
            bw.FeedLines(1);
            bw.High("     Total:  ");
            bw.FeedLines(1);
            bw.NormalFont("  Payment:  " );
            bw.NormalFont("  Balance:  " );
            bw.Finish();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
        private static void Print(string printerName, byte[] document)
        {

            NativeMethods.DOC_INFO_1 documentInfo;
            IntPtr printerHandle;

            documentInfo = new NativeMethods.DOC_INFO_1();
            documentInfo.pDataType = "RAW";
            documentInfo.pDocName = "Receipt";

            printerHandle = new IntPtr(0);

            if (NativeMethods.OpenPrinter(printerName.Normalize(), out printerHandle, IntPtr.Zero))
            {
                if (NativeMethods.StartDocPrinter(printerHandle, 1, documentInfo))
                {
                    int bytesWritten;
                    byte[] managedData;
                    IntPtr unmanagedData;

                    managedData = document;
                    unmanagedData = Marshal.AllocCoTaskMem(managedData.Length);
                    Marshal.Copy(managedData, 0, unmanagedData, managedData.Length);

                    if (NativeMethods.StartPagePrinter(printerHandle))
                    {
                        NativeMethods.WritePrinter(
                            printerHandle,
                            unmanagedData,
                            managedData.Length,
                            out bytesWritten);
                        NativeMethods.EndPagePrinter(printerHandle);
                    }
                    else
                    {
                        throw new Win32Exception();
                    }

                    Marshal.FreeCoTaskMem(unmanagedData);

                    NativeMethods.EndDocPrinter(printerHandle);
                }
                else
                {
                    throw new Win32Exception();
                }

                NativeMethods.ClosePrinter(printerHandle);
            }
            else
            {
                throw new Win32Exception();
            }

        }
    }

}
