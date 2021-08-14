using BLL;
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
    public partial class UpdateSample : Form
    {
        public delegate void RefreshDelegate();
        public RefreshDelegate refreshFunc;

        public SAMPLE sample;

        List<medicineSell> listSampleMedicine = new List<medicineSell>();

        public UpdateSample(int id)
        {
            InitializeComponent();
            sample = _BLL.Instance.getSampleByID(id);
            setDetailSampleInformation();
        }

        public void setDetailSampleInformation()
        {
            txtSampleName.Text = sample.NAME.ToString();
            txtPrescription.Text = sample.PRESCRIPTION.ToString();
            foreach (var item in _BLL.Instance.getListMedicineBySampleID(sample.SAMPLEID))
            {
                listSampleMedicine.Add(item);
                SampleMedicineItem sampleMedicineItem = new SampleMedicineItem(item);
                sampleMedicineItem.deleteMedicineFromPanel = new SampleMedicineItem.DeleteDelegate(deleteFromPanel);
                panelContainMedicine.Controls.Add(sampleMedicineItem);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            panelSearch.Controls.Clear();
            panelSearch.SuspendLayout();
            try
            {
                foreach (var item in _BLL.Instance.getlistMedicineSearch(txtSearch.Text))
                {
                    SearchSampleMedicineItem searchSample = new SearchSampleMedicineItem(item);
                    searchSample.addMedicineToPanel = new SearchSampleMedicineItem.AddDelegate(addToPanelContainMedicine);
                    panelSearch.Controls.Add(searchSample);
                }
            }
            finally
            {
                panelSearch.ResumeLayout();
            }
        }

        public void addToPanelContainMedicine(medicineSell medicineItem)
        {
            listSampleMedicine.Add(medicineItem);
            SampleMedicineItem sampleMedicineItem = new SampleMedicineItem(medicineItem);
            sampleMedicineItem.deleteMedicineFromPanel = new SampleMedicineItem.DeleteDelegate(deleteFromPanel);
            panelContainMedicine.Controls.Add(sampleMedicineItem);
        }

        public void deleteFromPanel(SampleMedicineItem sampleMedicineItem)
        {
            listSampleMedicine.Remove(sampleMedicineItem.medicineItem);
            panelContainMedicine.Controls.Remove(sampleMedicineItem);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (panelContainMedicine.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm thuốc vào đơn mẫu");
            }
            else if (listSampleMedicine.FindAll(o => o.quantysell == 0).Count != 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng của thuốc");
            }
            else if (txtSampleName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên mẫu");
            }
            else if (txtPrescription.Text == "")
            {
                MessageBox.Show("Vui lòng nhập kê đơn");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn cập nhật đơn thuốc mẫu này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SAMPLE newSample = new SAMPLE
                    {
                        SAMPLEID = sample.SAMPLEID,
                        NAME = txtSampleName.Text,
                        PRESCRIPTION = txtPrescription.Text,
                    };

                    foreach (var item in listSampleMedicine)
                    {
                        newSample.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
                        {
                            QTY = item.quantysell,
                            MEDICINE_ID = item.ID,
                            SAMPLE_ID = newSample.SAMPLEID,
                        });
                    }
                    _BLL.Instance.updateSample(newSample);

                    refreshFunc();
                    this.Close();
                }
            }
        }

    }
}
