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
            guna2DataGridView2.DataSource = _BLL.Instance.getListStockDetailView();
            guna2DataGridView1.DataSource = _BLL.Instance.getListReportStaff();
            guna2TextBox1.Text = DateTime.Now.ToString("MM/yyyy");

        }
    }
}
