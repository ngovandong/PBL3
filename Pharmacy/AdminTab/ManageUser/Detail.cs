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
    public partial class Detail : Form
    {
        public int ID;
        public Detail(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            setForm();
        }
        public void setForm()
        {
            USER u = _BLL.Instance.getUser(ID);
            guna2TextBox1.Text = u.NAME;
            guna2TextBox2.Text = u.PHONE;
            guna2TextBox3.Text = u.ADDRESS;
            guna2TextBox4.Text = u.USER_NAME;
            guna2TextBox5.Text = u.PASSWORD;
            guna2ComboBox1.Items.Add( u.ROLE ? "Admin" : "Staff");
            guna2ComboBox1.SelectedIndex = 0;
            guna2DateTimePicker1.Value = u.DateOfBirth.Value;
        }
    }
}
