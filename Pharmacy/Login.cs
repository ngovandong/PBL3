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
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        public Login()
        {
            InitializeComponent();
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
            if (_BLL.Instance.checkUser(guna2TextBox1.Text,guna2TextBox2.Text)==1)
            {
                Admin f = new Admin(guna2TextBox1.Text);
                f.Show();
                this.Hide();
            }
            else if (_BLL.Instance.checkUser(guna2TextBox1.Text, guna2TextBox2.Text) == 2)
            {
                Staff f = new Staff(guna2TextBox1.Text);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong user or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
