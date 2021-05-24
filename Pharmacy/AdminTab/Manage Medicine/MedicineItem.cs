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

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class MedicineItem : UserControl
    {
        public int ID;
        public MedicineStock medicine;
        public delegate void Mydel(MedicineItem m);
        public delegate void Mydel2();
        public Mydel d;
        public Mydel2 d2;
        private string _no;
        [Category("Custom Prop")]
        public string No
        {
            get { return _no; }
            set { _no = value; lbSTT.Text = value; }
        }
        public MedicineItem(MedicineStock m)
        {
            InitializeComponent();
            this.medicine = m;
        }
        public void setStart()
        {
            this.ID = medicine.ID;
            lbName.Text = medicine.name;
            lbID.Text = medicine.ID.ToString();
            textBoxDonVi.Text = medicine.unit;
            textBoxDonGia.Text = medicine.original_price.ToString();
            numericUpDownSoluong.Value = 1;
            medicine.HSD = guna2DateTimePicker1.Value.Date;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            d(this);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDownSoluong_ValueChanged(object sender, EventArgs e)
        {
            medicine.quantityInStock = Convert.ToInt32(numericUpDownSoluong.Value);
            textBoxDonGia_MouseLeave(sender, e);
        }

        private void MedicineItem_Load(object sender, EventArgs e)
        {
            setStart();
        }

        private void textBoxDonGia_MouseLeave(object sender, EventArgs e)
        {
            int don_gia = Convert.ToInt32(textBoxDonGia.Text);
            int so_luong = Convert.ToInt32(numericUpDownSoluong.Value);
            if(textboxGiamGia.Text == "")
            {
                textboxGiamGia.Text = "0";
            }
            int giam_gia = Convert.ToInt32(textboxGiamGia.Text);
            if(giam_gia > 100)
            {
                giam_gia = 100;
            }
            textBoxThanhTien.Text = (don_gia * so_luong * (100 - giam_gia) / 100).ToString();
            medicine.final_price = don_gia * so_luong * (100 - giam_gia) / 100;
            d2();
        }

        private void textboxGiamGia_MouseLeave(object sender, EventArgs e)
        {
            if (textboxGiamGia.Text == "")
            {
                textboxGiamGia.Text = "0";
            }
            else
            {
                int sale = Convert.ToInt32(textboxGiamGia.Text);
                if(sale > 100)
                {
                    sale = 100;
                    textboxGiamGia.Text = sale.ToString();
                }
            }
            textBoxDonGia_MouseLeave(sender, e);
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            medicine.HSD = guna2DateTimePicker1.Value.Date;
        }

        private void textboxGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
