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
            panel2.Visible = false;
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
            if((txtMedicineCode.Text!="")&& (txtName.Text != "") && (cbBoxType.Text != "") && (txtBarcode.Text != "") && (txtBrand.Text != "") && (txtSubcribe.Text != "") && (txtLocation.Text != "") && (txtIngredient.Text != "") && (txtDescription.Text != "") && (cbBoxUnit.Text != "")&& (txtOriginalPrice.Text != "") && (txtSalePrice.Text != "")&&guna2CheckBox2.Checked&&guna2CheckBox1.Checked)
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

        private void txtName_Enter(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }



        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //ListBox.ObjectCollection oc = new ListBox.ObjectCollection(this.listBox1, _BLL.Instance.getListSuggest(txtName.Text).Take(30).ToArray());
            listBox1.DataSource = _BLL.Instance.getListSuggest(txtName.Text).Take(30).ToArray();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                LISTMEDICINE L = (LISTMEDICINE)listBox1.SelectedItem;
                txtName.Text = L.medicine_name;
                txtIngredient.Text = L.chemicals;
                txtBrand.Text = L.branch;
                txtSubcribe.Text = L.no_subscribe;
                txtDescription.Text = L.content;
                txtMedicineCode.Text = L.medicine_code;
            }
            panel2.Visible = false;
        }

        private void txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (txtMedicineCode.Text != "" && _BLL.Instance.checkNameMedicine(txtMedicineCode.Text))
            {
                guna2CheckBox1.Checked = true;
            }
            else
            {
                guna2CheckBox1.Checked = false;
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text != "" && _BLL.Instance.checkBarcode(txtBarcode.Text))
            {
                guna2CheckBox2.Checked = true;
            }
            else
            {
                guna2CheckBox2.Checked = false;
            }
        }
    }
}
