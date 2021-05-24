using BLL;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.AdminTab.Manage_Medicine
{
    public partial class AddSupplier : Form
    {
        public delegate void Mydel(string name);
        public Mydel d;
        public AddSupplier()
        {
            InitializeComponent();
            start();
        }
        private void start()
        {
            textboxName.Text = "";
            textboxPhone.Text = "";
            textboxAddress.Text = "";
            textboxEmail.Text = "";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textboxName.Text = "";
            textboxPhone.Text = "";
            textboxAddress.Text = "";
            textboxEmail.Text = "";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if("" == textboxName.Text || "" == textboxPhone.Text || "" == textboxEmail.Text || "" == textboxEmail.Text || _BLL.Instance.checkSupplier(textboxName.Text.Trim()))
            {
                if("" == textboxName.Text || "" == textboxPhone.Text || "" == textboxEmail.Text || "" == textboxEmail.Text)
                {
                    MessageBox.Show("Nhập đầy đủ thông tin");
                }
                else
                {
                    MessageBox.Show("Đã có tên này");
                }
            }
            else
            {
                _BLL.Instance.addSupplier(new SUPPLIER()
                {
                    NAME = textboxName.Text.Trim(),
                    PHONE_NUMBER = textboxPhone.Text.Trim(),
                    ADDRESS = textboxAddress.Text.Trim(),
                    EMAIL = textboxEmail.Text.Trim()
                });
                d(textboxName.Text);
                buttonCancel_Click(sender, e);
            }
        }

        private void textboxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
