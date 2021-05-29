using BLL;
using BLL.Model_View;
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
    public partial class UpdateStock : Form
    {
        public delegate void Mydel();
        public Mydel Refresh;
        private List<MedicineItem> listMedicineItem;
        private SupplierView supplierView;
        private STOCK stock;
        public UpdateStock(STOCK s)
        {
            InitializeComponent();
            listMedicineItem = new List<MedicineItem>();
            stock = s;
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 1);
        }
        private void setListMedicineItem()
        {
            for(int i = 0; i < stock.STOCK_DETAIL.Count; i++)
            {
                listMedicineItem.Add(new MedicineItem(_BLL.Instance.STOCKtoMedicineStock(stock)[i]));
            }
            foreach (var item in listMedicineItem)
            {
                item.d = new MedicineItem.Mydel(delToBoard);
                item.d2 = new MedicineItem.Mydel2(setTotalPrice);
            }
        }
        private void setsupplierView()
        {
            supplierView = new SupplierView()
            {
                ID = stock.SUPPLIER.ID,
                Name = stock.SUPPLIER.NAME,
                Phone = stock.SUPPLIER.PHONE_NUMBER
            };
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        public void delToBoard(MedicineItem m)
        {
            listMedicineItem.Remove(m);
            flowLayoutPanel2.Controls.Clear();
            int i = 1;
            foreach (var item in listMedicineItem)
            {
                flowLayoutPanel2.Controls.Add(item);
                item.No = i.ToString();
                i++;
            }
            setTotalPrice();
        }
        public void setTotalPrice()
        {
            int total = 0;
            foreach (var item in listMedicineItem)
            {
                total += item.medicine.final_price;
            }
            textboxPriceTotalBefore.Text = total.ToString();
        }
        public void addToBoard(MedicineStock m)
        {
            var c = from p in listMedicineItem where (m.ID == p.ID) select p;
            if (c.Count() == 0)
            {
                MedicineItem i = new MedicineItem(m);
                i.d = new MedicineItem.Mydel(delToBoard);
                i.d2 = new MedicineItem.Mydel2(setTotalPrice);
                listMedicineItem.Add(i);
                i.No = listMedicineItem.Count.ToString();
                flowLayoutPanel2.Controls.Add(i);
            }
        }
        public void setSupplier(string name)
        {
            textboxSupplier.Text = name.Trim();
            supplierView = _BLL.Instance.getListSupplierView(name)[0];
        }

        private void buttonAddSupplier_Click(object sender, EventArgs e)
        {
            AddSupplier sup = new AddSupplier();
            sup.d = new AddSupplier.Mydel(setSupplier);
            sup.ShowDialog();
        }

        private void textBoxSearchMedicine_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            try
            {
                foreach (var item in _BLL.Instance.getlistMedicineSearchinStock(textBoxSearchMedicine.Text))
                {
                    SearchMedicineItem s = new SearchMedicineItem(item);
                    s.d = new SearchMedicineItem.Mydel(addToBoard);
                    flowLayoutPanel1.Controls.Add(s);

                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout();
            }
        }

        private void textBoxSearchMedicine_Leave(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Visible = false;
        }

        private void textBoxSearchMedicine_Enter(object sender, EventArgs e)
        {
            textBoxSearchMedicine_TextChanged(sender, e);
        }

        private void textboxPriceTotalBefore_TextChanged(object sender, EventArgs e)
        {
            int total_before = Convert.ToInt32(textboxPriceTotalBefore.Text);
            int sale = Convert.ToInt32(textboxSale.Text);
            int total_after = (total_before * (100 - sale)) / 100;
            textboxPriceTotalAfter.Text = total_after.ToString();
        }
        public void addSup(SupplierView s)
        {
            textboxSupplier.Text = s.Name;
            supplierView = s;
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 1);
        }

        private void textboxSupplier_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel3.Visible = true;
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 100);
            flowLayoutPanel3.Controls.Clear();
            try
            {
                foreach (var item in _BLL.Instance.getListSupplierView(textboxSupplier.Text.Trim()))
                {
                    SearchSupplierItem s = new SearchSupplierItem(item);
                    s.d = new SearchSupplierItem.Mydel(addSup);
                    flowLayoutPanel3.Controls.Add(s);

                }
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout();
            }
        }

        private void textboxSupplier_Leave(object sender, EventArgs e)
        {
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 1);
        }

        private void textboxSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void textboxSale_MouseLeave(object sender, EventArgs e)
        {
            if (textboxSale.Text == "")
            {
                textboxSale.Text = "0";
            }
            else
            {
                int sale = Convert.ToInt32(textboxSale.Text);
                if (sale > 100)
                {
                    sale = 100;
                    textboxSale.Text = sale.ToString();
                }
            }
            textboxPriceTotalBefore_TextChanged(sender, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Controls.Count == 0 || !_BLL.Instance.checkSupplier(textboxSupplier.Text.Trim()))
            {
                if (flowLayoutPanel2.Controls.Count == 0)
                {
                    MessageBox.Show("Chưa thêm thuốc!");
                }
                if (!_BLL.Instance.checkSupplier(textboxSupplier.Text.Trim()))
                {
                    lbRed.Visible = true;
                }
                else
                {
                    lbRed.Visible = false;
                }
            }
            else
            {
                stock.DATE = guna2DateTimePicker1.Value.Date;
                stock.Name = textboxNameStock.Text.Trim();
                stock.NOTE = richTextBox1.Text.Trim();
                stock.PRICETOTAL = Convert.ToInt32(textboxPriceTotalAfter.Text);
                stock.supplierId = supplierView.ID;
                stock.SUPPLIER = _BLL.Instance.getSupplier(supplierView.ID);
                _BLL.Instance.UpdateStock(stock);

                foreach(var item in stock.STOCK_DETAIL)
                {
                    _BLL.Instance.subMedicineQuantity(item);
                    _BLL.Instance.DeleteStockDetail(item);
                }
                foreach(var item in listMedicineItem)
                {
                    _BLL.Instance.AddStockDetail(new STOCK_DETAIL()
                    {
                        ORGIGINAL_PRICE = item.medicine.import_price,
                        QUANTITY = item.medicine.quantityInStock,
                        dateExpire = item.medicine.HSD,
                        ID_MEDICINE = item.medicine.ID,
                        ID_STOCK = stock.ID
                    });
                    _BLL.Instance.addMedicineQuantity(item.medicine);
                }
                Refresh();
                this.Dispose();
            }
        }

        private void UpdateStock_Load(object sender, EventArgs e)
        {
            setListMedicineItem();
            setsupplierView();
            for(int i = 0; i < listMedicineItem.Count; i++)
            {
                flowLayoutPanel2.Controls.Add(listMedicineItem[i]);
                setTotalPrice();
            }
            textboxSupplier.Text = supplierView.Name;
            textboxNameStock.Text = stock.Name;
            richTextBox1.Text = stock.NOTE;
            guna2DateTimePicker1.Value = stock.DATE.Value.Date;

        }
    }
}
