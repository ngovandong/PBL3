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
        }

        private void MedicineItem_Load(object sender, EventArgs e)
        {
            this.ID = medicine.ID;
            MedicinCode.Text = medicine.code;
            NameMedicine.Text = medicine.name;
            Unit.Text = medicine.unit;
            price.Text = medicine.sell_price.ToString();
            ComboBoxStock.Items.AddRange(medicine.STOCK_DETAIL.Where(p=>p.QUANTITY>0).ToArray());
            ComboBoxStock.SelectedIndex = 0;
            Total.Text = medicine.sell_price.ToString();
            QuantiyUpDown.Value = medicine.quantysell;
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

        

        

        private void ComboBoxStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            medicine.stock_detail = ((STOCK_DETAIL)ComboBoxStock.SelectedItem);
            StockDetailLabel.Text = medicine.stock_detail.dateExpire.ToShortDateString() + " Tồn: " + medicine.stock_detail.QUANTITY.ToString();
        }

        private void QuantiyUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (QuantiyUpDown.Value > ((STOCK_DETAIL)ComboBoxStock.SelectedItem).QUANTITY)
            {
                MessageBox.Show("Số lượng mua lớn hơn số lượng còn trong lô!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuantiyUpDown.Value = 1;
            }
            else if (QuantiyUpDown.Value == 0)
            {
                QuantiyUpDown.Value = 1;
                medicine.quantysell = 1;
                Total.Text = medicine.sell_price.ToString();
                d2();
            }
            else
            {
                int t = (int)(QuantiyUpDown.Value * medicine.sell_price);
                this.Total.Text = t.ToString();
                medicine.quantysell = (int)QuantiyUpDown.Value;
                d2();
            }
        }

    }
}
