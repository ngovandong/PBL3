using Pharmacy.AdminTab.Manage_Medicine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab
{
    public partial class medicine : UserControl
    {
        public medicine()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddMedicine f = new AddMedicine();
            f.Show();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            DetailMedicine f = new DetailMedicine();
            f.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateMedicine f = new UpdateMedicine();
            f.Show();
        }
    }
}
