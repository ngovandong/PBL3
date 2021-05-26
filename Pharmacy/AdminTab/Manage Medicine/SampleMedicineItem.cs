using BLL;
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
    public partial class SampleMedicineItem : UserControl
    {
        public medicineSell medicineSellItem;

        public delegate void DeleteDelegate(SampleMedicineItem item);
        public DeleteDelegate deleteFunc;

        public SampleMedicineItem(medicineSell obj)
        {
            InitializeComponent();
            medicineSellItem = obj;
            setInformation();
        }
        
        public void setInformation()
        {
            lbName.Text = medicineSellItem.name;
            txtUnit.Text = medicineSellItem.unit;
            txtQuantity.Text = "0";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            deleteFunc(this);
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if(txtQuantity.Text == "")
            {
                return;
            }
            else
            {
                medicineSellItem.quantysell = Convert.ToInt32(txtQuantity.Text);
            }
        }
    }
}
