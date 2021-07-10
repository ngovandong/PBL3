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

namespace Pharmacy.AdminTab
{
    public partial class editProfilecs : UserControl
    {
        public editProfilecs()
        {
            InitializeComponent();
            buttonProfile.PerformClick();
            setForm();
        }

        public void setForm()
        {
            PHARMACY_PROFILE f = _BLL.Instance.getProfile();
            if (f != null)
            {
                ñame.Text = f.PharmacyName == null ? "" : f.PharmacyName;
                phone.Text = f.PhoneNumber;
                address.Text = f.Address;
                hours.Text = f.BusinessHours;
                email.Text = f.Email;
                LabelName.Text = f.PharmacyName;
            }
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ñame.Text = "";
            address.Text = "";
            email.Text = "";
            phone.Text = "";
            hours.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ñame.Text != ""
                && phone.Text != ""
                && address.Text != ""
                && hours.Text != ""
                &&email.Text!=""
                )
            {
                try
                {
                    Convert.ToInt64(phone.Text);
                    PHARMACY_PROFILE f = new PHARMACY_PROFILE();
                    f.PharmacyName = ñame.Text;
                    f.PhoneNumber = phone.Text;
                    f.Email = email.Text;
                    f.Address = address.Text;
                    f.BusinessHours = hours.Text;
                    _BLL.Instance.UpdateProfile(f);
                    LabelName.Text = ñame.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Fail! Please check all property.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter all property!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
