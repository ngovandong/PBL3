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
using BLL;
using DAL.DTO;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class Sample : UserControl
    {
        
        public Sample()
        {
            InitializeComponent();
            setDataGridView();
        }

        public void setDataGridView()
        {
            sampleDataGridView.DataSource = _BLL.Instance.getListSampleView("");
            sampleDataGridView.Columns["ID"].Visible = false;
            sampleDataGridView.Columns["Name"].HeaderText = "Tên mẫu";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSample addForm = new AddSample();
            addForm.refreshFunc = new AddSample.RefreshDelegate(setDataGridView);
            addForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(sampleDataGridView.SelectedRows.Count == 1)
            {
                UpdateSample updateSample = new UpdateSample(Convert.ToInt32(sampleDataGridView.SelectedRows[0].Cells[0].Value));
                updateSample.refreshFunc = new UpdateSample.RefreshDelegate(setDataGridView);
                updateSample.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng thuốc mẫu để cập nhật thông tin");
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            if (sampleDataGridView.SelectedRows.Count == 1)
            {
                DetailSample detailSample = new DetailSample(Convert.ToInt32(sampleDataGridView.SelectedRows[0].Cells[0].Value));
                detailSample.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng thuốc mẫu để xem thông tin chi tiết");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            sampleDataGridView.DataSource = _BLL.Instance.getListSampleView(txtSearch.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (sampleDataGridView.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn xóa các đơn thuốc mẫu này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    List<int> listIdOfDeletedItems = new List<int>();
                    int count = sampleDataGridView.SelectedRows.Count;
                    for (int i = 0; i < count; ++i)
                    {
                        listIdOfDeletedItems.Add(Convert.ToInt32(sampleDataGridView.SelectedRows[i].Cells[0].Value));
                    }
                    _BLL.Instance.deleteSample(listIdOfDeletedItems);
                    setDataGridView();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng đơn thuốc mẫu để xóa");
            }
        }
    }
}
