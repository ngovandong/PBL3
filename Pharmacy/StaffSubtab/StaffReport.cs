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
        }

        public StaffReport()
        {
            InitializeComponent();
        }
        public void setStart()
        {
            string nameMedicine = textBoxMedicine.Text.Trim();
            string nameCustomer = textBoxCustomer.Text.Trim();
            this.guna2DataGridView1.DataSource = _BLL.Instance.getListInvoice(this.u.ID, nameCustomer, nameMedicine);
            guna2DataGridView1.Columns[0].Visible = false;
            guna2DataGridView1.Columns[1].HeaderText = "Ngày";
            guna2DataGridView1.Columns[2].HeaderText = "Tên khách hàng";
            guna2DataGridView1.Columns[3].HeaderText = "Giảm giá";
            guna2DataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            guna2DataGridView1.Columns[4].HeaderText = "Tổng tiền";
            guna2DataGridView1.Columns[4].DefaultCellStyle.Format = "#,##0";
            guna2DataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            guna2DataGridView1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void StaffReport_Load(object sender, EventArgs e)
        {
            setStart();
        }

        private void textBoxMedicine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setStart();
            }
        }

        private void textBoxCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                setStart();
            }
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(guna2DataGridView1.SelectedRows.Count);
            if (count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn một lô hàng");
            }
            else if (0 == count)
            {
                MessageBox.Show("Hiện không có lô hàng nào");
            }
            else
            {
                int index = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                Invoice_Detail invoice_Detail = new Invoice_Detail(index);
                invoice_Detail.ShowDialog();
            }
        }
    }
}
