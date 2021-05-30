using Pharmacy.StaffSubtab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace Pharmacy
{
    public partial class Staff : Form
    {
        private USER user;
        public Staff(USER u)
        {
            this.user = u;
            InitializeComponent();
            ButtonDashBoard.PerformClick();
            NameStaffLabel.Text = u.USER_NAME;
            this.WindowState = FormWindowState.Maximized;
        }


        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void ButtonDashBoard_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Dashboard";
            this.staffDashBoard1.BringToFront();
            
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Báo cáo";
            this.staffReport1.BringToFront();
        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Thông tin cá nhân";
            this.staffProfile1.BringToFront();
        }

        public void reload()
        {
            this.staffDashBoard1.setForm();
            this.staffReport1.setStart();
        }
        private void ButtonSell_Click(object sender, EventArgs e)
        {
            Sell f = new Sell(this.user);
            f.d = new Sell.Mydel(reload);
            f.ShowDialog();
        }

        private void Staff_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            USER u = this.user;
            Staff f = new Staff(u);
            f.Show();
            this.Hide();
        }
    }
}
