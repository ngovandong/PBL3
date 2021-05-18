using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab.DashBoard
{
    public partial class report : UserControl
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            chart1.Series["Revenue"].Points.AddXY("January", 100);
            chart1.Series["Profit"].Points.AddXY("January", 34);
        }
    }
}
