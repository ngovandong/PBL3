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
    public partial class SearchList : UserControl
    {
        private List<searchItem> ListSearch;
        public SearchList()
        {
            ListSearch = new List<searchItem>();
            InitializeComponent();
            this.Size = new System.Drawing.Size(425, 46);
            panel2.Visible = false;
            flowLayoutPanel1.Visible = false;
        }



        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(425, 200);
            ListSearch.Clear();
            for (int i = 0; i < 100; i++)
            {
                searchItem s1 = new searchItem();
                ListSearch.Add(s1);
                
            }
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(ListSearch.ToArray());
            flowLayoutPanel1.Visible = true;
        }

        private void SearchList_Leave(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(425, 46);
            flowLayoutPanel1.Visible = false;
        }

        public void addCus(string name)
        {
            this.Size = new System.Drawing.Size(425, 46);
            flowLayoutPanel1.Visible = false;
            guna2TextBox1.Text = name;
            //guna2TextBox1.Enabled = false;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            addCustomer f = new addCustomer();
            f.d = new addCustomer.Mydel(addCus);
            f.Show();
        }


    }
}
