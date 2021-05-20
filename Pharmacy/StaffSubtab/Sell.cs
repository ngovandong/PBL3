using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.StaffSubtab
{
    public partial class Sell : Form
    {
        private List<MedicineItem> ListMe;
        public Sell()
        {
            ListMe = new List<MedicineItem>();
            InitializeComponent();
            setStart();
            
        }

        private void Sell_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
           
        }
        public void setStart()
        {
            guna2TextBox2.Text= Convert.ToDouble(guna2TextBox2.Text).ToString("#,##0");
            guna2TextBox4.Text = Convert.ToDouble(guna2TextBox4.Text).ToString("#,##0");
            guna2TextBox5.Text = Convert.ToDouble(guna2TextBox5.Text).ToString("#,##0");
        }

        public void delAddItem(SearchMedicineItem m)
        {
            flowLayoutPanel2.Controls.Remove(m);
            MedicineItem i = new MedicineItem();
            i.d = new MedicineItem.Mydel(delItem);
            ListMe.Add(i);
            i.No = (ListMe.Count).ToString();
            flowLayoutPanel1.Controls.Add(i);
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
                for (int i = 0; i < 5; i++)
                {
                    SearchMedicineItem s = new SearchMedicineItem();
                    s.d = new SearchMedicineItem.Mydel(delAddItem);
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
