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
    
    public partial class addCustomer : Form
    {
        public delegate void Mydel(string name);
        public Mydel d;
        public addCustomer()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            d(guna2TextBox2.Text);
            this.Close();
        }
    }
}
