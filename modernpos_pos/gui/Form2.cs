using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void pdPrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x, y, lineOffset;

            // Instantiate font objects used in printing.
            Font printFont = new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular, GraphicsUnit.Point); // Substituted to FontA Font

            e.Graphics.PageUnit = GraphicsUnit.Point;

            // Draw the bitmap
            x = 79;
            y = 0;
            //e.Graphics.DrawImage(pbImage.Image, x, y, pbImage.Image.Width - 13, pbImage.Image.Height - 10);

            // Print the receipt text
            lineOffset = printFont.GetHeight(e.Graphics) - (float)3.5;
            x = 10;
            y = 24 + lineOffset;
            for (int i = 0; i < 500; i++)
            {
                e.Graphics.DrawString("123xxstreet,xxxcity,xxxxstate", printFont, Brushes.Black, x, y);
                y += lineOffset;
            }

            e.Graphics.DrawString("              TEL   9999-99-9999       C#2", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("       November.23, 2007     PM 4:24", printFont, Brushes.Black, x, y);
            y = y + (lineOffset * (float)2.5);
            e.Graphics.DrawString("apples                       $20.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("grapes                       $30.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("bananas                      $40.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("lemons                       $50.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("oranges                      $60.00", printFont, Brushes.Black, x, y);
            y += (lineOffset * (float)2.3);
            e.Graphics.DrawString("Tax excluded.               $200.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("Tax     5.0%                 $10.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("___________________________________", printFont, Brushes.Black, x, y);

            printFont = new Font("Microsoft Sans Serif", 20, FontStyle.Regular, GraphicsUnit.Point);
            lineOffset = printFont.GetHeight(e.Graphics) - 3;
            y += lineOffset;
            e.Graphics.DrawString("Total     $210.00", printFont, Brushes.Black, x - 1, y);

            printFont = new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular, GraphicsUnit.Point);
            lineOffset = printFont.GetHeight(e.Graphics);
            y = y + lineOffset + 1;
            e.Graphics.DrawString("Customer's payment         $250.00", printFont, Brushes.Black, x, y);
            y += lineOffset;
            e.Graphics.DrawString("Change                      $40.00", printFont, Brushes.Black, x, y - 2);

            // Indicate that no more data to print, and the Print Document can now send the print data to the spooler.
            e.HasMorePages = false;
        }
        private void Form2_Load(object sender, EventArgs e)
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Boolean isFinish;
            PrintDocument pdPrint = new PrintDocument();
            pdPrint.PrintPage += new PrintPageEventHandler(pdPrint_PrintPage);
            // Change the printer to the indicated printer.
            pdPrint.PrinterSettings.PrinterName = cboPrinter.Text;

            try
            {
                // Open a printer status monitor for the selected printer.
                if (true)
                {
                    if (pdPrint.PrinterSettings.IsValid)
                    {
                        pdPrint.DocumentName = "Testing";
                        // Start printing.
                        pdPrint.Print();

                        // Check printing status.
                        isFinish = false;

                        // Perform the status check as long as the status is not ASB_PRINT_SUCCESS.
                        //do
                        //{
                        //    if (m_objAPI.Status.ToString().Contains(ASB.ASB_PRINT_SUCCESS.ToString()))
                        //        isFinish = true;

                        //} while (!isFinish);

                        // Notify printing completion.
                        MessageBox.Show("Printing complete.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Printer is not available.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    // Always close the Status Monitor after using the Status API.
                    //if (m_objAPI.CloseMonPrinter() != ErrorCode.SUCCESS)
                    //    MessageBox.Show("Failed to close printer status monitor.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                    MessageBox.Show("Failed to open printer status monitor.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Failed to open StatusAPI.", "Program06", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
