using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab
{
    public partial class dashBoard : UserControl
    {
        public dashBoard()
        {
            InitializeComponent();
            ButtonDashBoard.PerformClick();
        }

        private void ButtonDashBoard_Click(object sender, EventArgs e)
        {
            genneral1.Visible = true;
            genneral1.BringToFront();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            report1.Visible = true;
            report1.BringToFront();
        }
    }
}
