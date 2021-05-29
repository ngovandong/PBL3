using BLL;
using DAL;
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
    public partial class StaffReport : UserControl
    {
        private USER u;
        public StaffReport(USER u)
        {
            InitializeComponent();
            this.u = u;
            setStart();
        }
        public void setStart()
        {
            this.guna2DataGridView1.DataSource = _BLL.Instance.getListInvoice(this.u.ID);
        }
    }
}
