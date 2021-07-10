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
using DAL;

namespace Pharmacy.StaffSubtab
{
    public partial class Invoice_Detail : Form
    {
        private INVOICE invoice;
        public Invoice_Detail(int id)
        {
            InitializeComponent();
            invoice = _BLL.Instance.getINVOICE(id);
        }

        private void setStart()
        {
            guna2DateTimePicker1.Value = invoice.DATE.Date;
            textBoxCustomer.Text = invoice.CUSTOMER == null ? "" : invoice.CUSTOMER.Customer_name;
            textBoxTotal.Text = invoice.TOTAL.ToString("#,##0");
            textBoxDiscount.Text = invoice.DISCOUNT.ToString();
            textBoxCharge.Text = invoice.CHARGE.ToString("#,##0");
            textBoxPRESCRIPTION.Text = invoice.PRESCRIPTION.ToString();
            guna2DataGridView1.DataSource = _BLL.Instance.getListInvoice_Detail(invoice.ID_INVOICE);
            guna2DataGridView1.Columns[0].HeaderText = "Tên thuốc";
            guna2DataGridView1.Columns[1].HeaderText = "Số lượng";
            guna2DataGridView1.Columns[2].HeaderText = "Thành tiền";
            guna2DataGridView1.Columns[2].DefaultCellStyle.Format = "#,##0";
            guna2DataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            guna2DataGridView1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Invoice_Detail_Load(object sender, EventArgs e)
        {
            setStart();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
