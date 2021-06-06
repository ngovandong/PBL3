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

namespace Pharmacy.AdminTab
{
    public partial class AddUser : Form
    {
        public delegate void Mydel();
        public Mydel d;
        public AddUser()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.guna2TextBox1.Text = "";
            this.guna2TextBox2.Text = "";
            this.guna2TextBox3.Text = "";
            this.guna2TextBox4.Text = "";
            this.guna2TextBox5.Text = "";
            this.guna2TextBox6.Text = "";
            this.guna2DateTimePicker1.ResetText();
            this.guna2ComboBox1.SelectedIndex = -1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != ""
                && guna2TextBox2.Text != ""
                && guna2TextBox3.Text != ""
                && guna2TextBox4.Text != ""
                && guna2TextBox5.Text != ""
                && guna2TextBox6.Text != ""
                && guna2ComboBox1.SelectedIndex != -1
                &&guna2CheckBox1.Checked)
            {
                USER u = getInforOnForm();
                if (u != null)
                {
                    _BLL.Instance.AddUser(u);
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    d();
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

        private USER getInforOnForm()
        {
            try
            {
                Convert.ToInt64(guna2TextBox2.Text);
                Convert.ToInt64(guna2TextBox6.Text);
                string FileName = pictureBox1.ImageLocation;
                byte[] ImageData;
                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                ImageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return new USER
                {
                    ROLE = (guna2ComboBox1.SelectedIndex == 0),
                    NAME = guna2TextBox1.Text,
                    DateOfBirth = guna2DateTimePicker1.Value,
                    PHONE = guna2TextBox2.Text,
                    ID_CMND = guna2TextBox6.Text,
                    ADDRESS = guna2TextBox3.Text,
                    USER_NAME = guna2TextBox4.Text.ToLower(),
                    PASSWORD = guna2TextBox5.Text,
                    DELETED = false,
                    IMAGE = ImageData
                };
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (_BLL.Instance.checkUserHasAlready(guna2TextBox4.Text.ToLower()) && !(guna2TextBox4.Text==""))
            {
                guna2CheckBox1.Checked = true;
            }
            else
            {
                guna2CheckBox1.Checked = false;
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter= "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
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
