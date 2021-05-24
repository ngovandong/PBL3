using BLL.Model_View;
using DAL.DTO;
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
    public partial class SearchSupplierItem : UserControl
    {
        public SupplierView supplier;
        public delegate void Mydel(SupplierView s);
        public Mydel d;
        public SearchSupplierItem(SupplierView s)
        {
            InitializeComponent();
            supplier = s;
            setValue();
        }
        public void setValue()
        {
            this.lbName.Text = supplier.Name;
            this.lbPhone.Text = "Phone " +  supplier.Phone;
        }
        private void Mouse_Click(object sender, EventArgs e)
        {
            d(supplier);
        }
        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            d(supplier);
        }
    }
}
