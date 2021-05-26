using BLL.Model_View;
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
    public partial class MedicineItem : UserControl
    {
        public int ID;
        public medicineSell medicine;
        public delegate void Mydel1(MedicineItem m);
        public Mydel1 d1;
        public delegate void Mydel2();
        public Mydel2 d2;
        public MedicineItem(medicineSell m)
        {
            InitializeComponent();
            this.medicine = m;
            setStart();
        }

        public void setStart()
        {
            this.ID = medicine.ID;
            MedicinCode.Text = medicine.code;
            NameMedicine.Text = medicine.name;
            Unit.Text = medicine.unit;
            price.Text = medicine.sell_price.ToString();
            ComboBoxStock.Items.AddRange(medicine.STOCK_DETAIL.ToArray());
            ComboBoxStock.SelectedIndex = 0;
            Total.Text = medicine.sell_price.ToString();
            medicine.quantysell = 1;
        }
        
        private string _no;
        [Category("Custom Prop")]
        public string No
        {
            get { return _no; }
            set { _no = value;NoMedicine.Text = value; }
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            d1(this);
        }



        private void guna2ShadowPanel1_MouseEnter_1(object sender, EventArgs e)
        {
            this.guna2ShadowPanel1.FillColor = Color.LightGray;

        }

        private void guna2ShadowPanel1_MouseLeave_1(object sender, EventArgs e)
        {
            this.guna2ShadowPanel1.FillColor = Color.White;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!"".Equals(this.Qty.Text))
                {
                    int a = Convert.ToInt32(Qty.Text);
                    if (a < 1)
                        throw new Exception();
                    if (a > ((STOCK_DETAIL)ComboBoxStock.SelectedItem).QUANTITY)
                    {
                        MessageBox.Show("Số lượng mua lớn hơn số lượng còn trong lô!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new Exception();
                    }
                    int t = a * medicine.sell_price;
                    this.Total.Text = t.ToString();
                    medicine.quantysell = a;
                    d2();
                }
                
            }
            catch (Exception)
            {
                this.Qty.Text = "1";
                this.Total.Text = medicine.sell_price.ToString();
                medicine.quantysell = 1;
                d2();
            }
            
        }

        private void Qty_Leave_1(object sender, EventArgs e)
        {
            if ("".Equals(this.Qty.Text))
            {
                this.Qty.Text = "1";
                this.Total.Text = medicine.sell_price.ToString();
                medicine.quantysell = 1;
                d2();
            }
        }

        private void ComboBoxStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicine.stock_detail = ((STOCK_DETAIL)ComboBoxStock.SelectedItem);
            StockDetailLabel.Text = medicine.stock_detail.dateExpire.ToShortDateString() + " Tồn: " + medicine.stock_detail.QUANTITY.ToString();
        }

        
    }
}
