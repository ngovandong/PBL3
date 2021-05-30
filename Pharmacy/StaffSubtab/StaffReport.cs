using BLL;
using DAL;
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
    public partial class StaffReport : UserControl
    {
        private USER u;
        public StaffReport(USER u)
        {
            InitializeComponent();
            this.u = u;
            setStart();
        }

        public StaffReport()
        {
            InitializeComponent();
        }
        public void setStart()
        {
            this.guna2DataGridView1.DataSource = _BLL.Instance.getListInvoice(this.u.ID);
            guna2DataGridView1.Columns[0].HeaderText = "Ngày";
            guna2DataGridView1.Columns[1].HeaderText = "Giảm giá";
            guna2DataGridView1.Columns[2].HeaderText = "Tổng tiền";
            guna2DataGridView1.Columns[3].HeaderText = "Tên khách hàng";
        }
    }
}
