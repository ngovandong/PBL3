using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
namespace Pharmacy.StaffSubtab
{
    public partial class SearchCustomer : UserControl
    {
        public delegate void Mydel(CUSTOMER c);
        public Mydel d;
        private List<CustomerItem> ListSearch;
        private CUSTOMER Customer;
        public SearchCustomer()
        {
            InitializeComponent();
            setForm();
        }

        public void setForm()
        {
            ListSearch = new List<CustomerItem>();
            this.Size = new System.Drawing.Size(425, 46);
            panel2.Visible = false;
            flowLayoutPanel1.Visible = false;
        }

        public void setText(CUSTOMER c)
        {
            this.Customer = c;
            Searchbox.Text = c.Customer_name;
            this.Size = new System.Drawing.Size(425, 46);
            panel2.Visible = false;
            flowLayoutPanel1.Visible = false;
            d(c);
        }

        private void SearchList_Leave(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(425, 46);
            flowLayoutPanel1.Visible = false;
        }

       
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addCustomer f = new addCustomer();
            f.d = new addCustomer.Mydel(setText);
            f.Show();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(425, 200);
            ListSearch.Clear();
            foreach (CUSTOMER c in _BLL.Instance.getListCus(Searchbox.Text))
            {
                CustomerItem s1 = new CustomerItem(c);
                s1.d = new CustomerItem.MyDel(setText);
                ListSearch.Add(s1);
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(ListSearch.ToArray());
            flowLayoutPanel1.Visible = true;
        }

        private void Searchbox_Enter(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(425, 200);
            ListSearch.Clear();
            foreach (CUSTOMER c in _BLL.Instance.getListCus(Searchbox.Text))
            {
                CustomerItem s1 = new CustomerItem(c);
                s1.d = new CustomerItem.MyDel(setText);
                ListSearch.Add(s1);
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(ListSearch.ToArray());
            flowLayoutPanel1.Visible = true;
        }

        public  void clearTextbox()
        {
            Searchbox.Text = "";
        }
    }
}
