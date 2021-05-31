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
            int c = _BLL.Instance.checkUser(guna2TextBox1.Text.ToLower(), guna2TextBox2.Text);
            if (c==1)
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
                MessageBox.Show("Wrong user or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
