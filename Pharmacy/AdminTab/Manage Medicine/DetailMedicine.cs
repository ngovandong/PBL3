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
    public partial class DetailMedicine : Form
    {
        public int id;
        public DetailMedicine(int ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailMedicine_Load(object sender, EventArgs e)
        {
            MEDICINE md = _BLL.Instance.getMedicineByID(id);
            txtMedicineCode.Text = md.MEDICINE_CODE;
            txtName.Text = md.MEDICINE_NAME;
            txtType.Text = md.MEDICINE_TYPE.TypeName;
            txtBarcode.Text = md.BARCODE;
            txtBrand.Text = md.BRAND;
            txtSubcribe.Text = md.ID_SUB;
            txtLocation.Text = md.LOCATION;
            txtIngredient.Text = md.INGREDIENT;
            txtDescription.Text = md.CONTENT;
            txtUnit.Text = md.UNIT.NAME;
            txtQuantity.Text = md.QUANTITY.ToString();
            txtOriginalPrice.Text = md.ORIGINAL_PRICE.ToString();
            txtSalePrice.Text = md.SALE_PRICE.ToString();
        }
    }
}
