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
        List<medicineSell> listSampleMedicine = new List<medicineSell>();
        public Sample()
        {
            InitializeComponent();
            setPanelSearch();
        }

        public void setPanelSearch()
        {
            panelSearch.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            panelSearch.BringToFront();
            panelSearch.Controls.Clear();
            panelSearch.SuspendLayout();
            try
            {
                foreach (var item in _BLL.Instance.getlistMedicineSearch(txtSearch.Text))
                {
                    SearchSampleMedicineItem searchSample = new SearchSampleMedicineItem(item);
                    searchSample.AddFunc = new SearchSampleMedicineItem.AddDelegate(AddToPanel);
                    panelSearch.Controls.Add(searchSample);
                }
            }
            finally
            {
                panelSearch.ResumeLayout();
            }
        }

        public void AddToPanel(medicineSell medicineItem)
        {
            setPanelSearch();
            listSampleMedicine.Add(medicineItem);
            SampleMedicineItem sampleMedicine = new SampleMedicineItem(medicineItem);
            sampleMedicine.DeleteFunc = new SampleMedicineItem.DeleteDelegate(deleteFromPanel);
            panelMedicine.Controls.Add(sampleMedicine);
        }

        public void deleteFromPanel(SampleMedicineItem sampleMedicine)
        {
            listSampleMedicine.Remove(sampleMedicine.medicineItem);
            panelMedicine.Controls.Remove(sampleMedicine);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (panelMedicine.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào đơn mẫu");
            }
            else if (listSampleMedicine.FindAll(o => o.quantysell == 0).Count != 0)
            {
                MessageBox.Show("Vui lòng nhập lại số lượng của thuốc");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên mẫu");
            }
            else if (txtPrescription.Text == "")
            {
                MessageBox.Show("Vui lòng nhập kê đơn");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn thêm đơn thuốc mẫu này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SAMPLE sample = new SAMPLE
                    {
                        NAME = txtName.Text,
                        PRESCRIPTION = txtPrescription.Text,
                    };
                    foreach(var item in listSampleMedicine)
                    {
                        sample.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
                        {
                            QTY = item.quantysell,
                            MEDICINE_ID = item.ID,
                            SAMPLE_ID = sample.SAMPLEID,
                        });
                    }
                    _BLL.Instance.addSample(sample);
                    setClearView();
                }
                else
                {

                }
            }
        }
        public void setClearView()
        {
            panelMedicine.Controls.Clear();
            txtName.Text = "";
            txtPrescription.Text = "";
            txtSearch.Text = "";
        }

        private void panelMedicine_MouseClick(object sender, MouseEventArgs e)
        {
            panelSearch.Visible = false;
        }

    }
}
