using BLL;
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
    public partial class DetailSample : Form
    {

        public SAMPLE sample;
        public DetailSample(int id)
        {
            InitializeComponent();
            sample = _BLL.Instance.getSampleByID(id);
            setDetailSampleInformation();
        }

        public void setDetailSampleInformation()
        {
            txtSampleName.Text = sample.SAMPLEID.ToString();
            txtPrescription.Text = sample.PRESCRIPTION.ToString();
            foreach(var item in _BLL.Instance.getListMedicineBySampleID(sample.SAMPLEID))
            {
                SampleMedicineItem sampleMedicineItem = new SampleMedicineItem(item);
                sampleMedicineItem.BtnDelete = false;
                sampleMedicineItem.TxtQuantity = false;
                panelContainMedicine.Controls.Add(sampleMedicineItem);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
