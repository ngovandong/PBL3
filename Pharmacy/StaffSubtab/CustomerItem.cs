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
namespace Pharmacy.StaffSubtab
{
    public partial class CustomerItem : UserControl
    {
        private CUSTOMER c;
        public delegate void MyDel(CUSTOMER c);
        public MyDel d;
        public CustomerItem(CUSTOMER c)
        {
            InitializeComponent();
            this.c = c;
            setForm();
        }

        public void setForm()
        {
            CusName.Text = c.Customer_name;
            Phone.Text = c.Phone;
            ID_CUS.Text = "Ma KH: "+ c.ID.ToString();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.LightGray;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void CusName_MouseClick(object sender, MouseEventArgs e)
        {
            d(c);
        }


    }
}
