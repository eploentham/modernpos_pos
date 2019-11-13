using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using modernpos_pos.control;
using modernpos_pos.object1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.gui
{
    public partial class FrmStockCard : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;

        C1FlexGrid  grfOrder;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;
        C1DockingTab tcMain;
        C1DockingTabPage tabOnhand;

        int colId = 1, colCode = 2, colName = 3, colPrice = 4, colWeight = 5, colOnhand=6; 
        public FrmStockCard(mPOSControl x)
        {
            InitializeComponent();
            this.mposC = x;
            initConfig();
        }
        private void initConfig()
        {
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            tcMain = new C1DockingTab();
            tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            tcMain.Location = new System.Drawing.Point(0, 266);
            tcMain.Name = "c1DockingTab1";
            tcMain.Size = new System.Drawing.Size(669, 200);
            tcMain.TabIndex = 0;
            tcMain.TabsSpacing = 5;
            panel2.Controls.Add(tcMain);
            theme1.SetTheme(tcMain, mposC.iniC.themeApplication);
            theme1.SetTheme(panel1, mposC.iniC.themeApplication);
            theme1.SetTheme(panel2, mposC.iniC.themeApplication);
            theme1.SetTheme(cboYear, mposC.iniC.themeApplication);
            theme1.SetTheme(label7, mposC.iniC.themeApplication);

            tabOnhand = new C1DockingTabPage();
            tabOnhand.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabOnhand.Size = new System.Drawing.Size(667, 175);
            tabOnhand.TabIndex = 0;
            tabOnhand.Text = "Material";
            tabOnhand.Name = "tabMat";
            //theme1.SetTheme(tabOnhand, mposC.iniC.themeApplication);
            tcMain.Controls.Add(tabOnhand);

            initgrfOnhand();
            
        }
        private void initgrfOnhand()
        {
            grfOrder = new C1FlexGrid();
            grfOrder.Font = fEdit;
            grfOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            grfOrder.Location = new System.Drawing.Point(0, 0);
            grfOrder.Rows[0].Visible = false;
            grfOrder.Cols[0].Visible = true;
            grfOrder.Cols[colId].Visible = false;
            grfOrder.DoubleClick += GrfOrder_DoubleClick;

            grfOrder.Name = "grfOrder";
            theme1.SetTheme(grfOrder, "Office2016Black");
            tabOnhand.Controls.Add(grfOrder);
        }

        private void GrfOrder_DoubleClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            String id = "", name="";
            id = grfOrder[grfOrder.Row, colId] != null ? grfOrder[grfOrder.Row, colId].ToString() : "";
            name = grfOrder[grfOrder.Row, colName] != null ? grfOrder[grfOrder.Row, colName].ToString() : "";

            C1DockingTabPage tabMat = new C1DockingTabPage();
            tabMat.Location = new System.Drawing.Point(1, 24);
            //tabScan.Name = "c1DockingTabPage1";
            tabMat.Size = new System.Drawing.Size(667, 175);
            tabMat.TabIndex = 0;
            tabMat.Text = name;
            tabMat.Name = "tab"+ id;
            //theme1.SetTheme(tabOnhand, mposC.iniC.themeApplication);
            tcMain.Controls.Add(tabMat);

            C1FlexGrid grf = new C1FlexGrid();
            grf = new C1FlexGrid();
            grf.Font = fEdit;
            grf.Dock = System.Windows.Forms.DockStyle.Fill;
            grf.Location = new System.Drawing.Point(0, 0);
            grf.Rows[0].Visible = false;
            grf.Cols[0].Visible = true;
            grf.Cols[colId].Visible = false;
            //grf.DoubleClick += GrfOrder_DoubleClick;

            grf.Name = "grf"+id;
            theme1.SetTheme(grf, "Office2016Black");
            tabMat.Controls.Add(grf);
            setGrf(grf, id);
            tcMain.SelectedTab = tabMat;
        }
        private void setGrf(C1FlexGrid grf, String matid)
        {
            grf.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.stkDB.selectByMatId(matid);
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grf.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grf.Cols.Count = 7;

            grf.Cols[colCode].Caption = "วันที่";
            grf.Cols[colName].Caption = "รายการ";
            grf.Cols[colPrice].Caption = "Price";
            grf.Cols[colWeight].Caption = "Weight";
            grf.Cols[colOnhand].Caption = "OnHand";
            grf.Cols[colCode].Width = 120;
            grf.Cols[colName].Width = 200;
            grf.Cols[colPrice].Width = 120;
            grf.Cols[colWeight].Width = 120;
            grf.Cols[colOnhand].Width = 120;

            grf.ShowCursor = true;

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    //Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grf[i, colId] = row[mposC.mposDB.stkDB.stkc.stock_id].ToString();
                    grf[i, colCode] = mposC.datetoShow(row[mposC.mposDB.stkDB.stkc.rec_draw_date].ToString());
                    grf[i, colName] = row[mposC.mposDB.stkDB.stkc.status_rec_draw].ToString().Equals("1") 
                        ? "รับเข้า" : row[mposC.mposDB.stkDB.stkc.status_rec_draw].ToString().Equals("2") 
                        ? "เบิกจ่าย" : row[mposC.mposDB.stkDB.stkc.status_rec_draw].ToString().Equals("3") ? "ขาย" : "อื่นๆ";
                    grf[i, colPrice] = row[mposC.mposDB.stkDB.stkc.price].ToString();
                    grf[i, colWeight] = row[mposC.mposDB.stkDB.stkc.weight].ToString();
                    grf[i, colOnhand] = row[mposC.mposDB.stkDB.stkc.onhand].ToString();
                    //grfOrder[i, colRsLotInput] = row[ic.ivfDB.lbresDB.lbRes.lot_input].ToString();

                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grf);
            grf.Cols[colId].Visible = false;
            //grfOrder.Cols[colRsLabId].Visible = false;
            //grfOrder.Cols[colRsReqId].Visible = false;
            //grfOrder.Cols[colRsEdit].Visible = false;
            //grfOrder.Cols[colRsLotInput].Visible = false;

            grf.Cols[colCode].AllowEditing = false;
            grf.Cols[colOnhand].AllowEditing = false;
            grf.Cols[colName].AllowEditing = false;
            grf.Cols[colPrice].AllowEditing = false;
            grf.Cols[colWeight].AllowEditing = true;

            //theme1.SetTheme(grfFinish, ic.theme);
        }
        private void setGrfOnhand()
        {
            grfOrder.Clear();
            DataTable dt = new DataTable();
            dt = mposC.mposDB.matDB.selectAll();
            //grfExpn.Rows.Count = dt.Rows.Count + 1;
            grfOrder.Rows.Count = dt.Rows.Count + 1;
            //grfSperm.DataSource = dt;
            grfOrder.Cols.Count = 7;

            grfOrder.Cols[colCode].Caption = "CODE";
            grfOrder.Cols[colName].Caption = "ชื่อ";
            grfOrder.Cols[colPrice].Caption = "Price";
            grfOrder.Cols[colWeight].Caption = "Weight";
            grfOrder.Cols[colOnhand].Caption = "OnHand";
            grfOrder.Cols[colCode].Width = 120;
            grfOrder.Cols[colName].Width = 200;
            grfOrder.Cols[colPrice].Width = 120;
            grfOrder.Cols[colWeight].Width = 120;
            grfOrder.Cols[colOnhand].Width = 120;

            grfOrder.ShowCursor = true;

            int i = 0;
            decimal aaa = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    i++;
                    //if (i == 1) continue;
                    //Decimal.TryParse(row[ic.ivfDB.oLabiDB.labI.Price].ToString(), out aaa);
                    grfOrder[i, colId] = row[mposC.mposDB.matDB.mat.material_id].ToString();
                    grfOrder[i, colCode] = row[mposC.mposDB.matDB.mat.material_code].ToString();
                    grfOrder[i, colName] = row[mposC.mposDB.matDB.mat.material_name].ToString();
                    grfOrder[i, colPrice] = row[mposC.mposDB.matDB.mat.price].ToString();
                    grfOrder[i, colWeight] = row[mposC.mposDB.matDB.mat.weight].ToString();
                    grfOrder[i, colOnhand] = row[mposC.mposDB.matDB.mat.on_hand].ToString();
                    //grfOrder[i, colRsLotInput] = row[ic.ivfDB.lbresDB.lbRes.lot_input].ToString();

                    row[0] = (i - 2);
                }
                catch (Exception ex)
                {
                    String err = "";
                }
            }
            CellNoteManager mgr = new CellNoteManager(grfOrder);
            grfOrder.Cols[colId].Visible = false;
            //grfOrder.Cols[colRsLabId].Visible = false;
            //grfOrder.Cols[colRsReqId].Visible = false;
            //grfOrder.Cols[colRsEdit].Visible = false;
            //grfOrder.Cols[colRsLotInput].Visible = false;

            grfOrder.Cols[colCode].AllowEditing = false;
            grfOrder.Cols[colOnhand].AllowEditing = false;
            grfOrder.Cols[colName].AllowEditing = false;
            grfOrder.Cols[colPrice].AllowEditing = false;
            grfOrder.Cols[colWeight].AllowEditing = true;
            
            //theme1.SetTheme(grfFinish, ic.theme);
        }
        private void FrmStockCard_Load(object sender, EventArgs e)
        {
            String re = mposC.mposDB.matDB.genStock();
            setGrfOnhand();
        }
    }
}
