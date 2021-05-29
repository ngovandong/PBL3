using BLL;
using BLL.Model_View;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.StaffSubtab
{
    public partial class StaffDashBoard : UserControl
    {
        private USER u; 
        public StaffDashBoard(USER u)
        {
            InitializeComponent();
            this.u = u;
            setForm();
        }
        public void setForm()
        {
            reportStaff s1 = _BLL.Instance.getReportStaff(u.ID, true);
            label1.Text = "Bán được: " + s1.TotalSold;
            label2.Text = "Tổng số đơn: " + s1.NumberOfInvoice;
            label3.Text = "Hôm nay: "+DateTime.Now.ToShortDateString();

            reportStaff s2 = _BLL.Instance.getReportStaff(u.ID, false);
            label7.Text = "Bán được: " + s2.TotalSold;
            label4.Text = "Tổng số đơn: " + s2.NumberOfInvoice;
            label6.Text = "Tháng nay: " + DateTime.Now.ToString("MM/yyyy");

            loadChart(0);
            
        }

        public void loadChart(int i)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            switch (i)
            {
                case 0:
                    foreach (var item in _BLL.Instance.getListChartStaffDate(u.ID))
                    {
                        chart1.Series[0].Points.AddXY(item.date, item.sale);
                        chart1.Series[1].Points.AddXY(item.date, item.qty);
                    }
                    break;
                case 1:
                    foreach (var item in _BLL.Instance.getListChartStaffMonth(u.ID))
                    {
                        chart1.Series[0].Points.AddXY(item.date, item.sale);
                        chart1.Series[1].Points.AddXY(item.date, item.qty);
                    }
                    break;
                default:
                    break;
            }
        }
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChart(guna2ComboBox1.SelectedIndex);
        }
    }
}
