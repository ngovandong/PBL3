using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class MEDICINE_VIEW
    {
        public int ID { get; set; }
        public string Name { get; set;}
        public int? original_Price { get; set;}
        public int? sale_Price { get; set; }
        public int Quantity { get; set; }
    }
}
