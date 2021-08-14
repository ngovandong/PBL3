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
using BLL.Model_View;
using DAL.DTO;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class AddSample : Form
    {
        public delegate void RefreshDelegate();
        public RefreshDelegate refreshFunc;

        List<medicineSell> listSampleMedicine = new List<medicineSell>();

        public AddSample()
        {
            InitializeComponent();
            setDisablePanelSearch();
        }

        public void setDisablePanelSearch()
        {
            panelSearch.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            panelSearch.Controls.Clear();
            panelSearch.SuspendLayout();
            try
            {
                foreach(var item in _BLL.Instance.getlistMedicineSearch(txtSearch.Text))
                {
                    SearchSampleMedicineItem searchSample = new SearchSampleMedicineItem(item);
                    searchSample.addMedicineToPanel = new SearchSampleMedicineItem.AddDelegate(addToPanelContainMedicine);
                    panelSearch.Controls.Add(searchSample);
                }
            } finally
            {
                panelSearch.ResumeLayout();
            }
        }

        public void addToPanelContainMedicine(medicineSell medicineItem)
        {
            bool check = listSampleMedicine.Any(obj => obj.ID == medicineItem.ID);
            if (!check)
            {
                listSampleMedicine.Add(medicineItem);
                SampleMedicineItem sampleMedicineItem = new SampleMedicineItem(medicineItem);
                sampleMedicineItem.deleteMedicineFromPanel = new SampleMedicineItem.DeleteDelegate(deleteFromPanel);
                panelContainMedicine.Controls.Add(sampleMedicineItem);
            }
        }

        public void deleteFromPanel(SampleMedicineItem sampleMedicineItem)
        {
            listSampleMedicine.Remove(sampleMedicineItem.medicineItem);
            panelContainMedicine.Controls.Remove(sampleMedicineItem);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn thêm đơn thuốc mẫu này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SAMPLE sample = new SAMPLE
                    {
                        NAME = txtSampleName.Text,
                        PRESCRIPTION = txtPrescription.Text,
                    };
                    foreach (var item in listSampleMedicine)
                    {
                        sample.SAMPLE_DETAIL.Add(new SAMPLE_DETAIL
                        {
                            QTY = item.quantysell,
                            MEDICINE_ID = item.ID,
                            SAMPLE_ID = sample.SAMPLEID,
                        });
                    }
                    _BLL.Instance.addSample(sample);
                    refreshFunc();
                    this.Close();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
