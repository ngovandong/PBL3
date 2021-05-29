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
    public partial class ImportMedicine : UserControl
    {
        public ImportMedicine()
        {
            InitializeComponent();
            setCBBItem();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddStock stock = new AddStock();
            stock.Refresh = new AddStock.Mydel(setDataGridView);
            stock.ShowDialog();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(guna2DataGridView1.SelectedRows.Count);
            if(count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn một lô hàng");
            }
            else
            {
                int index = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                StockDetail stockDetail = new StockDetail(index);
                stockDetail.ShowDialog();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(guna2DataGridView1.SelectedRows.Count);
            if (count > 1)
            {
                MessageBox.Show("Vui lòng chỉ chọn một lô hàng");
            }
            else
            {
                int idStock = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                STOCK stock = _BLL.Instance.getStock(idStock);
                UpdateStock updateStock = new UpdateStock(stock);
                updateStock.ShowDialog();
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }
        private void setCBBItem()
        {
            comboboxItem.Items.AddRange(new object[] { "NAME", "SUPPLIER", "MEDICINE" });
            comboboxItem.SelectedItem = comboboxItem.Items[0];
        }
        private void setDataGridView()
        {
            string name = textBoxSearch.Text;
            string option = comboboxItem.SelectedItem.ToString();
            guna2DataGridView1.DataSource = _BLL.Instance.getListStockView(name, option);
            guna2DataGridView1.Columns["id"].Visible = false;
            guna2DataGridView1.Columns["nameStock"].HeaderText = "Lô hàng";
            guna2DataGridView1.Columns["nameSupplier"].HeaderText = "Nhà cung cấp";
            guna2DataGridView1.Columns["dateImport"].HeaderText = "Ngày nhập hàng";
            guna2DataGridView1.Columns["priceTotal"].HeaderText = "Tổng tiền";
        }

        private void ImportMedicine_Load(object sender, EventArgs e)
        {
            setDataGridView();
        }
    }
}
