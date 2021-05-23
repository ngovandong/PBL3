using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model_View
{
    public class medicineSell
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public string code { get; set; }
        public int sell_price { get; set; }
        public int Qty { get; set; }
        public string Barcode { get; set; }
        public string location { get; set; }
        public string type { get; set; }
        public string Ingredient { get; set; }
        public virtual ICollection<STOCK_DETAIL> STOCK_DETAIL { get; set; }
        public virtual STOCK_DETAIL stock_detail{get;set;}
        public int quantysell { get; set; }

    }
}
