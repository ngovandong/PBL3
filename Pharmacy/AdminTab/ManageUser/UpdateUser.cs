﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab
{
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.guna2TextBox1.Text = "";
            this.guna2TextBox2.Text = "";
            this.guna2TextBox3.Text = "";
            this.guna2TextBox5.Text = "";
            this.guna2DateTimePicker1.ResetText();
            this.guna2ComboBox1.SelectedIndex = -1;
        }

   
    }
}
