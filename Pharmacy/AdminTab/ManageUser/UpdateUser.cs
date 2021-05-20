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
namespace Pharmacy.AdminTab
{
    public partial class UpdateUser : Form
    {
        public delegate void myDel();
        public myDel d;
        private int id;
        public UpdateUser(int id)
        {
            InitializeComponent();
            this.id = id;
            setForm();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != ""
                && guna2TextBox2.Text != ""
                && guna2TextBox3.Text != ""
                && guna2TextBox5.Text != ""
                )
            {
                USER u = getInforOnForm();
                if (u != null)
                {
                    _BLL.Instance.UpdateUser(u);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            setForm();
        }


        public void setForm()
        {
            USER u = _BLL.Instance.getUser(id);
            guna2TextBox1.Text = u.NAME;
            guna2TextBox2.Text = u.PHONE;
            guna2TextBox3.Text = u.ADDRESS;
            guna2TextBox5.Text = u.PASSWORD;
            guna2ComboBox1.SelectedIndex = u.ROLE ? 0 : 1;
            guna2DateTimePicker1.Value = u.DateOfBirth.Value;

        }

        private USER getInforOnForm()
        {
            try
            {
                Convert.ToInt64(guna2TextBox2.Text);
                return new USER
                {
                    ID = id,
                    ROLE = (guna2ComboBox1.SelectedIndex == 0),
                    NAME = guna2TextBox1.Text,
                    DateOfBirth = guna2DateTimePicker1.Value,
                    PHONE = guna2TextBox2.Text,
                    ADDRESS = guna2TextBox3.Text,
                    USER_NAME = "",
                    PASSWORD = guna2TextBox5.Text.ToLower(),
                };
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
