using C1.Win.C1Command;
using C1.Win.C1FlexGrid;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Tile;
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
    public partial class FrmTakeOut3 : Form
    {
        mPOSControl mposC;
        Font fEdit, fEditB, fEdit1, fgrd;

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
        int colOrdNo = 1, colOrdFooName = 2, colOrdPrice = 3, colOrdQty = 5, colOrdqtyplus = 6, colOrdqtyminus = 4, colOrdRemark = 7, colOrdTopping = 8, colOrdArrowDown = 9, colOrdThrumb = 10, colOrdStatus = 11, colOrdFooId = 12, colOrdPrinterName = 13, colOrdFooName1 = 14;
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
        Boolean flagModi = false, flagShowTitle = false;
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
        public FrmTakeOut3(mPOSControl x, Form frmmain)
        {
            InitializeComponent();
            mposC = x;
            this.frmmain = frmmain;
            initConfig();
        }
        private void initConfig()
        {

        }
        private void FrmTakeOut3_Load(object sender, EventArgs e)
        {

        }
    }
}
