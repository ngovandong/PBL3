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
using DAL;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class AddMedicine : Form
    {

        public delegate void RefreshDelegate();
        public RefreshDelegate RefreshFunc;

        public AddMedicine()
        {
            InitializeComponent();
            setComboBoxMedicine_Type();
            setComboBoxUnit();
        }

        public void setComboBoxMedicine_Type()
        {
            cbBoxType.Items.Clear();
            cbBoxType.Items.AddRange(_BLL.Instance.getListCBBMedicine_Type().ToArray());
        }

        public void setComboBoxUnit()
        {
            cbBoxUnit.Items.Clear();
            cbBoxUnit.Items.AddRange(_BLL.Instance.getListCBBUnit().ToArray());
        }

        private MEDICINE getInforFromForm()
        {
            try
            {
                return new MEDICINE
                {
                    BARCODE = txtBarcode.Text,
                    MEDICINE_NAME = txtName.Text,
                    MEDICINE_CODE = txtMedicineCode.Text,
                    LOCATION = txtLocation.Text,
                    ID_SUB = txtSubcribe.Text,
                    INGREDIENT = txtIngredient.Text,
                    CONTENT = txtDescription.Text,
                    BRAND = txtBrand.Text,
                    QUANTITY = 0,
                    ORIGINAL_PRICE = Convert.ToInt32(txtOriginalPrice.Text),
                    SALE_PRICE = Convert.ToInt32(txtSalePrice.Text),
                    TYPEID = ((BLL.Model_View.COMBOBOX_ITEM)cbBoxType.SelectedItem).ID,
                    UNIT_ID = ((BLL.Model_View.COMBOBOX_ITEM)cbBoxUnit.SelectedItem).ID
                };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if((txtMedicineCode.Text!="")&& (txtName.Text != "") && (cbBoxType.Text != "") && (txtBarcode.Text != "") && (txtBrand.Text != "") && (txtSubcribe.Text != "") && (txtLocation.Text != "") && (txtIngredient.Text != "") && (txtDescription.Text != "") && (cbBoxUnit.Text != "")&& (txtOriginalPrice.Text != "") && (txtSalePrice.Text != ""))
            {
                MEDICINE m = getInforFromForm();
                if (m != null)
                {
                    _BLL.Instance.addMedicine(m);
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshFunc();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Fail! Please check all property.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter all property!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMedicineType_Click(object sender, EventArgs e)
        {
            AddMedicineType addForm = new AddMedicineType();
            addForm.updateFunc = new AddMedicineType.UpdateCBBUnitDelegate(setComboBoxMedicine_Type);
            addForm.Show();
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            AddMedicineUnit addForm = new AddMedicineUnit();
            addForm.updateFunc = new AddMedicineUnit.UpdateCBBUnitDelegate(setComboBoxUnit);
            addForm.Show();
        }

 
    }
}
