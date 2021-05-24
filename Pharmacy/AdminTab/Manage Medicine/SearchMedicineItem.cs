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
    public partial class SearchMedicineItem : UserControl
    {
        int id;
        public MedicineStock medicine;
        public delegate void Mydel(MedicineStock m);
        public Mydel d;
        public SearchMedicineItem(MedicineStock m)
        {
            InitializeComponent();
            this.medicine = m;
            setValue();
        }
        public void setValue()
        {
            this.NameMedicine.Text = medicine.name;
            this.Unit.Text = medicine.unit;
            this.id = medicine.ID;
            this.code.Text = medicine.ID.ToString();
            this.Available.Text = medicine.quantityInKho.ToString();
            this.Price.Text = "Price: " + medicine.original_price.ToString();
        }

        private void SearchMedicineItem_MouseClick(object sender, MouseEventArgs e)
        {
            d(medicine);
        }

        private void SearchMedicineItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            ForeColor = Color.Black;
            this.Unit.ForeColor = Color.White;
        }

        private void SearchMedicineItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            ForeColor = Color.Black;
            this.Unit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
        }

        private void SearchMedicineItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(144)))), ((int)(((byte)(218)))));
            ForeColor = Color.White;
            this.Unit.ForeColor = Color.White;
        }

        private void NameMedicine_Click(object sender, EventArgs e)
        {
            d(medicine);
        }

        private void NameMedicine_MouseClick(object sender, MouseEventArgs e)
        {
            d(medicine);
        }

        private void SearchMedicineItem_Click(object sender, EventArgs e)
        {
            d(medicine);
        }

        private void buttonAddMedicine_Click(object sender, EventArgs e)
        {
            d(medicine);
        }
    }
}
