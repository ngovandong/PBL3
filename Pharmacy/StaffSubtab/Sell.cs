using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Model_View;

namespace Pharmacy.StaffSubtab
{
    public partial class Sell : Form
    {
        private List<MedicineItem> ListMe;
        public Sell()
        {
            InitializeComponent();
            setStart();
        }

        private void Sell_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
           
        }
        public void setStart()
        {
            
            ListMe = new List<MedicineItem>();
            guna2TextBox1_TextChanged(null, new EventArgs());
            
        }

        public void changeNumber()
        {
            
            Total.Text = Convert.ToDouble(Total.Text).ToString("#,##0");
            charge.Text = Convert.ToDouble(charge.Text).ToString("#,##0");
            change.Text = Convert.ToDouble(change.Text).ToString("#,##0");
            if (!"".Equals(receive.Text)){
                receive.Text= Convert.ToDouble(receive.Text).ToString("#,##0");
            }
        }
        public void getTotal()
        {
            int tong = 0;
            foreach (MedicineItem item in flowLayoutPanel1.Controls)
            {
                tong += item.medicine.quantysell * item.medicine.sell_price;
            }
            Total.Text = tong.ToString();
        }

        public void addToSell(medicineSell m)
        {
            var c = from p in ListMe where (m.ID == p.ID) select p ;
            if (c.Count()==0) {
                MedicineItem i = new MedicineItem(m);
                i.d1 = new MedicineItem.Mydel1(delItem);
                i.d2 = new MedicineItem.Mydel2(getTotal);
                ListMe.Add(i);
                i.No = (ListMe.Count).ToString();
                flowLayoutPanel1.Controls.Add(i);
                getTotal();
            }
            
        }
        public void delItem(MedicineItem m)
        {
            ListMe.Remove(m);
            flowLayoutPanel1.Controls.Clear();
            int i = 1;
            foreach (var item in ListMe)
            {
                flowLayoutPanel1.Controls.Add(item);
                item.No = i.ToString();
                i++;
            }
            getTotal();
        }

        

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.SuspendLayout();
            try
            {
                foreach (var item in _BLL.Instance.getlistMedicineSearch(TextBoxSearchMedicine.Text))
                {
                    SearchMedicineItem s = new SearchMedicineItem(item);
                    s.d = new SearchMedicineItem.Mydel(addToSell);
                    flowLayoutPanel2.Controls.Add(s);
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout();
            }
        }


        private void Total_TextChanged(object sender, EventArgs e)
        {
            int s = (int)(Convert.ToInt32(Total.Text) -Convert.ToInt32(Total.Text) * (Convert.ToInt32(discount.Text) / 100.0));
            charge.Text = s.ToString();
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(discount.Text))
                {
                    int a = Convert.ToInt32(discount.Text);
                    if (a > 100)
                        a = 100;
                    if (a < 0)
                        a = 0;
                    discount.Text = a.ToString();
                    int s = (int)(Convert.ToInt32(Total.Text) - Convert.ToInt32(Total.Text) * (Convert.ToInt32(discount.Text) / 100.0));
                    charge.Text = s.ToString();
                }
            }
            catch (Exception)
            {
                discount.Text = "0";
                int s = (int)(Convert.ToInt32(Total.Text) - Convert.ToInt32(Total.Text) * (Convert.ToInt32(discount.Text) / 100.0));
                charge.Text = s.ToString();
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(receive.Text))
                {
                    change.Text = (Convert.ToInt32(receive.Text)- Convert.ToInt32(charge.Text)).ToString();
                }
            }
            catch (Exception)
            {
                receive.Text = "";
                change.Text = "";
            }
        }
    }
}
