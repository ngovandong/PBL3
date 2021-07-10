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
namespace Pharmacy.StaffSubtab
{
    
    public partial class addCustomer : Form
    {
        public delegate void Mydel(CUSTOMER c);
        public Mydel d;
        public addCustomer()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (CusName.Text != "" && Phone.Text != "")
            {
                try
                {
                    Convert.ToInt64(Phone.Text);
                    CUSTOMER c = new CUSTOMER
                    {
                        Customer_name = CusName.Text,
                        Phone = Phone.Text
                    };
                    
                    d(_BLL.Instance.AddCustomer(c));
                    MessageBox.Show("Success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Fail!", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter all property!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
