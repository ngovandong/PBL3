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
using BLL.Model_View;
using DAL.DTO;
using DAL;
using DGVPrinterHelper;
using Guna.UI2.WinForms;

namespace Pharmacy.StaffSubtab
{
    public partial class Sell : Form
    {
        public delegate void Mydel();
        public Mydel d;
        private CUSTOMER customer;
        private USER user;
        private int Ntotal;
        private int Ncharge;
        private int Ndiscount;
        private List<MedicineItem> ListMe;
        public Sell(USER u)
        {
            InitializeComponent();
            setStart();
            this.user = u;
        }

        private void Sell_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
           
        }
        public void setStart()
        {
            discount.Text = "0";
            Total.Text = "0";
            ListMe = new List<MedicineItem>();
            guna2TextBox1_TextChanged(null, null);
            SearchSampleTextbox_TextChanged(null, null);
            searchList1.d = new SearchCustomer.Mydel(setCus);
        }

        public void setCus(CUSTOMER c)
        {
            this.customer = c;
            NameCustomerLabel.Text = c.Customer_name;
            customerInvoiceHistoryDatagridview.DataSource = this.customer.INVOICEs.Select(p => new INVOICE_VIEW  { ID = p.ID_INVOICE, date = p.DATE.ToString() }).ToList();
            customerInvoiceHistoryDatagridview.Columns[0].Visible = false;
        }
        public void refresh()
        {
            ListMe = new List<MedicineItem>();
            flowLayoutPanel1.Controls.Clear();
            Total.Text = "0";
            discount.Text = "0";
            charge.Text = "0";
            receive.Text = "";
            change.Text = "";
            Ntotal = 0;
            Ndiscount = 0;
            Ncharge = 0;
            Note.Text = "";

            TextBoxSearchMedicine.Text = "";
            guna2TextBox1_TextChanged(null, null);
            SearchSampleTextbox_TextChanged(null, null);
            SearchSampleTextbox.Text = "";

            this.customer = null;
            NameCustomerLabel.Text = "";
            customerInvoiceHistoryDatagridview.DataSource = 0;
            searchList1.clearTextbox();
            
        }

        public void changeNumber()
        {
            
            Total.Text = Convert.ToDouble(Total.Text).ToString("#,##0");
            charge.Text = Convert.ToDouble(charge.Text).ToString("#,##0");
            if (!"".Equals(change.Text)) {
                change.Text = Convert.ToDouble(change.Text).ToString("#,##0");
            }
            if (!"".Equals(receive.Text)){
                receive.Text= Convert.ToDouble(receive.Text).ToString("#,##0");
            }
        }
        public void getTotal()
        {
            int tong = 0;
            foreach (MedicineItem item in flowLayoutPanel1.Controls)
            {
                tong += item.medicine.quantysell * item.medicine.sell_price;
            }
            Ntotal = tong;
            Total.Text = tong.ToString();
        }

        public void setDetail(medicineSell m)
        {
            MedicineNameLabel.Text = m.name;
            MedicineCodeLabel.Text = m.code;
            TypeMedicineLabel.Text = m.type;
            QtyLabel.Text = m.Qty.ToString();
            UnitLabel.Text = m.unit;
            LocationLabel.Text = m.location;
            PriceSellLabel.Text = m.sell_price.ToString();
            IngredientTexbox.Text = m.Ingredient;
            CodeBarLabel.Text = m.Barcode;
        }

        public void addToSell(medicineSell m)
        {
            setDetail(m);
            if (m.STOCK_DETAIL.Count > 0 && m.Qty > 0)
            {
                var c = from p in ListMe where (m.ID == p.ID) select p;
                if (c.Count() == 0)
                {
                    MedicineItem i = new MedicineItem(m);
                    i.d1 = new MedicineItem.Mydel1(delItem);
                    i.d2 = new MedicineItem.Mydel2(getTotal);
                    ListMe.Add(i);
                    i.No = (ListMe.Count).ToString();
                    flowLayoutPanel1.Controls.Add(i);
                    getTotal();
                }
            }
            else
            {
                MessageBox.Show("Out of stock!");
            }
        }
        public void delItem(MedicineItem m)
        {
            ListMe.Remove(m);
            flowLayoutPanel1.Controls.Clear();
            int i = 1;
            foreach (var item in ListMe)
            {
                flowLayoutPanel1.Controls.Add(item);
                item.No = i.ToString();
                i++;
            }
            getTotal();
        }

        

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            d();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.SuspendLayout();
            try
            {
                foreach (medicineSell item in _BLL.Instance.getlistMedicineSearch(TextBoxSearchMedicine.Text))
                {
                    SearchMedicineItem s = new SearchMedicineItem(item);
                    s.d = new SearchMedicineItem.Mydel(addToSell);
                    flowLayoutPanel2.Controls.Add(s);
                }
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout();
            }
        }


        private void Total_TextChanged(object sender, EventArgs e)
        {
            int s = (int)(Ntotal -Ntotal * (Ndiscount / 100.0));
            Ncharge = s;
            charge.Text = s.ToString();
            changeNumber();
        }

        private void discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(discount.Text))
                {
                    int a = Convert.ToInt32(discount.Text);
                    if (a > 100)
                        a = 100;
                    if (a < 0)
                        a = 0;
                    Ndiscount = a;
                    discount.Text = a.ToString();
                    int s = (int)(Ntotal - Ntotal * (Ndiscount / 100.0));
                    Ncharge = s;
                    charge.Text = s.ToString();
                    changeNumber();
                }
            }
            catch (Exception)
            {
                discount.Text = "0";
                
            }
        }

        private void receive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (!"".Equals(receive.Text))
                    {
                        int a = Convert.ToInt32(receive.Text.Replace(",", ""));
                        change.Text = (a - Ncharge).ToString();
                        changeNumber();
                    }
                }
                catch (Exception)
                {
                    receive.Text = "";
                    change.Text = "";
                }
            }
            
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if (ListMe.Count > 0)
            {
                INVOICE I;
                if (this.customer == null)
                {
                    I = new INVOICE
                    {
                        DATE = DateTime.Now,
                        DISCOUNT = Ndiscount / 100.0,
                        PRESCRIPTION = Note.Text,
                        User_ID = this.user.ID,
                        TOTAL = Ntotal,
                        CHARGE = Ncharge,
                    };
                }
                else
                {
                    I = new INVOICE
                    {
                        DATE = DateTime.Now,
                        DISCOUNT = Ndiscount / 100.0,
                        ID_CUSTOMER = this.customer.ID,
                        PRESCRIPTION = Note.Text,
                        User_ID = this.user.ID,
                        TOTAL = Ntotal,
                        CHARGE = Ncharge,
                    };
                }
                List<InvoiceView> L = new List<InvoiceView>();
                foreach (MedicineItem item in ListMe)
                {
                    int oprice = item.medicine.stock_detail.ORGIGINAL_PRICE * item.medicine.quantysell;
                    int total = item.medicine.sell_price * item.medicine.quantysell;
                    int sprice = (int)(total - total * Ndiscount / 100.0);
                    I.INVOICE_DETAIL.Add(new INVOICE_DETAIL
                    {
                        ID_MEDICINE = item.medicine.ID,
                        QUANTITY = item.medicine.quantysell,
                        ORIGINAL_PRICE = oprice,
                        SALE_PRICE = sprice,
                    });
                    _BLL.Instance.UpdateStockDetail(item.medicine.stock_detail,item.medicine.quantysell);

                    L.Add(new InvoiceView
                    {
                        name = item.medicine.name,
                        pricePerUnit = item.medicine.sell_price.ToString("#,##0"),
                        quantity= item.medicine.quantysell,
                        EXP=item.medicine.stock_detail.dateExpire.ToString()
                    }) ;

                }
                _BLL.Instance.AddInvoice(I);
                DialogResult dr = MessageBox.Show("Bạn có muốn in hóa đơn không?", "Thanh toán thành công?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    DGVPrinter print = new DGVPrinter();
                    PHARMACY_PROFILE p = _BLL.Instance.getProfile();
                    print.Title = "Hóa đơn";
                    print.SubTitle = String.Format("Tiệm thuốc: {0}\nĐịa chỉ: {1}\nĐiện thoại: {2}\nGiờ mở cửa: {3}\n\n\nNgày: {4}\n\n\n", p.PharmacyName,p.Address,p.PhoneNumber,p.BusinessHours, DateTime.Now.ToString());
                    print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                    print.PageNumbers = false;
                    print.PageNumberInHeader = false;
                    print.PorportionalColumns = true;
                    print.HeaderCellAlignment = StringAlignment.Near;
                    print.Footer = String.Format("Chú thích:\n\t{0}\n\n\nTổng: {1}\nGiảm giá: {2}%\nCần trả: {3}", Note.Text, Ntotal.ToString("#,##0"), Ndiscount.ToString(), Ncharge.ToString("#,##0"));
                    print.FooterSpacing = 15;
                    dataGridView1.DataSource = L;
                    print.PrintDataGridView(dataGridView1);
                }
                refresh();
            }
            else
            {
                MessageBox.Show("Không có gì để thanh toán!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchSampleTextbox_TextChanged(object sender, EventArgs e)
        {
            SampleDataGridView.DataSource = _BLL.Instance.getListSampleView(SearchSampleTextbox.Text);
            SampleDataGridView.Columns[0].Visible = false;
        }


        private void SampleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            ListMe.Clear();
            int id = (int)SampleDataGridView.SelectedRows[0].Cells[0].Value;
            
            foreach (var item in _BLL.Instance.getListMedicineBySampleID(id))
            {
                if (item.STOCK_DETAIL.Count > 0 && item.Qty >item.quantysell)
                {
                        MedicineItem i = new MedicineItem(item);
                        i.d1 = new MedicineItem.Mydel1(delItem);
                        i.d2 = new MedicineItem.Mydel2(getTotal);
                        ListMe.Add(i);
                        i.No = (ListMe.Count).ToString();
                        flowLayoutPanel1.Controls.Add(i);
                        getTotal();
                }
                else
                {
                    MessageBox.Show("Hết hàng!");
                    flowLayoutPanel1.Controls.Clear();
                    ListMe.Clear();
                    return;
                }
                SAMPLE s = _BLL.Instance.getSampleByID(id);
                Note.Text = s.PRESCRIPTION;
            }
        }

        private void customerInvoiceHistoryDatagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            ListMe.Clear();
            int id = (int)customerInvoiceHistoryDatagridview.SelectedRows[0].Cells[0].Value;
            foreach (var item in _BLL.Instance.getlistMedicineSearch2(id))
            {
                if (item.STOCK_DETAIL.Count > 0 && item.Qty > item.quantysell)
                {
                    MedicineItem i = new MedicineItem(item);
                    i.d1 = new MedicineItem.Mydel1(delItem);
                    i.d2 = new MedicineItem.Mydel2(getTotal);
                    ListMe.Add(i);
                    i.No = (ListMe.Count).ToString();
                    flowLayoutPanel1.Controls.Add(i);
                    getTotal();
                }
                else
                {
                    MessageBox.Show("Hết hàng!");
                    flowLayoutPanel1.Controls.Clear();
                    ListMe.Clear();
                    return;
                }
                INVOICE I = customer.INVOICEs.Where(p => p.ID_INVOICE == id).Select(p => p).Single();
                Note.Text = I.PRESCRIPTION;
            }
        }

        private void BackButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
