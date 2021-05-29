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
            staffDashBoard1.BringToFront();
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Report";
            staffReport1.BringToFront();
        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            titleLabel.Text = "Profile";
            staffProfile1.BringToFront();
        }

        public void reloadDashBoard()
        {
            this.staffDashBoard1.setForm();
            this.staffReport1.setStart();
        }
        private void ButtonSell_Click(object sender, EventArgs e)
        {
            Sell f = new Sell(this.user);
            f.d = new Sell.Mydel(reloadDashBoard);
            f.ShowDialog();
        }

        private void Staff_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
