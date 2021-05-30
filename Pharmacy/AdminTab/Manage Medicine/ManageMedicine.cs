using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class ManageMedicine : UserControl
    {
        public delegate void myDel();
        public myDel d;
        public ManageMedicine()
        {
            InitializeComponent();
            ButtonMedicine.PerformClick();
        }

        private void ButtonMedicine_Click(object sender, EventArgs e)
        {
            medicine1.BringToFront();
        }

        private void buttonSample_Click(object sender, EventArgs e)
        {
            sample1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            importMedicine1.BringToFront();
        }



        private void ButtonCheckExpiryDate_Click(object sender, EventArgs e)
        {
            checkExpiredMedicine1.BringToFront();
        }
    }
}
