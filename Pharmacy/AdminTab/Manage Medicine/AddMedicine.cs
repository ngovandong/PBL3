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
        public AddMedicine()
        {
            InitializeComponent();
            setComboBoxMedicine_Type();
            setComboBoxUnit();
        }

        public void setComboBoxMedicine_Type()
        {
            cbBoxType.Items.AddRange(_BLL.Instance.getListCBBMedicine_Type().ToArray());
            Console.WriteLine(_BLL.Instance.getListCBBMedicine_Type().ToArray().Length);
        }

        public void setComboBoxUnit()
        {
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
                    MEDICINE_CODE = txtID.Text,
                    LOCATION = txtLocation.Text,
                    ID_SUB = txtSubcribe.Text,
                    INGREDIENT = txtIngredient.Text,
                    CONTENT = txtDescription.Text,
                    BRAND = txtBrand.Text,
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

        
    }
}
