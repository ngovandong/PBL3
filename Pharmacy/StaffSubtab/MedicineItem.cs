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
        public delegate void Mydel(MedicineItem m);
        public Mydel d;
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
            Qty.Text = "1";
            Total.Text = medicine.sell_price.ToString();
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
            d(this);
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
                    int t = a * medicine.sell_price;
                    this.Total.Text = t.ToString();
                }
                
            }
            catch (Exception)
            {
                this.Qty.Text = "1";
                this.Total.Text = medicine.sell_price.ToString();
            }
        }

        private void Qty_Leave(object sender, EventArgs e)
        {
            if ("".Equals(this.Qty.Text))
            {
                this.Qty.Text = "1";
                this.Total.Text = medicine.sell_price.ToString();
            }
        }
    }
}
