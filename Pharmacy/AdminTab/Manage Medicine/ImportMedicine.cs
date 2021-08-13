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
            dateTimeFinish.Value = DateTime.Now;
            TimeSpan timeSpan = new System.TimeSpan(90, 0, 0, 0);
            dateTimeBegin.Value = DateTime.Now.Subtract(timeSpan);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddStock stock = new AddStock();
            stock.d = new AddStock.Mydel(setDataGridView);
            stock.ShowDialog();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(guna2DataGridView1.SelectedRows.Count);
            if(count > 1)
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
            else if(0 == count)
            {
                MessageBox.Show("Hiện không có lô hàng nào");
            }
            else
            {
                int idStock = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                STOCK stock = _BLL.Instance.getStock(idStock);
                UpdateStock updateStock = new UpdateStock(stock);
                updateStock.d = new UpdateStock.Mydel(setDataGridView);
                updateStock.ShowDialog();
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(guna2DataGridView1.SelectedRows.Count);
            if(count < 1)
            {
                MessageBox.Show("Vui lòng chọn lô hàng cần xóa.");
            }
            else
            {
                for(int i = 0; i < count; i++)
                {
                    STOCK st = _BLL.Instance.getStock(Convert.ToInt32(guna2DataGridView1.SelectedRows[i].Cells[0].Value));
                    foreach(var item in st.STOCK_DETAIL)
                    {
                        _BLL.Instance.subMedicineQuantity(item);
                        _BLL.Instance.DeleteStockDetail(item);
                    }
                    _BLL.Instance.DeleteStock(st.ID);
                }
                setDataGridView();
            }
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
            guna2DataGridView1.DataSource = _BLL.Instance.getListStockView(name, option, dateTimeBegin.Value.Date, dateTimeFinish.Value.Date);
            guna2DataGridView1.Columns["id"].Visible = false;
            guna2DataGridView1.Columns["nameStock"].HeaderText = "Lô hàng";
            guna2DataGridView1.Columns["nameSupplier"].HeaderText = "Nhà cung cấp";
            guna2DataGridView1.Columns["dateImport"].HeaderText = "Ngày nhập hàng";
            guna2DataGridView1.Columns["priceTotal"].HeaderText = "Tổng tiền";
            guna2DataGridView1.Columns["priceTotal"].DefaultCellStyle.Format = "#,##0";
        }

        private void ImportMedicine_Load(object sender, EventArgs e)
        {
            setDataGridView();
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                setDataGridView();
            }
        }

        private void dateTimeBegin_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Compare(dateTimeBegin.Value.Date, dateTimeFinish.Value.Date) > 0)
            {
                dateTimeBegin.Value = dateTimeFinish.Value.Date;
            }
        }

        private void dateTimeFinish_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateTimeBegin.Value.Date, dateTimeFinish.Value.Date) > 0)
            {
                dateTimeFinish.Value = dateTimeBegin.Value.Date;
            }
        }
    }
}
