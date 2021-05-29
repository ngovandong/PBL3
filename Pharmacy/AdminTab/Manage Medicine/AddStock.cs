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
    public partial class AddStock : Form
    {
        public delegate void Mydel();
        public Mydel Refresh;
        private List<MedicineItem> listMedicineItem;
        private SupplierView supplierView;
        public AddStock()
        {
            InitializeComponent();
            listMedicineItem = new List<MedicineItem>();
            supplierView = new SupplierView();
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 1);
            guna2DateTimePicker1.Value = DateTime.Now.Date;
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
        private void guna2ImageButton2_Click(object sender, EventArgs e)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonOK_Click_1(object sender, EventArgs e)
        {
            if (flowLayoutPanel2.Controls.Count == 0 || !_BLL.Instance.checkSupplier(textboxSupplier.Text.Trim()) || _BLL.Instance.checkNameStock(textboxNameStock.Text.Trim()) || "" == textboxNameStock.Text.Trim())
            {
                if(flowLayoutPanel2.Controls.Count == 0)
                {
                    MessageBox.Show("Chưa thêm thuốc!");
                }
                if(!_BLL.Instance.checkSupplier(textboxSupplier.Text.Trim()))
                {
                    lbRed.Visible = true;
                }
                else
                {
                    lbRed.Visible = false;
                }
                if(_BLL.Instance.checkNameStock(textboxNameStock.Text.Trim()))
                {
                    lbRedName.Visible = true;
                    lbRedName.Text = "Đã có lô này rồi!";
                }
                else if("" == textboxNameStock.Text.Trim())
                {
                    lbRedName.Visible = true;
                    lbRedName.Text = "Nhập tên lô";
                }
                else
                {
                    lbRedName.Visible = false;
                }
            }
            else
            {
                STOCK newStock = new STOCK()
                {
                    DATE = guna2DateTimePicker1.Value.Date,
                    Name = textboxNameStock.Text.Trim(),
                    NOTE = textboxNote.Text.Trim(),
                    PRICETOTAL = Convert.ToInt32(textboxPriceTotalAfter.Text),
                    supplierId = supplierView.ID
                };
                foreach(var item in listMedicineItem)
                {
                    newStock.STOCK_DETAIL.Add(new STOCK_DETAIL()
                    {
                        ORGIGINAL_PRICE = item.medicine.import_price,
                        QUANTITY = item.medicine.quantityInStock,
                        dateExpire = item.medicine.HSD,
                        ID_MEDICINE = item.medicine.ID,
                    });

                    _BLL.Instance.addMedicineQuantity(item.medicine);
                }
                _BLL.Instance.addStock(newStock);

                Refresh();
                this.Dispose();
            }
        }
        public void addSup(SupplierView s)
        {
            textboxSupplier.Text = s.Name;
            supplierView = s;
            flowLayoutPanel3.Controls.Clear();
            flowLayoutPanel3.Size = new System.Drawing.Size(245, 1);
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
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

        private void flowLayoutPanel3_MouseLeave(object sender, EventArgs e)
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
                if(sale > 100)
                {
                    sale = 100;
                    textboxSale.Text = sale.ToString();
                }
            }
            textboxPriceTotalBefore_TextChanged(sender, e);
        }

        private void textboxSupplier_Enter(object sender, EventArgs e)
        {
            guna2TextBox1_TextChanged(sender, e);
        }
    }
}
