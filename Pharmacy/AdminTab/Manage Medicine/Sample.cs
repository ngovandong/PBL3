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
    public partial class Sample : UserControl
    {
        List<medicineSell> listMedicineSample = new List<medicineSell>();
        public Sample()
        {
            InitializeComponent();
            setSearchBox();
        }
        
        public void setSearchBox()
        {
            panelSearch.Visible = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            panelSearch.Visible = true;
            panelSearch.Controls.Clear();
            try
            {
                foreach(var item in _BLL.Instance.getlistMedicineSearch(txtSearch.Text))
                {
                    SearchMedicineItem sItem = new SearchMedicineItem(item);
                    sItem.AddToPanelFunc = new SearchMedicineItem.AddToPanelDelegate(addToPanel);
                    panelSearch.Controls.Add(sItem);
                }
            }
            finally
            {
                panelSearch.ResumeLayout();
            }
        }

        public void addToPanel(medicineSell item)
        {
            listMedicineSample.Add(item);
            SampleMedicineItem sItem = new SampleMedicineItem(item);
            sItem.deleteFunc = new SampleMedicineItem.DeleteDelegate(deleteFromPanel);
            panelSampleMedicine.Controls.Add(sItem);
            panelSearch.Visible = false;
        }   

        public void deleteFromPanel(SampleMedicineItem item)
        {
            listMedicineSample.Remove(item.medicineSellItem);
            panelSampleMedicine.Controls.Remove(item);
        }

        private void Sample_MouseClick(object sender, MouseEventArgs e)
        {
            panelSearch.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            if (panelSampleMedicine.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm thuốc");
            }
            else if(listMedicineSample.FindAll(o => o.quantysell == 0).Count != 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng thuốc");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên của đơn thuốc");
            }
            else if (txtPrescription.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin kê đơn");
            }
            else
            {
                SAMPLE s = new SAMPLE
                {
                    NAME = txtName.Text,
                    PRESCRIPTION = txtPrescription.Text
                };
                
                foreach(var item in listMedicineSample)
                {
                    try
                    {
                        s.SAMPLE_DETAILs.Add(new SAMPLE_DETAIL
                        {
                            QTY = item.quantysell,
                            MEDICINE_ID = item.ID,
                            SAMPLE_ID = s.SAMPLEID,
                        });
                    }
                    catch
                    {
                        MessageBox.Show(s.NAME);
                    }
                }

                _BLL.Instance.addSample(s);
            }
        }
    }
}
