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
            guna2DataGridView2.Columns[0].Visible = false;
            guna2DataGridView2.Columns[1].Visible = false;
            guna2DataGridView2.Columns["StockName"].HeaderText = "Tên lô";
            guna2DataGridView2.Columns["MedicineName"].HeaderText = "Tên thuốc";
            guna2DataGridView2.Columns["Available"].HeaderText = "Tồn kho";
            guna2DataGridView2.Columns["EXP"].HeaderText = "Ngày hết hạn";
            guna2DataGridView2.Columns["Expired"].HeaderText = "Đã hết hạn";

            guna2DataGridView1.DataSource = _BLL.Instance.getListReportStaff();
            guna2DataGridView1.Columns["StaffName"].HeaderText = "Tên nhân viên";
            guna2DataGridView1.Columns["TotalSold"].HeaderText = "Doanh thu";
            guna2DataGridView1.Columns["NumberOfInvoice"].HeaderText = "Số đơn hàng";
            guna2TextBox1.Text = DateTime.Now.ToString("MM/yyyy");

        }
    }
}
