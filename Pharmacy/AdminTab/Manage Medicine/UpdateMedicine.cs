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
    public partial class UpdateMedicine : Form
    {
        public int medicineID;
        public delegate void RefreshDelegate();
        public RefreshDelegate RefreshFunc;
        public UpdateMedicine(int id)
        {
            InitializeComponent();
            medicineID = id;
            setComboBox();
        }

        public void setComboBox()
        {
            cbBoxType.Items.AddRange(_BLL.Instance.getListCBBMedicine_Type().ToArray());
            cbBoxUnit.Items.AddRange(_BLL.Instance.getListCBBUnit().ToArray());
        }

        private void UpdateMedicine_Load(object sender, EventArgs e)
        {
            MEDICINE md = _BLL.Instance.getMedicineByID(medicineID);
            txtMedicineCode.Text = md.MEDICINE_CODE;
            txtName.Text = md.MEDICINE_NAME;
            cbBoxType.Text = md.MEDICINE_TYPE.TypeName;
            txtBarcode.Text = md.BARCODE;
            txtBrand.Text = md.BRAND;
            txtSubcribe.Text = md.ID_SUB;
            txtLocation.Text = md.LOCATION;
            txtIngredient.Text = md.INGREDIENT;
            txtDescription.Text = md.CONTENT;
            cbBoxUnit.Text = md.UNIT.NAME;
            txtQuantity.Text = md.QUANTITY.ToString();
            txtOriginalPrice.Text = md.ORIGINAL_PRICE.ToString();
            txtSalePrice.Text = md.SALE_PRICE.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtMedicineCode.Text != "") && (txtName.Text != "") && (cbBoxType.Text != "") && (txtBarcode.Text != "") && (txtBrand.Text != "") && (txtSubcribe.Text != "") && (txtLocation.Text != "") && (txtIngredient.Text != "") && (txtDescription.Text != "") && (cbBoxUnit.Text != "") && (txtQuantity.Text != "") && (txtOriginalPrice.Text != "") && (txtSalePrice.Text != ""))
            {
                MEDICINE md = getInforFromForm();
                DialogResult dr = MessageBox.Show("Xác nhận", "Bạn có muốn cập nhật các thông tin này?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    _BLL.Instance.updateMedicine(md);
                    RefreshFunc();
                    this.Close();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
        }
        private MEDICINE getInforFromForm()
        {
            try
            {
                return new MEDICINE
                {
                    ID = medicineID,
                    BARCODE = txtBarcode.Text,
                    MEDICINE_NAME = txtName.Text,
                    MEDICINE_CODE = txtMedicineCode.Text,
                    LOCATION = txtLocation.Text,
                    ID_SUB = txtSubcribe.Text,
                    INGREDIENT = txtIngredient.Text,
                    CONTENT = txtDescription.Text,
                    BRAND = txtBrand.Text,
                    QUANTITY = Convert.ToInt32(txtQuantity.Text),
                    ORIGINAL_PRICE = Convert.ToInt32(txtOriginalPrice.Text),
                    SALE_PRICE = Convert.ToInt32(txtSalePrice.Text),
                    TYPEID = ((BLL.Model_View.COMBOBOX_ITEM)cbBoxType.SelectedItem).ID,
                    UNIT_ID = ((BLL.Model_View.COMBOBOX_ITEM)cbBoxUnit.SelectedItem).ID
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
