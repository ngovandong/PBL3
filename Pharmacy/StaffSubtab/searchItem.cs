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
    public partial class searchItem : UserControl
    {
        public searchItem()
        {
            InitializeComponent();
        }



        private void searchItem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // truyen delegate
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.LightGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }
    }
}
