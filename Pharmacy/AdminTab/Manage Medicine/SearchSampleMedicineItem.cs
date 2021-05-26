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
    public partial class SearchSampleMedicineItem : UserControl
    {
        medicineSell medicineItem;

        public delegate void AddDelegate(medicineSell medicineItem);
        public AddDelegate AddFunc;
        public SearchSampleMedicineItem(medicineSell obj)
        {
            InitializeComponent();
            medicineItem = obj;
            setInformation();
        }

        private void lbUnit_MouseClick(object sender, MouseEventArgs e)
        {
            AddFunc(medicineItem);
        }
        
        public void setInformation()
        {
            lbName.Text = medicineItem.name;
            lbPrice.Text = medicineItem.sell_price.ToString();
            lbUnit.Text = medicineItem.unit;
        }
    }
}
