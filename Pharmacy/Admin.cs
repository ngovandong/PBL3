﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            ButtonDashBoard.PerformClick();
        }
        
        public Admin(string s)
        {
            InitializeComponent();
            label2.Text = s;
            ButtonDashBoard.PerformClick();
            this.WindowState = FormWindowState.Maximized;

        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }


        private void Admin_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();

        private void ButtonDashBoard_Click(object sender, EventArgs e)
        {
            dashBoard1.BringToFront();
        }

        private void ButtonProfile_Click(object sender, EventArgs e)
        {
            editProfilecs1.BringToFront();
        }

        private void ButtonMangeUser_Click(object sender, EventArgs e)
        {
            manageUser1.BringToFront();
        }

        private void ButtonManageMedicine_Click(object sender, EventArgs e)
        {
            manageMedicine1.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string s = label2.Text;
            Admin f = new Admin(s);
            f.Show();
            this.Hide();
        }
    }
}
