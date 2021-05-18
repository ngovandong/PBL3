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
        public delegate void Mydel(SearchMedicineItem s);
        public Mydel d;
        public SearchMedicineItem()
        {
            InitializeComponent();
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
            d(this);
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
            d(this);
        }
    }
}
