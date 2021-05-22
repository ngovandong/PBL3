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
using BLL;

namespace Pharmacy.AdminTab
{
    public partial class medicine : UserControl
    {
        public medicine()
        {
            InitializeComponent();
            setDataGridView();
            setDataTextBoxSearch();
        }

        public void setDataGridView()
        {
            dataGridView.DataSource = _BLL.Instance.getListMedicineView();
        }

        public void setDataTextBoxSearch()
        {
            txtSearch.AutoCompleteCustomSource.AddRange(_BLL.Instance.getListMedicineView().Select(o => o.Name).ToArray());
        }
     
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddMedicine f = new AddMedicine();
            f.RefreshFunc = new AddMedicine.RefreshDelegate(setDataGridView);
            f.Show();
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count == 1)
            {
                DetailMedicine f = new DetailMedicine(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng thuốc để xem chi tiết");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                UpdateMedicine f = new UpdateMedicine(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                f.RefreshFunc = new UpdateMedicine.RefreshDelegate(setDataGridView);
                f.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng thuốc để chỉnh sửa thông tin");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn xóa các hàng thuốc này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    List<int> listIDOfDeletedItems = new List<int>();
                    int count = dataGridView.SelectedRows.Count;
                    for(int i = 0; i < count; ++i)
                    {
                        listIDOfDeletedItems.Add(Convert.ToInt32(dataGridView.SelectedRows[i].Cells[0].Value));
                    }
                    _BLL.Instance.deleteMedicine(listIDOfDeletedItems);
                    setDataGridView();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng thuốc để xóa");
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = _BLL.Instance.getListMedicineView().FindAll(o => o.Name.ToLower().Contains(txtSearch.Text.ToLower()));
        }
    }
}
