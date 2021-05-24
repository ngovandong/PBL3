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
    public partial class ImportMedicine : UserControl
    {
        public ImportMedicine()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddStock stock = new AddStock();
            stock.ShowDialog();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            StockDetail stockDetail = new StockDetail();
            stockDetail.ShowDialog();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            StockDetail stockDetail = new StockDetail();
            stockDetail.ShowDialog();
        }
    }
}
