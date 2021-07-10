using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class MedicineStock
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int original_price { get; set; }
        public int import_price { get; set; }
        public int final_price { get; set; }
        public int sale_price { get; set; }
        public int quantityInStock { get; set; }
        public int quantityInKho { get; set; }
        public DateTime HSD { get; set; }
        public int ID_STOCK { get; set; }
    }
}
