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
    public partial class MedicineItem : UserControl
    {
        public delegate void Mydel(MedicineItem m);
        public Mydel d;
        public MedicineItem()
        {
            InitializeComponent();
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

    }
}
