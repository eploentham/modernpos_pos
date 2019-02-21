using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modernpos_pos.control
{
    public class VNEControl
    {
        public void setCboPaymentPendingList(ComboBox c, String len, String obj1)
        {
            //ComboBox c = new ComboBox();
            ComboBoxItem item = new ComboBoxItem();
            c.Items.Clear();
            //String aaa = "";
            ComboBoxItem item1 = new ComboBoxItem();
            item1.Text = "";
            item1.Value = "";
            
            c.Items.Add(item1);
            //for (int i = 0; i < dt.Rows.Count; i++)

            int chk = 0;
            if(int.TryParse(len, out chk))
            {
                dynamic aaa = JsonConvert.DeserializeObject(obj1);
                //JArray a = JArray.Parse(aaa);
                //var jsonObject = new JObject();
                //jsonObject = aaa;
                foreach (var item11 in aaa)
                {
                    //dynamic bbb = 
                    String a = String.Concat(item11);
                    item = new ComboBoxItem();
                    item.Text = a;
                    item.Value = a;
                    c.Items.Add(item);
                }
                
            }
            //return c;
        }
    }
}
