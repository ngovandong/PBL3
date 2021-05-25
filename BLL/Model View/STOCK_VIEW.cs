using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class STOCK_VIEW
    {
        public int id { get; set; }
        public string nameStock { get; set; }
        public string nameSupplier { get; set; }
        public DateTime dateImport { get; set; }
        public int priceTotal { get; set; }
    }
}
