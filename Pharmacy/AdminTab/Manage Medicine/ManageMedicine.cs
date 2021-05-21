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
        public ManageMedicine()
        {
            InitializeComponent();
            ButtonMedicine.PerformClick();
        }

        private void ButtonMedicine_Click(object sender, EventArgs e)
        {
            medicine1.Visible = true;
            medicine1.BringToFront();
        }

        private void buttonSample_Click(object sender, EventArgs e)
        {
            sample1.Visible = true;
            sample1.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            importMedicine1.Visible = true;
            importMedicine1.BringToFront();
        }

        private void sample1_Load(object sender, EventArgs e)
        {

        }
    }
}
