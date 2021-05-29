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

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class StockDetail : Form
    {
        public delegate void Mydel();
        public Mydel d;
        private STOCK stock;
        public StockDetail(int id)
        {
            InitializeComponent();
            stock = _BLL.Instance.getStock(id);
        }
        public void setStart()
        {
            textboxNameStock.Text = stock.Name;
            textboxIDStock.Text = stock.ID.ToString();
            textboxSupplier.Text = stock.SUPPLIER.NAME;
            guna2DateTimePicker1.Value = stock.DATE.Value.Date;
            richTextBoxNote.Text = stock.NOTE;
            textboxPriceTotalStock.Text = stock.PRICETOTAL.ToString();
            textboxQuantityMedicineinStock.Text = stock.STOCK_DETAIL.Count().ToString();
            int quantity = 0;
            foreach(var item in stock.STOCK_DETAIL)
            {
                quantity += item.QUANTITY;
            }
            textboxQuantityMedicine.Text = quantity.ToString();
            guna2DataGridView1.DataSource = _BLL.Instance.getListMEDICINEinStockView(stock.ID);
            guna2DataGridView1.Columns["idMedicine"].Visible = false;
            guna2DataGridView1.Columns["nameMedicine"].HeaderText = "Tên thuốc";
            guna2DataGridView1.Columns["quantity"].HeaderText = "Số lượng";
            guna2DataGridView1.Columns["import_price"].HeaderText = "Giá nhập";
            guna2DataGridView1.Columns["total_price"].HeaderText = "Tổng cộng";
            guna2DataGridView1.Columns["dateExpire"].HeaderText = "Hạn sử dụng";
            
        }

        private void StockDetail_Load(object sender, EventArgs e)
        {
            setStart();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[1].Value);
            DetailMedicine detailMedicine = new DetailMedicine(index);
            detailMedicine.ShowDialog();
        }
    }
}
