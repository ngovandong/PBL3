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
            //guna2TextBox2.Text= Convert.ToDouble(guna2TextBox2.Text).ToString("#,##0");
            //guna2TextBox4.Text = Convert.ToDouble(guna2TextBox4.Text).ToString("#,##0");
            //guna2TextBox5.Text = Convert.ToDouble(guna2TextBox5.Text).ToString("#,##0");
            ListMe = new List<MedicineItem>();
            guna2TextBox1_TextChanged(null, new EventArgs());
        }


        public void addToSell(medicineSell m)
        {
            var c = from p in ListMe where (m.ID == p.ID) select p ;
            if (c.Count()==0) {
                MedicineItem i = new MedicineItem(m);
                i.d = new MedicineItem.Mydel(delItem);
                ListMe.Add(i);
                i.No = (ListMe.Count).ToString();
                flowLayoutPanel1.Controls.Add(i);
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

        private void searchList1_Load(object sender, EventArgs e)
        {

        }
    }
}
