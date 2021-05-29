using BLL;
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
    public partial class AddMedicineType : Form
    {
        public delegate void UpdateCBBUnitDelegate();
        public UpdateCBBUnitDelegate updateFunc;

        public AddMedicineType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn thêm đơn vị này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    string name = txtName.Text;
                    _BLL.Instance.addMedicineType(name);
                    updateFunc();
                    this.Dispose();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
