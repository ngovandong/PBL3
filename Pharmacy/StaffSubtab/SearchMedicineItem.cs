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

namespace Pharmacy.StaffSubtab
{
    public partial class SearchMedicineItem : UserControl
    {
        public int id;
        public medicineSell medicine;
        public delegate void Mydel(medicineSell m);
        public Mydel d;
        public SearchMedicineItem(medicineSell m)
        {
            InitializeComponent();
            this.medicine = m;
            setValue();
        }


        private void NameMedicine_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
            ForeColor = Color.White;
            this.Unit.ForeColor = Color.White;
        }

        private void NameMedicine_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            ForeColor = Color.Black;
            this.Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
        }

        private void SearchMedicineItem_MouseClick(object sender, MouseEventArgs e)
        {
            d(medicine);
        }

        private void SearchMedicineItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
            ForeColor = Color.White;
            this.Unit.ForeColor = Color.White;
        }

        private void SearchMedicineItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            ForeColor = Color.Black;
            this.Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
        }

        private void NameMedicine_MouseClick(object sender, MouseEventArgs e)
        {
            d(medicine);
        }

        public void setValue()
        {
            this.NameMedicine.Text = medicine.name;
            this.Unit.Text = medicine.unit;
            this.id = medicine.ID;
            this.code.Text = medicine.code;
            this.Available.Text = medicine.Qty.ToString();
            this.Price.Text = medicine.sell_price.ToString();
        }
    }
}
