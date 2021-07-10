using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class INVOICE_VIEW_REPORT
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public double? Discount { get; set; }
        public int Charge { get; set; }
    }
}
