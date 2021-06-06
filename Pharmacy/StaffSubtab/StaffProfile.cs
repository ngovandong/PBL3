using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.StaffSubtab
{
    public partial class StaffProfile : UserControl
    {
        private string User_name;
        private USER u;

        public StaffProfile()
        {
            InitializeComponent();
        }
        public StaffProfile(string s)
        {
            this.User_name = s;
            InitializeComponent();
            setForm();
        }

        public void setForm()
        {
            u = _BLL.Instance.getUserByUserName(this.User_name);
            userNane.Text = User_name;
            phone.Text = u.PHONE;
            role.Text = "Staff";
            guna2DateTimePicker1.Value = u.DateOfBirth.Value;
            address.Text = u.ADDRESS;
            name.Text = u.NAME;
        }

        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (name.Text != ""
                && phone.Text != ""
                && address.Text != ""
                && password.Text != ""
                )
            {
                try
                {
                    string FileName = pictureBox1.ImageLocation;
                    byte[] ImageData;
                    FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();


                    Convert.ToInt64(phone.Text);
                    u.NAME = name.Text;
                    u.ADDRESS = address.Text;
                    u.PASSWORD = password.Text;
                    u.PHONE = phone.Text;
                    u.DateOfBirth = guna2DateTimePicker1.Value;
                    u.IMAGE = ImageData;
                    _BLL.Instance.UpdateUser(u);
                    
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            setForm();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.Multiselect = false;
            DialogResult result;
            result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
