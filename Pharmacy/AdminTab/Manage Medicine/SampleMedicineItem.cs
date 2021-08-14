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
        public medicineSell medicineItem;
        public delegate void DeleteDelegate(SampleMedicineItem sampleMedicine);
        public DeleteDelegate deleteMedicineFromPanel;

        public bool BtnDelete
        {
            set
            {
                btnDelete.Visible = value;
            }
        }

        public bool TxtQuantity
        {
            set
            {
                txtQuantity.Enabled = value;
            }
        }

        public SampleMedicineItem(medicineSell obj)
        {
            InitializeComponent();
            medicineItem = obj;
            setInformation();
        }

        public void setInformation()
        {
            lbName.Text = medicineItem.name;
            txtUnit.Text = medicineItem.unit;
            txtQuantity.Text = medicineItem.quantysell.ToString();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                medicineItem.quantysell = 0;
            }
            else
            {
                medicineItem.quantysell = Convert.ToInt32(txtQuantity.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteMedicineFromPanel(this);
        }
    }
}
