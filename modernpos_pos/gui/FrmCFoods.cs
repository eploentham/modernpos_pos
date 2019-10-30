using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1SuperTooltip;
using C1.Win.C1Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using modernpos_pos.control;
using modernpos_pos.object1;
using modernpos_pos.Properties;
using System.IO;

namespace modernpos_pos.gui
{
    public partial class FrmCFoods : Form
    {
        mPOSControl mposC;
        Foods foo;

        Font fEdit, fEditB;

        Color bg, fc;
        Font ff, ffB;
        int colID = 1, colCode = 2, colName = 3, colRemark = 4, colE = 5, colS = 6, coledit = 7, colCnt = 7;
        int colFmId = 1, colFmName = 2, colFmprice = 3, colFmWeight = 4, colFmQty = 5, colFmTotal=6, colFmedit = 7;
        int colmId = 1, colmName = 2, colmPrice = 3, colmWeight = 4;

        C1FlexGrid grfFoo, grfRec, grfFooS, grfFooT, grfMat, grfFooM;

        //C1TextBox txtPassword = new C1.Win.C1Input.C1TextBox();
        Boolean flagEdit = false, pageLoad=false;
        C1SuperTooltip stt;
        C1SuperErrorProvider sep;

        String userIdVoid = "";
        public FrmCFoods(mPOSControl x)
        {
            InitializeComponent();
            mposC = x;
            initConfig();
        }

        private void initConfig()
        {
            foo = new Foods();
            fEdit = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Regular);
            fEditB = new Font(mposC.iniC.grdViewFontName, mposC.grdViewFontSize, FontStyle.Bold);

            //C1ThemeController.ApplicationTheme = mposC.iniC.themeApplication;
            theme1.Theme = mposC.iniC.themeApplication;
            theme1.SetTheme(sB, "BeigeOne");
            foreach (Control c in panel3.Controls)
            {
                if (c is C1PictureBox) continue;
                theme1.SetTheme(c, mposC.iniC.themeApplication);
            }

            bg = txtFooCode.BackColor;
            fc = txtFooCode.ForeColor;
            ff = txtFooCode.Font;
            txtPasswordVoid.KeyUp += TxtPasswordVoid_KeyUp;
            btnImg.Click += BtnImg_Click;
            tC.Click += TC_Click;
            btnFoosSave.Click += BtnFoosSave_Click;
            btnFoosNew.Click += BtnFoosNew_Click;
            btnFoosVoid.Click += BtnFoosVoid_Click;
            btnFootSave.Click += BtnFootSave_Click;
            btnFootNew.Click += BtnFootNew_Click;
            btnFootVoid.Click += BtnFootVoid_Click;
            btnFoomAdd.Click += BtnFoomAdd_Click;
            btnFoomVoid.Click += BtnFoomVoid_Click;
            //btnFoomNew.Click += BtnFoomNew_Click;
            //btnFoomSave.Click += BtnFoomSave_Click;

            mposC.mposDB.resDB.setCboRestaurant(cboRes);
            mposC.mposDB.footDB.setCboFoodsType(cboFoodsType);
            mposC.mposDB.foocDB.setCboFoodsCat(cboFoodsCat);
            mposC.setC1ComboPrinter(cboPrinter,"");

            initGrfFoo();
            initGrfRec();
            initGrfSpec();
            initGrfTopping();
            initGrfMaterial();
            initGrfFoodsMaterial();
            setGrfFoo();

            setGrfRec();
            
            setControlEnable(false);
            setFocusColor();
            sB1.Text = "";
            btnVoid.Hide();
            txtPasswordVoid.Hide();
            stt = new C1SuperTooltip();
            sep = new C1SuperErrorProvider();
            picFoo.SizeMode = PictureBoxSizeMode.StretchImage;
            //stt.BackgroundGradient = C1.Win.C1SuperTooltip.BackgroundGradient.Gold;
        }

        private void BtnFoomVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            voidFoodsMaterial();
        }

        private void BtnFoomAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            saveFoodsMaterial();
        }
        private void voidFoodsMaterial()
        {
            if (grfFooM.Row <= 0) return;
            if (grfFooM.Col <= 1) return;
            String foomid = "", foomname = "", foomprice = "", foomqty = "", foomweight = "", matid = "";
            matid = grfFooM[grfFooM.Row, 1] != null ? grfFooM[grfFooM.Row, 1].ToString() : "";
            mposC.mposDB.foomDB.voidFoodsMeterial(matid, "");
            setGrfFoodsMaterial(txtID.Text);
        }
        private void saveFoodsMaterial()
        {
            //throw new NotImplementedException();
            if(grfMat.Row <= 0) return;
            if (grfMat.Col <= 1) return;

            String foomid = "", foomname = "", foomprice = "", foomqty = "", foomweight = "", matid="";
            matid = grfMat[grfMat.Row, colFmId] != null ? grfMat[grfMat.Row, colFmId].ToString() : "";
            foomname = grfMat[grfMat.Row, colFmName] != null ? grfMat[grfMat.Row, colFmName].ToString() : "";
            foomprice = grfMat[grfMat.Row, colFmprice] != null ? grfMat[grfMat.Row, colFmprice].ToString() : "";
            foomweight = grfMat[grfMat.Row, colFmWeight] != null ? grfMat[grfMat.Row, colFmWeight].ToString() : "";
            //foomid = grfMat[grfMat.Row, 1] != null ? grfMat[grfMat.Row, 1].ToString() : "";

            FoodsMaterial foom = new FoodsMaterial();
            foom.foods_material_id = "";
            foom.foods_id = txtID.Text;
            foom.material_id = matid.Trim();
            foom.material_name = foomname;
            foom.active = "1";
            foom.remark = "";
            foom.sort1 = "";
            foom.date_cancel = "";
            foom.date_create = "";
            foom.date_modi = "";
            foom.user_cancel = "";
            foom.user_create = "";
            foom.user_modi = "";
            foom.host_id = "";
            foom.branch_id = "";
            foom.device_id = mposC.MACAddress;
            foom.price = foomprice;
            foom.qty = "1";
            foom.weight = foomweight;
            mposC.mposDB.foomDB.insertFoodsMaterial(foom, "");
            setGrfFoodsMaterial(txtID.Text);
        }

        private void BtnFoomNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //txtFoomId.Value = "";
            //txtFoomName.Value = "";
            //txtFoomPrice.Value = "";
            //txtFoomWeight.Value = "";
            //txtFoomQty.Value = "";
        }

        private void BtnFootVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtFootpId.Text.Equals("")) return;
            mposC.mposDB.footpDB.voidFoodsTopping(txtFootpId.Text, "");
            setGrfTopping(txtID.Text);
            //setGrfTopping(txtID.Text);
        }

        private void BtnFootNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtFootpId.Value = "";
            txtFootpName.Value = "";
            txtFootpPrice.Value = "";
        }

        private void BtnFootSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FoodsTopping footp = new FoodsTopping();
            footp.foods_topping_id = txtFootpId.Text;
            footp.foods_id = txtID.Text;
            footp.foods_topping_name = txtFootpName.Text;
            footp.active = "1";
            footp.remark = "";
            footp.sort1 = "";
            footp.date_cancel = "";
            footp.date_create = "";
            footp.date_modi = "";
            footp.user_cancel = "";
            footp.user_create = "";
            footp.user_modi = "";
            footp.host_id = "";
            footp.branch_id = "";
            footp.device_id = mposC.MACAddress;
            footp.price = txtFootpPrice.Text;
            mposC.mposDB.footpDB.insertFoodsTopping(footp, "");
            setGrfTopping(txtID.Text);
        }

        private void BtnFoosVoid_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtFoosId.Text.Equals("")) return;
            mposC.mposDB.foosDB.voidFoodsSpecial(txtFoosId.Text,"");
            setGrfSpec(txtID.Text);
        }

        private void BtnFoosNew_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            txtFoosId.Value = "";
            txtFoosName.Value = "";
        }

        private void BtnFoosSave_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            FoodsSpecial foos = new FoodsSpecial();
            foos.foods_spec_id = txtFoosId.Text;
            foos.foods_id = txtID.Text;
            foos.foods_spec_name = txtFoosName.Text;
            foos.active = "1";
            foos.remark = "";
            foos.sort1 = "";
            foos.date_cancel = "";
            foos.date_create = "";
            foos.date_modi = "";
            foos.user_cancel = "";
            foos.user_create = "";
            foos.user_modi = "";
            foos.host_id = "";
            foos.branch_id = "";
            foos.device_id = mposC.MACAddress;
            mposC.mposDB.foosDB.insertFoodsSpecial(foos, "");
            setGrfSpec(txtID.Text);
        }

        private void TC_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(tC.SelectedTab == tabRecommend)
            {
                setGrfRec();
            }
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (txtID.Text.Length <= 0) return;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images (*.BMP;*.JPG;*.Jepg;*.Png;*.GIF)|*.BMP;*.JPG;*.Jepg;*.Png;*.GIF|Pdf Files|*.pdf|All files (*.*)|*.*";
            ofd.Multiselect = false;
            ofd.Title = "My Image Browser";
            DialogResult dr = ofd.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(ofd.FileName))
                {
                    mposC.savePicFoodstoServer(txtID.Text, ofd.FileName);
                    showImg();
                }
            }
        }
        private void showImg()
        {
            if (pageLoad) return;
            try
            {
                picFoo.Image = null;
                MemoryStream stream = new MemoryStream();
                Image loadedImage = null, resizedImage;
                if (foo.filename.Equals("")) return;
                string ext = Path.GetExtension(foo.filename);
                String filename = "/foods/" + foo.filename.Replace(ext,"")+"_210" +ext;
                stream = mposC.ftpC.download(mposC.iniC.ShareFile + filename);
                loadedImage = new Bitmap(stream);
                if (loadedImage != null)
                {
                    int originalWidth = loadedImage.Width;
                    int newWidth = 210;
                    resizedImage = loadedImage.GetThumbnailImage(newWidth, (newWidth * loadedImage.Height) / originalWidth, null, IntPtr.Zero);
                    picFoo.Image = resizedImage;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message, "showImg");
            }
        }
        private void initGrfFoodsMaterial()
        {
            grfFooM = new C1FlexGrid();
            grfFooM.Font = fEdit;
            grfFooM.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooM.Location = new System.Drawing.Point(0, 0);
            grfFooM.Rows.Count = 1;
            grfFooM.Cols[colFmId].Width = 60;

            grfFooM.Cols[colFmName].Width = 200;
            grfFooM.Cols[colFmprice].Width = 120;
            grfFooM.Cols[colFmWeight].Width = 120;
            grfFooM.Cols[colFmQty].Width = 70;

            grfFooM.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooM.Cols[colFmName].Caption = "Material";
            grfFooM.Cols[colFmprice].Caption = "Price";
            grfFooM.Cols[colFmWeight].Caption = "Weight";
            grfFooM.Cols[colFmQty].Caption = "Qty";
            grfFooM.Cols[colFmTotal].Caption = "Total";
            //FilterRow fr = new FilterRow(grfPosi);

            grfFooM.CellChanged += GrfFooM_CellChanged;

            pnMaterialAdd.Controls.Add(this.grfFooM);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooM, theme);
        }

        private void GrfFooM_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Col == colFmWeight)
            {
                calTotal();
            }
        }
        private void calTotal()
        {
            Decimal nettotal = 0;
            foreach (Row row in grfFooM.Rows)
            {
                String qty = "", price = "", weight = "";
                Decimal total1 = 0;
                qty = row[colFmQty] != null ? row[colFmQty].ToString() : "";
                price = row[colFmprice] != null ? row[colFmprice].ToString() : "";
                weight = row[colFmWeight] != null ? row[colFmWeight].ToString() : "";
                String total = calMaterial(qty, price, weight);
                Decimal.TryParse(total, out total1);
                row[colFmTotal] = total;
                nettotal += total1;
            }
            txtMatTotal.Value = nettotal;
        }
        private String calMaterial(String qty, String price, String weight)
        {
            String total = "";
            Decimal qty1 = 0, weight1 = 0, price1 = 0, total1 = 0;
            Decimal.TryParse(qty, out qty1);
            Decimal.TryParse(price, out price1);
            Decimal.TryParse(weight, out weight1);
            total1 = ((qty1 * weight1) * price1) / 1000;
            return total1.ToString();
        }
        private void setGrfFoodsMaterial(String fooId)
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfFooM.Clear();
            //grfFooM.Rows.Count = 1;
            DataTable dt = new DataTable();
            dt = mposC.mposDB.foomDB.selectByFoodsId(fooId);
            grfFooM.Cols.Count = 8;
            grfFooM.Rows.Count = 1;
            //CellStyle cs = grfFooM.Styles.Add("btn");
            //cs.DataType = typeof(Button);
            ////cs.ComboList = "|Tom|Dick|Harry";
            //cs.ForeColor = Color.Navy;
            //cs.Font = new Font(Font, FontStyle.Bold);
            //cs = grfFooM.Styles.Add("date");
            //cs.DataType = typeof(DateTime);
            //cs.Format = "dd-MMM-yy";
            //cs.ForeColor = Color.DarkGoldenrod;

            grfFooM.Cols[colFmId].Width = 60;

            grfFooM.Cols[colFmName].Width = 200;
            grfFooM.Cols[colFmprice].Width = 120;
            grfFooM.Cols[colFmWeight].Width = 120;
            grfFooM.Cols[colFmQty].Width = 70;

            grfFooM.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooM.Cols[colFmName].Caption = "Material";
            grfFooM.Cols[colFmprice].Caption = "Price";
            grfFooM.Cols[colFmWeight].Caption = "Weight";
            grfFooM.Cols[colFmQty].Caption = "Qty";
            grfFooM.Cols[colFmTotal].Caption = "Total";

            //grfFooM.AfterRowColChange += GrfFooM_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFooM.GetCellRange(2, colE);
            int i = 1;
            Decimal nettotal = 0;
            foreach (DataRow row in dt.Rows)
            {
                Row row1 = grfFooM.Rows.Add();
                row1[0] = i; 
                String price = "", qty = "", weight = "";
                Decimal price1 =0, qty1 = 0, weight1 =0, total1=0;
                row1[colFmprice] = row[mposC.mposDB.foomDB.foom.price].ToString();
                row1[colFmName] = row[mposC.mposDB.foomDB.foom.material_name].ToString();
                row1[colFmWeight] = row[mposC.mposDB.foomDB.foom.weight].ToString();
                row1[colFmQty] = row[mposC.mposDB.foomDB.foom.qty].ToString();
                row1[colFmId] = row[mposC.mposDB.foomDB.foom.foods_material_id].ToString();

                price = row1[colFmprice] != null ? row1[colFmprice].ToString() : "";
                qty = row1[colFmQty] != null ? row1[colFmQty].ToString() : "";
                weight = row1[colFmWeight] != null ? row1[colFmWeight].ToString() : "";
                //Decimal.TryParse(price, out price1);
                //Decimal.TryParse(qty, out qty1);
                //Decimal.TryParse(weight, out weight1);
                String total = calMaterial(qty, price, weight);
                Decimal.TryParse(total, out total1);
                //total1 = price1 * qty1;
                nettotal += total1;
                //price = grfFooM[grfFooM.Row, grfFooM.Col] != null ? grfFooM[grfFooM.Row, grfFooM.Col].ToString() : "";
                row1[colFmTotal] = Math.Round(total1,4);

                if (i % 2 == 0)
                    grfFooM.Rows[i-1].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                    //row1[i].st = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
                i++;
            }
            //grfFooT.Cols[colCode].Visible = false;
            grfFooM.Cols[colFmId].Visible = false;
            grfFooM.Cols[colFmedit].Visible = false; 
            grfFooM.Cols[colFmName].AllowEditing = false;
            grfFooM.Cols[colFmprice].AllowEditing = false;
            grfFooM.Cols[colFmWeight].AllowEditing = true;
            grfFooM.Cols[colFmQty].AllowEditing = false;
            grfFooM.Cols[colFmTotal].AllowEditing = false;
            lbMatCnt.Text = grfFooM.Rows.Count.ToString();
            txtMatTotal.Value = nettotal;
            pageLoad = false;
            //calTotal();
        }

        private void GrfFooM_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfMat.Row < 0) return;
            if (grfMat.Col < 0) return;
            if (grfMat[grfMat.Row, grfFooS.Col] == null) return;
            String id = "", name = "", price = "";
            id = grfMat[grfMat.Row, colFmId].ToString();
            name = grfMat[grfMat.Row, colFmName].ToString();
            price = grfMat[grfMat.Row, colFmprice].ToString();
            //txtFoomId.Value = id;
            //txtFoomName.Value = name;
            //txtFoomPrice.Value = price;
        }
        private void initGrfMaterial()
        {
            grfMat = new C1FlexGrid();
            grfMat.Font = fEdit;
            grfMat.Dock = System.Windows.Forms.DockStyle.Fill;
            grfMat.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfMat.CellChanged += GrfMat_CellChanged;

            pnMaterialView.Controls.Add(this.grfMat);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfMat, theme);
        }

        private void GrfMat_CellChanged(object sender, RowColEventArgs e)
        {
            //throw new NotImplementedException();
            //if (e.Col == colFmQty)
            //{
            //    foreach(Row row in grfMat.Rows)
            //    {
            //        String qty = "", price = "", weight = "";
            //        qty = row[colFmQty] != null ? row[colFmQty].ToString() : "";
            //        price = row[colFmprice] != null ? row[colFmprice].ToString() : "";
            //        weight = row[colFmWeight] != null ? row[colFmWeight].ToString() : "";
            //        String total = calMaterial(qty, price, weight);
            //        row[colFmTotal] = total;
            //    }
            //}
        }
        
        private void setGrfMaterial(String fooId)
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfMat.DataSource = mposC.mposDB.matDB.selectByFoodsId();
            grfMat.Cols.Count = 5;

            CellStyle cs = grfMat.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfMat.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfMat.Cols[colmId].Width = 60;

            grfMat.Cols[colmName].Width = 180;
            grfMat.Cols[colmPrice].Width = 80;
            grfMat.Cols[colmWeight].Width = 100;

            grfMat.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfMat.Cols[colmName].Caption = "Material";
            grfMat.Cols[colmPrice].Caption = "Price";
            grfMat.Cols[colmWeight].Caption = "Weight";

            grfMat.AfterRowColChange += GrfMat_AfterRowColChange;
            //grfMat.DoubleClick += GrfMat_DoubleClick;
            //grfMat.MouseDoubleClick += GrfMat_MouseDoubleClick;
            
            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfMat.GetCellRange(2, colE);
            for (int i = 1; i < grfMat.Rows.Count; i++)
            {
                grfMat[i, 0] = i;
                if (i % 2 == 0)
                    grfMat.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //grfFooT.Cols[colCode].Visible = false;
            grfMat.Cols[colmId].Visible = false;
            grfMat.Cols[colmId].AllowEditing = false;
            grfMat.Cols[colmName].AllowEditing = false;
            grfMat.Cols[colmPrice].AllowEditing = false;
            grfMat.Cols[colmWeight].AllowEditing = false;
            //grfMat.Cols[colE].AllowEditing = false;
            //grfFooT.Cols[colS].Visible = false;
            pageLoad = false;
        }

        private void GrfMat_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfMat.Row < 0) return;
            if (grfMat.Col < 0) return;
            if (grfMat[grfMat.Row, grfFooS.Col] == null) return;
            String id = "", name = "", price = "";
            id = grfMat[grfMat.Row, colmId].ToString();
            name = grfMat[grfMat.Row, colmName].ToString();
            price = grfMat[grfMat.Row, colmPrice].ToString();
            //txtFoomId.Value = id;
            //txtFoomName.Value = name;
            //txtFoomPrice.Value = price;
        }
        private void initGrfTopping()
        {
            grfFooT = new C1FlexGrid();
            grfFooT.Font = fEdit;
            grfFooT.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooT.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfRec.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfRec.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfRec.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            pnTopping.Controls.Add(this.grfFooT);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooT, theme);
        }
        private void setGrfTopping(String fooId)
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfFooT.DataSource = mposC.mposDB.footpDB.selectByFoodsId(fooId);
            grfFooT.Cols.Count = 5;

            CellStyle cs = grfFooT.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFooT.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFooT.Cols[1].Width = 60;

            grfFooT.Cols[2].Width = 80;
            grfFooT.Cols[3].Width = 200;

            grfFooT.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooT.Cols[2].Caption = "รายการสั่งเพิ่ม";

            grfFooT.AfterRowColChange += GrfFooT_AfterRowColChange; ;
            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFooT.GetCellRange(2, colE);
            for (int i = 1; i < grfFooT.Rows.Count; i++)
            {
                grfFooT[i, 0] = i;
                if (i % 2 == 0)
                    grfFooT.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //grfFooT.Cols[colCode].Visible = false;
            grfFooT.Cols[colID].Visible = false;
            //grfFooT.Cols[colE].Visible = false;
            //grfFooT.Cols[colS].Visible = false;
            pageLoad = false;
        }

        private void GrfFooT_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            if (grfFooT.Row < 0) return;
            if (grfFooT.Col < 0) return;
            if (grfFooT[grfFooT.Row, grfFooS.Col] == null) return;
            String id = "", name = "", price="";
            id = grfFooT[grfFooT.Row, 1].ToString();
            name = grfFooT[grfFooT.Row, 2].ToString();
            price = grfFooT[grfFooT.Row, 3].ToString();
            txtFootpId.Value = id;
            txtFootpName.Value = name;
            txtFootpPrice.Value = price;
        }

        private void initGrfSpec()
        {
            grfFooS = new C1FlexGrid();
            grfFooS.Font = fEdit;
            grfFooS.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFooS.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfRec.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfRec.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfRec.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            pnSpec.Controls.Add(this.grfFooS);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFooS, theme);
        }
        private void setGrfSpec(String fooId)
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfFooS.DataSource = mposC.mposDB.foosDB.selectByFoodsId(fooId);
            grfFooS.Cols.Count = 4;

            CellStyle cs = grfFooS.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFooS.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFooS.Cols[1].Width = 60;

            grfFooS.Cols[2].Width = 80;
            grfFooS.Cols[3].Width = 200;

            grfFooS.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFooS.Cols[2].Caption = "รายการสั่งพิเศษ";

            grfFooS.AfterRowColChange += GrfFooS_AfterRowColChange;
            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFooS.GetCellRange(2, colE);
            for (int i = 1; i < grfFooS.Rows.Count; i++)
            {
                grfFooS[i, 0] = i;
                if (i % 2 == 0)
                    grfFooS.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            //grfFooS.Cols[colCode].Visible = false;
            grfFooS.Cols[colID].Visible = false;
            //grfFooS.Cols[colE].Visible = false;
            //grfFooS.Cols[colS].Visible = false;
            pageLoad = false;
        }

        private void GrfFooS_AfterRowColChange(object sender, RangeEventArgs e)
        {
            //throw new NotImplementedException();
            //if (grfFooS.Row == null) return;
            if (grfFooS.Row < 0) return;
            if (grfFooS.Col < 0) return;
            if (grfFooS[grfFooS.Row, grfFooS.Col] == null) return;
            String id = "", name = "";
            id = grfFooS[grfFooS.Row, 1].ToString();
            name = grfFooS[grfFooS.Row, 2].ToString();
            txtFoosId.Value = id;
            txtFoosName.Value = name;
        }

        private void initGrfRec()
        {
            grfRec = new C1FlexGrid();
            grfRec.Font = fEdit;
            grfRec.Dock = System.Windows.Forms.DockStyle.Fill;
            grfRec.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            //grfRec.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            //grfRec.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            //grfRec.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel4.Controls.Add(this.grfRec);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfRec, theme);
        }
        private void setGrfRec()
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfRec.DataSource = mposC.mposDB.fooDB.selectByRecommend();
            grfRec.Cols.Count = colCnt;
            CellStyle cs = grfRec.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfRec.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfRec.Cols[colE].Style = grfRec.Styles["btn"];
            grfRec.Cols[colS].Style = grfRec.Styles["date"];

            grfRec.Cols[colID].Width = 60;

            grfRec.Cols[colCode].Width = 80;
            grfRec.Cols[colName].Width = 300;

            grfRec.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfRec.Cols[colCode].Caption = "รหัส";
            grfRec.Cols[colName].Caption = "ชื่ออาหาร";
            grfRec.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfRec.GetCellRange(2, colE);
            for (int i = 1; i < grfRec.Rows.Count; i++)
            {
                grfRec[i, 0] = i;
                if (i % 2 == 0)
                    grfRec.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfRec.Cols[colID].Visible = false;
            grfRec.Cols[colE].Visible = false;
            grfRec.Cols[colS].Visible = false;
            pageLoad = false;
        }
        private void initGrfFoo()
        {
            grfFoo = new C1FlexGrid();
            grfFoo.Font = fEdit;
            grfFoo.Dock = System.Windows.Forms.DockStyle.Fill;
            grfFoo.Location = new System.Drawing.Point(0, 0);

            //FilterRow fr = new FilterRow(grfPosi);

            grfFoo.AfterRowColChange += new C1.Win.C1FlexGrid.RangeEventHandler(this.grfPosi_AfterRowColChange);
            grfFoo.CellButtonClick += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellButtonClick);
            grfFoo.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(this.grfPosi_CellChanged);

            panel2.Controls.Add(this.grfFoo);

            C1Theme theme = C1ThemeController.GetThemeByName("Office2013Red", false);
            C1ThemeController.ApplyThemeToObject(grfFoo, theme);
        }
        private void setGrfFoo()
        {
            //grfDept.Rows.Count = 7;
            pageLoad = true;
            grfFoo.DataSource = mposC.mposDB.fooDB.selectAll();
            grfFoo.Cols.Count = colCnt;
            CellStyle cs = grfFoo.Styles.Add("btn");
            cs.DataType = typeof(Button);
            //cs.ComboList = "|Tom|Dick|Harry";
            cs.ForeColor = Color.Navy;
            cs.Font = new Font(Font, FontStyle.Bold);
            cs = grfFoo.Styles.Add("date");
            cs.DataType = typeof(DateTime);
            cs.Format = "dd-MMM-yy";
            cs.ForeColor = Color.DarkGoldenrod;

            grfFoo.Cols[colE].Style = grfFoo.Styles["btn"];
            grfFoo.Cols[colS].Style = grfFoo.Styles["date"];

            grfFoo.Cols[colID].Width = 60;

            grfFoo.Cols[colCode].Width = 80;
            grfFoo.Cols[colName].Width = 300;

            grfFoo.ShowCursor = true;
            //grdFlex.Cols[colID].Caption = "no";
            //grfDept.Cols[colCode].Caption = "รหัส";

            grfFoo.Cols[colCode].Caption = "รหัส";
            grfFoo.Cols[colName].Caption = "ชื่ออาหาร";
            grfFoo.Cols[colRemark].Caption = "หมายเหตุ";

            //grfDept.Cols[coledit].Visible = false;
            CellRange rg = grfFoo.GetCellRange(2, colE);
            for (int i = 1; i < grfFoo.Rows.Count; i++)
            {
                grfFoo[i, 0] = i;
                if (i % 2 == 0)
                    grfFoo.Rows[i].StyleNew.BackColor = ColorTranslator.FromHtml(mposC.iniC.grfRowColor);
            }
            grfFoo.Cols[colID].Visible = false;
            grfFoo.Cols[colE].Visible = false;
            grfFoo.Cols[colS].Visible = false;
            pageLoad = false;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = mposC.cTxtFocus;
            a.Font = new Font(ff, FontStyle.Bold);
        }
        private void setFocusColor()
        {
            this.txtFooCode.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFooCode.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtFooNameT.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtFooNameT.Enter += new System.EventHandler(this.textBox_Enter);

            this.txtRemark.Leave += new System.EventHandler(this.textBox_Leave);
            this.txtRemark.Enter += new System.EventHandler(this.textBox_Enter);
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            C1TextBox a = (C1TextBox)sender;
            a.BackColor = bg;
            a.ForeColor = fc;
            a.Font = new Font(ff, FontStyle.Regular);
        }
        private void setControl(String fooId)
        {
            foo = mposC.mposDB.fooDB.selectByPk1(fooId);
            txtID.Value = foo.foods_id;
            txtFooCode.Value = foo.foods_code;
            txtFooNameT.Value = foo.foods_name;
            txtRemark.Value = foo.remark;
            txtPrice.Value = foo.foods_price;
            //if (foo.status_foods.Equals("1"))
            //{
            //    chkStatusToGo.Checked = true;
            //}
            //else
            //{
            //    chkStatusToGo.Checked = false;
            //}
            chkStatusToGo.Checked = foo.status_to_go.Equals("1") ? true : false;
            chkDineIn.Checked = foo.status_dine_in.Equals("1") ? true : false;
            mposC.setC1Combo(cboRes, foo.res_id);
            mposC.setC1Combo(cboFoodsType, foo.foods_type_id);
            mposC.setC1Combo(cboFoodsCat, foo.foods_cat_id);
            mposC.setC1Combo(cboPrinter, foo.printer_name);
            chkStatusRecommend.Checked = foo.status_recommend.Equals("1") ? true : false;

            showImg();
            setGrfSpec(fooId);
            setGrfTopping(fooId);
            setGrfMaterial(fooId);
            setGrfFoodsMaterial(fooId);
            //if (area.status_embryologist.Equals("1"))
            //{
            //    chkEmbryologist.Checked = true;
            //}
            //else
            //{
            //    chkEmbryologist.Checked = false;
            //}
        }
        private void setControlEnable(Boolean flag)
        {
            //txtID.Enabled = flag;
            cboFoodsType.Enabled = flag;
            txtFooCode.Enabled = flag;
            txtFooNameT.Enabled = flag;
            txtRemark.Enabled = flag;
            chkVoid.Enabled = flag;
            cboRes.Enabled = flag;
            cboFoodsType.Enabled = flag;
            cboFoodsCat.Enabled = flag;
            cboPrinter.Enabled = flag;
            txtPrice.Enabled = flag;
            btnEdit.Image = !flag ? Resources.lock24 : Resources.open24;
        }

        private void setFoods()
        {
            foo.foods_id = txtID.Text;
            foo.foods_code = txtFooCode.Text;
            foo.foods_name = txtFooNameT.Text;
            foo.foods_price = txtPrice.Text;
            foo.remark = txtRemark.Text;
            foo.status_foods = "1";
            foo.status_dine_in = chkDineIn.Checked == true ? "1" : "0";
            foo.status_to_go = chkStatusToGo.Checked == true ? "1" : "0";
            foo.foods_cat_id = cboFoodsCat.SelectedItem == null ? "" : ((ComboBoxItem)cboFoodsCat.SelectedItem).Value;
            foo.foods_type_id = cboFoodsType.SelectedItem == null ? "" : ((ComboBoxItem)cboFoodsType.SelectedItem).Value;
            foo.res_id = cboRes.SelectedItem == null ? "" : ((ComboBoxItem)cboRes.SelectedItem).Value;
            foo.printer_name = cboPrinter.SelectedItem == null ? "" : ((ComboBoxItem)cboPrinter.SelectedItem).Value;
            foo.status_recommend = chkStatusRecommend.Checked == true ? "1" : "0";
        }
        private void grfPosi_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {
            if (e.NewRange.r1 < 0) return;
            if (e.NewRange.Data == null) return;

            String deptId = "";
            deptId = grfFoo[e.NewRange.r1, colID] != null ? grfFoo[e.NewRange.r1, colID].ToString() : "";
            setControl(deptId);
            setControlEnable(false);
            //setControlAddr(addrId);
            //setControlAddrEnable(false);
        }
        private void grfPosi_CellButtonClick(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }
        private void grfPosi_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //if (e.Row == 0) return;
            //CellStyle cs = grfDept.Styles.Add("text");
            //cs.BackColor = Color.DimGray;
            //sB1.Text = grfDept[e.Row, e.Col].ToString();
            ////grfDept[e.Row, coledit] = "1";
            //grfDept.Rows[e.Row].Style = cs;
            //if((e.Row+1) == ((RowCollection)grfDept.Rows).Count)
            //{
            //    ((RowCollection)grfDept.Rows).Count = ((RowCollection)grfDept.Rows).Count + 1;
            //}
        }
        private void TxtPasswordVoid_KeyUp(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Enter)
            {
                userIdVoid = mposC.mposDB.stfDB.selectByPasswordAdmin(txtPasswordVoid.Text.Trim());
                if (userIdVoid.Length>0)
                {
                    txtPasswordVoid.Hide();
                    btnVoid.Show();
                    //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> รหัสผ่านถูกต้อง", btnVoid);
                }
                else
                {
                    sep.SetError(txtPasswordVoid, "333");
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Value = "";
            txtFooCode.Value = "";
            txtFooNameT.Value = "";
            txtRemark.Value = "";
            chkVoid.Checked = false;
            btnVoid.Hide();
            flagEdit = true;
            chkDineIn.Checked = true;
            chkStatusToGo.Checked = true;
            setControlEnable(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flagEdit = true;
            setControlEnable(flagEdit);
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ ยกเลิกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                mposC.mposDB.posiDB.VoidPosition(txtID.Text, userIdVoid);
                setGrfFoo();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ต้องการ บันทึกช้อมูล ", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                setFoods();
                String re = mposC.mposDB.fooDB.insertFoods(foo, mposC.user.staff_id);
                int chk = 0;
                if (int.TryParse(re, out chk))
                {
                    btnSave.Image = Resources.accept_database24;
                }
                else
                {
                    btnSave.Image = Resources.accept_database24;
                }
                setGrfFoo();
                //setGrdView();
                //this.Dispose();
            }
        }
        private void chkVoid_Click(object sender, EventArgs e)
        {
            if (btnVoid.Visible)
            {
                btnVoid.Hide();
            }
            else
            {
                txtPasswordVoid.Show();
                txtPasswordVoid.Focus();
                //stt.Show("<p><b>ต้องการยกเลิก</b></p> <br> กรุณาป้อนรหัสผ่าน", txtPasswordVoid);
            }
        }
        private void FrmCFoods_Load(object sender, EventArgs e)
        {
            tC.SelectedTab = tabFoods;
            tC1.SelectedTab = tabImg;
        }
    }
}
