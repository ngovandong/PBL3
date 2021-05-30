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
namespace Pharmacy.AdminTab.DashBoard
{
    public partial class Genneral : UserControl
    {
        public Genneral()
        {
            InitializeComponent();
            setDatagridview();
            LoadChart(0);
            
        }
        public void LoadChart(int i)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            switch (i)
            {
                case 0:
                    foreach (var item in _BLL.Instance.getListChart0())
                    {
                        chart1.Series[0].Points.AddXY(item.date, item.sellPrice);
                        chart1.Series[1].Points.AddXY(item.date, item.originalPrice);
                    }
                    break;
                case 1:
                    foreach (var item in _BLL.Instance.getListChart1())
                    {
                        chart1.Series[0].Points.AddXY(item.date, item.sellPrice);
                        chart1.Series[1].Points.AddXY(item.date, item.originalPrice);
                    }
                    break;
                default:
                    break;
            }
        }


        private void OptionCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadChart(OptionCombobox.SelectedIndex);
        }

        public void setDatagridview()
        {
            int a = _BLL.Instance.getProgressValue1();
            int b = _BLL.Instance.getProgressValue2();
            int percent1 = (int)(((float)a/b)*100);
            guna2CircleProgressBar1.Value = percent1;
            label2.Text ="Thuốc hết hạn: "+ a.ToString();
            label3.Text = "Thuốc còn hạn: " +(b-a).ToString();

            int c = _BLL.Instance.getProgressValue3();
            int d = _BLL.Instance.getProgressValue4();
            int percent2 = (int)(((float)c / d)*100);
            guna2CircleProgressBar2.Value = percent2;
            label5.Text = "Thuốc hết hàng: " + c.ToString();
            label4.Text = "Thuốc còn hàng: " + (d - c).ToString();
        }
    }
}
