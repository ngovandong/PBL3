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
namespace Pharmacy
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            _BLL.Instance.CheckExpiredMedicine();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                int c = _BLL.Instance.checkUser(guna2TextBox1.Text.ToLower(), guna2TextBox2.Text);
                if (c == 1)
                {
                    Admin f = new Admin(guna2TextBox1.Text.ToLower());
                    f.Show();
                    this.Hide();
                }
                else if (c == 2)
                {
                    Staff f = new Staff(_BLL.Instance.getUserByUserName(guna2TextBox1.Text.ToLower()));
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu hoặc tên đăng nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


    }
}
