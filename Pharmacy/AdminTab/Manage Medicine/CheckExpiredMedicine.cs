using BLL;
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
    public partial class CheckExpiredMedicine : UserControl
    {
        public CheckExpiredMedicine()
        {
            InitializeComponent();
            setStart();
        }
        public void setStart()
        {
            guna2DataGridView1.DataSource = _BLL.Instance.getListStockDetailView().Where(p => p.Expired == true).ToList();
            guna2DataGridView1.Columns[0].Visible = false;
            guna2DataGridView1.Columns[1].Visible = false;
            guna2DataGridView1.Columns[2].HeaderText = "Tên lô";
            guna2DataGridView1.Columns[3].HeaderText = "Tên thuốc";
            guna2DataGridView1.Columns[4].Visible = false;
            guna2DataGridView1.Columns[5].HeaderText = "Ngày hết hạn";
            guna2DataGridView1.Columns[6].Visible = false;

            guna2DataGridView2.DataSource = _BLL.Instance.getListMedicineView().Where(p=>p.Quantity==0).ToList();
            guna2DataGridView2.Columns[0].Visible = false;
            guna2DataGridView2.Columns[1].HeaderText = "Tên thuốc";
            guna2DataGridView2.Columns[2].Visible = false;
            guna2DataGridView2.Columns[3].Visible = false;
            guna2DataGridView2.Columns[4].Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            _BLL.Instance.DeleteMedicineExpired();
            setStart();
        }
    }
}
