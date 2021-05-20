using BLL;
using System;
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
    public partial class ManageUser : UserControl
    {
        public ManageUser()
        {
            InitializeComponent();
            refresh();
        }

        public void refresh()
        {
            guna2DataGridView1.DataSource = _BLL.Instance.getListUser();
        }

        private void buttonDetail_Click_1(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32( guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                Detail f = new Detail(id);
                f.Show();
            }
            else
            {
                MessageBox.Show("Please choose one row", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            AddUser f = new AddUser();
            f.d = new AddUser.Mydel(refresh);
            f.Show();
        }

        private void buttonUpdate_Click_1(object sender, EventArgs e)
        {
            
            if (guna2DataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells[0].Value);
                UpdateUser f = new UpdateUser(id);
                f.d = new UpdateUser.myDel(refresh);
                f.Show();
            }
            else
            {
                MessageBox.Show("Please choose one row", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                List<int> Lint = new List<int>();
                foreach (DataGridViewRow item in guna2DataGridView1.SelectedRows)
                {
                    Lint.Add(Convert.ToInt32(item.Cells[0].Value));
                }
                _BLL.Instance.DelUser(Lint);
                refresh();
            }
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string s = guna2TextBox3.Text;
            guna2DataGridView1.DataSource = _BLL.Instance.SearchUser(s);
        }
    }
}
