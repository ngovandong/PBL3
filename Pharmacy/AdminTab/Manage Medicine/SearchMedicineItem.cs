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
using BLL.Model_View;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class SearchMedicineItem : UserControl
    {

        public medicineSell medicineSellItem;
        public delegate void AddToPanelDelegate(medicineSell item);
        public AddToPanelDelegate AddToPanelFunc;
        public SearchMedicineItem(medicineSell obj)
        {
            InitializeComponent();
            medicineSellItem = obj;
            setInformation();
        }

        public void setInformation()
        {
            lbName.Text = medicineSellItem.name;
            lbPrice.Text = medicineSellItem.sell_price.ToString();
            lbUnit.Text = medicineSellItem.unit;
        }

        private void guna2Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            AddToPanelFunc(medicineSellItem);
        }
    }
}
